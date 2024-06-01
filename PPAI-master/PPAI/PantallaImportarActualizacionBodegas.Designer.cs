namespace PPAI
{
    partial class PantallaImportarActualizacionBodegas
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnImportarActu = new Button();
            btnActualizar = new Button();
            label1 = new Label();
            gridBodegasActualizar = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridBodegasActualizar).BeginInit();
            SuspendLayout();
            // 
            // btnImportarActu
            // 
            btnImportarActu.Location = new Point(212, 164);
            btnImportarActu.Margin = new Padding(3, 4, 3, 4);
            btnImportarActu.Name = "btnImportarActu";
            btnImportarActu.Size = new Size(223, 57);
            btnImportarActu.TabIndex = 0;
            btnImportarActu.Text = "Importar Actualizaciones";
            btnImportarActu.UseVisualStyleBackColor = true;
            btnImportarActu.Click += PantallaImportarActualizacionBodegas_Load;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(742, 51);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(101, 71);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(312, 51);
            label1.Name = "label1";
            label1.Size = new Size(224, 20);
            label1.TabIndex = 4;
            label1.Text = "Seleccione los vinos a actualizar:";
            // 
            // gridBodegasActualizar
            // 
            gridBodegasActualizar.AllowUserToAddRows = false;
            gridBodegasActualizar.AllowUserToDeleteRows = false;
            gridBodegasActualizar.AllowUserToResizeColumns = false;
            gridBodegasActualizar.AllowUserToResizeRows = false;
            gridBodegasActualizar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBodegasActualizar.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewCheckBoxColumn1 });
            gridBodegasActualizar.Location = new Point(197, 252);
            gridBodegasActualizar.Name = "gridBodegasActualizar";
            gridBodegasActualizar.RowHeadersWidth = 51;
            gridBodegasActualizar.Size = new Size(460, 188);
            gridBodegasActualizar.TabIndex = 6;
            gridBodegasActualizar.CellContentClick += gridBodegaActualizar_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Bodega";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.HeaderText = "Seleccionar";
            dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // PantallaImportarActualizacionBodegas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BonVinito;
            ClientSize = new Size(866, 591);
            Controls.Add(gridBodegasActualizar);
            Controls.Add(label1);
            Controls.Add(btnActualizar);
            Controls.Add(btnImportarActu);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "PantallaImportarActualizacionBodegas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importar actualización vinos de bodega";
            Load += PantallaImportarActualizacionBodegas_Load;
            ((System.ComponentModel.ISupportInitialize)gridBodegasActualizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImportarActu;
        private Button btnActualizar;
        private Label label1;
        private DataGridView gridBodegasActualizar;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}