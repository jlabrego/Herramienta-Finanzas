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

namespace TryCash_Alternativas.Vistas
{
    public partial class frmImpactoNumeroRamosProducidosRentabilidad : Form
    {
        public frmImpactoNumeroRamosProducidosRentabilidad()
        {
            InitializeComponent();
        }
        public void ConfigurarTablaBasica()
        {
            dgvBasica.Columns.Clear();
            dgvBasica.Columns.Add("Ramos", "Ramos");
            dgvBasica.Columns.Add("Rentabilidad", "Rentabilidad (%)");

            // Datos de la imagen
            dgvBasica.Rows.Add("BÁSICA", "11.51%"); 
            dgvBasica.Rows.Add("768", "8.37%");
            dgvBasica.Rows.Add("784", "9.93%");
            dgvBasica.Rows.Add("800", "11.51%");
            dgvBasica.Rows.Add("816", "13.08%");
            dgvBasica.Rows.Add("832", "14.65%");

            dgvBasica.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
            dgvBasica.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font(dgvBasica.Font, FontStyle.Bold);
        }
        public void GraficarBasica()
        {
            var serie = chartBasica.Series[0];
            serie.Points.Clear();
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;
            serie.Color = Color.SteelBlue;

            serie.Points.AddXY(768, 8.37);
            serie.Points.AddXY(784, 9.93);
            serie.Points.AddXY(800, 11.51);
            serie.Points.AddXY(816, 13.08);
            serie.Points.AddXY(832, 14.65);

            var area = chartBasica.ChartAreas[0];
            area.AxisX.Minimum = 720;
            area.AxisX.Maximum = 840;
            area.AxisX.Interval = 20;

            area.AxisY.Minimum = 5;
            area.AxisY.Maximum = 15;
            area.AxisY.LabelStyle.Format = "{0}%";

            lblPendienteBasica.Text = "Pendiente:\n0.098%";
        }
        public void ConfigurarTablaCalidad()
        {
            dgvCalidad.Rows.Clear();
            dgvCalidad.Columns.Clear();

            dgvCalidad.Columns.Add("Ramos", "Ramos");
            dgvCalidad.Columns.Add("Rentabilidad", "Rentabilidad (%)");

            dgvCalidad.Rows.Add("CALIDAD", "10.79%"); 
            dgvCalidad.Rows.Add("749", "7.59%");
            dgvCalidad.Rows.Add("764", "9.18%");
            dgvCalidad.Rows.Add("780", "10.79%"); 
            dgvCalidad.Rows.Add("796", "12.38%");
            dgvCalidad.Rows.Add("812", "13.98%");

            // 4. Aplicar estilos
            dgvCalidad.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
            dgvCalidad.Rows[3].DefaultCellStyle.Font = new System.Drawing.Font(dgvCalidad.Font, FontStyle.Bold);
        }
        public void GraficarCalidad()
        {
            var serie = chartCalidad.Series[0];
            serie.Points.Clear();
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;
            serie.Color = Color.SteelBlue;

            serie.Points.AddXY(749, 7.59);
            serie.Points.AddXY(764, 9.18);
            serie.Points.AddXY(780, 10.79);
            serie.Points.AddXY(796, 12.38);
            serie.Points.AddXY(812, 13.98);

            var area = chartCalidad.ChartAreas[0];
            area.AxisX.Minimum = 720;
            area.AxisX.Maximum = 840;
            area.AxisX.Interval = 20;

            area.AxisY.Minimum = 5;
            area.AxisY.Maximum = 15;
            area.AxisY.LabelStyle.Format = "{0}%";

            // ACTUALIZAR EL LABEL
            lblPendienteCalidad.Text = "Pendiente:\n0.102%";
        }
        public void ConfigurarTablaFrancia()
        {
            dgvFrancia.Columns.Clear();
            dgvFrancia.Columns.Add("Ramos", "Ramos");
            dgvFrancia.Columns.Add("Rentabilidad", "Rentabilidad (%)");

            dgvFrancia.Rows.Add("FRANCIA", "9.02%");
            dgvFrancia.Rows.Add("720", "5.15%");
            dgvFrancia.Rows.Add("735", "7.07%");
            dgvFrancia.Rows.Add("750", "9.02%"); 
            dgvFrancia.Rows.Add("765", "10.96%");
            dgvFrancia.Rows.Add("780", "12.92%");

            dgvFrancia.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); // Verde
            dgvFrancia.Rows[3].DefaultCellStyle.Font = new System.Drawing.Font(dgvFrancia.Font, FontStyle.Bold);
            dgvFrancia.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font(dgvFrancia.Font, FontStyle.Bold); // Negrita al encabezado
        }
        public void GraficarFrancia()
        {
            var serie = chartFrancia.Series[0];
            serie.Points.Clear();
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;
            serie.Color = Color.SteelBlue;

            serie.Points.AddXY(720, 5.15);
            serie.Points.AddXY(735, 7.07);
            serie.Points.AddXY(750, 9.02);
            serie.Points.AddXY(765, 10.96);
            serie.Points.AddXY(780, 12.92);

            var area = chartFrancia.ChartAreas[0];
            area.AxisX.Minimum = 720;
            area.AxisX.Maximum = 840;
            area.AxisX.Interval = 20; 

            area.AxisY.Minimum = 5;
            area.AxisY.Maximum = 15;
            area.AxisY.LabelStyle.Format = "{0}%";

            lblPendienteFrancia.Text = "Pendiente:\n0.130%";
        }
        public void ExportarAExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Rentabilidad");

