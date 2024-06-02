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
        public PantallaImportarActualizacionBodegas(Usuario usu)
        {
            InitializeComponent();
        }

        private void PantallaImportarActualizacionBodegas_Load(object sender, EventArgs e)
        {

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
            //Llamar método del gestor
            List<String> listaBodega = GestorImportarActualizacionBodegas.OpcionImportarActualizacionVinosBodega();
            if (importarActuPresionado == false)
            {
                if (listaBodega.Count == 0)
                {
                    MessageBox.Show("No hay bodegas para actualizar, Estas al día!!!");
                }
                else
                {
                    for (int i = 0; i < listaBodega.Count; i++)
                    {
                        PresentarBodegasParaActualizar(listaBodega[i]);
                        importarActuPresionado = true;
                    }
                }
            }
        }

        private void PresentarBodegasParaActualizar(String bodega)
        {
            DataGridViewRow filita = new DataGridViewRow();

            DataGridViewTextBoxCell celdaNomBodega = new DataGridViewTextBoxCell();
            celdaNomBodega.Value = bodega;

            filita.Cells.Add(celdaNomBodega);
            gridBodegasActualizar.Rows.Add(filita);
        }

        //Le indicamos al gestor que tome todos los vinos de la API de la bodega seleccionada
        private void TomarBodega(object sender, EventArgs e)
        {
            //Llamar método del gestor
            if (gridBodegasActualizar.Rows.Count == 0)
            {
                MessageBox.Show("No seleccionaste ninguna bodega");
            }
            else
            {
                for (int i = 0; i < gridBodegasActualizar.Rows.Count; i++)
                {
                    bool seleccionadaBodega = Convert.ToBoolean(gridBodegasActualizar.Rows[i].Cells["Seleccionar"].Value);
                    if (seleccionadaBodega)
                    {
                        string nombreBodega = Convert.ToString(gridBodegasActualizar.Rows[i].Cells["Bodega"].Value);
                        GestorImportarActualizacionBodegas.TomarBodega(nombreBodega);
                    }
                }
            }
        }
    }
}
