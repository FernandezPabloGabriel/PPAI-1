using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PPAI.Entidades
{
    public class Bodega
    {
        private string nombre;
        private string descripcion;
        private string historia;
        private int periodoActualizacion;
        private DateTime fechaUltimaActualizacion;
        private List<float> coordenadasUbicacion;

        public Bodega(string nombre, string descripcion, string historia, int periodoActualizacion, List<float> coordenadasUbicacion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.historia = historia;
            this.periodoActualizacion = periodoActualizacion;
            this.coordenadasUbicacion = coordenadasUbicacion;
        }
        public string Nombre //mostrarNombre()
        {
            get => nombre;
            set => nombre = value;
        }

        public string Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }

        public string Historia
        {
            get => historia;
            set => historia = value;
        }

        public int PeriodoActualizacion
        {
            get => periodoActualizacion;
            set => periodoActualizacion = value;
        }
        public DateTime FechaUltimaActualizacion
        {
            get => fechaUltimaActualizacion;
            set => fechaUltimaActualizacion = value;
        }

        public List<float> CoordenadasUbicacion
        {
            get => coordenadasUbicacion;
            set => coordenadasUbicacion = value;
        }

        public static bool ExisteActualizacionDisponible(int periodoActu)
        {
            //    string filePath = "../Jsons/Bodegas.json";
            //    

            //    // Leer el contenido del archivo JSON
            //    string jsonContent = File.ReadAllText(filePath);

            //    // Deserializar el JSON en un objeto de tipo Persona
            //    Bodega bodega = JsonConvert.DeserializeObject<Bodega>(jsonContent);

            //    // Usar los datos deserializados
            //    MessageBox.Show($" {bodega.nombre} {bodega.descripcion} {bodega.historia} {bodega.periodoActualizacion} {bodega.periodoActualizacion} {bodega.coordenadasUbicacion}");

            //   
            //}
            bool resultado = false;
            return resultado;
        }
    }
}

// Falta agregar los metodos contarReseñas(), mostrarTodosVinos(), existeActualizacionDisponible(), mostrarNombre(), actualizarVinos()