                var rangoTitulo = ws.Range("A1:F1");
                rangoTitulo.Merge().Value = "Impacto del número de ramos producidos en la rentabilidad";
                rangoTitulo.Style.Font.Bold = true;
                rangoTitulo.Style.Font.FontSize = 14;
                rangoTitulo.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                EscribirTablaEnExcel(ws, dgvBasica, 3, "BÁSICA", lblPendienteBasica.Text);
                AgregarGraficoAExcel(ws, chartBasica, 3, "GraficoBasica");

                EscribirTablaEnExcel(ws, dgvCalidad, 14, "CALIDAD", lblPendienteCalidad.Text);
                AgregarGraficoAExcel(ws, chartCalidad, 14, "GraficoCalidad");

                EscribirTablaEnExcel(ws, dgvFrancia, 25, "FRANCIA", lblPendienteFrancia.Text);
                AgregarGraficoAExcel(ws, chartFrancia, 25, "GraficoFrancia");

                ws.Columns().AdjustToContents();

                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Reporte_Completo_Ramos.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Excel exportado con éxito.", "TryCash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EscribirTablaEnExcel(IXLWorksheet ws, DataGridView dgv, int filaInicio, string titulo, string pendiente)
        {
            ws.Cell(filaInicio, 1).Value = titulo;
            ws.Cell(filaInicio, 1).Style.Font.Bold = true;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                var cell = ws.Cell(filaInicio + 1, i + 1);
                cell.Value = dgv.Columns[i].HeaderText;
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            int r;
            for (r = 0; r < dgv.Rows.Count; r++)
            {
                if (dgv.Rows[r].IsNewRow) continue;
                ws.Cell(filaInicio + r + 2, 1).Value = dgv.Rows[r].Cells[0].Value?.ToString();
                ws.Cell(filaInicio + r + 2, 2).Value = dgv.Rows[r].Cells[1].Value?.ToString();
            }

            var celdaPendiente = ws.Cell(filaInicio + r + 2, 1);
            celdaPendiente.Value = pendiente;
            celdaPendiente.Style.Font.Italic = true;

            celdaPendiente.Style.Font.SetFontColor(XLColor.DarkBlue);

        }

