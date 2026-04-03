using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TryCash_Alternativas.Datos; 

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
            CargarDatosResumen();
        }

        private void ConfigurarColumnasDataGrid()
        {
            dgvResumen.Columns.Clear();
            dgvResumen.Rows.Clear();
            dgvResumen.EnableHeadersVisualStyles = false; // Permite cambiar colores de encabezados

            // Configurar encabezados generales
            dgvResumen.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvResumen.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvResumen.ColumnHeadersDefaultCellStyle.Font = new Font(dgvResumen.Font, FontStyle.Bold);

            // Columna Concepto
            dgvResumen.Columns.Add("Concepto", "Concepto");
            dgvResumen.Columns["Concepto"].Width = 150;

            // Agregar columnas de alternativas desde la DB
            MetodosDatos db = new MetodosDatos();
            DataTable dtNombres = db.ObtenerNombresEscenarios();

            foreach (DataRow row in dtNombres.Rows)
            {
                string nombre = row["Nombre"].ToString();
                int colIndex = dgvResumen.Columns.Add(nombre, nombre);
                dgvResumen.Columns[colIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void CargarDatosResumen()
        {
            MetodosDatos db = new MetodosDatos();
            DataTable dtDatos = db.ObtenerTodosLosEscenarios();

            string[] conceptos = { "Ramos producidos", "Precio de venta", "Devaluacion", "Costo embalaje" };

            foreach (string concepto in conceptos)
            {
                int rowIndex = dgvResumen.Rows.Add();
                dgvResumen.Rows[rowIndex].Cells[0].Value = concepto;

                foreach (DataRow dr in dtDatos.Rows)
                {
                    string nombreEscenario = dr["Nombre"].ToString();

                    if (dgvResumen.Columns.Contains(nombreEscenario))
                    {
                        decimal valor = 0;

                        switch (concepto)
                        {
                            case "Ramos producidos": valor = Convert.ToDecimal(dr["GspRamos"]); break;
                            case "Precio de venta": valor = Convert.ToDecimal(dr["GspPrecio"]); break;
                            case "Devaluacion": valor = Convert.ToDecimal(dr["GspDevaluacion"]); break;
                            case "Costo embalaje": valor = Convert.ToDecimal(dr["GspEmbalaje"]); break;
                        }
                        dgvResumen.Rows[rowIndex].Cells[nombreEscenario].Value = valor.ToString("N2");

                        if (valor < 0)
                        {
                            dgvResumen.Rows[rowIndex].Cells[nombreEscenario].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgvResumen.Rows[rowIndex].Cells[nombreEscenario].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void frmResumenSensibilidad_Load_1(object sender, EventArgs e)
        {
            ConfigurarColumnasDataGrid();
            CargarDatosResumen();
        }

        private void dgvResumen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Pintar la columna de Concepto (Columna 0) en Azul Claro
            if (e.ColumnIndex == 0)
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font(dgvResumen.Font, FontStyle.Bold);
            }

            if (e.ColumnIndex > 0 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    if (valor < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}