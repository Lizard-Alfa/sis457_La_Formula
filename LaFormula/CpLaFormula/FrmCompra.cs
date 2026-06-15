using CadLaFormula;
using ClnLaFormula;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmCompra : MaterialSkin.Controls.MaterialForm
    {
        private List<CompraDetalle> detalle = new List<CompraDetalle>();
        private decimal total = 0;

        public FrmCompra() { InitializeComponent(); }

        private void FrmCompra_Load(object sender, EventArgs e)
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
            Size = new Size(845, 500);
            cboProveedor.DataSource = ProveedorCln.listar();
            cboProveedor.DisplayMember = "razonSocial";
            cboProveedor.ValueMember = "id";
            cboProveedor.SelectedIndex = -1;

            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.ColumnHeadersHeight = 40;

            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.ColumnHeadersHeight = 35;
            dgvDetalle.Columns.Add("id", "ID");
            dgvDetalle.Columns.Add("cod", "Código");
            dgvDetalle.Columns.Add("desc", "Descripción");
            dgvDetalle.Columns.Add("cant", "Cantidad");
            dgvDetalle.Columns.Add("pre", "Precio");
            dgvDetalle.Columns.Add("tot", "Total");
            dgvDetalle.Columns["id"].Visible = false;

            cargarProductos("");
        }

        private void cargarProductos(string f)
        {
            dgvProductos.DataSource = ProductoCln.listarPorParametro(f);
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
            dgvProductos.Columns["precioVenta"].HeaderText = "Precio Compra";
        }

        private void btnBuscar_Click(object sender, EventArgs e) => cargarProductos(txtBuscar.Text);

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnBuscar.PerformClick();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvProductos.Rows[e.RowIndex];
            int id = (int)r.Cells["id"].Value;
            if (detalle.Exists(x => x.idProducto == id))
            {
                MessageBox.Show("El producto ya está en el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string c = Microsoft.VisualBasic.Interaction.InputBox("Cantidad:", "Stock", "1");
            if (!decimal.TryParse(c, out decimal cant) || cant <= 0) return;

            detalle.Add(new CompraDetalle
            {
                idProducto = id,
                cantidad = cant,
                precioUnitario = (decimal)r.Cells["precioVenta"].Value,
                total = cant * (decimal)r.Cells["precioVenta"].Value
            });
            refrescarDetalle();
        }

        private void refrescarDetalle()
        {
            dgvDetalle.Rows.Clear();
            total = 0;
            foreach (var d in detalle)
            {
                var pr = dgvProductos.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["id"].Value?.ToString() == d.idProducto.ToString());

                string codigo = pr?.Cells["codigo"].Value?.ToString() ?? "";
                string descripcion = pr?.Cells["descripcion"].Value?.ToString() ?? "";

                dgvDetalle.Rows.Add(d.idProducto, codigo, descripcion, d.cantidad, d.precioUnitario, d.total);
                total += d.total;
            }
            lblTotal.Text = total.ToString("N2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;
            detalle.RemoveAll(x => x.idProducto == (int)dgvDetalle.CurrentRow.Cells["id"].Value);
            refrescarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (detalle.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sb = new StringBuilder("[");
            for (int i = 0; i < detalle.Count; i++)
            {
                var d = detalle[i];
                sb.Append($"{{\"idProducto\":{d.idProducto},\"cantidad\":{d.cantidad},\"precioUnitario\":{d.precioUnitario},\"total\":{d.total}}}");
                if (i < detalle.Count - 1) sb.Append(",");
            }
            sb.Append("]");

            try
            {
                int idUsuario = Util.usuario != null ? Util.usuario.id : 0;
                CompraCln.registrar((int)cboProveedor.SelectedValue, Util.usuario.id, sb.ToString());
                MessageBox.Show("Compra registrada correctamente", "Mensaje La Formula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                detalle.Clear();
                refrescarDetalle();
                cboProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista superior", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvProductos_CellDoubleClick(dgvProductos, new DataGridViewCellEventArgs(0, dgvProductos.CurrentRow.Index));
        }
    }
}