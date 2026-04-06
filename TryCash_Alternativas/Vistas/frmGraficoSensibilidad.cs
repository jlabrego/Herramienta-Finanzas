using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PdfFont = iTextSharp.text.Font;
using PdfRectangle = iTextSharp.text.Rectangle;
using DrawingFont = System.Drawing.Font;
using DrawingRectangle = System.Drawing.Rectangle;

namespace TryCash_Alternativas.Vistas
{
    public partial class frmImpactoSalarioMinimoUtilidad : Form
    {
        public frmImpactoSalarioMinimoUtilidad()
        {
            InitializeComponent();

            ConfigurarTablaImpacto();

            LlenarDatosImpacto();

            GenerarGraficoArana();
        }

        private void ConfigurarTablaImpacto()
        {
            dgvImpacto.Columns.Clear();
            dgvImpacto.Rows.Clear();
            dgvImpacto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvImpacto.Columns.Add("Salario", ""); // Columna 0
            dgvImpacto.Columns.Add("UtilBasica", "Básica (Util)");       // Columna 1
            dgvImpacto.Columns.Add("UtilCalidad", "Calidad (Util)");     // Columna 2
            dgvImpacto.Columns.Add("UtilFrancia", "Francia (Util)");     // Columna 3
            dgvImpacto.Columns.Add("IndBasica", "Básica (%)");           // Columna 4
            dgvImpacto.Columns.Add("IndCalidad", "Calidad (%)");         // Columna 5
            dgvImpacto.Columns.Add("IndFrancia", "Francia (%)");         // Columna 6

            for (int i = 1; i <= 3; i++) dgvImpacto.Columns[i].DefaultCellStyle.Format = "N0";
            for (int i = 4; i <= 6; i++) dgvImpacto.Columns[i].DefaultCellStyle.Format = "N1";
        }

        public void LlenarDatosImpacto()
        {
            dgvImpacto.Rows.Clear();

            dgvImpacto.Rows.Add("", "35,673,810", "37,231,474", "32,460,048", "", "", "");

            dgvImpacto.Rows[0].DefaultCellStyle.BackColor = Color.White;
            dgvImpacto.Rows[0].ReadOnly = true;
            dgvImpacto.Rows[1].DefaultCellStyle.BackColor = Color.LightGray;

            string[][] filas = {
        new string[] { "915,000", "36,793,810", "38,631,474", "34,140,048", "103.1", "103.8", "105.2" },
        new string[] { "920,000", "36,233,810", "37,931,474", "33,300,048", "101.6", "101.9", "102.6" },
        new string[] { "925,000", "35,673,810", "37,231,474", "32,460,048", "100.0", "100.0", "100.0" },
        new string[] { "930,000", "35,113,810", "36,531,474", "31,620,048", "98.4", "98.1", "97.4" },
        new string[] { "935,000", "34,553,810", "35,831,474", "30,780,048", "96.9", "96.2", "94.8" }
    };

            foreach (var fila in filas)
            {
                int n = dgvImpacto.Rows.Add(fila);
                if (fila[0] == "925,000") dgvImpacto.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
            }
        }

