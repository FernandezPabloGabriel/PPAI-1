using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PPAI.Entidades;
using PPAI.Boundaries;
using System.Reflection;

namespace PPAI.Gestor
{
    public class GestorImportarActualizacionBodegas
    {
        //Que es el signo de ?
        public List<Bodega>? bodegasParaActualizar {  get; set; }
        public Bodega? bodegaSeleccionada { get; set; }
        public static List<Vino>? DatosDeVinosDeBodegaParaActualizar { get; set; }
        public List<Maridaje>? MaridajeParaVinosACrear { get; set; }
        public List<TipoUva>? TipoUvaParaVinosACrear { get; set; }
        public List<Usuario>? NombresUsuariosSeguidoresDeBodega { get; set; }
        public static List<string> vinoActualizado = new List<string>();

        // Por defecto la ruta relativa hacia nuestra carpeta "Jsons" va a estar precedida por "\bin\Debug\net8.0-windows", por lo tanto utilizamos ..\..\..\ para acceder a ella
        private static string _rutaAPIsDelSistemaBodegas = @"..\..\..\Jsons\APIsDelSistema\Bodegas.json";
        private static string _rutaAPIsDelSistemaVinos = @"..\..\..\Jsons\APIsDelSistema\Vinos.json";
        private static string _rutaAPIsDeLasBodegas = @"..\..\..\Jsons\APIsDeLasBodegas\";
        
        
        /* Método anteriormente utilizado para obtener la ruta hacia "Jsons" pero es redundante ya que solo nos da la ruta absoluta
        private static string _rutaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _rutaBodegas);*/
        public static List<String> OpcionImportarActualizacionVinosBodega()
        {
            List <String> listaNombreBodegas = BuscarBodegaParaActualizar();
            return listaNombreBodegas;
        }


        public static string ObtenerBodegasDeJSON()
        {
            string bodegasDeJson;
            //Forma estandar de leer un archivo de disco
            using (var reader = new StreamReader(_rutaAPIsDelSistemaBodegas))
            {
                bodegasDeJson = reader.ReadToEnd();
            }
            return bodegasDeJson;
        }


        public static List<Bodega> DeserializarJSON(string bodegasDeJSON)
        {
            var bodegas = JsonConvert.DeserializeObject<List<Bodega>>(bodegasDeJSON);
            return bodegas;
        }


        //Devuelve array de strings que contiene los nombres de las bodegas a actualizar
        private static List<String> BuscarBodegaParaActualizar()
        {
            //Obtenemos los datos de cada bodega desde el archivo JSON Bodegas.json
            string bodegasDeJson = ObtenerBodegasDeJSON();
            //Transformamos las bodegas de json a formato array de objetos y las guardamos en el array listaBodega
            List<Bodega> listaBodega = DeserializarJSON(bodegasDeJson);
            List<string> nombreBodegas = new List<string>();

            foreach (var bodega in listaBodega)
            {
                if (ExisteActualizacionDisponible(bodega))
                {
                    nombreBodegas.Add(bodega.Nombre);
                }
            }

            return nombreBodegas;
        }


        // Método que comprueba, por medio de la diferencia de meses entre fechas, si una bodega está en su periodo de actualización o no -Devuelve un booleano-
        private static bool ExisteActualizacionDisponible(Bodega bodega)
        {
            DateTime fechaHoy = DateTime.Now;
            bool actualizacionDisponible = false;

            int diferenciaMeses = fechaHoy.Month - bodega.FechaUltimaActualizacion.Month;
            if (diferenciaMeses > bodega.PeriodoActualizacion)
            {
                actualizacionDisponible = true;
            }
            else if (diferenciaMeses == bodega.PeriodoActualizacion && fechaHoy.Day >= bodega.FechaUltimaActualizacion.Day)
            {
                actualizacionDisponible = true;
            }

            return actualizacionDisponible;
        }


        //Tomamos todos los vinos de la API de la bodega seleccionada
        public static void TomarBodega(string nombreBodega)
        {
            MessageBox.Show("Seleccionaste: " + nombreBodega);
            ObtenerActualizacionDeBodegas(nombreBodega);

        }



