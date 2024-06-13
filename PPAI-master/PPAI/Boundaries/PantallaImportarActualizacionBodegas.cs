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
using System.Reflection.Emit;
using PPAI.Recursos_Extra;


namespace PPAI
{
    public partial class PantallaImportarActualizacionBodegas : Form
    {
        public PantallaImportarActualizacionBodegas() //La función que habilita los componentes de la pantalla
        {
            InitializeComponent();
        }


        //Lo que hará la pantalla al cargarse
        private void PantallaImportarActualizacionBodegas_Load(object sender, EventArgs e)
        {
            
        }

        /*
         * --------------------------------------------
         * ----------------- PASO 1. ------------------
         * --------------------------------------------
         */

        //1°) Método que hace referencia a la presión del botón de mismo nombre que nos habilitará el grid
        private void OpcionImportarActualizacionVinosBodega(object sender, EventArgs e)
        {
            
            habilitarPantalla();
            
            //Llamar método del gestor, guardamos en una lista de string los nombres de bodegas devueltos
            List<String> listaNombreBodegas = GestorImportarActualizacionBodegas.OpcionImportarActualizacionVinosBodega();

            //Validamos si hay actualizaciones disponibles, si las hay llamamos al método "presentarBodegasParaActualizar" de la interfaz 
            if (listaNombreBodegas.Count == 0)
            {
                MessageBox.Show("No hay bodegas para actualizar, Estas al día!!!");
            }
            else
            {
                for (int i = 0; i < listaNombreBodegas.Count; i++)
                {
                    PresentarBodegasParaActualizar(listaNombreBodegas[i]);
                }
            }
        }


        //2°)
        private void habilitarPantalla()
        {
            //Declaramos objeto de tipo BarraDeCarga y la llamamos posteriormente
            BarraDeCarga barraDeCarga = new BarraDeCarga();
            barraDeCarga.ShowDialog();

            //Cambiamos algunos valores de los componentes para que se visualice posteriormente las bodegas a actualizar
            lblTitulo.Text = "Seleccione los vinos a actualizar: ";
            lblAyuda.Visible = false;
            gridBodegasActualizar.Visible = true;
            btnActualizar.Visible = true;
            btnImportarActu.Visible = false;
        }


        //7°)
        private void PresentarBodegasParaActualizar(String nombreBodega)
        {
            DataGridViewRow fila = new DataGridViewRow(); //Creamos una nueva fila del dataGridView
            fila.Cells.Add(new DataGridViewTextBoxCell() { Value = nombreBodega }); //Añadimos celda con el valor del nombre de la bodega
            gridBodegasActualizar.Rows.Add(fila); //Añadimos la fila al dataGridView
        }



        //8°) Le indicamos al gestor que tome todos los vinos de la API de la bodega seleccionada
        private void TomarBodega(object sender, EventArgs e)
        {
            bool haySeleccion = false;
            //Llamar método del gestor
            if (gridBodegasActualizar.Rows.Count == 0)
            {
                MessageBox.Show("No hay bodegas a seleccionar ¡Estas al día!");
            }
            else
            {
                for (int i = 0; i < gridBodegasActualizar.Rows.Count; i++)
                {
                    bool seleccionadaBodega = Convert.ToBoolean(gridBodegasActualizar.Rows[i].Cells["Seleccionar"].Value); //Obtenemos valor de verdad del checkbox de la fila
                    if (seleccionadaBodega)
                    {
                        string nombreBodega = Convert.ToString(gridBodegasActualizar.Rows[i].Cells["Bodega"].Value); //Obtenemos texto que guarda la celda de la columna "Bodega"
                        GestorImportarActualizacionBodegas.TomarBodega(nombreBodega);
                        gridBodegasActualizar.Rows[i].Cells["Seleccionar"].Value = false;
                        gridBodegasActualizar.Rows[i].Visible = false;
                        haySeleccion = true;
                    }
                }
                if (haySeleccion == false) 
                {
                    MessageBox.Show("Por favor selecciona una bodega para actualizar");
                }
            }
        }


        /*-----METODOS AUXILIARES-----*/
    }
}
