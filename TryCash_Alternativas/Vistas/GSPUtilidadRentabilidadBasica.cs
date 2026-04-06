using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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

namespace TryCash_Alternativas.Vistas
{
    public partial class GSPUtilidadRentabilidadBasica : Form
    {
        public GSPUtilidadRentabilidadBasica()
        {
            InitializeComponent();
            ConfigurarColumnas();
            LlenarDatosSensibilidadPuntual();
            AplicarFormatoEstiloExcel();
        }

        private void ConfigurarColumnas()
        {
            if (dgvSensibilidad.Columns.Count == 0)
            {
                dgvSensibilidad.Columns.Add("Col1", "Variable / Alternativa");
                dgvSensibilidad.Columns.Add("Col2", "Base (%)");
                dgvSensibilidad.Columns.Add("Col3", "-1");
                dgvSensibilidad.Columns.Add("Col4", "0");
                dgvSensibilidad.Columns.Add("Col5", "+1");
                dgvSensibilidad.Columns.Add("Col6", "Var. % Resultado");
                dgvSensibilidad.Columns.Add("Col7", "Grado Sensibilidad");

                dgvSensibilidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void LlenarDatosSensibilidadPuntual()
        {
            if (dgvSensibilidad.Columns.Count == 0) return; 
            dgvSensibilidad.Rows.Clear();
            // Ramos Producidos
            dgvSensibilidad.Rows.Add("Ramos producidos", "", "768", "800", "832", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "35,673,810", "25,520,458", "35,673,810", "45,827,162", "28.5%", "7.12");
            dgvSensibilidad.Rows.Add("Rentabilidad", "11.51%", "8.34%", "11.51%", "14.62%", "27.0%", "6.74");
            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");

            // Precio de Venta
            dgvSensibilidad.Rows.Add("Precio de venta", "", "17.76", "18.50", "19.24", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "35,673,810", "23,926,858", "35,673,810", "47,420,762", "32.9%", "8.23");
            dgvSensibilidad.Rows.Add("Rentabilidad", "11.51%", "7.77%", "11.51%", "15.20%", "32.0%", "8.01");
            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");

            // Devaluación
            dgvSensibilidad.Rows.Add("Devaluación", "", "-1.44%", "-1.50%", "-1.56%", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "35,673,810", "35,852,698", "35,673,810", "35,494,922", "-0.5%", "-0.13");
            dgvSensibilidad.Rows.Add("Rentabilidad", "11.51%", "11.57%", "11.51%", "11.46%", "-0.5%", "-0.12");
            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");

            // Costo Embalaje
            dgvSensibilidad.Rows.Add("Costo embalaje", "", "7,968", "8,300", "8,632", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "35,673,810", "37,267,410", "35,673,810", "34,080,210", "-4.5%", "-1.12");
            dgvSensibilidad.Rows.Add("Rentabilidad", "11.51%", "12.09%", "11.51%", "10.94%", "-5.0%", "-1.24");
        }

        public void ExportarAPDF(DataGridView dgv)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 30, 30, 30, 30);
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = "Sensibilidad_Basica_TryCash.pdf" };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    BaseColor pdfVerdeClaro = new BaseColor(198, 239, 206);
                    BaseColor pdfVerdeFuerte = new BaseColor(0, 176, 80);
                    BaseColor pdfRosaVariaciones = new BaseColor(252, 228, 236);
                    BaseColor pdfAmarillo = BaseColor.YELLOW;

                    iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    Paragraph titulo = new Paragraph("SENSIBILIDAD PUNTUAL DE UTILIDAD Y RENTABILIDAD - BÁSICA", fontTitulo);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);
                    doc.Add(new Chunk("\n"));
                    PdfPTable tabla = new PdfPTable(dgv.Columns.Count) { WidthPercentage = 100 };

                    float[] anchos = { 2f, 1f, 1f, 1f, 1f, 1.2f, 1.2f };
                    tabla.SetWidths(anchos);

                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        var column = dgv.Columns[i];

