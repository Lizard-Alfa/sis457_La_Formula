using ClnLaFormula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmPrincipal : Form
    {
        FrmAutenticacion frmAutenticacion;

        public FrmPrincipal(FrmAutenticacion frmAutenticacion)
        {
            InitializeComponent();
            this.frmAutenticacion = frmAutenticacion;
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {


        }
        private void btnProducto_Click(object sender, EventArgs e)
        {
            FrmProducto frm = new FrmProducto();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 0);
            panelPrinci.Controls.Clear();
            panelPrinci.Controls.Add(frm);
            frm.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleado frm = new FrmEmpleado();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 0);
            panelPrinci.Controls.Clear();
            panelPrinci.Controls.Add(frm);
            frm.Show();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            FrmCompra frm = new FrmCompra();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 0);
            panelPrinci.Controls.Clear();
            panelPrinci.Controls.Add(frm);
            frm.Show();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            int idUsuario = Util.usuario != null ? Util.usuario.id : 0;
            string nombreVendedor = Util.usuario != null ? Util.usuario.usuario1 : "Desconocido";
            new FrmVenta(idUsuario, nombreVendedor).ShowDialog();
        }

        private void btnRegistroVenta_Click(object sender, EventArgs e)
        {
            FrmConsultaVenta frm = new FrmConsultaVenta();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 0);
            panelPrinci.Controls.Clear();
            panelPrinci.Controls.Add(frm);
            frm.Show();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.usuario = null;
            frmAutenticacion.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
