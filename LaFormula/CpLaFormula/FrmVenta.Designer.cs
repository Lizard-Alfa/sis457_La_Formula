namespace CpLaFormula
{
    partial class FrmVenta
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblVendedorActual = new System.Windows.Forms.Label();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.gbxProductos = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.gbxDetalle = new System.Windows.Forms.GroupBox();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.erpCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.btnDisminuir = new System.Windows.Forms.Button();
            this.btnAumentar = new System.Windows.Forms.Button();
            this.lblAumentarDisminuir = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cbxMetodoPago = new System.Windows.Forms.ComboBox();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.txtAgregarMonto = new System.Windows.Forms.TextBox();
            this.btnAregarPago = new System.Windows.Forms.Button();
            this.lblTotalPagado = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblTotalPagadoValor = new System.Windows.Forms.Label();
            this.lblCambioValor = new System.Windows.Forms.Label();
            this.btnEliminarPago = new System.Windows.Forms.Button();
            this.gbxProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblTitulo.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(-4, 64);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(977, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Venta de Productos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCliente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(2, 133);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(64, 19);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Location = new System.Drawing.Point(78, 132);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(240, 21);
            this.cboCliente.TabIndex = 2;
            // 
            // lblVendedorActual
            // 
            this.lblVendedorActual.AutoSize = true;
            this.lblVendedorActual.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVendedorActual.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedorActual.Location = new System.Drawing.Point(544, 125);
            this.lblVendedorActual.Name = "lblVendedorActual";
            this.lblVendedorActual.Size = new System.Drawing.Size(88, 19);
            this.lblVendedorActual.TabIndex = 3;
            this.lblVendedorActual.Text = "Vendedor: ";
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFechaActual.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaActual.Location = new System.Drawing.Point(742, 125);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(60, 19);
            this.lblFechaActual.TabIndex = 4;
            this.lblFechaActual.Text = "Fecha: ";
            // 
            // gbxProductos
            // 
            this.gbxProductos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxProductos.Controls.Add(this.dgvProductos);
            this.gbxProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxProductos.Location = new System.Drawing.Point(6, 159);
            this.gbxProductos.Name = "gbxProductos";
            this.gbxProductos.Size = new System.Drawing.Size(960, 226);
            this.gbxProductos.TabIndex = 5;
            this.gbxProductos.TabStop = false;
            this.gbxProductos.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 20);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(948, 202);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProducto.Location = new System.Drawing.Point(8, 402);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(64, 19);
            this.lblBuscarProducto.TabIndex = 6;
            this.lblBuscarProducto.Text = "Buscar:";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(84, 404);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(300, 20);
            this.txtBuscarProducto.TabIndex = 7;
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscarProducto.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.Image = global::CpLaFormula.Properties.Resources.lupa2;
            this.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarProducto.Location = new System.Drawing.Point(388, 391);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(145, 43);
            this.btnBuscarProducto.TabIndex = 8;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // gbxDetalle
            // 
            this.gbxDetalle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxDetalle.Controls.Add(this.dgvDetalleVenta);
            this.gbxDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetalle.Location = new System.Drawing.Point(6, 440);
            this.gbxDetalle.Name = "gbxDetalle";
            this.gbxDetalle.Size = new System.Drawing.Size(960, 183);
            this.gbxDetalle.TabIndex = 9;
            this.gbxDetalle.TabStop = false;
            this.gbxDetalle.Text = "Detalle";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(6, 20);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ReadOnly = true;
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(944, 158);
            this.dgvDetalleVenta.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(525, 719);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 22);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Green;
            this.lblValorTotal.Location = new System.Drawing.Point(590, 719);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(49, 24);
            this.lblValorTotal.TabIndex = 11;
            this.lblValorTotal.Text = "0.00";
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAcciones.Controls.Add(this.btnCerrar);
            this.pnlAcciones.Controls.Add(this.btnEliminarDetalle);
            this.pnlAcciones.Controls.Add(this.btnAgregar);
            this.pnlAcciones.Controls.Add(this.btnGuardar);
            this.pnlAcciones.Controls.Add(this.btnCancelar);
            this.pnlAcciones.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAcciones.Location = new System.Drawing.Point(6, 748);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(960, 56);
            this.pnlAcciones.TabIndex = 12;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::CpLaFormula.Properties.Resources.cerrar;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(766, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(145, 46);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.Image = global::CpLaFormula.Properties.Resources.borrar;
            this.btnEliminarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(250, 3);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(145, 46);
            this.btnEliminarDetalle.TabIndex = 1;
            this.btnEliminarDetalle.Text = "Eliminar";
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(62, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(145, 46);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(433, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(145, 46);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Vender";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(609, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 46);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // erpCliente
            // 
            this.erpCliente.ContainerControl = this;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(78, 106);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(240, 20);
            this.txtBuscarCliente.TabIndex = 13;
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoCliente.Image")));
            this.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoCliente.Location = new System.Drawing.Point(337, 108);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(110, 46);
            this.btnNuevoCliente.TabIndex = 14;
            this.btnNuevoCliente.Text = "Agregar";
            this.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.AutoSize = true;
            this.lblBuscarCliente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBuscarCliente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarCliente.Location = new System.Drawing.Point(2, 104);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new System.Drawing.Size(64, 19);
            this.lblBuscarCliente.TabIndex = 16;
            this.lblBuscarCliente.Text = "Buscar:";
            // 
            // btnDisminuir
            // 
            this.btnDisminuir.Image = global::CpLaFormula.Properties.Resources.cancel;
            this.btnDisminuir.Location = new System.Drawing.Point(269, 629);
            this.btnDisminuir.Name = "btnDisminuir";
            this.btnDisminuir.Size = new System.Drawing.Size(33, 30);
            this.btnDisminuir.TabIndex = 19;
            this.btnDisminuir.Click += new System.EventHandler(this.btnDisminuir_Click);
            // 
            // btnAumentar
            // 
            this.btnAumentar.Image = global::CpLaFormula.Properties.Resources._new;
            this.btnAumentar.Location = new System.Drawing.Point(318, 630);
            this.btnAumentar.Name = "btnAumentar";
            this.btnAumentar.Size = new System.Drawing.Size(36, 29);
            this.btnAumentar.TabIndex = 20;
            this.btnAumentar.Click += new System.EventHandler(this.btnAumentar_Click);
            // 
            // lblAumentarDisminuir
            // 
            this.lblAumentarDisminuir.AutoSize = true;
            this.lblAumentarDisminuir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAumentarDisminuir.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAumentarDisminuir.Location = new System.Drawing.Point(8, 630);
            this.lblAumentarDisminuir.Name = "lblAumentarDisminuir";
            this.lblAumentarDisminuir.Size = new System.Drawing.Size(255, 19);
            this.lblAumentarDisminuir.TabIndex = 21;
            this.lblAumentarDisminuir.Text = "Aumentar o dismunuir producto:";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMetodoPago.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.Location = new System.Drawing.Point(8, 662);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(127, 19);
            this.lblMetodoPago.TabIndex = 17;
            this.lblMetodoPago.Text = "Metodo de pago";
            // 
            // cbxMetodoPago
            // 
            this.cbxMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMetodoPago.Location = new System.Drawing.Point(141, 665);
            this.cbxMetodoPago.Name = "cbxMetodoPago";
            this.cbxMetodoPago.Size = new System.Drawing.Size(177, 21);
            this.cbxMetodoPago.TabIndex = 18;
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Location = new System.Drawing.Point(729, 629);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.Size = new System.Drawing.Size(231, 115);
            this.dgvPagos.TabIndex = 22;
            // 
            // txtAgregarMonto
            // 
            this.txtAgregarMonto.Location = new System.Drawing.Point(324, 666);
            this.txtAgregarMonto.Name = "txtAgregarMonto";
            this.txtAgregarMonto.Size = new System.Drawing.Size(109, 20);
            this.txtAgregarMonto.TabIndex = 23;
            // 
            // btnAregarPago
            // 
            this.btnAregarPago.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAregarPago.Image = global::CpLaFormula.Properties.Resources.billeteras;
            this.btnAregarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAregarPago.Location = new System.Drawing.Point(467, 649);
            this.btnAregarPago.Name = "btnAregarPago";
            this.btnAregarPago.Size = new System.Drawing.Size(117, 47);
            this.btnAregarPago.TabIndex = 5;
            this.btnAregarPago.Text = "Agregar Pago";
            this.btnAregarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPagado
            // 
            this.lblTotalPagado.AutoSize = true;
            this.lblTotalPagado.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagado.Location = new System.Drawing.Point(13, 701);
            this.lblTotalPagado.Name = "lblTotalPagado";
            this.lblTotalPagado.Size = new System.Drawing.Size(126, 22);
            this.lblTotalPagado.TabIndex = 24;
            this.lblTotalPagado.Text = "Total pagado:";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(297, 701);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(81, 22);
            this.lblCambio.TabIndex = 25;
            this.lblCambio.Text = "Cambio:";
            // 
            // lblTotalPagadoValor
            // 
            this.lblTotalPagadoValor.AutoSize = true;
            this.lblTotalPagadoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagadoValor.ForeColor = System.Drawing.Color.Green;
            this.lblTotalPagadoValor.Location = new System.Drawing.Point(145, 700);
            this.lblTotalPagadoValor.Name = "lblTotalPagadoValor";
            this.lblTotalPagadoValor.Size = new System.Drawing.Size(49, 24);
            this.lblTotalPagadoValor.TabIndex = 26;
            this.lblTotalPagadoValor.Text = "0.00";
            // 
            // lblCambioValor
            // 
            this.lblCambioValor.AutoSize = true;
            this.lblCambioValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioValor.ForeColor = System.Drawing.Color.Green;
            this.lblCambioValor.Location = new System.Drawing.Point(384, 701);
            this.lblCambioValor.Name = "lblCambioValor";
            this.lblCambioValor.Size = new System.Drawing.Size(49, 24);
            this.lblCambioValor.TabIndex = 27;
            this.lblCambioValor.Text = "0.00";
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPago.Image = global::CpLaFormula.Properties.Resources.anular;
            this.btnEliminarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPago.Location = new System.Drawing.Point(594, 649);
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Size = new System.Drawing.Size(111, 46);
            this.btnEliminarPago.TabIndex = 28;
            this.btnEliminarPago.Text = "Anular Pago";
            this.btnEliminarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = global::CpLaFormula.Properties.Resources.fondito;
            this.ClientSize = new System.Drawing.Size(972, 812);
            this.Controls.Add(this.btnEliminarPago);
            this.Controls.Add(this.lblCambioValor);
            this.Controls.Add(this.lblTotalPagadoValor);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.lblTotalPagado);
            this.Controls.Add(this.btnAregarPago);
            this.Controls.Add(this.txtAgregarMonto);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.lblAumentarDisminuir);
            this.Controls.Add(this.btnAumentar);
            this.Controls.Add(this.btnDisminuir);
            this.Controls.Add(this.lblBuscarCliente);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.cbxMetodoPago);
            this.Controls.Add(this.lblVendedorActual);
            this.Controls.Add(this.lblFechaActual);
            this.Controls.Add(this.gbxProductos);
            this.Controls.Add(this.lblBuscarProducto);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.gbxDetalle);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.pnlAcciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Formularío de Ventas ";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.gbxProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbxDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblVendedorActual;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.GroupBox gbxProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.GroupBox gbxDetalle;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ErrorProvider erpCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.Button btnDisminuir;
        private System.Windows.Forms.Label lblAumentarDisminuir;
        private System.Windows.Forms.Button btnAumentar;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cbxMetodoPago;
        private System.Windows.Forms.Button btnAregarPago;
        private System.Windows.Forms.TextBox txtAgregarMonto;
        private System.Windows.Forms.Label lblCambioValor;
        private System.Windows.Forms.Label lblTotalPagadoValor;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblTotalPagado;
        private System.Windows.Forms.Button btnEliminarPago;
    }
}