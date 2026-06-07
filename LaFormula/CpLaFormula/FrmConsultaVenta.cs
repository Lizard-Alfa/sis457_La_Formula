using ClnLaFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmConsultaVenta : Form
    {
        public FrmConsultaVenta()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmConsultaVenta_Load(object sender, EventArgs e)
        {
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
    }
}