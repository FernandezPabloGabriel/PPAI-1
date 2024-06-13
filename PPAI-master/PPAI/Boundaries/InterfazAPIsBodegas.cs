﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PPAI.Entidades;
using PPAI.Recursos_Extra;


namespace PPAI.Boundaries
{
    public class InterfazAPIsBodegas
    {
        //11°) Obtener las últimas actualizaciones de los vinos de las APIs de las bodegas registradas en el sistema
        public static List<Vino> ObtenerActualizacion(string nombreBodega, string _rutaAPIsDeLasBodegas)
        {
            string _rutaAPIBodega = $"{_rutaAPIsDeLasBodegas}{nombreBodega}.json"; //Ruta ensamblada que nos dirige a la API de Bodega correspondiente
            Deserializador<Vino> deserializador = new Deserializador<Vino>();
            List<Vino> listaVinosImportados = deserializador.RecuperarJson(_rutaAPIBodega);
            
            return listaVinosImportados;
        }
    }
}
