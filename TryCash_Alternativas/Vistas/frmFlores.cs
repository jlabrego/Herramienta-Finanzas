using DocumentFormat.OpenXml.VariantTypes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using TryCash_Alternativas.Datos;
using TryCash_Alternativas.Logica;
using TryCash_Alternativas.Modelos;
namespace TryCash_Alternativas.Vistas
{
    public partial class frmFlores : Form
    {
        public frmFlores()
        {
            InitializeComponent();
        }

        public void GenerarReportePDF(Alternativa alt, decimal utilidad, decimal gsp)
        {
            Document doc = new Document(PageSize.A4);
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Reporte_{alt.Nombre}.pdf");
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();
                var titulo = new Paragraph("SISTEMA TRY_CASH: EVALUACIÓN FINANCIERA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Resumen de Alternativa: {alt.Nombre}"));
                doc.Add(new Paragraph($"Fecha de Evaluación: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));

                // Tabla de Resultados

                PdfPTable table = new PdfPTable(2);

                table.WidthPercentage = 100;
                table.AddCell("Concepto");
                table.AddCell("Valor");
                table.AddCell("Utilidad Neta Proyectada:");
                table.AddCell(utilidad.ToString("C2"));
                table.AddCell("Grado de Sensibilidad (GSP Precio):");
                table.AddCell(gsp.ToString("N2"));
                table.AddCell("Rentabilidad Estimada:");

                decimal rentabilidad = 0;
                decimal dolarVal = decimal.Parse(txtDolar.Text);
                decimal tasaBase = alt.Nombre.ToLower().Contains("francia") ? 4130m : dolarVal; 
                decimal tasaConDev = tasaBase * (1 + alt.DevaluacionEsperada);
                decimal ramosTotales = alt.RamosProducidos * alt.AreaHectareas;
                decimal ingresos = ramosTotales * alt.PrecioVentaUnitario * tasaConDev;
                decimal gastosTotales = ingresos - utilidad;

                if (gastosTotales != 0)
                {
                    rentabilidad = (utilidad / gastosTotales) * 100;
                }

                table.AddCell("Rentabilidad Estimada:");
                table.AddCell(rentabilidad.ToString("N2") + "%");
                doc.Add(table);
                doc.Add(new Paragraph("\nCONCLUSIÓN TÉCNICA:"));

                string conclusion = gsp > 5
                    ? "Esta alternativa presenta un ALTO RIESGO ante variaciones de mercado."
                    : "Esta alternativa presenta estabilidad ante cambios de precio.";

                doc.Add(new Paragraph(conclusion));
                doc.Close();

                MessageBox.Show("¡PDF generado con éxito en tu Escritorio!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear PDF: " + ex.Message);
            }
        }
        private void ExportarAPDF_ConRuta(string nombreAlt, decimal utilidad, decimal gsp, string rutaDestino)
        {
            Document doc = new Document(PageSize.A4);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));
                doc.Open();
                var fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var fSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Paragraph titulo = new Paragraph("TRYCASH: REPORTE DE EVALUACIÓN FINANCIERA\n", fTitulo);

                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n", fNormal));

                // Información de la Alternativa
                doc.Add(new Paragraph($"Alternativa Evaluada: {nombreAlt}", fSub));
                doc.Add(new Paragraph("------------------------------------------------------------------------------------------\n"));
                
                // Tabla de Resultados
                PdfPTable tabla = new PdfPTable(2);

                tabla.WidthPercentage = 100;

                tabla.AddCell("Concepto Financiero");
                tabla.AddCell("Valor Resultante");
                tabla.AddCell("Utilidad Neta Proyectada");
                tabla.AddCell(utilidad.ToString("C2"));
                tabla.AddCell("Sensibilidad (GSP Precio)");
                tabla.AddCell(gsp.ToString("N2"));
                tabla.AddCell("Rentabilidad sobre Inversión");
                tabla.AddCell(((utilidad / 80000000m) * 100).ToString("N2") + "%");

                doc.Add(tabla);
                doc.Add(new Paragraph("\nANÁLISIS DE RESULTADOS:", fSub));
                string msg = gsp > 5
                    ? "ALTA SENSIBILIDAD: El proyecto es vulnerable a cambios en el precio o mercado."
                    : "ESTABILIDAD MODERADA: El proyecto tolera variaciones razonables en las variables.";
                doc.Add(new Paragraph(msg, fNormal));
                doc.Close();

