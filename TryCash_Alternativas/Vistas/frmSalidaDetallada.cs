using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TryCash_Alternativas.Vistas
{
    public partial class frmSalidaDetallada : Form
    {
        public frmSalidaDetallada()
        {
            InitializeComponent();
        }

        public void ConfigurarTablaSalida()
        {
            dgvSalida.Columns.Clear();
            dgvSalida.Rows.Clear();
            dgvSalida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalida.AllowUserToAddRows = false; 

            dgvSalida.Columns.Add("Concepto", "Descripción");
            dgvSalida.Columns.Add("Basica", "Básica");
            dgvSalida.Columns.Add("Calidad", "Mejor Calidad");
            dgvSalida.Columns.Add("Francia", "Exportar a Francia");

            dgvSalida.Columns[0].Width = 180;

            for (int i = 1; i <= 3; i++)
            {
                dgvSalida.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalida.Columns[i].DefaultCellStyle.Format = "N0";
            }
        }

        public void LlenarDatosFijos()
        {
            dgvSalida.Rows.Clear();

            string[][] datos = {
        new string[] { "Ventas", "345,498,600", "382,382,910", "392,422,275" },
        new string[] { "", "", "", "" },
        new string[] { "Arrendamiento", "15,000,000", "15,000,000", "15,000,000" },
        new string[] { "Mano de obra", "74,000,000", "92,500,000", "111,000,000" },
        new string[] { "Seguridad social", "13,320,000", "16,650,000", "19,980,000" },
        new string[] { "Liquidación", "16,280,000", "20,350,000", "24,420,000" },
        new string[] { "Equipos de trabajo", "80,000,000", "80,000,000", "80,000,000" },
        new string[] { "Gasto en fungicidas", "8,400,000", "10,500,000", "9,660,000" },
        new string[] { "Gasto en abono", "9,000,000", "11,250,000", "11,700,000" },
        new string[] { "Gasto en agua", "2,160,000", "2,700,000", "2,160,000" },
        new string[] { "Costo embalaje", "39,840,000", "38,844,000", "46,800,000" },
        new string[] { "Gasto comercialización", "51,824,790", "57,357,437", "39,242,228" },
        new string[] { "TOTAL GASTOS", "309,824,790", "345,151,437", "359,962,228" },
        new string[] { "", "", "", "" },
        new string[] { "UTILIDAD", "35,673,810", "37,231,474", "32,460,048" },
        new string[] { "RENTABILIDAD", "11.51%", "10.79%", "9.02%" }
    };

            foreach (string[] fila in datos)
            {
                int n = dgvSalida.Rows.Add(fila);

                string col0 = fila[0].ToUpper();
                if (col0 == "VENTAS" || col0 == "TOTAL GASTOS" || col0 == "UTILIDAD" || col0 == "RENTABILIDAD")
                {
                    dgvSalida.Rows[n].DefaultCellStyle.Font = new System.Drawing.Font(dgvSalida.Font, FontStyle.Bold);
                }
            }
        }

        private void dgvSalida_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == dgvSalida.Rows.Count - 1 && e.ColumnIndex > 0)
            {
                e.CellStyle.ForeColor = Color.White; 

                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    e.CellStyle.BackColor = Color.Green; 
                }
                else if (e.ColumnIndex == 3)
                {
                    e.CellStyle.BackColor = Color.Red; 
                }
            }
        }
        private void frmSalidaDetallada_Load(object sender, EventArgs e)
        {
            ConfigurarTablaSalida();
            LlenarDatosFijos();
            dgvSalida.Refresh();
        }
        public void CargarTabla()
        {
            ConfigurarTablaSalida();
            LlenarDatosFijos();
        }
        private void ExportarExcel()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Resultado_Alternativas_TryCash.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Resultados");

                        // Encabezados
                        for (int i = 1; i <= dgvSalida.Columns.Count; i++)
                        {
                            var cell = worksheet.Cell(1, i);
                            cell.Value = dgvSalida.Columns[i - 1].HeaderText;
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#F0F0F0");
                        }

                        // Datos
                        for (int i = 0; i < dgvSalida.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvSalida.Columns.Count; j++)
                            {
                                var cell = worksheet.Cell(i + 2, j + 1);
                                cell.Value = dgvSalida.Rows[i].Cells[j].Value?.ToString();

                                if (i == dgvSalida.Rows.Count - 1 && j > 0)
                                {
                                    cell.Style.Font.FontColor = XLColor.White;
                                    cell.Style.Font.Bold = true;
                                    if (j == 1 || j == 2) // Básica y Mejor Calidad
                                        cell.Style.Fill.BackgroundColor = XLColor.Green;
                                    else if (j == 3) // Exportar a Francia
                                        cell.Style.Fill.BackgroundColor = XLColor.Red;
                                }
                            }
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Excel generado con colores con éxito.");
                    }
                }
            }
        }
        private void ExportarPDF()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF Document|*.pdf", FileName = "Reporte_Alternativas_TryCash.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    doc.Add(new Paragraph("RESUMEN FINANCIERO DETALLADO", fontTitulo));
                    doc.Add(new Paragraph(" "));
                    PdfPTable pdfTable = new PdfPTable(dgvSalida.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Celdas de Encabezado
                    foreach (DataGridViewColumn col in dgvSalida.Columns)
                    {
                        pdfTable.AddCell(new PdfPCell(new Phrase(col.HeaderText)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    }

                    // Celdas de Datos
                    for (int i = 0; i < dgvSalida.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvSalida.Columns.Count; j++)
                        {
                            string texto = dgvSalida.Rows[i].Cells[j].Value?.ToString() ?? "";
                            PdfPCell pdfCell = new PdfPCell(new Phrase(texto));

                            if (i == dgvSalida.Rows.Count - 1 && j > 0)
                            {
                                pdfCell.Phrase.Font.Color = BaseColor.WHITE;
                                if (j == 1 || j == 2) pdfCell.BackgroundColor = BaseColor.GREEN;
                                else if (j == 3) pdfCell.BackgroundColor = BaseColor.RED;
                            }

                            pdfTable.AddCell(pdfCell);
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();
                    MessageBox.Show("PDF generado con colores con éxito.");
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

        private void frmSalidaDetallada_Load_1(object sender, EventArgs e)
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
