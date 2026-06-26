using CadLaFormula;
using ClnLaFormula;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmVenta : MaterialSkin.Controls.MaterialForm
    {
        private List<VentaDetalle> listaDetalle;
        private decimal totalVenta;
        private int idUsuarioActual;
        private string nombreVendedor;
        private List<string> listaMetodosPago = new List<string>();
        private List<decimal> listaMontosPago = new List<decimal>();

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
            configurarMetodoPago();
            configurarPagosMixtos();
            pnlAcciones.Enabled = true;
            dgvProductos.ColumnWidthChanged += dgvProductos_ColumnWidthChanged;
        }

        // CONFIGURAR MÉTODOS DE PAGO
        private void configurarMetodoPago()
        {
            cbxMetodoPago.Items.Clear();
            cbxMetodoPago.Items.Add("EFECTIVO");
            cbxMetodoPago.Items.Add("TARJETA");
            cbxMetodoPago.Items.Add("TRANSFERENCIA");
            cbxMetodoPago.Items.Add("QR");
            cbxMetodoPago.SelectedIndex = 0;
        }
        // CONFIGURAR PAGOS MIXTOS
        private void configurarPagosMixtos()
        {
            dgvPagos.Columns.Clear();
            dgvPagos.Columns.Add("MetodoPago", "Método de Pago");
            dgvPagos.Columns.Add("Monto", "Monto");
            dgvPagos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPagos.Columns["Monto"].DefaultCellStyle.Format = "N2";
            dgvPagos.Columns["MetodoPago"].HeaderText = "Metodo de pago";
            dgvPagos.Columns["Monto"].HeaderText = "Monto";
            dgvPagos.AllowUserToAddRows = false;

            // Inicializar valores
            lblValorTotal.Text = "0.00";
            lblTotalPagadoValor.Text = "0.00";
            lblCambioValor.Text = "0.00";
            lblCambioValor.ForeColor = System.Drawing.Color.Black;
            btnGuardar.Enabled = false;

            // Eventos
            btnAregarPago.Click += btnAgregarPago_Click;
            btnEliminarPago.Click += btnEliminarPago_Click;
            txtAgregarMonto.TextChanged += CalcularTotalesPagos;
        }
        // AGREGAR PAGO
        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            try
            {
                string metodo = cbxMetodoPago.SelectedItem?.ToString() ?? "EFECTIVO";
                decimal monto = string.IsNullOrEmpty(txtAgregarMonto.Text) ? 0 : decimal.Parse(txtAgregarMonto.Text);

                if (monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                listaMetodosPago.Add(metodo);
                listaMontosPago.Add(monto);

                actualizarDataGridViewPagos();
                CalcularTotalesPagos(null, null);

                txtAgregarMonto.Text = "0";
                txtAgregarMonto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ELIMINAR PAGO
        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int index = dgvPagos.CurrentRow.Index;
                listaMetodosPago.RemoveAt(index);
                listaMontosPago.RemoveAt(index);
                actualizarDataGridViewPagos();
                CalcularTotalesPagos(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ACTUALIZAR DATAGRIDVIEW DE PAGOS
        private void actualizarDataGridViewPagos()
        {
            dgvPagos.Rows.Clear();
            for (int i = 0; i < listaMetodosPago.Count; i++)
            {
                dgvPagos.Rows.Add(listaMetodosPago[i], listaMontosPago[i]);
            }
        }
        // CALCULAR TOTAL PAGADO Y CAMBIO
        private void CalcularTotalesPagos(object sender, EventArgs e)
        {
            try
            {
                decimal totalPagado = 0;
                foreach (var monto in listaMontosPago)
                {
                    totalPagado += monto;
                }

                decimal cambio = totalPagado - totalVenta;

                // ACTUALIZAR VALORES
                lblValorTotal.Text = $"{totalVenta:N2} Bs.";
                lblTotalPagadoValor.Text = $"{totalPagado:N2} Bs.";

                if (totalPagado >= totalVenta && totalVenta > 0)
                {
                    lblCambioValor.Text = $"{cambio:N2} Bs.";
                    lblCambioValor.ForeColor = System.Drawing.Color.Green;
                    btnGuardar.Enabled = true;
                }
                else if (totalVenta > 0)
                {
                    decimal faltante = totalVenta - totalPagado;
                    lblCambioValor.Text = $"-{faltante:N2} Bs.";
                    lblCambioValor.ForeColor = System.Drawing.Color.Red;
                    btnGuardar.Enabled = false;
                }
                else
                {
                    lblCambioValor.Text = "0.00 Bs.";
                    lblCambioValor.ForeColor = System.Drawing.Color.Black;
                    btnGuardar.Enabled = false;
                }
            }
            catch { }
        }
        // CARGAR CLIENTES
        private void cargarClientes()
        {
            try
            {
                var clientes = ClienteCln.listar()
                                         .OrderByDescending(c => c.id)
                                         .Take(10)
                                         .ToList();
                var listaClientes = new List<Cliente>();
                listaClientes.Add(new Cliente { id = 0, nombres = "Seleccione un cliente..." });
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
        // BUSCAR CLIENTES
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
                listaClientes.Add(new Cliente { id = 0, nombres = "Seleccione un cliente..." });
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
        // CONFIGURAR DATAGRIDVIEWS
        private void configurarDataGridViews()
        {
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
        // CARGAR PRODUCTOS
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

                dgvProductos.Columns["codigo"].Width = 65;
                dgvProductos.Columns["descripcion"].Width = 265;
                dgvProductos.Columns["unidadMedida"].Width = 90;
                dgvProductos.Columns["categoria"].Width = 80;
                dgvProductos.Columns["marca"].Width = 60;
                dgvProductos.Columns["ubicacionBodega"].Width = 90;
                dgvProductos.Columns["saldo"].Width = 70;
                dgvProductos.Columns["precioVenta"].Width = 80;

                dgvProductos.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // BUSCAR PRODUCTOS
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
        // AGREGAR PRODUCTO AL DETALLE
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

                if (saldo <= 0)
                {
                    MessageBox.Show($"El producto '{descripcion}' no tiene stock disponible.",
                        "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existente = listaDetalle.Find(d => d.idProducto == idProducto);
                if (existente != null)
                {
                    MessageBox.Show("El producto ya está en el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cantidadStr = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Cantidad a vender (Stock disponible: {saldo})", "Cantidad", "1");

                if (string.IsNullOrWhiteSpace(cantidadStr)) return;

                if (!decimal.TryParse(cantidadStr, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cantidad > saldo)
                {
                    MessageBox.Show($"No hay suficiente stock. Disponible: {saldo}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // ACTUALIZAR DETALLE
        private void actualizarDetalleDataGridView()
        {
            //  GUARDAR: El ID del producto seleccionado actualmente
            int? idProductoSeleccionado = null;
            if (dgvDetalleVenta.CurrentRow != null)
            {
                idProductoSeleccionado = Convert.ToInt32(dgvDetalleVenta.CurrentRow.Cells["idProducto"].Value);
            }

            // LIMPIAR: El DataGridView
            dgvDetalleVenta.Rows.Clear();

            // RECARGAR: Todos los productos del detalle
            foreach (var item in listaDetalle)
            {
                // Buscar el producto en el DataGridView de productos
                string codigo = "";
                string descripcion = "";
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells["id"].Value != null &&
                        row.Cells["id"].Value.ToString() == item.idProducto.ToString())
                    {
                        codigo = row.Cells["codigo"].Value.ToString();
                        descripcion = row.Cells["descripcion"].Value.ToString();
                        break;
                    }
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

            // RESTAURAR: La selección anterior
            if (idProductoSeleccionado.HasValue)
            {
                foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                {
                    if (row.Cells["idProducto"].Value != null &&
                        Convert.ToInt32(row.Cells["idProducto"].Value) == idProductoSeleccionado.Value)
                    {
                        dgvDetalleVenta.CurrentCell = row.Cells["codigo"];
                        row.Selected = true;
                        break;
                    }
                }
            }
        }
        // CALCULAR TOTAL
        private void calcularTotal()
        {
            totalVenta = 0;
            foreach (var item in listaDetalle)
            {
                totalVenta += item.subtotal;
            }
            lblValorTotal.Text = $"{totalVenta:N2} Bs.";
            CalcularTotalesPagos(null, null);
        }
        // ELIMINAR PRODUCTO DEL DETALLE
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
        // AUMENTAR CANTIDAD
        private void btnAumentar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto del detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProducto = Convert.ToInt32(dgvDetalleVenta.CurrentRow.Cells["idProducto"].Value);
                var item = listaDetalle.Find(d => d.idProducto == idProducto);

                if (item == null) return;

                // Obtener el saldo actual del producto
                decimal saldo = 0;
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells["id"].Value != null && row.Cells["id"].Value.ToString() == idProducto.ToString())
                    {
                        saldo = Convert.ToDecimal(row.Cells["saldo"].Value);
                        break;
                    }
                }

                // Verificar stock
                if (item.cantidad + 1 > saldo)
                {
                    MessageBox.Show($"No hay suficiente stock. Disponible: {saldo}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Aumentar cantidad
                item.cantidad += 1;
                item.subtotal = item.cantidad * item.precioUnitario;

                // Actualizar (mantiene selección automáticamente)
                actualizarDetalleDataGridView();
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // DISMINUIR CANTIDAD
        private void btnDisminuir_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto del detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProducto = Convert.ToInt32(dgvDetalleVenta.CurrentRow.Cells["idProducto"].Value);
                var item = listaDetalle.Find(d => d.idProducto == idProducto);

                if (item == null) return;

                // Verificar que no baje de 1
                if (item.cantidad <= 1)
                {
                    MessageBox.Show("La cantidad mínima es 1.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Disminuir cantidad
                item.cantidad -= 1;
                item.subtotal = item.cantidad * item.precioUnitario;

                // Actualizar (mantiene selección automáticamente)
                actualizarDetalleDataGridView();
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // VALIDAR
        private bool validar()
        {
            bool esValido = true;
            erpCliente.Clear();

            if (cboCliente.SelectedValue == null || Convert.ToInt32(cboCliente.SelectedValue) <= 0)
            {
                erpCliente.SetError(cboCliente, "Debe seleccionar un cliente");
                MessageBox.Show("Debe seleccionar un cliente para realizar la venta.",
                    "Cliente requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }

            if (listaDetalle.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al detalle",
                    "Detalle vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }

            if (listaDetalle.Count > 0)
            {
                decimal totalPagado = 0;
                foreach (var monto in listaMontosPago)
                {
                    totalPagado += monto;
                }

                if (listaMetodosPago.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un método de pago.",
                        "Pago requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    esValido = false;
                }
                else if (totalPagado < totalVenta)
                {
                    MessageBox.Show($"Pago insuficiente.\nTotal: {totalVenta:N2} Bs.\nPagado: {totalPagado:N2} Bs.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    esValido = false;
                }
            }

            return esValido;
        }
        // GUARDAR VENTA
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

                string pagosMixtos = "";
                for (int i = 0; i < listaMetodosPago.Count; i++)
                {
                    if (i > 0) pagosMixtos += " + ";
                    pagosMixtos += $"{listaMetodosPago[i]}:{listaMontosPago[i]:N2}";
                }

                if (string.IsNullOrEmpty(pagosMixtos))
                {
                    pagosMixtos = cbxMetodoPago.SelectedItem?.ToString() ?? "EFECTIVO";
                }

                string metodoPago = cbxMetodoPago.SelectedItem?.ToString() ?? "EFECTIVO";
                if (listaMetodosPago.Count > 0)
                {
                    metodoPago = listaMetodosPago[0];
                }

                int idVenta = VentaCln.registrar(idCliente, idUsuarioActual, listaDetalle, metodoPago, pagosMixtos);

                decimal totalPagado = 0;
                foreach (var monto in listaMontosPago)
                {
                    totalPagado += monto;
                }

                MessageBox.Show($" Venta registrada exitosamente.\n\n" +
                                $"ID: {idVenta}\n" +
                                $"Total: {totalVenta:N2} Bs.\n" +
                                $"Pagado: {totalPagado:N2} Bs.\n" +
                                $"Cambio: {(totalPagado - totalVenta):N2} Bs.\n" +
                                $"Pagos: {pagosMixtos}",
                    "Mensaje La Formula", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // LIMPIAR
        private void limpiar()
        {
            cboCliente.SelectedIndex = 0;
            txtBuscarCliente.Clear();
            txtBuscarProducto.Clear();
            listaDetalle.Clear();
            dgvDetalleVenta.Rows.Clear();
            totalVenta = 0;

            // Resetear valores
            lblValorTotal.Text = "0.00";
            lblTotalPagadoValor.Text = "0.00";
            lblCambioValor.Text = "0.00";
            btnGuardar.Enabled = false;

            listaMetodosPago.Clear();
            listaMontosPago.Clear();
            dgvPagos.Rows.Clear();
            txtAgregarMonto.Text = "0";
            cbxMetodoPago.SelectedIndex = 0;

            erpCliente.Clear();
            cargarProductos();
            cargarClientes();
            cboCliente.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
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