        public void GenerarGraficoArana()
        {
            chartSensibilidad.Series.Clear();
            chartSensibilidad.ChartAreas.Clear();
            chartSensibilidad.Legends.Clear();

            var areaUtilidad = new ChartArea("AreaUtilidad");
            var areaIndice = new ChartArea("AreaIndice");

            areaUtilidad.Position = new ElementPosition(0, 15, 48, 80);
            areaIndice.Position = new ElementPosition(52, 15, 48, 80);

            chartSensibilidad.ChartAreas.Add(areaUtilidad);
            chartSensibilidad.ChartAreas.Add(areaIndice);

            var leg1 = new Legend("MainLegendLeft")
            {
                DockedToChartArea = "AreaUtilidad",
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                IsDockedInsideChartArea = false
            };

            var leg2 = new Legend("MainLegendRight")
            {
                DockedToChartArea = "AreaIndice",
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                IsDockedInsideChartArea = false
            };

            chartSensibilidad.Legends.Add(leg1);
            chartSensibilidad.Legends.Add(leg2);

            ConfigurarEjes(areaUtilidad, "Salario Mínimo", "Utilidad", 30000000, 40000000);
            ConfigurarEjes(areaIndice, "Salario Mínimo", "Índice %", 94, 106);

            chartSensibilidad.Series.Add(CrearSerie("Básica", Color.Black, "AreaUtilidad", false, "MainLegendLeft", 915000, 36793810, 925000, 35673810, 935000, 34553810));
            chartSensibilidad.Series.Add(CrearSerie("Calidad", Color.Red, "AreaUtilidad", true, "MainLegendLeft", 915000, 38631474, 925000, 37231474, 935000, 35831474));
            chartSensibilidad.Series.Add(CrearSerie("Francia", Color.Green, "AreaUtilidad", false, "MainLegendLeft", 915000, 34140048, 925000, 32460048, 935000, 30780048));

            chartSensibilidad.Series.Add(CrearSerie("Básica ", Color.Black, "AreaIndice", false, "MainLegendRight", 915000, 103.1, 925000, 100.0, 935000, 96.9));
            chartSensibilidad.Series.Add(CrearSerie("Calidad ", Color.Red, "AreaIndice", true, "MainLegendRight", 915000, 103.8, 925000, 100.0, 935000, 96.2));
            chartSensibilidad.Series.Add(CrearSerie("Francia ", Color.Green, "AreaIndice", false, "MainLegendRight", 915000, 105.2, 925000, 100.0, 935000, 94.8));
        }
        private void ConfigurarEjes(ChartArea area, string titX, string titY, double min, double max)
        {
            area.AxisX.Title = titX;
            area.AxisY.Title = titY;
            area.AxisY.Minimum = min;
            area.AxisY.Maximum = max;

            area.AxisX.Minimum = 915000;
            area.AxisX.Maximum = 935000;
            area.AxisX.IsMarginVisible = false;
            // --------------------------------------------------------------

            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.Format = "N0";

            area.AxisX.Interval = 10000;
        }

        private System.Windows.Forms.DataVisualization.Charting.Series CrearSerie(string nombre, Color color, string area, bool punteada, string legendName, params double[] pts)
        {
            var serie = new System.Windows.Forms.DataVisualization.Charting.Series(nombre);
            serie.ChartArea = area;
            serie.Legend = legendName; 
            serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            serie.BorderWidth = 3;
            serie.Color = color;

            if (punteada)
                serie.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

            for (int i = 0; i < pts.Length; i += 2)
            {
                serie.Points.AddXY(pts[i], pts[i + 1]);
            }

            return serie;
        }

