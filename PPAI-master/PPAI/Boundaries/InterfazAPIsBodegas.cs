using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PPAI.Entidades;


namespace PPAI.Boundaries
{
    public class InterfazAPIsBodegas
    {
        //Obtener Actualizaciones de cada vino de la bodega
        public static List<Vino> ObtenerActualizacion(string nombreBodega, string _rutaAPIsDeLasBodegas)
        {
            string _rutaAPIBodega = $"{_rutaAPIsDeLasBodegas}{nombreBodega}.json"; //Ruta ensamblada que nos dirige a la API de Bodega correspondiente
            var listaVinosJson = ObtenerVinosDeBodegaDeJSON(_rutaAPIBodega);
            List<Vino> listaVinosDeBodega = DeserializarJSON(listaVinosJson);
            
            return listaVinosDeBodega;
        }

        public static string ObtenerVinosDeBodegaDeJSON(string _rutaAPIBodega)
        {
            string vinosDeJson;
            using (var reader = new StreamReader(_rutaAPIBodega))
            {
                vinosDeJson = reader.ReadToEnd();
            }
            return vinosDeJson;
        }

        public static List<Vino> DeserializarJSON(string listaVinosJSON)
        {
            var vinos = JsonConvert.DeserializeObject<List<Vino>>(listaVinosJSON);
            return vinos;
        }
    }
}
