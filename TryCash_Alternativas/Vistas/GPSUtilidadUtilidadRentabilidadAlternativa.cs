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

namespace TryCash_Alternativas.Vistas
{
    public partial class GSPUtilidadRentabilidadMejorAlternativa : Form
    {
        public GSPUtilidadRentabilidadMejorAlternativa()
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

            // Ramos Producidos - Alternativa Mejor Calidad
            dgvSensibilidad.Rows.Add("Ramos producidos", "", "749", "780", "811", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "37,231,474", "25,784,215", "37,231,474", "48,678,732", "30.7%", "7.69");
            dgvSensibilidad.Rows.Add("Rentabilidad", "10.79%", "7.55%", "10.79%", "13.95%", "29.3%", "7.33");
            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");

            // Precio de Venta - Alternativa Mejor Calidad
            dgvSensibilidad.Rows.Add("Precio de venta", "", "20.16", "21.00", "21.84", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "37,231,474", "24,230,455", "37,231,474", "50,232,492", "34.9%", "8.73");
            dgvSensibilidad.Rows.Add("Rentabilidad", "10.79%", "7.07%", "10.79%", "14.46%", "34.0%", "8.51");
            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");

            // Devaluación - Alternativa Mejor Calidad
            dgvSensibilidad.Rows.Add("Devaluación", "", "-1.44%", "-1.50%", "-1.56%", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "37,231,474", "37,429,459", "37,231,474", "37,033,488", "-0.5%", "-0.13");
            dgvSensibilidad.Rows.Add("Rentabilidad", "10.79%", "10.84%", "10.79%", "10.73%", "-0.5%", "-0.13");
            dgvSensibilidad.Rows.Add("", "", "", "", "", "", "");

            // Costo Embalaje - Alternativa Mejor Calidad
            dgvSensibilidad.Rows.Add("Costo embalaje", "", "7,968", "8,300", "8,632", "", "");
            dgvSensibilidad.Rows.Add("Utilidad", "37,231,474", "38,785,234", "37,231,474", "35,677,714", "-4.2%", "-1.04");
            dgvSensibilidad.Rows.Add("Rentabilidad", "10.79%", "11.29%", "10.79%", "10.29%", "-4.6%", "-1.15");
        }
        public void ExportarAPDF(DataGridView dgv)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 30, 30, 30, 30);
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = "Sensibilidad_Puntual_MejorCalidad_TryCash.pdf" };

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
                    Paragraph titulo = new Paragraph("SENSIBILIDAD PUNTUAL DE UTILIDAD Y RENTABILIDAD - MEJOR CALIDAD", fontTitulo);
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
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Sensibilidad_Puntual_MejorCalidad_TryCash.xlsx" })
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
                                    else if (j == 6) 
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
        private void AplicarFormatoEstiloExcel()
        {
            System.Drawing.Color verdeClaro = ColorTranslator.FromHtml("#C6EFCE");
            System.Drawing.Color verdeFuerte = ColorTranslator.FromHtml("#00B050");
            System.Drawing.Color rosadoHeader = ColorTranslator.FromHtml("#F4CCCC");
            System.Drawing.Color amarillo = System.Drawing.Color.Yellow;
            System.Drawing.Color rojo = System.Drawing.Color.Red;

            dgvSensibilidad.EnableHeadersVisualStyles = false;
            dgvSensibilidad.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSensibilidad.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

            dgvSensibilidad.Columns[2].HeaderCell.Style.BackColor = rosadoHeader;
            dgvSensibilidad.Columns[3].HeaderCell.Style.BackColor = rosadoHeader;
            dgvSensibilidad.Columns[4].HeaderCell.Style.BackColor = rosadoHeader;

            foreach (DataGridViewRow row in dgvSensibilidad.Rows)
            {
                if (row.IsNewRow) continue;

                string concepto = row.Cells[0].Value?.ToString() ?? "";
                bool esTitulo = new[] { "Ramos producidos", "Precio de venta", "Devaluación", "Costo embalaje" }.Contains(concepto);

                for (int i = 1; i <= 4; i++) row.Cells[i].Style.BackColor = verdeClaro;

                if (esTitulo)
                {
                    row.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }

                DataGridViewCell celdaSensibilidad = row.Cells[6];
                if (celdaSensibilidad.Value != null && double.TryParse(celdaSensibilidad.Value.ToString(), out double valor))
                {
                    if (valor <= -1)
                    {
                        celdaSensibilidad.Style.BackColor = amarillo;
                        celdaSensibilidad.Style.ForeColor = rojo;
                        celdaSensibilidad.Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else if (valor > 0)
                    {
                        celdaSensibilidad.Style.BackColor = verdeFuerte;
                        celdaSensibilidad.Style.ForeColor = System.Drawing.Color.White;
                        celdaSensibilidad.Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else
                    {
                        celdaSensibilidad.Style.BackColor = System.Drawing.Color.White;
                        celdaSensibilidad.Style.ForeColor = System.Drawing.Color.Black;
                        celdaSensibilidad.Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    }
                }
            }
            dgvSensibilidad.ClearSelection();
        }

        private void pictureBox1_Click(object sender, EventArgs e) => ExportarExcel(dgvSensibilidad);
        private void pictureBox2_Click(object sender, EventArgs e) => ExportarAPDF(dgvSensibilidad);

        private void GSPUtilidadRentabilidadMejorAlternativa_Load(object sender, EventArgs e)
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
