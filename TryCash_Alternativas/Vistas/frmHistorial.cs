using ClosedXML.Excel;
using System;
using System.Data;
using System.Windows.Forms;
using TryCash_Alternativas.Datos;

namespace TryCash_Alternativas.Vistas
{
    public partial class frmHistorial : Form
    {
        MetodosDatos db = new MetodosDatos();

        public frmHistorial()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvHistorial.DataSource = db.ConsultarHistorial();
                if (dgvHistorial.Columns.Contains("Utilidad Neta"))
                    dgvHistorial.Columns["Utilidad Neta"].DefaultCellStyle.Format = "C2";

                if (dgvHistorial.Columns.Contains("% Rentabilidad"))
                    dgvHistorial.Columns["% Rentabilidad"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        private void btnExportar_Click_1(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Workbook|*.xlsx";
            saveDialog.FileName = "Historial_Evaluaciones_TryCash_" + DateTime.Now.ToString("yyyyMMdd");

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        DataTable dt = (DataTable)dgvHistorial.DataSource;
                        var worksheet = workbook.Worksheets.Add(dt, "Escenarios");
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveDialog.FileName);
                    }
                    MessageBox.Show("Reporte Excel generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el archivo Excel: " + ex.Message);
                }
            }
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count < 2)
            {
                MessageBox.Show("Por favor, selecciona al menos 2 escenarios.");
                return;
            }

            string comparativa = "=== DIAGNÓSTICO COMPARATIVO TRYCASH ===\n\n";

            decimal mejorRentabilidad = 0;
            string mejorNombre = "";

            foreach (DataGridViewRow row in dgvHistorial.SelectedRows)
            {
                string nombre = row.Cells["Escenario"].Value?.ToString() ?? "Sin nombre";
                decimal utilidad = Convert.ToDecimal(row.Cells["Utilidad Neta"].Value);
                decimal rentabilidad = Convert.ToDecimal(row.Cells["% Rentabilidad"].Value);
                decimal gspPrecio = Convert.ToDecimal(row.Cells["GSP Precio"].Value);

                comparativa += $"Alternativa: {nombre}\n";
                comparativa += $"Utilidad: {utilidad:C2}\n";
                comparativa += $"Rentabilidad: {rentabilidad:N2}%\n";
                comparativa += $"GSP Precio: {gspPrecio:N2}\n";

                if (rentabilidad >= 10)
                    comparativa += "- Cumple con la rentabilidad mínima\n";
                else
                    comparativa += "- No cumple con la rentabilidad mínima\n";

                comparativa += "--------------------------------------\n";
                if (rentabilidad > mejorRentabilidad)
                {
                    mejorRentabilidad = rentabilidad;
                    mejorNombre = nombre;
                }
            }
            comparativa += "\n=== CONCLUSIÓN ===\n";
            comparativa += $"La mejor alternativa es: {mejorNombre} ({mejorRentabilidad:N2}%)\n";

            MessageBox.Show(comparativa, "Comparación de Escenarios");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}