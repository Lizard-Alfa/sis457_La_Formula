using ClnLaFormula;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                var ventas = VentaCln.listarTodas();

                dgvVentas.DataSource = ventas.Select(v => new
                {
                    v.id,
                    Fecha = v.fecha.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = v.Cliente != null ? v.Cliente.nombres : "Sin Cliente",
                    Vendedor = v.Usuario != null ? v.Usuario.usuario1 : "Sistema",
                    Total = v.total.ToString("N2"),
                    pagos = string.IsNullOrEmpty(v.pagos) ?
                        (v.metodoPago ?? "EFECTIVO") :
                        string.Join(" + ", v.pagos.Split('+').Select(p => p.Split(':')[0].Trim())),
                    Estado = v.estado == 1 ? "Activa" : "Anulada"
                }).ToList();

                if (dgvVentas.Columns["id"] != null)
                dgvVentas.Columns["id"].Visible = false;
                dgvVentas.Columns["Fecha"].HeaderText = "Fecha";
                dgvVentas.Columns["Cliente"].HeaderText = "Cliente";
                dgvVentas.Columns["Vendedor"].HeaderText = "Vendedor";
                dgvVentas.Columns["Total"].HeaderText = "Total Bs.";
                dgvVentas.Columns["pagos"].HeaderText = "Método Pago";
                dgvVentas.Columns["Estado"].HeaderText = "Estado";
                dgvVentas.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "N2";
                dgvVentas.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVentas.Columns["pagos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    string estado = row.Cells["Estado"].Value.ToString();
                    if (estado == "Anulada")
                    {
                    }
                }

                bool hayDatos = dgvVentas.Rows.Count > 0;
                btnAnular.Enabled = hayDatos;
                btnVer.Enabled = hayDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               // BOTÓN ANULAR
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para anular.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["id"].Value);
                string cliente = dgvVentas.CurrentRow.Cells["Cliente"].Value.ToString();
                string total = dgvVentas.CurrentRow.Cells["Total"].Value.ToString();

                var result = MessageBox.Show(
                    $"¿Anular venta?\n\nCliente: {cliente}\nTotal: {total} Bs.\n\n" +
                    "Se restaurará el stock de los productos.",
                    "Confirmar Anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool exito = VentaCln.anular(idVenta);

                    if (exito)
                    {
                        MessageBox.Show("Venta anulada. Stock restaurado.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarVentas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo anular la venta.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para ver el detalle.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["id"].Value);

                using (var frm = new FrmDetalleVenta(idVenta))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}