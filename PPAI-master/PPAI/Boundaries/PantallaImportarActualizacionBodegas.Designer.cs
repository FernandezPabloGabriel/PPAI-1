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
            Bodega = new DataGridViewTextBoxColumn();
            Seleccionar = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridBodegasActualizar).BeginInit();
            SuspendLayout();
            // 
            // btnImportarActu
            // 
            btnImportarActu.Location = new Point(197, 169);
            btnImportarActu.Margin = new Padding(3, 4, 3, 4);
            btnImportarActu.Name = "btnImportarActu";
            btnImportarActu.Size = new Size(223, 57);
            btnImportarActu.TabIndex = 0;
            btnImportarActu.Text = "Importar Actualizaciones";
            btnImportarActu.UseVisualStyleBackColor = true;
            btnImportarActu.Click += OpcionImportarActualizacionVinosBodega;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(434, 169);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(223, 57);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar Bodegas";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += TomarBodega;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(107, 38);
            label1.Name = "label1";
            label1.Size = new Size(655, 54);
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
            gridBodegasActualizar.Columns.AddRange(new DataGridViewColumn[] { Bodega, Seleccionar });
            gridBodegasActualizar.Location = new Point(197, 252);
            gridBodegasActualizar.Name = "gridBodegasActualizar";
            gridBodegasActualizar.RowHeadersWidth = 51;
            gridBodegasActualizar.Size = new Size(460, 188);
            gridBodegasActualizar.TabIndex = 6;
            gridBodegasActualizar.CellContentClick += gridBodegaActualizar_CellContentClick;
            // 
            // Bodega
            // 
            Bodega.HeaderText = "Bodega";
            Bodega.MinimumWidth = 6;
            Bodega.Name = "Bodega";
            Bodega.ReadOnly = true;
            Bodega.Width = 250;
            // 
            // Seleccionar
            // 
            Seleccionar.HeaderText = "Seleccionar";
            Seleccionar.MinimumWidth = 6;
            Seleccionar.Name = "Seleccionar";
            Seleccionar.Width = 125;
            // 
            // PantallaImportarActualizacionBodegas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private DataGridViewTextBoxColumn Bodega;
        private DataGridViewCheckBoxColumn Seleccionar;
    }
}