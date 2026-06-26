using ClnLaFormula;
using MaterialSkin;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmDetalleVenta : MaterialSkin.Controls.MaterialForm
    {
        private int idVenta;

        public FrmDetalleVenta(int idVenta)
        {
            InitializeComponent();
            this.idVenta = idVenta;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
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

            cargarDetalle();
        }

        private void cargarDetalle()
        {
            try
            {
                var venta = VentaCln.obtenerPorId(idVenta);
                if (venta == null)
                {
                    MessageBox.Show("Venta no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Mostrar información de la venta
                lblIdVenta.Text = $"ID: {venta.id}";
                lblFecha.Text = $"Fecha: {venta.fecha.ToString("dd/MM/yyyy HH:mm")}";
                lblCliente.Text = $"Cliente: {venta.Cliente?.nombres ?? "Sin Cliente"}";
                lblVendedor.Text = $"Vendedor: {venta.Usuario?.usuario1 ?? "Sistema"}";
                lblTotal.Text = $"Total: {venta.total:N2} Bs.";

                // Mostrar método de pago
                string metodoPago = venta.metodoPago ?? "EFECTIVO";
                string pagos = venta.pagos ?? metodoPago;
                lblMetodoPago.Text = $"Pago: {pagos}";

                // ✅ MOSTRAR PAGADO Y CAMBIO
                decimal totalPagado = CalcularTotalPagado(venta.pagos, venta.total);
                decimal cambio = totalPagado - venta.total;
                lblPagado.Text = $"Pagado: {totalPagado:N2} Bs.";
                lblCambio.Text = $"Cambio: {cambio:N2} Bs.";
                lblCambio.ForeColor = cambio >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                // Mostrar detalles de productos
                var detalles = VentaCln.obtenerDetallesPorVenta(venta.id);
                dgvDetalles.DataSource = detalles.Select(d => new
                {
                    Producto = d.Producto != null ? d.Producto.descripcion : "Producto eliminado",
                    Cantidad = d.cantidad,
                    PrecioUnitario = d.precioUnitario.ToString("N2"),
                    Subtotal = d.subtotal.ToString("N2")
                }).ToList();

                // Configurar columnas del DataGridView
                dgvDetalles.Columns["Producto"].HeaderText = "Producto";
                dgvDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
                dgvDetalles.Columns["PrecioUnitario"].HeaderText = "Precio Unit.";
                dgvDetalles.Columns["Subtotal"].HeaderText = "Subtotal";

                dgvDetalles.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvDetalles.Columns["Producto"].Width = 300;
                dgvDetalles.Columns["Cantidad"].Width = 100;
                dgvDetalles.Columns["PrecioUnitario"].Width = 120;
                dgvDetalles.Columns["Subtotal"].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ MÉTODO PARA CALCULAR EL TOTAL PAGADO
        private decimal CalcularTotalPagado(string pagos, decimal totalVenta)
        {
            if (string.IsNullOrEmpty(pagos))
                return totalVenta;

            decimal total = 0;
            var partes = pagos.Split('+');
            foreach (var parte in partes)
            {
                var datos = parte.Split(':');
                if (datos.Length == 2)
                {
                    if (decimal.TryParse(datos[1].Trim(), out decimal monto))
                    {
                        total += monto;
                    }
                }
            }

            return total > 0 ? total : totalVenta;
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}