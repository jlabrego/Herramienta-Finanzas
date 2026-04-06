namespace TryCash_Alternativas.Vistas
{
    partial class GSPUtilidadRentabilidadFrancia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GSPUtilidadRentabilidadFrancia));
            this.lblTituloAplicadas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSensibilidad = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloAplicadas
            // 
            this.lblTituloAplicadas.AutoSize = true;
            this.lblTituloAplicadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAplicadas.Location = new System.Drawing.Point(361, 188);
            this.lblTituloAplicadas.Name = "lblTituloAplicadas";
            this.lblTituloAplicadas.Size = new System.Drawing.Size(252, 15);
            this.lblTituloAplicadas.TabIndex = 22;
            this.lblTituloAplicadas.Text = "VARIACIONES PORCENTUALES APLICADAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Variación porcentual de la variable independiente: 4%";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(56, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 16.2F);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(711, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sensibilidad Puntual de Utilidad y Rentabilidad - Francia";
            // 
            // dgvSensibilidad
            // 
            this.dgvSensibilidad.AllowUserToAddRows = false;
            this.dgvSensibilidad.AllowUserToDeleteRows = false;
            this.dgvSensibilidad.AllowUserToResizeColumns = false;
            this.dgvSensibilidad.AllowUserToResizeRows = false;
            this.dgvSensibilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSensibilidad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvSensibilidad.BackgroundColor = System.Drawing.Color.White;
            this.dgvSensibilidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSensibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensibilidad.Location = new System.Drawing.Point(12, 206);
            this.dgvSensibilidad.Name = "dgvSensibilidad";
            this.dgvSensibilidad.ReadOnly = true;
            this.dgvSensibilidad.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvSensibilidad.RowTemplate.Height = 24;
            this.dgvSensibilidad.Size = new System.Drawing.Size(948, 548);
            this.dgvSensibilidad.TabIndex = 17;
            // 
            // GSPUtilidadRentabilidadFrancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 782);
            this.Controls.Add(this.lblTituloAplicadas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSensibilidad);
            this.Name = "GSPUtilidadRentabilidadFrancia";
            this.Text = "SENSIBILIDAD PUNTUAL DE UTILIDAD Y RENTABILIDAD FRANCIA";
            this.Load += new System.EventHandler(this.GSPUtilidadRentabilidadFrancia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensibilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloAplicadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSensibilidad;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}