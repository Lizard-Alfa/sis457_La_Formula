using ClnLaFormula;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmConsultaVenta : MaterialSkin.Controls.MaterialForm
    {
        public FrmConsultaVenta()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmConsultaVenta_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red800,
                Primary.Red900,
                Primary.Red600,
                Accent.Red100,
                TextShade.WHITE
            );
            cargarVentas();
        }

        private void cargarVentas()
        {
            try
            {
                var ventas = VentaCln.listar();
                dgvVentas.DataSource = ventas.Select(v => new
                {
                    v.id,
                    Fecha = v.fecha.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = v.Cliente != null ? v.Cliente.nombres : "Sin Cliente",
                    Vendedor = v.Usuario != null ? v.Usuario.ToString() : "Sistema",
                    Total = v.total.ToString("N2")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}