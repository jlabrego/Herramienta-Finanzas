namespace TryCash_Alternativas.Vistas
{
    partial class frmAnalisisGSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalisisGSP));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvSensibilidad = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chartTornado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTituloAplicadas = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensibilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTornado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSensibilidad
            // 
            this.dgvSensibilidad.AllowUserToAddRows = false;
            this.dgvSensibilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSensibilidad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSensibilidad.BackgroundColor = System.Drawing.Color.White;
            this.dgvSensibilidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSensibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensibilidad.Location = new System.Drawing.Point(4, 176);
            this.dgvSensibilidad.Name = "dgvSensibilidad";
            this.dgvSensibilidad.ReadOnly = true;
            this.dgvSensibilidad.RowHeadersWidth = 51;
            this.dgvSensibilidad.RowTemplate.Height = 24;
            this.dgvSensibilidad.Size = new System.Drawing.Size(919, 485);
            this.dgvSensibilidad.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(36, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 16.2F);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(642, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Análisis de Sensibilidad Puntual de la Rentabilidad";
            // 
            // chartTornado
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTornado.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTornado.Legends.Add(legend1);
            this.chartTornado.Location = new System.Drawing.Point(948, 201);
            this.chartTornado.Name = "chartTornado";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTornado.Series.Add(series1);
            this.chartTornado.Size = new System.Drawing.Size(597, 353);
            this.chartTornado.TabIndex = 12;
            this.chartTornado.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Variación porcentual de la variable independiente: 4%";
            // 
            // lblTituloAplicadas
            // 
            this.lblTituloAplicadas.AutoSize = true;
            this.lblTituloAplicadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAplicadas.Location = new System.Drawing.Point(328, 157);
            this.lblTituloAplicadas.Name = "lblTituloAplicadas";
            this.lblTituloAplicadas.Size = new System.Drawing.Size(252, 15);
            this.lblTituloAplicadas.TabIndex = 14;
            this.lblTituloAplicadas.Text = "VARIACIONES PORCENTUALES APLICADAS";
            // 
            // frmAnalisisGSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1571, 707);
            this.Controls.Add(this.lblTituloAplicadas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartTornado);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSensibilidad);
            this.Name = "frmAnalisisGSP";
            this.Text = "ANÁLISIS DE SENSIBILIDAD PUNTUAL DE LA RENTABILIDAD";
            this.Load += new System.EventHandler(this.frmGSPBasica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensibilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTornado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSensibilidad;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTornado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTituloAplicadas;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}