                        iTextSharp.text.Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK);
                        PdfPCell cellHeader = new PdfPCell(new Phrase(column.HeaderText, fontHeader));

                        if (i >= 2 && i <= 4)
                        {
                            cellHeader.BackgroundColor = new BaseColor(252, 228, 236);
                        }
                        else
                        {
                            cellHeader.BackgroundColor = BaseColor.WHITE;
                        }

                        cellHeader.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellHeader.Padding = 5;

                        tabla.AddCell(cellHeader);
                    }

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string concepto = row.Cells[0].Value?.ToString() ?? "";
                        bool esTitulo = new[] { "Ramos producidos", "Precio de venta", "Devaluación", "Costo embalaje" }.Contains(concepto);

                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            string cellValue = row.Cells[j].Value?.ToString() ?? "";

                            iTextSharp.text.Font fontCelda = FontFactory.GetFont(FontFactory.HELVETICA, 8,
                                esTitulo ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                            PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, fontCelda));
                            pdfCell.Padding = 5;
                            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                            if (j >= 1 && j <= 4)
                            {
                                pdfCell.BackgroundColor = new BaseColor(0, 176, 80);
                                fontCelda.Color = BaseColor.BLACK;
                            }
                            if (esTitulo && j >= 2 && j <= 4)
                            {
                                fontCelda.Color = BaseColor.BLACK;
                                fontCelda.SetStyle(iTextSharp.text.Font.BOLD);
                            }
                            else if (j == 6 && double.TryParse(cellValue, out double v))
                            {
                                if (v <= -1)
                                {
                                    pdfCell.BackgroundColor = BaseColor.YELLOW;
                                    fontCelda.Color = BaseColor.RED;
                                    fontCelda.SetStyle(iTextSharp.text.Font.BOLD);
                                    pdfCell.Phrase = new Phrase(cellValue, fontCelda);
                                }
                                else if (v < 0)
                                {
                                    pdfCell.BackgroundColor = BaseColor.WHITE;
                                    fontCelda.Color = BaseColor.BLACK;
                                    pdfCell.Phrase = new Phrase(cellValue, fontCelda);
                                }
                                else if (v > 0)
                                {
                                    pdfCell.BackgroundColor = new BaseColor(0, 176, 80);
                                    fontCelda.Color = BaseColor.WHITE;
                                    fontCelda.SetStyle(iTextSharp.text.Font.BOLD);
                                    pdfCell.Phrase = new Phrase(cellValue, fontCelda);
                                }
                            }

                            tabla.AddCell(pdfCell);
                        }
                    }

                    doc.Add(tabla);
                    doc.Close();
                    MessageBox.Show("Reporte PDF generado con éxito.", "TryCash - Exportar");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message, "Error");
                }
            }
        }

        public void ExportarExcel(DataGridView dgv)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Sensibilidad_Puntual_Basica_TryCash.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Sensibilidad Puntual");

                            var colorVerdeClaro = XLColor.FromHtml("#C6EFCE");
                            var colorRosa = XLColor.FromHtml("#FCE4EC");
                            var colorVerdeFuerte = XLColor.FromHtml("#00B050");

                            for (int i = 1; i <= dgv.Columns.Count; i++)
                            {
                                var cell = ws.Cell(1, i);
                                cell.Value = dgv.Columns[i - 1].HeaderText;
                                cell.Style.Font.Bold = true;
                                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                if (i >= 3 && i <= 5)
                                {
                                    cell.Style.Fill.BackgroundColor = colorRosa;
                                }
                            }

                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                if (dgv.Rows[i].IsNewRow) continue;

                                string concepto = dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                                bool esTitulo = new[] { "Ramos producidos", "Precio de venta", "Devaluación", "Costo embalaje" }.Contains(concepto);

                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    var cell = ws.Cell(i + 2, j + 1);
                                    cell.Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                                    if (esTitulo)
                                    {
                                        cell.Style.Font.Bold = true;
                                        cell.Style.Fill.BackgroundColor = colorVerdeClaro;
                                    }
                                    else if (j == 6) // Columna Grado Sensibilidad
                                    {
                                        if (double.TryParse(cell.Value.ToString(), out double val))
                                        {
                                            if (val <= -1)
                                            {
                                                cell.Style.Fill.BackgroundColor = XLColor.Yellow;
                                                cell.Style.Font.FontColor = XLColor.Red;
                                                cell.Style.Font.Bold = true;
                                            }
                                            else if (val > 0)
                                            {
                                                cell.Style.Fill.BackgroundColor = colorVerdeFuerte;
                                                cell.Style.Font.FontColor = XLColor.White;
                                                cell.Style.Font.Bold = true;
                                            }
                                        }
                                    }
                                }
                            }
                            ws.Columns().AdjustToContents();
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Excel generado con éxito", "TryCash");
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) => ExportarExcel(dgvSensibilidad);
        private void pictureBox2_Click(object sender, EventArgs e) => ExportarAPDF(dgvSensibilidad);

        private void GSPUtilidadRentabilidadBasica_Load(object sender, EventArgs e)
        {
            AplicarFormatoEstiloExcel();
            toolTip1.AutoPopDelay = 5000; 
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;   
            toolTip1.ShowAlways = true;   

            toolTip1.SetToolTip(this.pictureBox1, "Exportar Excel");
            toolTip1.SetToolTip(this.pictureBox2, "Exportar PDF");
        }
        private void AplicarFormatoEstiloExcel()
        {
            System.Drawing.Color verdeClaro = ColorTranslator.FromHtml("#C6EFCE");
            System.Drawing.Color verdeFuerte = ColorTranslator.FromHtml("#00B050");
            System.Drawing.Color rosadoHeader = ColorTranslator.FromHtml("#F4CCCC");
            System.Drawing.Color amarillo = System.Drawing.Color.Yellow;
            System.Drawing.Color rojo = System.Drawing.Color.Red;

            dgvSensibilidad.EnableHeadersVisualStyles = false;

            dgvSensibilidad.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSensibilidad.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSensibilidad.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dgvSensibilidad.ColumnHeadersHeight = 35;

            dgvSensibilidad.Columns[2].HeaderCell.Style.BackColor = rosadoHeader;
            dgvSensibilidad.Columns[3].HeaderCell.Style.BackColor = rosadoHeader;
            dgvSensibilidad.Columns[4].HeaderCell.Style.BackColor = rosadoHeader;

            dgvSensibilidad.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvSensibilidad.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvSensibilidad.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvSensibilidad.GridColor = System.Drawing.Color.Black;

            foreach (DataGridViewRow row in dgvSensibilidad.Rows)
            {
                if (row.IsNewRow) continue;

                string concepto = row.Cells[0].Value?.ToString() ?? "";

                bool esTitulo = new[]
                {
            "Ramos producidos",
            "Precio de venta",
            "Devaluación",
            "Costo embalaje"
        }.Contains(concepto);

                row.Cells[0].Style.BackColor = System.Drawing.Color.White; 

                for (int i = 1; i <= 4; i++)
                {
                    row.Cells[i].Style.BackColor = verdeClaro;
                }

                row.Cells[5].Style.BackColor = System.Drawing.Color.White;
                row.Cells[6].Style.BackColor =   System.Drawing.Color.White;

                if (esTitulo)
                {
                    row.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }

                DataGridViewCell celda = row.Cells[6];

                if (celda.Value != null && double.TryParse(celda.Value.ToString(), out double valor))
                {
                    if (valor <= -1)
                    {
                        celda.Style.BackColor = amarillo;
                        celda.Style.ForeColor = rojo;
                        celda.Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else if (valor < 0)
                    {
                        // negativos leves → sin color
                        celda.Style.BackColor = System.Drawing.Color.White;
                        celda.Style.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (valor > 0)
                    {
                        celda.Style.BackColor = verdeFuerte;
                        celda.Style.ForeColor = System.Drawing.Color.White;
                        celda.Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    }
                }
            }
            dgvSensibilidad.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            for (int i = 1; i < dgvSensibilidad.Columns.Count; i++)
            {
                dgvSensibilidad.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvSensibilidad.CurrentCell = null;
            dgvSensibilidad.ClearSelection();
            dgvSensibilidad.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvSensibilidad.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
    }
}