        private void dgvImpacto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 4 && e.Value != null && e.RowIndex > 0)
            {
                if (double.TryParse(e.Value.ToString(), out double valor))
                {
                    if (valor > 100.1) e.CellStyle.ForeColor = Color.Green;
                    else if (valor < 99.9) e.CellStyle.ForeColor = Color.Red;

                    if (valor == 100.0) e.CellStyle.Font = new System.Drawing.Font(dgvImpacto.Font, FontStyle.Bold);
                }
            }
        }
        private void dgvImpacto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string textoSuperior = "ÍNDICE DE SENSIBILIDAD (%)";
            if (e.RowIndex == 0 && e.ColumnIndex >= 4 && e.ColumnIndex <= 6)
            {
                using (Brush gridBrush = new SolidBrush(this.dgvImpacto.GridColor), backBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        e.Graphics.FillRectangle(backBrush, e.CellBounds);

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                        if (e.ColumnIndex == 6) 
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                        if (e.ColumnIndex == 4)
                        {
                            System.Drawing.Rectangle rectSpan = new System.Drawing.Rectangle(e.CellBounds.X, e.CellBounds.Y,
                                dgvImpacto.Columns[4].Width + dgvImpacto.Columns[5].Width + dgvImpacto.Columns[6].Width,
                                e.CellBounds.Height);

                            TextRenderer.DrawText(e.Graphics, textoSuperior, new System.Drawing.Font(dgvImpacto.Font, FontStyle.Bold),
                                rectSpan, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                        }
                        e.Handled = true;
                    }
                }
            }
        }

        private void chartSensibilidad_Click(object sender, EventArgs e)
        {

        }
        public void ExportarAExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Impacto Salario");

                var rangoIndice = worksheet.Range(1, 5, 1, 7);
                rangoIndice.Merge().Value = "INDICE Valor referencia = 100";
                rangoIndice.Style.Font.Bold = true;
                rangoIndice.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right; 

                for (int i = 0; i < dgvImpacto.Columns.Count; i++)
                {
                    var celda = worksheet.Cell(2, i + 1);
                    celda.Value = dgvImpacto.Columns[i].HeaderText;
                    celda.Style.Font.Bold = true;
                    celda.Style.Fill.BackgroundColor = XLColor.LightGray;
                    celda.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                for (int r = 0; r < dgvImpacto.Rows.Count; r++)
                {
                    if (dgvImpacto.Rows[r].IsNewRow) continue;

                    for (int c = 0; c < dgvImpacto.Columns.Count; c++)
                    {
                        var celdaDatos = worksheet.Cell(r + 3, c + 1);
                        celdaDatos.Value = dgvImpacto.Rows[r].Cells[c].Value?.ToString();

                        if (dgvImpacto.Rows[r].Cells[0].Value?.ToString() == "925,000")
                        {
                            celdaDatos.Style.Fill.BackgroundColor = XLColor.FromHtml("#C8FFC8");
                        }
                    }
                }

                // Ajustar columnas automáticamente
                worksheet.Columns().AdjustToContents();

                using (MemoryStream ms = new MemoryStream())
                {
                    chartSensibilidad.SaveImage(ms, ChartImageFormat.Png);
                    var imagen = worksheet.AddPicture(ms)
                        .MoveTo(worksheet.Cell(dgvImpacto.Rows.Count + 5, 1));
                    imagen.Scale(0.8);
                }

                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("¡Excel exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void ExportarAPDF()
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                // 1. Título principal centrado
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var pTitulo = new Paragraph("Reporte de Impacto del Salario Mínimo en la Utilidad", fontTitulo);
                pTitulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(pTitulo);
                doc.Add(new Chunk("\n"));

                // 2. Título secundario de referencia a la derecha
                var fontRef = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var pRef = new Paragraph("INDICE Valor referencia = 100", fontRef);
                pRef.Alignment = Element.ALIGN_RIGHT; // <-- Esto lo pega a la derecha, sobre el Índice
                doc.Add(pRef);
                doc.Add(new Chunk("\n"));

                // 3. Tabla principal (dgvImpacto)
                PdfPTable table = new PdfPTable(dgvImpacto.Columns.Count);
                table.WidthPercentage = 100;

                // Añadir encabezados
                foreach (DataGridViewColumn col in dgvImpacto.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                // Añadir filas de datos
                foreach (DataGridViewRow row in dgvImpacto.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int c = 0; c < dgvImpacto.Columns.Count; c++)
                    {
                        table.AddCell(new Phrase(row.Cells[c].Value?.ToString() ?? ""));
                    }
                }

                doc.Add(table);
                doc.Add(new Chunk("\n"));

                using (MemoryStream ms = new MemoryStream())
                {
                    chartSensibilidad.SaveImage(ms, ChartImageFormat.Png);
                    iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                    chartImg.ScaleToFit(780f, 500f);
                    chartImg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    doc.Add(chartImg);
                }

                doc.Close();
                MessageBox.Show("¡PDF generado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
                ExportarAExcel();
            }
            }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            { ExportarAPDF(); }
        }

        private void frmImpactoSalarioMinimoUtilidad_Load(object sender, EventArgs e)
        {
            toolTip1.AutoPopDelay = 5000; 
            toolTip1.InitialDelay = 500;  
            toolTip1.ReshowDelay = 200;   
            toolTip1.ShowAlways = true;   

            toolTip1.SetToolTip(this.pictureBox1, "Exportar Excel");
            toolTip1.SetToolTip(this.pictureBox2, "Exportar PDF");
        }
    }
}