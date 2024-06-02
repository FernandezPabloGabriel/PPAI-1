using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PPAI.Entidades;
using PPAI.Boundaries;

namespace PPAI.Gestor
{
    public class GestorImportarActualizacionBodegas
    {
        //Que es el signo de ?
        public List<Bodega>? bodegasParaActualizar {  get; set; }
        public Bodega? bodegaSeleccionada { get; set; }
        public List<Vino>? DatosDeVinosDeBodegaParaActualizar { get; set; }
        public List<Maridaje>? MaridajeParaVinosACrear { get; set; }
        public List<TipoUva>? TipoUvaParaVinosACrear { get; set; }
        public List<Usuario>? NombresUsuariosSeguidoresDeBodega { get; set; }

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
            List<Vino> listaVinos = InterfazAPIsBodegas.ObtenerActualizacion(nombreBodega, _rutaAPIsDeLasBodegas);
            foreach(Vino vino in listaVinos)
            {
                MessageBox.Show("El vino " + vino.Nombre + " pertenece a la bodega " + vino.Bodega.Nombre);
                DatosDeVinosDeBodegaParaActualizar.Add( vino );
            }
        }
    }
}
