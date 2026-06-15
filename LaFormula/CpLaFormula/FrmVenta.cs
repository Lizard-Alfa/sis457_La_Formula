using CadLaFormula;
using ClnLaFormula;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmVenta : MaterialSkin.Controls.MaterialForm
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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red800,
                Primary.Red900,
                Primary.Red600,
                Accent.Red100,
                TextShade.WHITE
            );
            lblVendedorActual.Text = nombreVendedor;
            lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cargarClientes();
            configurarDataGridViews();
            cargarProductos();
            pnlAcciones.Enabled = true;
            dgvProductos.ColumnWidthChanged += dgvProductos_ColumnWidthChanged;
        }

        private void cargarClientes()
        {
            try
            {
                var clientes = ClienteCln.listar();

                var listaClientes = new List<Cliente>();
                listaClientes.Add(new Cliente { id = 0, nombres = "Cliente no registrado" });
                listaClientes.AddRange(clientes);

                cboCliente.DataSource = listaClientes;
                cboCliente.DisplayMember = "nombres";
                cboCliente.ValueMember = "id";
                cboCliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            buscarClientes();
        }

        private void buscarClientes()
        {
            try
            {
                string parametro = txtBuscarCliente.Text.Trim();
                var clientes = ClienteCln.buscarPorParametro(parametro);

                var listaClientes = new List<Cliente>();
                listaClientes.Add(new Cliente { id = 0, nombres = "Cliente no registrado" });
                listaClientes.AddRange(clientes);

                cboCliente.DataSource = listaClientes;
                cboCliente.DisplayMember = "nombres";
                cboCliente.ValueMember = "id";

                if (listaClientes.Count > 1)
                    cboCliente.SelectedIndex = 1;
                else
                    cboCliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvProductos.ScrollBars = ScrollBars.Both;
            dgvProductos.ColumnHeadersHeight = 45;

            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.ColumnHeadersHeight = 35;
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

                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["idUnidadMedida"].Visible = false;
                dgvProductos.Columns["idCategoria"].Visible = false;
                dgvProductos.Columns["usuarioRegistro"].Visible = false;
                dgvProductos.Columns["fechaRegistro"].Visible = false;
                dgvProductos.Columns["estado"].Visible = false;
                if (dgvProductos.Columns["factor"] != null) dgvProductos.Columns["factor"].Visible = false;

                dgvProductos.Columns["codigo"].HeaderText = "Código";
                dgvProductos.Columns["descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["unidadMedida"].HeaderText = "Unidad de Medida";
                dgvProductos.Columns["categoria"].HeaderText = "Categoría";
                dgvProductos.Columns["marca"].HeaderText = "Marca";
                dgvProductos.Columns["ubicacionBodega"].HeaderText = "Ubicación";
                dgvProductos.Columns["saldo"].HeaderText = "Saldo";
                dgvProductos.Columns["precioVenta"].HeaderText = "Precio de Venta";
                // Anchos de columnas
                dgvProductos.Columns["codigo"].Width = 65;
                dgvProductos.Columns["descripcion"].Width = 265;
                dgvProductos.Columns["unidadMedida"].Width = 90;
                dgvProductos.Columns["categoria"].Width = 80;
                dgvProductos.Columns["marca"].Width = 60;
                dgvProductos.Columns["ubicacionBodega"].Width = 90;
                dgvProductos.Columns["saldo"].Width = 70;
                dgvProductos.Columns["precioVenta"].Width = 80;
                // Alineación derecha para números
                dgvProductos.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["idUnidadMedida"].Visible = false;
                dgvProductos.Columns["idCategoria"].Visible = false;
                dgvProductos.Columns["usuarioRegistro"].Visible = false;
                dgvProductos.Columns["fechaRegistro"].Visible = false;
                dgvProductos.Columns["estado"].Visible = false;
                if (dgvProductos.Columns["factor"] != null) dgvProductos.Columns["factor"].Visible = false;

                dgvProductos.Columns["codigo"].HeaderText = "Código";
                dgvProductos.Columns["descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["unidadMedida"].HeaderText = "Unidad Medida";
                dgvProductos.Columns["categoria"].HeaderText = "Categoría";
                dgvProductos.Columns["marca"].HeaderText = "Marca";
                dgvProductos.Columns["ubicacionBodega"].HeaderText = "Ubicación";
                dgvProductos.Columns["saldo"].HeaderText = "Saldo";
                dgvProductos.Columns["precioVenta"].HeaderText = "P. Venta";
                dgvProductos.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("El producto ya está en el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cantidadStr = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Cantidad a vender (Se Tiene: {saldo})", "Cantidad", "1");
                if (string.IsNullOrWhiteSpace(cantidadStr)) return;
                if (!decimal.TryParse(cantidadStr, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cantidad > saldo)
                {
                    MessageBox.Show($"No hay suficiente stock. Disponible: {saldo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un producto del detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Agregue al menos un producto al detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }
            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            try
            {
                int idCliente = Convert.ToInt32(cboCliente.SelectedValue);

                if (idCliente == 0)
                {
                    MessageBox.Show("Seleccione un cliente registrado o regístrelo con el botón '+'",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string detallesJson = generarJsonDetalle();
                int idVenta = VentaCln.registrar(idCliente, idUsuarioActual, detallesJson);
                MessageBox.Show($"Venta registrada exitosamente.\nID: {idVenta}\nTotal: {totalVenta:N2}",
                    "Mensaje La Formula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtBuscarCliente.Clear();
            txtBuscarProducto.Clear();
            listaDetalle.Clear();
            dgvDetalleVenta.Rows.Clear();
            totalVenta = 0;
            lblValorTotal.Text = "0.00";
            erpCliente.Clear();
            cargarProductos();
            cargarClientes();
            cboCliente.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClienteRapido())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cargarClientes();
                    cboCliente.SelectedValue = frm.IdClienteCreado;
                }
            }
        }
        private void dgvProductos_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Visible)
            {
                this.Text = $"Columna: {e.Column.HeaderText} | Ancho: {e.Column.Width}px";
            }
        }
    }
}