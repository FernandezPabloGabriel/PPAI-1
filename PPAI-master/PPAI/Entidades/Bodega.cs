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

        //6°) mostrarNombre()
        public string Nombre 
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


        //5°) Método que comprueba, por medio de la diferencia de meses entre fechas, si una bodega está en su periodo de actualización o no -Devuelve un booleano-
        /* -----EJEMPLO P.EXPERTO-----
         * Aplicamos patrón creador porque directamente utilizamos la fechaUltimaActualización de la bodega
         * y no se la pasamos al gestor para determinar si una bodega está en periodo de actualizacion*/
        public bool ExisteActualizacionDisponible()
        {
            DateTime fechaHoy = DateTime.Now; //Obtenemos la fecha de hoy y la guardamos
            bool actualizacionDisponible = false;
            int diferenciaMeses = fechaHoy.Month - FechaUltimaActualizacion.Month;

            if (diferenciaMeses > PeriodoActualizacion)
            {
                actualizacionDisponible = true;
            }
            else if (diferenciaMeses == PeriodoActualizacion && fechaHoy.Day >= FechaUltimaActualizacion.Day)
            {
                actualizacionDisponible = true;
            }

            return actualizacionDisponible;
        }
    }
}

// Falta agregar los metodos contarReseñas(), mostrarTodosVinos(), , mostrarNombre(), actualizarVinos()