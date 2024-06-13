using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PPAI.Entidades;
using PPAI.Boundaries;
using System.Reflection;
using PPAI.Recursos_Extra;

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

       
        //3°) ¿Que este devuelva la lista de string?
        public static List<String> OpcionImportarActualizacionVinosBodega()
        {
            List<String> listaNombreBodegas = BuscarBodegaParaActualizar();
            return listaNombreBodegas;
        }


        //4°) Devuelve array de strings que contiene los nombres de las bodegas a actualizar
        private static List<String> BuscarBodegaParaActualizar()
        {
            //Utilizamos la clase "Deserealizador" para que esta extraiga los datos del JSON y nos devuelva le array de objetos respectivo
            Deserializador<Bodega> deserializador = new Deserializador<Bodega>();
            List<Bodega> listaBodegas = deserializador.RecuperarJson(_rutaAPIsDelSistemaBodegas);
            
            //Extraemos los nombres de la lista de bodegas
            List<string> listaNombreBodegas = new List<string>();
            foreach (Bodega bodega in listaBodegas)
            {
                //Utilización de 5°) y 6°)
                if (bodega.ExisteActualizacionDisponible())
                {
                    listaNombreBodegas.Add(bodega.Nombre);
                }
            }

            return listaNombreBodegas;
        }


        
        //9°) Tomamos todos los vinos de la API "externa" de la bodega seleccionada
        public static void TomarBodega(string nombreBodega)
        {
            //MessageBox.Show("Seleccionaste: " + nombreBodega);
            ObtenerActualizacionDeBodegas(nombreBodega);

        }


        //10°)
        private static void ObtenerActualizacionDeBodegas(string nombreBodega)
        { 
            bool hayActualizacion = false;
            //Vinos importados
            List<Vino> listaVinosImportados = InterfazAPIsBodegas.ObtenerActualizacion(nombreBodega, _rutaAPIsDeLasBodegas);
            //Obtener lista de vinos del sistema
            Deserializador<Vino> deserializador = new Deserializador<Vino>();
            DatosDeVinosDeBodegaParaActualizar = deserializador.RecuperarJson(_rutaAPIsDelSistemaVinos);

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


        /*-----METODOS AUXILIARES-----*/

    }
}
