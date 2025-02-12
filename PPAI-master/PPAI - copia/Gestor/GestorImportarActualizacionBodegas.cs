﻿using System;
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
        public static List<string> bodegaActualizada = new List<string>();

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
            //Vinos importados
            List<Vino> listaVinos = InterfazAPIsBodegas.ObtenerActualizacion(nombreBodega, _rutaAPIsDeLasBodegas);

            //Obtener lista de vinos del sistema
            var listaVinosJson = InterfazAPIsBodegas.ObtenerVinosDeBodegaDeJSON(_rutaAPIsDelSistemaVinos);
            DatosDeVinosDeBodegaParaActualizar = InterfazAPIsBodegas.DeserializarJSON(listaVinosJson);

            foreach(Vino vinoImportado in listaVinos)
            {
                //DatosDeVinosDeBodegaParaActualizar.Add( vino );
                foreach(Vino vinoSistema in DatosDeVinosDeBodegaParaActualizar)
                {
                    if (vinoImportado.Nombre.Equals(vinoSistema.Nombre))
                    {
                        if (CompararCampos(vinoSistema, vinoImportado))
                        {
                            MessageBox.Show("Se ha actualizado: " + nombreBodega + "\n" + bodegaActualizada);
                        }
                        //MessageBox.Show($"{vinoSistema.Nombre} y {vinoImportado.Nombre} son iguales");
                        //MessageBox.Show(vinoImportado.ToString + " " + vinoSistema.ToString);
                        //if (vinoImportado.Equals(vinoSistema))
                        //{
                        //    MessageBox.Show($"{vinoSistema.Nombre} y {vinoImportado.Nombre} son iguales");
                        //}
                        //else
                        //{
                        //    MessageBox.Show($"{vinoSistema.Nombre} y {vinoImportado.Nombre} NOOOOOO son iguales");
                        //}
                        

                    }
                    //else
                    //{
                        
                    //}
                }
            }
        }

        private static bool CompararCampos(Vino vinoSistema, Vino vinoImportado)
        {
            bool bandera = true;
            //if (vinoSistema.ImagenEtiqueta == vinoImportado.ImagenEtiqueta)
            //{
            //    if (vinoSistema.PrecioArs == vinoImportado.PrecioArs)
            //    {
            //        if (vinoSistema.Aniada == vinoImportado.Aniada)
            //        {
            //            if(vinoSistema)
            //        }
            //    }
            //}
            PropertyInfo[] propiedades = vinoSistema.GetType().GetProperties();
            
            //Recorremos cada propiedad de un objeto "Vino" hasta "fechaUltimaActualizacion". Si pasamos de ahí compara objetos y arroja resultados imprecisos
            for (int i = 0; i < 6; i++)
            {
                PropertyInfo propiedad = propiedades[i];
                var atributoVinoSistema = propiedad.GetValue(vinoSistema);
                var atributoVinoImportado = propiedad.GetValue(vinoImportado);
                
                if (!(atributoVinoSistema.Equals(atributoVinoImportado)))
                {
                    bandera = false;
                    string cadenita = Convert.ToString(atributoVinoSistema) + " --> " + Convert.ToString(atributoVinoSistema) + "\n";
                    bodegaActualizada.Add(cadenita);
                }
            }
            return bandera;
            
            //if (bandera == true) 
            //{
            //    MessageBox.Show("To bien");
            //}
            //else
            //{
            //    MessageBox.Show(vinoSistema.Nombre + " y " + vinoImportado.Nombre + " No son iguales");
            //}
        }
    }
}
