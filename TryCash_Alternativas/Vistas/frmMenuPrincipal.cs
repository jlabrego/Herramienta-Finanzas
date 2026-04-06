using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryCash_Alternativas.Vistas
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
            this.Load += (s, e) => {
                AbrirFormularioEnPanel(new frminicio());
            };
        }
        bool isMenuExpanded = false;
        const int AlturaMaxima = 350; 
        const int AlturaMinima = 50;  
        private void tmrMenu_Tick(object sender, EventArgs e)
        {
            if (isMenuExpanded)
            {
                pnlSubMenuReportes.Height -= 15;
                if (pnlSubMenuReportes.Height <= AlturaMinima)
                {
                    pnlSubMenuReportes.Height = AlturaMinima;
                    tmrMenu.Stop();
                    isMenuExpanded = false;
                }
            }
            else
            {
                pnlSubMenuReportes.Height += 15;
                if (pnlSubMenuReportes.Height >= AlturaMaxima)
                {
                    pnlSubMenuReportes.Height = AlturaMaxima;
                    tmrMenu.Stop();
                    isMenuExpanded = true;
                }
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            tmrMenu.Start();
        }
        private void AbrirFormularioEnPanel(object formHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);

            Form fh = formHijo as Form;
            fh.TopLevel = false; 
            fh.FormBorderStyle = FormBorderStyle.None; 
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmSalidaDetallada hijo = new frmSalidaDetallada();

            AbrirFormularioEnPanel(hijo);
            hijo.CargarTabla();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmFlores()); 
    }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmResumenSensibilidad());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmImpactoSalarioMinimoUtilidad hijo = new frmImpactoSalarioMinimoUtilidad();

            AbrirFormularioEnPanel(hijo);
            hijo.GenerarGraficoArana();
            hijo.LlenarDatosImpacto();
            hijo.GenerarGraficoArana();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
    frmImpactoNumeroRamosProducidosRentabilidad hijo = new frmImpactoNumeroRamosProducidosRentabilidad();

            AbrirFormularioEnPanel(hijo);
            hijo.ConfigurarTablaBasica();
            hijo.ConfigurarTablaCalidad();
            hijo.ConfigurarTablaFrancia();
            hijo.GraficarBasica();
            hijo.GraficarCalidad();
            hijo.GraficarFrancia();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmAnalisisGSP());
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new GSPUtilidadRentabilidadBasica());
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new GSPUtilidadRentabilidadMejorAlternativa());
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new GSPUtilidadRentabilidadFrancia());
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void AlternarMenuReportes()
        {
            pnlSubMenuReportes.Visible = !pnlSubMenuReportes.Visible;

        }
        private void lblReportes_Click(object sender, EventArgs e) => AlternarMenuReportes();
        private void picIconoReportes_Click(object sender, EventArgs e) => AlternarMenuReportes();
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frminicio());
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {
            AbrirFormularioEnPanel(new frminicio());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmFlores());
        }

        private void label3_Click(object sender, EventArgs e)
        {

            frmSalidaDetallada hijo = new frmSalidaDetallada();

            AbrirFormularioEnPanel(hijo);
            hijo.CargarTabla();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmResumenSensibilidad());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmImpactoSalarioMinimoUtilidad hijo = new frmImpactoSalarioMinimoUtilidad();

            AbrirFormularioEnPanel(hijo);
            hijo.GenerarGraficoArana();
            hijo.LlenarDatosImpacto();
            hijo.GenerarGraficoArana();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            frmImpactoNumeroRamosProducidosRentabilidad hijo = new frmImpactoNumeroRamosProducidosRentabilidad();

            AbrirFormularioEnPanel(hijo);

            hijo.ConfigurarTablaBasica();
            hijo.ConfigurarTablaCalidad();
            hijo.ConfigurarTablaFrancia();
            hijo.GraficarBasica();
            hijo.GraficarCalidad();
            hijo.GraficarFrancia();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmAnalisisGSP());
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new GSPUtilidadRentabilidadBasica());
        }

        private void label15_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new GSPUtilidadRentabilidadMejorAlternativa());
        }

        private void label17_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new GSPUtilidadRentabilidadFrancia());
        }
    }
}
