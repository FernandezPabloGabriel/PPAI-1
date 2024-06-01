using PPAI.Entidades;
using PPAI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

using PPAI.Entidades;
using System.IO;
using Newtonsoft.Json;
using PPAI.Gestor;

namespace PPAI
{
    public partial class PantallaImportarActualizacionBodegas : Form
    {
        private static string _rutaBodegas = @"..\..\..\Jsons\APIsDelSistema\Bodegas.json";
        private static string _rutaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _rutaBodegas);

        public PantallaImportarActualizacionBodegas(Usuario usu)
        {
            InitializeComponent();
        }

        private void PantallaImportarActualizacionBodegas_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        public static string ObtenerBodegasDeJSON()
        {
            string bodegasDeJson;
            //Forma estandar de leer un archivo de disco
            using (var reader = new StreamReader(_rutaAbsoluta))
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
        private void PresentarBodegasParaActualizar(Bodega bodega)
        {
            DataGridViewRow filita = new DataGridViewRow();

            DataGridViewTextBoxCell celdaNomBodega = new DataGridViewTextBoxCell();
            celdaNomBodega.Value = bodega.Nombre;

            filita.Cells.Add(celdaNomBodega);
            gridBodegasActualizar.Rows.Add(filita);
        }

        bool importarActuPresionado = false;

        private void gridBodegasActualizar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridBodegaActualizar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OpcionImportarActualizacionVinosBodega(object sender, EventArgs e)
        {
            GestorImportarActualizacionBodegas.OpcionImportarActualizacionVinosBodega();
            string bodegasDeJson = ObtenerBodegasDeJSON();
            List<Bodega> listaBodega = DeserializarJSON(bodegasDeJson);
            if (importarActuPresionado == false)
            {
                for (int i = 0; i < listaBodega.Count; i++)
                {
                    PresentarBodegasParaActualizar(listaBodega[i]);
                    importarActuPresionado = true;
                }
            }
        }
    }
}
