using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TryCash_Alternativas.Vistas
{
    public partial class frmAnalisisGSP : Form
    {
        public frmAnalisisGSP()
        {
            InitializeComponent();
        }

        private void frmGSPBasica_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            LlenarDatos();
            AplicarFormatoExcel();
            DibujarGraficoTornadoSimulado();
            toolTip1.AutoPopDelay = 5000; 
            toolTip1.InitialDelay = 500;  
            toolTip1.ReshowDelay = 200;  
            toolTip1.ShowAlways = true; 

            toolTip1.SetToolTip(this.pictureBox1, "Exportar Excel");
            toolTip1.SetToolTip(this.pictureBox2, "Exportar PDF");
        }

        private void ConfigurarColumnas()

        {

            if (dgvSensibilidad.Columns.Count == 0)

            {

                dgvSensibilidad.Columns.Add("Var", "Variable / Alternativa");

                dgvSensibilidad.Columns.Add("Base", "Base (%)");

                dgvSensibilidad.Columns.Add("M1", "-1");

                dgvSensibilidad.Columns.Add("C0", "0");

                dgvSensibilidad.Columns.Add("P1", "+1");

                dgvSensibilidad.Columns.Add("VarRes", "Var. % Resultado");

                dgvSensibilidad.Columns.Add("Grado", "Grado Sensibilidad");

            }



            foreach (DataGridViewColumn col in dgvSensibilidad.Columns)

            {

                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            dgvSensibilidad.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgvSensibilidad.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvSensibilidad.DefaultCellStyle.SelectionForeColor = Color.Black;

        }



        private void LlenarDatos()

        {

            dgvSensibilidad.Rows.Clear();

            int f1 = dgvSensibilidad.Rows.Add("Arrendamiento", "", "2,400,000", "2,500,000", "2,600,000", "", "");

            dgvSensibilidad.Rows.Add("Básico", "11.51%", "11.73%", "11.51%", "11.30%", "-1.9%", "-0.47");

            dgvSensibilidad.Rows.Add("Calidad", "10.79%", "10.98%", "10.79%", "10.59%", "-1.8%", "-0.45");

            dgvSensibilidad.Rows.Add("Francia", "9.02%", "9.20%", "9.02%", "8.84%", "-2.0%", "-0.50");

            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");



            int fS = dgvSensibilidad.Rows.Add("Salario mínimo", "", "888,000", "925,000", "962,000", "", "");

            dgvSensibilidad.Rows.Add("Básico", "11.51%", "13.03%", "11.51%", "10.04%", "-12.8%", "-3.20");

            dgvSensibilidad.Rows.Add("Calidad", "10.79%", "12.48%", "10.79%", "9.15%", "-15.2%", "-3.80");

            dgvSensibilidad.Rows.Add("Francia", "9.02%", "10.93%", "9.02%", "7.17%", "-20.5%", "-5.13");

            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");



            int fI = dgvSensibilidad.Rows.Add("Inversión en equipos", "", "76,800,000", "80,000,000", "83,200,000", "", "");

            dgvSensibilidad.Rows.Add("Básico", "11.51%", "12.68%", "11.51%", "10.37%", "-9.9%", "-2.48");

            dgvSensibilidad.Rows.Add("Calidad", "10.79%", "11.82%", "10.79%", "9.77%", "-9.4%", "-2.36");

            dgvSensibilidad.Rows.Add("Francia", "9.02%", "10.00%", "9.02%", "8.06%", "-10.7%", "-2.66");

        }

        private void DibujarGraficoTornadoSimulado()
        {
            chartTornado.Series.Clear();
            chartTornado.ChartAreas[0].AxisX.CustomLabels.Clear();
            var area = chartTornado.ChartAreas[0];

            // Series
            var sInv = chartTornado.Series.Add("Inversión en equipos");
            sInv.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            sInv.Color = Color.Black;

            var sSal = chartTornado.Series.Add("Salario mínimo");
            sSal.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            sSal.Color = Color.SteelBlue;
            sSal.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Vertical;

            var sArr = chartTornado.Series.Add("Arrendamiento");
            sArr.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            sArr.Color = Color.SteelBlue;
            sArr.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DiagonalBrick;

            // Datos
            sInv.Points.AddXY(0, -2.48); sSal.Points.AddXY(0, -3.20); sArr.Points.AddXY(0, -0.47);
            sInv.Points.AddXY(1, -2.36); sSal.Points.AddXY(1, -3.80); sArr.Points.AddXY(1, -0.45);
            sInv.Points.AddXY(2, -2.66); sSal.Points.AddXY(2, -5.13); sArr.Points.AddXY(2, -0.50);

            // Ejes y Etiquetas
            area.AxisX.LabelStyle.Enabled = false;
            area.AxisX.CustomLabels.Add(-0.5, 0.5, "Básica");
            area.AxisX.CustomLabels.Add(0.5, 1.5, "Calidad");
            area.AxisX.CustomLabels.Add(1.5, 2.5, "Francia");

            area.AxisY.Minimum = -6;
            area.AxisY.Maximum = 0;
            area.AxisX.MajorGrid.Enabled = false;

            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            chartTornado.Legends[0].Enabled = true;
            chartTornado.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            chartTornado.Legends[0].IsDockedInsideChartArea = true;

            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition.Width = 70;
            area.InnerPlotPosition.Height = 85;
            area.InnerPlotPosition.X = 25;
            area.InnerPlotPosition.Y = 5;

            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Enabled = true;

            area.Position.Auto = false;
            area.Position.X = 20;
            area.Position.Width = 80;
            area.Position.Height = 90;
            area.Position.Y = 5;
            area.AxisX.Interval = 1;
        }

        private void AplicarFormatoExcel()

        {

            if (lblTituloAplicadas != null) lblTituloAplicadas.ForeColor = Color.Red;



            foreach (DataGridViewRow row in dgvSensibilidad.Rows)

            {

                string primeraCelda = row.Cells[0].Value?.ToString();

                if (primeraCelda == "Arrendamiento" || primeraCelda == "Salario mínimo" || primeraCelda == "Inversión en equipos")

                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204);

                    row.DefaultCellStyle.Font = new System.Drawing.Font(dgvSensibilidad.Font, FontStyle.Bold);

                }



                if (row.Cells[5].Value != null && row.Cells[5].Value.ToString().Contains("-"))

                {

                    row.Cells[5].Style.ForeColor = Color.Red;

                    row.Cells[5].Style.Font = new System.Drawing.Font(dgvSensibilidad.Font, FontStyle.Bold);

                }



                if (row.Cells[6].Value != null)

                {

                    string val = row.Cells[6].Value.ToString();

                    if (val.Contains("-5.13") || val.Contains("-2.66") || val.Contains("-3.20") || val.Contains("-3.80"))

                    {

                        row.Cells[6].Style.BackColor = Color.FromArgb(0, 176, 80);

                        row.Cells[6].Style.ForeColor = Color.White;

                    }

                    else if (val.Contains("-2.48") || val.Contains("-2.36"))

                    {

                        row.Cells[6].Style.BackColor = Color.Yellow;

                        row.Cells[6].Style.ForeColor = Color.Red;

                    }

                }

            }

        }


        private iTextSharp.text.Image ObtenerImagenGrafico(Chart chart)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                img.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                img.ScaleToFit(550f, 300f); 
                return img;
            }
        }
 
     public void ExportarAPDF(DataGridView dgv)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 30, 30, 30, 30);
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = "Analisis_Sensibilidad_GSP.pdf" };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph t = new Paragraph("REPORTE DE ANÁLISIS GSP - TRYCASH", fontTitulo);
                    t.Alignment = Element.ALIGN_CENTER;
                    t.SpacingAfter = 20f;
                    doc.Add(t);

                    PdfPTable tablaLayout = new PdfPTable(2);
                    tablaLayout.WidthPercentage = 100;
                    tablaLayout.SetWidths(new float[] { 0.45f, 0.55f });
                    tablaLayout.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    PdfPCell celdaIzquierda = new PdfPCell();
                    celdaIzquierda.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    celdaIzquierda.PaddingRight = 10f;

                    PdfPTable tablaDatos = new PdfPTable(dgv.Columns.Count);
                    tablaDatos.WidthPercentage = 100;

                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        var fCab = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fCab));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tablaDatos.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            var fCuerpo = FontFactory.GetFont(FontFactory.HELVETICA, 7);
                            tablaDatos.AddCell(new Phrase(cell.Value?.ToString() ?? "", fCuerpo));
                        }
                    }
                    celdaIzquierda.AddElement(tablaDatos);
                    tablaLayout.AddCell(celdaIzquierda);

                    PdfPCell celdaDerecha = new PdfPCell();
                    celdaDerecha.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    celdaDerecha.VerticalAlignment = Element.ALIGN_MIDDLE;

                    iTextSharp.text.Image imgTornado = ObtenerImagenGrafico(chartTornado);
                    imgTornado.ScaleToFit(400f, 300f);
                    celdaDerecha.AddElement(imgTornado);

                    tablaLayout.AddCell(celdaDerecha);

                    doc.Add(tablaLayout);

                    doc.Close();
                    MessageBox.Show("PDF generado con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }

        public void ExportarExcel(DataGridView dgv)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Analisis_GSP_TryCash.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Análisis GSP");

                            for (int i = 1; i <= dgv.Columns.Count; i++)
                            {
                                ws.Cell(1, i).Value = dgv.Columns[i - 1].HeaderText;
                                ws.Cell(1, i).Style.Font.Bold = true;
                                ws.Cell(1, i).Style.Fill.BackgroundColor = XLColor.LightGray;
                            }

                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                if (dgv.Rows[i].IsNewRow) continue;
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    ws.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                                }
                            }
                            ws.Columns().AdjustToContents();

                            string tempPath = Path.Combine(Path.GetTempPath(), "temp_chart.png");
                            chartTornado.SaveImage(tempPath, ChartImageFormat.Png);

                            var dibujo = ws.AddPicture(tempPath)
                                           .MoveTo(ws.Cell(1, dgv.Columns.Count + 2))
                                           .Scale(0.8);

                            wb.SaveAs(sfd.FileName);

                            if (File.Exists(tempPath)) File.Delete(tempPath);
                        }
                        MessageBox.Show("Excel con Gráfico exportado con éxito.", "TryCash");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en Excel: " + ex.Message);
                    }
                }
            }
        }



        private void pictureBox1_Click_1(object sender, EventArgs e) => ExportarExcel(dgvSensibilidad);
        private void pictureBox2_Click_1(object sender, EventArgs e) => ExportarAPDF(dgvSensibilidad);
    }
}