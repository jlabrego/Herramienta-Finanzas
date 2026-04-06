using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TryCash_Alternativas.Datos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TryCash_Alternativas.Vistas
{
    public partial class frmResumenSensibilidad : Form
    {
        MetodosDatos db = new MetodosDatos();

        public frmResumenSensibilidad()
        {
            InitializeComponent();
        }
        private void frmResumenSensibilidad_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasDataGrid();
            ConfigurarGrafico();
            CargarDatosResumen();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500; 
            toolTip1.ReshowDelay = 200;  
            toolTip1.ShowAlways = true;  

            toolTip1.SetToolTip(this.pictureBox1, "Exportar Excel");
            toolTip1.SetToolTip(this.pictureBox2, "Exportar PDF");
        }

        private void ConfigurarGrafico()
        {
            chartSensibilidad.Series.Clear();
            chartSensibilidad.ChartAreas.Clear();
            chartSensibilidad.Titles.Clear();

            Title tituloGrafico = new Title();
            tituloGrafico.Text = "Análisis de sensibilidad PUNTUAL de la rentabilidad";
            tituloGrafico.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
            tituloGrafico.ForeColor = Color.Red;
            tituloGrafico.Alignment = ContentAlignment.TopCenter;

            chartSensibilidad.Titles.Add(tituloGrafico);

            if (chartSensibilidad.Legends.Count > 0)
            {
                chartSensibilidad.Legends[0].Docking = Docking.Right;
                chartSensibilidad.Legends[0].Alignment = StringAlignment.Center;
                chartSensibilidad.Legends[0].BorderColor = Color.Transparent;
            }
            ChartArea mainArea = new ChartArea("MainArea");

            mainArea.AxisX.Interval = 1;
            mainArea.AxisX.MajorGrid.Enabled = false;
            mainArea.AxisX.IsMarginVisible = true;

            mainArea.AxisX.IsReversed = false;

            mainArea.AxisX.LabelStyle.Enabled = true;

            mainArea.InnerPlotPosition = new ElementPosition(20, 5, 75, 85);

            chartSensibilidad.ChartAreas.Add(mainArea);

        }

        private void CargarDatosResumen()
        {
            DataTable dtDatos = db.ObtenerTodosLosEscenarios();
            string[] conceptos = { "Ramos producidos", "Precio de venta", "Devaluacion", "Costo embalaje" };

            chartSensibilidad.Series.Clear();
            dgvResumen.Rows.Clear();

            string[] ordenEscenarios = { "Exportar a Francia", "Mejor calidad", "Básica" };

            foreach (string nombre in ordenEscenarios)
            {
                var filaEscenario = dtDatos.AsEnumerable()
                                     .FirstOrDefault(r => r["Nombre"].ToString().Trim() == nombre);

                if (filaEscenario != null)
                {
                    Series nuevaSerie = new Series(nombre);
                    nuevaSerie.ChartType = SeriesChartType.Bar;
                    nuevaSerie.ChartArea = "MainArea";

                    nuevaSerie["PointWidth"] = "0.8";

                    chartSensibilidad.Series.Add(nuevaSerie);
                }
            }

            foreach (string concepto in conceptos)
            {
                int rowIndex = dgvResumen.Rows.Add();
                dgvResumen.Rows[rowIndex].Cells[0].Value = concepto;

                foreach (DataRow dr in dtDatos.Rows)
                {
                    string nombreEscenario = dr["Nombre"].ToString().Trim();
                    decimal valor = 0;

                    try
                    {
                        switch (concepto)
                        {
                            case "Ramos producidos": valor = dr["GspRamos"] != DBNull.Value ? Convert.ToDecimal(dr["GspRamos"]) : 0; break;
                            case "Precio de venta": valor = dr["GspPrecio"] != DBNull.Value ? Convert.ToDecimal(dr["GspPrecio"]) : 0; break;
                            case "Devaluacion": valor = dr["GspDevaluacion"] != DBNull.Value ? Convert.ToDecimal(dr["GspDevaluacion"]) : 0; break;
                            case "Costo embalaje": valor = dr["GspEmbalaje"] != DBNull.Value ? Convert.ToDecimal(dr["GspEmbalaje"]) : 0; break;
                        }
                    }
                    catch { valor = 0; }
                    if (dgvResumen.Columns.Contains(nombreEscenario))
                    {
                        dgvResumen.Rows[rowIndex].Cells[nombreEscenario].Value = valor.ToString("N2");
                    }
                    var serieDestino = chartSensibilidad.Series.FirstOrDefault(s => s.Name == nombreEscenario);
                    if (serieDestino != null)
                    {
                        serieDestino.Points.AddXY(concepto, valor);
                    }
                }
            }
            chartSensibilidad.Invalidate();
        }
        private void ConfigurarColumnasDataGrid()
        {
            dgvResumen.Columns.Clear();
            dgvResumen.Rows.Clear();
            dgvResumen.EnableHeadersVisualStyles = false;

            dgvResumen.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvResumen.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvResumen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgvResumen.Font, FontStyle.Bold);

            dgvResumen.Columns.Add("Concepto", "Concepto");
            dgvResumen.Columns["Concepto"].Width = 150;

            DataTable dtNombres = db.ObtenerNombresEscenarios();
            foreach (DataRow row in dtNombres.Rows)
            {
                string nombre = row["Nombre"].ToString();
                int colIndex = dgvResumen.Columns.Add(nombre, nombre);
                dgvResumen.Columns[colIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void dgvResumen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.CellStyle.Font = new System.Drawing.Font(dgvResumen.Font, FontStyle.Bold);
            }

            if (e.ColumnIndex > 0 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    e.CellStyle.ForeColor = (valor < 0) ? Color.Red : Color.Black;
                }
            }
        }
        private void ExportarExcel()
        {
            
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "Sensibilidad_Puntual_TryCash.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Sensibilidad");

                            for (int i = 1; i <= dgvResumen.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i).Value = dgvResumen.Columns[i - 1].HeaderText;
                            }

                            for (int i = 0; i < dgvResumen.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvResumen.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvResumen.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            using (MemoryStream ms = new MemoryStream())
                            {
                                chartSensibilidad.SaveImage(ms, ChartImageFormat.Png);
                                var imagen = worksheet.AddPicture(ms).MoveTo(worksheet.Cell(dgvResumen.Rows.Count + 4, 1));
                                imagen.Scale(0.8);
                            }

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("¡Excel exportado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message);
                    }
                }
            }
        }
        private void ExportarPDF()
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF Document|*.pdf",
                FileName = "Reporte_Sensibilidad_TryCash.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(PageSize.A4.Rotate());
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED);
                        doc.Add(new Paragraph("Análisis de sensibilidad PUNTUAL de la rentabilidad", fontTitulo));
                        doc.Add(new Paragraph(" "));

                        PdfPTable pdfTable = new PdfPTable(dgvResumen.Columns.Count);
                        foreach (DataGridViewColumn column in dgvResumen.Columns)
                            pdfTable.AddCell(new Phrase(column.HeaderText));

                        foreach (DataGridViewRow row in dgvResumen.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                                pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                        }
                        doc.Add(pdfTable);
                        doc.Add(new Paragraph(" "));

                        using (MemoryStream ms = new MemoryStream())
                        {
                            chartSensibilidad.SaveImage(ms, ChartImageFormat.Png);
                            iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                            chartImg.ScalePercent(75f);
                            chartImg.Alignment = Element.ALIGN_CENTER;
                            doc.Add(chartImg);
                        }

                        doc.Close();
                        MessageBox.Show("¡PDF exportado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar PDF: " + ex.Message);
                    }
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExportarPDF();
        }
    }
}
