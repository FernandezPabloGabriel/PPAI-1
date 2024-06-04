using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Vino
    {
        private string nombre;
        private bool imagenEtiqueta;
        private float precioARS;
        private int aniada;
        private string notaDeCataBodega;
        private DateTime fechaActualizacion;
        private Bodega bodega;
        private List<Maridaje> maridajes;
        private List<Varietal> varietales;

        //public Vino(string nombre, bool imagenEtiqueta, float precioARS, int aniada, string notaDeCataBodega, DateTime fechaActualizacion, Bodega bodega, List<Maridaje> maridajes, List<Varietal> varietales)
        //{
        //    this.nombre = nombre;
        //    this.imagenEtiqueta = imagenEtiqueta;
        //    this.precioARS = precioARS;
        //    this.aniada = aniada;
        //    this.notaDeCataBodega = notaDeCataBodega;
        //    this.fechaActualizacion = fechaActualizacion;
        //    this.bodega = bodega;
        //    this.maridajes = maridajes;
        //    this.varietales = varietales;
        //}


        
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public bool ImagenEtiqueta
        {
            get => imagenEtiqueta;
            set => imagenEtiqueta = value;
        }

        public float PrecioArs
        {
            get => precioARS;
            set => precioARS = value;
        }

        public int Aniada
        {
            get => aniada;
            set => aniada = value;
        }

        public string NotaDeCataBodega
        {
            get => notaDeCataBodega;
            set => notaDeCataBodega = value;
        }

        public DateTime Fecha
        {
            get => fechaActualizacion;
            set => fechaActualizacion = value;
        }

        public Bodega Bodega
        {
            get => bodega;
            set => bodega = value;
        }

        public List<Maridaje> Maridajes
        {
            get => maridajes;
            set => maridajes = value;
        }

        public List<Varietal> Varietales
        {
            get => varietales; 
            set => varietales = value;
        }
    }
}

// Faltaría agregar cada uno de los 12 métodos...