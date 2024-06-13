using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI.Recursos_Extra
{
    public partial class BarraDeCarga : Form
    {
        public BarraDeCarga()
        {
            InitializeComponent();
        }

        int i;

        private void BarraDeCarga_Load(object sender, EventArgs e)
        {

            timerBarraCarga.Start();
            
        }


        private void timerBarraCarga_Tick(object sender, EventArgs e)
        {
            if (barraCarga.Value < 100)
            {
                barraCarga.Value += 2;
                lblCargando.Text = "Cargando..." + barraCarga.Value.ToString() + "%";
            }
            else {
                timerBarraCarga.Stop();
                this.Hide();
            }
        }
    }
}