        private static void ObtenerActualizacionDeBodegas(string nombreBodega)
        { 
            bool hayActualizacion = false;
            //Vinos importados
            List<Vino> listaVinosImportados = InterfazAPIsBodegas.ObtenerActualizacion(nombreBodega, _rutaAPIsDeLasBodegas);
            //Obtener lista de vinos del sistema
            var listaVinosJson = InterfazAPIsBodegas.ObtenerVinosDeBodegaDeJSON(_rutaAPIsDelSistemaVinos);
            DatosDeVinosDeBodegaParaActualizar = InterfazAPIsBodegas.DeserializarJSON(listaVinosJson);

            List<string> listaNombresVinosImportados = new List<string>();
            List<string> listaNombresVinosSistemas = new List<string>();

            foreach (Vino vino in listaVinosImportados) { listaNombresVinosImportados.Add(vino.Nombre); }
            foreach (Vino vino in DatosDeVinosDeBodegaParaActualizar) { listaNombresVinosSistemas.Add(vino.Nombre); }

            foreach (string nomVinoImportado in listaNombresVinosImportados)
            {
                //DatosDeVinosDeBodegaParaActualizar.Add( vino );
                bool contieneVinoElSistema = listaNombresVinosSistemas.Contains(nomVinoImportado);
                if( contieneVinoElSistema)
                {
                    Vino vinoSistema = new Vino();
                    Vino vinoImportado = new Vino();

                    //Obtenemos los objetos de tipo vino cuyos nombres sean iguales
                    foreach (Vino vino in listaVinosImportados) { if (vino.Nombre == nomVinoImportado) { vinoImportado = vino; } }
                    foreach (Vino vino in DatosDeVinosDeBodegaParaActualizar) { if (vino.Nombre == nomVinoImportado) { vinoSistema = vino; } }

                    if (CompararCampos(vinoSistema, vinoImportado))
                    {
                        hayActualizacion = true;
                    }
                }
                else 
                {
                    Vino vinoImportado = new Vino();
                    foreach (Vino vino in listaVinosImportados) { if (vino.Nombre == nomVinoImportado) { vinoImportado = vino; } }
                    string vinoCreado = CrearNuevoVino(vinoImportado);
                    vinoActualizado.Add("\n-----------------------------------" + vinoCreado);
                    hayActualizacion = true;
                }
            }

            if (hayActualizacion)
            {
                string cadena = $"Resumen de {nombreBodega}:";
                foreach (var vino in vinoActualizado)
                {
                    cadena += $"{vino}";
                }
                MessageBox.Show(cadena);
                MessageBox.Show("Se enviaron las notificaciones a los Seguidores de la bodega!");
            }
            else
            {
                MessageBox.Show($"{nombreBodega} está al día!");
            }
            vinoActualizado = [];
        }


        private static bool CompararCampos(Vino vinoSistema, Vino vinoImportado)
        {
            bool hayDiferencia = false;
            string cadenita = "";
            PropertyInfo[] propiedades = typeof(Vino).GetProperties();
            
            
            //Recorremos cada propiedad de un objeto "Vino" hasta "fechaUltimaActualizacion". Si pasamos de ahí compara objetos y arroja resultados imprecisos
            for (int i = 1; i < 6; i++)
            {
                PropertyInfo propiedad = propiedades[i];
                object atributoVinoSistema = propiedad.GetValue(vinoSistema);
                object atributoVinoImportado = propiedad.GetValue(vinoImportado);

                if (!(atributoVinoSistema.Equals(atributoVinoImportado)))
                {
                    hayDiferencia = true;
                    cadenita += $"\n | {propiedad}: {atributoVinoSistema} --> {atributoVinoImportado}";
                }
            }
            if (hayDiferencia)
            {
                vinoActualizado.Add($"\n-----------------------------------\nSe actualizó el vino: '{vinoSistema.Nombre}': {cadenita}");
            }
            
            return hayDiferencia;
        }


        private static string CrearNuevoVino(Vino vinoImportado)
        {
            string cadena = "";

            cadena += "\nSe añadió el vino: " + vinoImportado.Nombre;
            cadena += "\n | Imagen: " + vinoImportado.ImagenEtiqueta;
            cadena += "\n | Precio ARS: " + vinoImportado.PrecioArs;
            cadena += "\n | Añada: " + vinoImportado.Aniada;
            cadena += "\n | Nota de Cata: " + vinoImportado.NotaDeCataBodega;
            cadena += "\n | Maridajes: ";
            foreach (Maridaje marida in vinoImportado.Maridajes) 
            {
                cadena += "'" + marida.Nombre + "' ";
            }
            cadena += "\n | Varietales: ";
            foreach (Varietal varietal in vinoImportado.Varietales)
            {
                cadena += "'" + varietal.Descripcion + "' ";
            }
            

            return cadena;
        }


        private static void BuscarMaridaje()
        {
//           List<Maridaje> listaMaridajes = Maridaje.MaridaConVino(maridajeImportado);
        }


        private static void BuscarTipoUva()
        {
  //          TipoUva.EsTipoUva();
        }
    }
}