                MessageBox.Show($"¡PDF '{Path.GetFileName(rutaDestino)}' creado en el escritorio!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                var calculadora = new CalculadoraFinanciera();
                var alt = new Alternativa();

                if (cmbAlternativa.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona una alternativa.");
                    return;
                }

                alt.Nombre = cmbAlternativa.SelectedItem.ToString();
                alt.RamosProducidos = int.Parse(txtRamos.Text);
                alt.PrecioVentaUnitario = decimal.Parse(txtPrecio.Text);
                alt.NumeroOperarios = int.Parse(txtOperarios.Text);
                alt.ComisionVentasPct = decimal.Parse(txtComision.Text);
                alt.CostoEmbalajeUnitario = decimal.Parse(txtEmbalaje.Text);
                alt.DevaluacionEsperada = decimal.Parse(txtDevaluacion.Text);

                decimal salario = decimal.Parse(txtSalarioMin.Text);
                decimal dolar = decimal.Parse(txtDolar.Text);
                decimal area = decimal.Parse(txtArea.Text);
                decimal meses = decimal.Parse(txtMeses.Text);
                decimal arriendoHec = decimal.Parse(txtArriendoHec.Text);

                decimal resultado = calculadora.CalcularUtilidad(
                    alt, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendoHec);

                lblUtilidad.Text = resultado.ToString("C2");

                decimal tasaBase = alt.Nombre.ToLower().Contains("francia") ? 4130m : dolar;
                decimal tasaConDev = tasaBase * (1 + alt.DevaluacionEsperada);
                decimal ramosTotales = alt.RamosProducidos * area;
                decimal ingresos = ramosTotales * alt.PrecioVentaUnitario * tasaConDev;
                decimal gastos = ingresos - resultado;

                decimal rentabilidad = 0;
                if (gastos != 0)
                {
                    rentabilidad = (resultado / gastos) * 100;
                }

                decimal rentBase = rentabilidad;

                decimal utilidadMas4 = calculadora.CalcularSensibilidad(
                    alt, 0.04m, salario, dolar, area, meses, arriendoHec);

                decimal utilidadMenos4 = calculadora.CalcularSensibilidad(
                    alt, -0.04m, salario, dolar, area, meses, arriendoHec);

                lblUtilidadMas.Text = "Si precio sube 4%: " + utilidadMas4.ToString("C2");
                lblUtilidadMenos.Text = "Si precio baja 4%: " + utilidadMenos4.ToString("C2");

                decimal gspPrecio = 0;
                if (resultado != 0)
                {
                    gspPrecio = Math.Abs(((utilidadMas4 - resultado) / resultado) / 0.04m);
                    lblGSP.Text = gspPrecio.ToString("N2");
                }

                decimal ingresosMas = ramosTotales * (alt.PrecioVentaUnitario * 1.04m) * tasaConDev;
                decimal gastosMas = ingresosMas - utilidadMas4;

                decimal rentMas4 = (gastosMas != 0) ? (utilidadMas4 / gastosMas) * 100 : 0;

                decimal gspRentabilidad = 0;
                if (rentBase != 0)
                {
                    gspRentabilidad = Math.Abs(((rentMas4 - rentBase) / rentBase) / 0.04m);
                }
                lblGSPRent.Text = gspRentabilidad.ToString("N2");

                decimal utilidadRamos = calculadora.CalcularSensibilidadRamos(
                    alt, 0.04m, salario, dolar, area, meses, arriendoHec);

                int nuevosRamos = (int)(alt.RamosProducidos * 1.04m);

                decimal utilidadMas = calculadora.CalcularSensibilidadRamos(alt, 0.04m, salario, dolar, area, meses, arriendoHec);
                decimal utilidadMenos = calculadora.CalcularSensibilidadRamos(alt, -0.04m, salario, dolar, area, meses, arriendoHec);

                decimal gspRamos = 0;

                if (resultado != 0)
                {
                    gspRamos = Math.Abs(((utilidadMas - utilidadMenos) / resultado) / 0.08m);
                }

                if (alt.Nombre.ToLower().Contains("francia"))
                {
                    gspRamos = gspPrecio;
                }

                lblGSPRamos.Text = gspRamos.ToString("N2");

                decimal utilSalario = calculadora.CalcularSensibilidadSalario(
                    alt, 0.04m, salario, dolar, area, meses, arriendoHec);

                decimal gspSalario = 0;
                if (resultado != 0)
                {
                    gspSalario = Math.Abs(((utilSalario - resultado) / resultado) / 0.04m);
                }

                string conclusion = "";

                if (rentabilidad >= 10)
                    conclusion += "La alternativa es viable.\n";
                else
                    conclusion += "La alternativa NO es viable.\n";

                if (gspPrecio > gspSalario)
                    conclusion += "El precio es la variable más sensible.\n";
                else
                    conclusion += "El salario es la variable más sensible.\n";

                lblConclusion.Text = conclusion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el cálculo: " + ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var calculadora = new CalculadoraFinanciera();
    Alternativa escenarioActual = new Alternativa
    {
        Nombre = cmbAlternativa.SelectedItem.ToString(),
        RamosProducidos = int.Parse(txtRamos.Text),
        PrecioVentaUnitario = decimal.Parse(txtPrecio.Text),
        NumeroOperarios = int.Parse(txtOperarios.Text),
        ComisionVentasPct = decimal.Parse(txtComision.Text),
        CostoEmbalajeUnitario = decimal.Parse(txtEmbalaje.Text),
        DevaluacionEsperada = decimal.Parse(txtDevaluacion.Text),
        InversionEquipos = decimal.Parse(txtInversion.Text),
        ArrendamientoMensual = decimal.Parse(txtArriendoHec.Text),
        DuracionMeses = int.Parse(txtMeses.Text),
        AreaHectareas = int.Parse(txtArea.Text)
    };

                decimal salario = decimal.Parse(txtSalarioMin.Text);
                decimal dolar = decimal.Parse(txtDolar.Text);

                decimal utilidadBase = calculadora.CalcularUtilidad(
                    escenarioActual, salario, 0.18m, 0.22m, dolar, 4130m,
                    escenarioActual.AreaHectareas,
                    escenarioActual.DuracionMeses,
                    escenarioActual.ArrendamientoMensual);

                escenarioActual.UtilidadNeta = utilidadBase;

                decimal tasaBase = escenarioActual.Nombre.ToLower().Contains("francia") ? 4130m : dolar;
                decimal tasaConDev = tasaBase * (1 + escenarioActual.DevaluacionEsperada);

                decimal ingresosBase = escenarioActual.RamosProducidos *
                                       escenarioActual.AreaHectareas *
                                       escenarioActual.PrecioVentaUnitario * tasaConDev;

                decimal gastosBase = ingresosBase - utilidadBase;
                decimal rentBase = (gastosBase != 0) ? (utilidadBase / gastosBase) * 100 : 0;

                escenarioActual.RentabilidadPct = rentBase;

                decimal utilPrecioMas = calculadora.CalcularSensibilidad(
                    escenarioActual, 0.04m, salario, dolar,
                    escenarioActual.AreaHectareas,
                    escenarioActual.DuracionMeses,
                    escenarioActual.ArrendamientoMensual);

                escenarioActual.GspPrecio = (utilidadBase != 0)
                    ? Math.Abs(((utilPrecioMas - utilidadBase) / utilidadBase) / 0.04m)
                    : 0;

                decimal utilMas = calculadora.CalcularSensibilidadRamos(
                    escenarioActual, 0.04m, salario, dolar,
                    escenarioActual.AreaHectareas,
                    escenarioActual.DuracionMeses,
                    escenarioActual.ArrendamientoMensual);

                decimal utilMenos = calculadora.CalcularSensibilidadRamos(
                    escenarioActual, -0.04m, salario, dolar,
                    escenarioActual.AreaHectareas,
                    escenarioActual.DuracionMeses,
                    escenarioActual.ArrendamientoMensual);

                decimal gspRamos = (utilidadBase != 0)
                    ? Math.Abs(((utilMas - utilMenos) / utilidadBase) / 0.08m)
                    : 0;

                if (escenarioActual.Nombre.ToLower().Contains("francia"))
                {
                    gspRamos = escenarioActual.GspPrecio;
                }

                escenarioActual.GspRamos = gspRamos;

                decimal utilSalario = calculadora.CalcularSensibilidadSalario(
                    escenarioActual, 0.04m, salario, dolar,
                    escenarioActual.AreaHectareas,
                    escenarioActual.DuracionMeses,
                    escenarioActual.ArrendamientoMensual);

                escenarioActual.GspSalario = (utilidadBase != 0)
                    ? Math.Abs(((utilSalario - utilidadBase) / utilidadBase) / 0.04m)
                    : 0;

                MetodosDatos db = new MetodosDatos();
                db.GuardarEscenario(escenarioActual);

                MessageBox.Show("Escenario guardado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
}

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRamos.Clear();
            txtPrecio.Clear();
            txtOperarios.Clear();
            txtComision.Clear();
            txtDevaluacion.Clear();
            txtEmbalaje.Clear();
            cmbAlternativa.Text = "";
            lblUtilidad.Text = "0.00";
            lblUtilidadMas.Text = "Si precio sube 4%: 0.00";
            lblUtilidadMenos.Text = "Si precio baja 4%: 0.00";
            lblGSP.Text = "GSP Precio: 0.00";
            lblGSPRamos.Text = "0.00";
            lblGSPRent.Text = "0.00";
            lblConclusion.Text = ".";
            txtRamos.Focus();
        }
        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            frmHistorial ventana = new frmHistorial();
            ventana.ShowDialog();
        }
        private void btnPDF_Click_1(object sender, EventArgs e)

        {
            // 1. Creamos el cuadro de dialogo para guardar
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo PDF|*.pdf";
            guardar.Title = "Guardar Reporte de Evaluación";
            guardar.FileName = $"Reporte_{cmbAlternativa.SelectedItem.ToString()}";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                string nombre = cmbAlternativa.SelectedItem.ToString(); ;
                decimal utilidad = decimal.Parse(lblUtilidad.Text, System.Globalization.NumberStyles.Currency);
                string gspTexto = lblGSP.Text.Replace("GSP Precio: ", "");
                decimal gsp = decimal.Parse(gspTexto);

                // 2. Llamamos al método pasándole la ruta que eligió el usuario
                ExportarAPDF_ConRuta(nombre, utilidad, gsp, guardar.FileName);

            }

        }

        private void frmFlores_Load(object sender, EventArgs e)
        {

        }

        private void btnVerResumen_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el formulario que diseñamos con el DataGridView gris
            frmResumenSensibilidad pantallaGSP = new frmResumenSensibilidad();

            // 2. Lo abrimos para que bloquee la ventana de atrás hasta que se cierre
            pantallaGSP.ShowDialog();
        }
    }

}