        private void AgregarGraficoAExcel(IXLWorksheet ws, Chart chart, int fila, string nombre)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                var imagen = ws.AddPicture(ms);
                imagen.Name = nombre;
                imagen.MoveTo(ws.Cell(fila, 4)); // Columna D
                imagen.Scale(0.6);
            }
        }

        // --- PDF ---
        public void ExportarAPDF()
        {
            Document doc = new Document(PageSize.A4.Rotate());
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = "Reporte_Rentabilidad_Ramos.pdf" };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();


                Paragraph t = new Paragraph("Impacto del Número de Ramos Producidos en la Rentabilidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                t.Alignment = Element.ALIGN_CENTER;
                doc.Add(t);
                doc.Add(new Paragraph(" "));

                AgregarSeccionPDF(doc, "ALTERNATIVA BÁSICA", dgvBasica, chartBasica, lblPendienteBasica.Text);
                doc.Add(new Paragraph("\n"));
                AgregarSeccionPDF(doc, "ALTERNATIVA CALIDAD", dgvCalidad, chartCalidad, lblPendienteCalidad.Text);
                doc.Add(new Paragraph("\n"));
                AgregarSeccionPDF(doc, "ALTERNATIVA FRANCIA", dgvFrancia, chartFrancia, lblPendienteFrancia.Text);

                doc.Close();
                MessageBox.Show("PDF Completo generado con éxito.", "TryCash");
            }
        }

        private void AgregarSeccionPDF(Document doc, string titulo, DataGridView dgv, Chart chart, string pendiente)
        {
            PdfPTable contenedor = new PdfPTable(2);
            contenedor.WidthPercentage = 100;
            contenedor.SetWidths(new float[] { 1f, 1.5f }); 
            contenedor.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            PdfPCell celdaInfo = new PdfPCell();
            celdaInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;

            celdaInfo.AddElement(new Paragraph(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

            PdfPTable tablaDatos = new PdfPTable(dgv.Columns.Count);
            tablaDatos.WidthPercentage = 100;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                tablaDatos.AddCell(new Phrase(col.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9)));
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                tablaDatos.AddCell(new Phrase(row.Cells[0].Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                tablaDatos.AddCell(new Phrase(row.Cells[1].Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            }
            celdaInfo.AddElement(tablaDatos);

            Paragraph pPen = new Paragraph(pendiente.Replace("\n", " "), FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9, BaseColor.BLUE));
            celdaInfo.AddElement(pPen);

            contenedor.AddCell(celdaInfo);

            PdfPCell celdaGrafico = new PdfPCell();
            celdaGrafico.Border = iTextSharp.text.Rectangle.NO_BORDER;
            celdaGrafico.VerticalAlignment = Element.ALIGN_MIDDLE;

            iTextSharp.text.Image img = ImagenParaPDF(chart);
            img.ScaleToFit(380f, 220f); 
            celdaGrafico.AddElement(img);

            contenedor.AddCell(celdaGrafico);

            doc.Add(contenedor);
        }

        private iTextSharp.text.Image ImagenParaPDF(Chart chart)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                img.ScaleToFit(400f, 200f);
                img.Alignment = Element.ALIGN_CENTER;
                return img;
            }
        }

        private void frmImpactoNumeroRamosProducidosRentabilidad_Load(object sender, EventArgs e)
        {
            ConfigurarTablaBasica();
            GraficarBasica();
            ConfigurarTablaCalidad();
            GraficarCalidad();
            ConfigurarTablaFrancia();
            GraficarFrancia();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500; 
            toolTip1.ReshowDelay = 200;   
            toolTip1.ShowAlways = true;   

            // Asignar los textos a tus PictureBoxes específicos
            toolTip1.SetToolTip(this.pictureBox1, "Exportar Excel");
            toolTip1.SetToolTip(this.pictureBox2, "Exportar PDF");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExportarAPDF();
        }
    } 
}