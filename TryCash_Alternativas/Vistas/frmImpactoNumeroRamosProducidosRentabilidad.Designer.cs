namespace TryCash_Alternativas.Vistas
{
    partial class frmImpactoNumeroRamosProducidosRentabilidad
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpactoNumeroRamosProducidosRentabilidad));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPendienteBasica = new System.Windows.Forms.Label();
            this.chartBasica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvBasica = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblPendienteCalidad = new System.Windows.Forms.Label();
            this.chartCalidad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvCalidad = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblPendienteFrancia = new System.Windows.Forms.Label();
            this.chartFrancia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvFrancia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBasica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasica)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalidad)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFrancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFrancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1323, 810);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lblPendienteBasica);
            this.groupBox1.Controls.Add(this.chartBasica);
            this.groupBox1.Controls.Add(this.dgvBasica);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1301, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BÁSICA";
            // 
            // lblPendienteBasica
            // 
            this.lblPendienteBasica.AutoSize = true;
            this.lblPendienteBasica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendienteBasica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendienteBasica.Location = new System.Drawing.Point(1139, 111);
            this.lblPendienteBasica.Name = "lblPendienteBasica";
            this.lblPendienteBasica.Size = new System.Drawing.Size(61, 22);
            this.lblPendienteBasica.TabIndex = 2;
            this.lblPendienteBasica.Text = "label2";
            this.lblPendienteBasica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartBasica
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBasica.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBasica.Legends.Add(legend1);
            this.chartBasica.Location = new System.Drawing.Point(493, 12);
            this.chartBasica.Name = "chartBasica";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBasica.Series.Add(series1);
            this.chartBasica.Size = new System.Drawing.Size(606, 232);
            this.chartBasica.TabIndex = 1;
            this.chartBasica.Text = "chart1";
            // 
            // dgvBasica
            // 
            this.dgvBasica.AllowUserToAddRows = false;
            this.dgvBasica.BackgroundColor = System.Drawing.Color.White;
            this.dgvBasica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBasica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasica.Location = new System.Drawing.Point(25, 21);
            this.dgvBasica.Name = "dgvBasica";
            this.dgvBasica.RowHeadersWidth = 51;
            this.dgvBasica.RowTemplate.Height = 24;
            this.dgvBasica.Size = new System.Drawing.Size(441, 223);
            this.dgvBasica.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.Controls.Add(this.lblPendienteCalidad);
            this.groupBox5.Controls.Add(this.chartCalidad);
            this.groupBox5.Controls.Add(this.dgvCalidad);
            this.groupBox5.Location = new System.Drawing.Point(3, 259);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1301, 271);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CALIDAD";
            // 
            // lblPendienteCalidad
            // 
            this.lblPendienteCalidad.AutoSize = true;
            this.lblPendienteCalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendienteCalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendienteCalidad.Location = new System.Drawing.Point(1130, 127);
            this.lblPendienteCalidad.Name = "lblPendienteCalidad";
            this.lblPendienteCalidad.Size = new System.Drawing.Size(61, 22);
            this.lblPendienteCalidad.TabIndex = 5;
            this.lblPendienteCalidad.Text = "label3";
            this.lblPendienteCalidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartCalidad
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCalidad.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCalidad.Legends.Add(legend2);
            this.chartCalidad.Location = new System.Drawing.Point(493, 21);
            this.chartCalidad.Name = "chartCalidad";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCalidad.Series.Add(series2);
            this.chartCalidad.Size = new System.Drawing.Size(606, 244);
            this.chartCalidad.TabIndex = 4;
            this.chartCalidad.Text = "chart2";
            // 
            // dgvCalidad
            // 
            this.dgvCalidad.AllowUserToAddRows = false;
            this.dgvCalidad.BackgroundColor = System.Drawing.Color.White;
            this.dgvCalidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalidad.Location = new System.Drawing.Point(25, 21);
            this.dgvCalidad.Name = "dgvCalidad";
            this.dgvCalidad.RowHeadersWidth = 51;
            this.dgvCalidad.RowTemplate.Height = 24;
            this.dgvCalidad.Size = new System.Drawing.Size(441, 244);
            this.dgvCalidad.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.lblPendienteFrancia);
            this.groupBox4.Controls.Add(this.chartFrancia);
            this.groupBox4.Controls.Add(this.dgvFrancia);
            this.groupBox4.Location = new System.Drawing.Point(3, 536);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1301, 249);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FRANCIA";
            // 
            // lblPendienteFrancia
            // 
            this.lblPendienteFrancia.AutoSize = true;
            this.lblPendienteFrancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendienteFrancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendienteFrancia.Location = new System.Drawing.Point(1130, 118);
            this.lblPendienteFrancia.Name = "lblPendienteFrancia";
            this.lblPendienteFrancia.Size = new System.Drawing.Size(61, 22);
            this.lblPendienteFrancia.TabIndex = 8;
            this.lblPendienteFrancia.Text = "label4";
            this.lblPendienteFrancia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartFrancia
            // 
            chartArea3.Name = "ChartArea1";
            this.chartFrancia.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartFrancia.Legends.Add(legend3);
            this.chartFrancia.Location = new System.Drawing.Point(493, 21);
            this.chartFrancia.Name = "chartFrancia";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartFrancia.Series.Add(series3);
            this.chartFrancia.Size = new System.Drawing.Size(606, 219);
            this.chartFrancia.TabIndex = 7;
            this.chartFrancia.Text = "chart3";
            // 
            // dgvFrancia
            // 
            this.dgvFrancia.AllowUserToAddRows = false;
            this.dgvFrancia.BackgroundColor = System.Drawing.Color.White;
            this.dgvFrancia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFrancia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFrancia.Location = new System.Drawing.Point(25, 21);
            this.dgvFrancia.Name = "dgvFrancia";
            this.dgvFrancia.RowHeadersWidth = 51;
            this.dgvFrancia.RowTemplate.Height = 24;
            this.dgvFrancia.Size = new System.Drawing.Size(441, 219);
            this.dgvFrancia.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 16.2F);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(759, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Impacto del número de ramos producidos en la rentabilidad";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmImpactoNumeroRamosProducidosRentabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1347, 995);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmImpactoNumeroRamosProducidosRentabilidad";
            this.Text = "frmImpactoNumeroRamosProducidosRentabilidad";
            this.Load += new System.EventHandler(this.frmImpactoNumeroRamosProducidosRentabilidad_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBasica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasica)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalidad)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFrancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFrancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblPendienteBasica;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBasica;
        private System.Windows.Forms.DataGridView dgvBasica;
        private System.Windows.Forms.Label lblPendienteCalidad;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCalidad;
        private System.Windows.Forms.DataGridView dgvCalidad;
        private System.Windows.Forms.Label lblPendienteFrancia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFrancia;
        private System.Windows.Forms.DataGridView dgvFrancia;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}