using CadLaFormula;
using ClnLaFormula;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmVenta : Form
    {
        private List<VentaDetalle> listaDetalle;
        private decimal totalVenta;
        private int idUsuarioActual;
        private string nombreVendedor;

        public FrmVenta(int idUsuario, string nombreVendedor)
        {
            InitializeComponent();
            this.idUsuarioActual = idUsuario;
            this.nombreVendedor = nombreVendedor;
            listaDetalle = new List<VentaDetalle>();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            lblVendedorActual.Text = nombreVendedor;
            lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cargarClientes();
            configurarDataGridViews();
            cargarProductos();
            pnlAcciones.Enabled = true;
        }

        private void cargarClientes()
        {
            try
            {
                var clientes = ClienteCln.listar();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "nombres";
                cboCliente.ValueMember = "id";
                cboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configurarDataGridViews()
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ReadOnly = true;

            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.ReadOnly = true;

            dgvDetalleVenta.Columns.Clear();
            dgvDetalleVenta.Columns.Add("idProducto", "ID");
            dgvDetalleVenta.Columns.Add("codigo", "Código");
            dgvDetalleVenta.Columns.Add("descripcion", "Descripción");
            dgvDetalleVenta.Columns.Add("cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("precioUnitario", "Precio Unit.");
            dgvDetalleVenta.Columns.Add("subtotal", "Subtotal");

            dgvDetalleVenta.Columns["idProducto"].Visible = false;
            dgvDetalleVenta.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleVenta.Columns["precioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleVenta.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleVenta.Columns["subtotal"].DefaultCellStyle.Format = "N2";
        }

        private void cargarProductos()
        {
            try
            {
                var productos = ProductoCln.listarPorParametro("");
                dgvProductos.DataSource = productos;

                if (dgvProductos.Columns["id"] != null) dgvProductos.Columns["id"].Visible = false;
                if (dgvProductos.Columns["idUnidadMedida"] != null) dgvProductos.Columns["idUnidadMedida"].Visible = false;
                if (dgvProductos.Columns["idCategoria"] != null) dgvProductos.Columns["idCategoria"].Visible = false;
                if (dgvProductos.Columns["usuarioRegistro"] != null) dgvProductos.Columns["usuarioRegistro"].Visible = false;
                if (dgvProductos.Columns["fechaRegistro"] != null) dgvProductos.Columns["fechaRegistro"].Visible = false;
                if (dgvProductos.Columns["estado"] != null) dgvProductos.Columns["estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            buscarProductos();
        }

        private void buscarProductos()
        {
            try
            {
                string parametro = txtBuscarProducto.Text.Trim();
                var productos = ProductoCln.listarPorParametro(parametro);
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscarProductos();
                e.Handled = true;
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                agregarProductoAlDetalle();
            }
        }

        private void agregarProductoAlDetalle()
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id"].Value);
                string codigo = dgvProductos.CurrentRow.Cells["codigo"].Value.ToString();
                string descripcion = dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                decimal precioUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["precioVenta"].Value);
                decimal saldo = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["saldo"].Value);

                var existente = listaDetalle.Find(d => d.idProducto == idProducto);
                if (existente != null)
                {
                    MessageBox.Show("El producto ya está en el detalle", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Mensaje cuando se agrega un Producto
                string cantidadStr = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Cantidad a vender (Se Tiene: {saldo})",
                    "Cantidad", "1");

                if (string.IsNullOrWhiteSpace(cantidadStr))
                    return;

                if (!decimal.TryParse(cantidadStr, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cantidad > saldo)
                {
                    MessageBox.Show($"No hay suficiente stock. Disponible: {saldo}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal subtotal = cantidad * precioUnitario;

                var detalle = new VentaDetalle
                {
                    idProducto = idProducto,
                    cantidad = cantidad,
                    precioUnitario = precioUnitario,
                    subtotal = subtotal
                };

                listaDetalle.Add(detalle);
                actualizarDetalleDataGridView();
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarProductoAlDetalle();
        }

        private void actualizarDetalleDataGridView()
        {
            dgvDetalleVenta.Rows.Clear();
            foreach (var item in listaDetalle)
            {
                DataGridViewRow producto = null;
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells["id"].Value != null && row.Cells["id"].Value.ToString() == item.idProducto.ToString())
                    {
                        producto = row;
                        break;
                    }
                }

                string codigo = "";
                string descripcion = "";

                if (producto != null)
                {
                    codigo = producto.Cells["codigo"].Value.ToString();
                    descripcion = producto.Cells["descripcion"].Value.ToString();
                }

                dgvDetalleVenta.Rows.Add(
                    item.idProducto,
                    codigo,
                    descripcion,
                    item.cantidad,
                    item.precioUnitario,
                    item.subtotal
                );
            }
        }

        private void calcularTotal()
        {
            totalVenta = 0;
            foreach (var item in listaDetalle)
            {
                totalVenta += item.subtotal;
            }
            lblValorTotal.Text = totalVenta.ToString("N2");
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto del detalle", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(dgvDetalleVenta.CurrentRow.Cells["idProducto"].Value);
            var item = listaDetalle.Find(d => d.idProducto == idProducto);

            if (item != null)
            {
                listaDetalle.Remove(item);
                actualizarDetalleDataGridView();
                calcularTotal();
            }
        }

        private bool validar()
        {
            bool esValido = true;
            erpCliente.Clear();

            if (cboCliente.SelectedIndex == -1)
            {
                erpCliente.SetError(cboCliente, "Seleccione un cliente");
                esValido = false;
            }

            if (listaDetalle.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al detalle", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }

            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            try
            {
                int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                string detallesJson = generarJsonDetalle();
                int idVenta = VentaCln.registrar(idCliente, idUsuarioActual, detallesJson);

                MessageBox.Show($"Venta registrada exitosamente.\nID: {idVenta}\nTotal: {totalVenta:N2}",
                    "Mensaje La Formula", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string generarJsonDetalle()
        {
            var json = new System.Text.StringBuilder();
            json.Append("[");
            for (int i = 0; i < listaDetalle.Count; i++)
            {
                var item = listaDetalle[i];
                if (i > 0) json.Append(",");
                                
                string cant = item.cantidad.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string pre = item.precioUnitario.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string sub = item.subtotal.ToString(System.Globalization.CultureInfo.InvariantCulture);

                json.Append($"{{\"idProducto\":{item.idProducto},\"cantidad\":{cant},\"precioUnitario\":{pre},\"subtotal\":{sub}}}");
            }
            json.Append("]");
            return json.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            cboCliente.SelectedIndex = -1;
            txtBuscarProducto.Clear();
            listaDetalle.Clear();
            dgvDetalleVenta.Rows.Clear();
            totalVenta = 0;
            lblValorTotal.Text = "0.00";
            erpCliente.Clear();
            cargarProductos();
            cboCliente.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}