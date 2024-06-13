using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPAI.Entidades
{
    public class Maridaje
    {

        private string nombre;
        private string descripcion;

        public Maridaje(string nombre, string descripcion)
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
        public static Maridaje MaridaConVino(Maridaje maridajeImportado)
        {
            var maridajesJson = GetContactsJsonFromFile(@"..\..\APIsDelSistema\maridajes.json");
            List<Maridaje> listaMaridajes = DeserializeJsonFromFile(maridajesJson);

            foreach (var maridaje in listaMaridajes)
            {
                if (maridaje.Nombre == maridajeImportado.Nombre)
                {
                    return maridaje;
                }
            }
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

// Falta agregar el método maridaConVino()