namespace TryCash_Alternativas.Vistas
{
    partial class frmImpactoSalarioMinimoUtilidad
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpactoSalarioMinimoUtilidad));
            this.chartSensibilidad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvImpacto = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartSensibilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSensibilidad
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSensibilidad.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSensibilidad.Legends.Add(legend1);
            this.chartSensibilidad.Location = new System.Drawing.Point(82, 437);
            this.chartSensibilidad.Name = "chartSensibilidad";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSensibilidad.Series.Add(series1);
            this.chartSensibilidad.Size = new System.Drawing.Size(1336, 408);
            this.chartSensibilidad.TabIndex = 0;
            this.chartSensibilidad.Text = "chart1";
            this.chartSensibilidad.Click += new System.EventHandler(this.chartSensibilidad_Click);
            // 
            // dgvImpacto
            // 
            this.dgvImpacto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvImpacto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvImpacto.BackgroundColor = System.Drawing.Color.White;
            this.dgvImpacto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImpacto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpacto.Location = new System.Drawing.Point(18, 104);
            this.dgvImpacto.Name = "dgvImpacto";
            this.dgvImpacto.ReadOnly = true;
            this.dgvImpacto.RowHeadersWidth = 51;
            this.dgvImpacto.RowTemplate.Height = 24;
            this.dgvImpacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvImpacto.Size = new System.Drawing.Size(1467, 294);
            this.dgvImpacto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 16.2F);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Impacto del salario mínimo en la utilidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1005, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "INDICE Valor referencia = 100";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(44, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // frmImpactoSalarioMinimoUtilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1497, 976);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvImpacto);
            this.Controls.Add(this.chartSensibilidad);
            this.Name = "frmImpactoSalarioMinimoUtilidad";
            this.Text = "Impacto Salario Minimo Utilidad";
            this.Load += new System.EventHandler(this.frmImpactoSalarioMinimoUtilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSensibilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSensibilidad;
        private System.Windows.Forms.DataGridView dgvImpacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}