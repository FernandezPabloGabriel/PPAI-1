using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPAI.Entidades
{
    public class TipoUva
    {
        private string nombre;
        private string descripcion;

        public TipoUva(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
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

        /*
        public List<TipoUva> EsTipoUva()
        {
            var  = GetContactsJsonFromFile(@"..\..\APIsDelSistema\maridajes.json");
            var maridajes = DeserializeJsonFromFile(maridajesJson);

            return maridajes;
        }


        public static string GetContactsJsonFromFile(string ruta)
        {
            string maridajesJsonFromFile;
            using (var reader = new StreamReader(ruta))
            {
                maridajesJsonFromFile = reader.ReadToEnd();
            }
            return maridajesJsonFromFile;
        }


        public static List<Maridaje> DeserializeJsonFromFile(string contactsJsonFromFile)
        {
            var maridajes = JsonConvert.DeserializeObject<List<Maridaje>>(contactsJsonFromFile);
            return maridajes;
        }*/
    }
}

// Falta agregar el método: esTipoUva()