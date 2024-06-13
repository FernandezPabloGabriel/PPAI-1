using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Varietal
    {
        private string descripcion;
        private float porcentajeComposicion;
        private TipoUva tipoUva;

        public Varietal(string descripcion, float porcentajeComposicion, TipoUva tipoUva)
        {
            this.descripcion = descripcion;
            this.porcentajeComposicion = porcentajeComposicion;
            this.tipoUva = tipoUva;

        }

        public string Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }

        public float PorcentajeComposicion
        {
            get => porcentajeComposicion;
            set => porcentajeComposicion = value;
        }
        public TipoUva TipoUva
        {
            get => tipoUva;
            set => tipoUva = value;
        }
    }
}

// Falta agregar los métodos: conocerTipoUva(), esDeTipoUva(), mostrarPorcentaje() y crear()