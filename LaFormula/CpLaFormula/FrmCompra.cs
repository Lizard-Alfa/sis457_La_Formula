using CadLaFormula;
using ClnLaFormula;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
namespace CpLaFormula
{
    public partial class FrmCompra : Form
    {
        private List<CompraDetalle> detalle = new List<CompraDetalle>();
        private decimal total = 0;
        public FrmCompra() { InitializeComponent(); }
        private void FrmCompra_Load(object sender, EventArgs e)
        {
            Size = new Size(845, 500);
            cboProveedor.DataSource = ProveedorCln.listar();
            cboProveedor.DisplayMember = "razonSocial"; cboProveedor.ValueMember = "id"; cboProveedor.SelectedIndex = -1;
            dgvProductos.AllowUserToAddRows = false; dgvProductos.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false; dgvDetalle.ReadOnly = true;
            dgvDetalle.Columns.Add("id", "ID"); dgvDetalle.Columns.Add("cod", "Código"); dgvDetalle.Columns.Add("desc", "Descripción");
            dgvDetalle.Columns.Add("cant", "Cantidad"); dgvDetalle.Columns.Add("pre", "Precio"); dgvDetalle.Columns.Add("tot", "Total");
            dgvDetalle.Columns["id"].Visible = false;
            cargarProductos("");
        }
        private void cargarProductos(string f)
        {
            dgvProductos.DataSource = ProductoCln.listarPorParametro(f);
            dgvProductos.Columns["id"].Visible = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e) => cargarProductos(txtBuscar.Text);
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == 13) btnBuscar.PerformClick(); }
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvProductos.Rows[e.RowIndex];
            int id = (int)r.Cells["id"].Value;
            if (detalle.Exists(x => x.idProducto == id)) return;
            string c = Microsoft.VisualBasic.Interaction.InputBox("Cantidad:", "Stock", "1");
            if (!decimal.TryParse(c, out decimal cant) || cant <= 0) return;
            detalle.Add(new CompraDetalle { idProducto = id, cantidad = cant, precioUnitario = (decimal)r.Cells["precioVenta"].Value, total = cant * (decimal)r.Cells["precioVenta"].Value });
            refrescarDetalle();
        }
        private void refrescarDetalle()
        {
            dgvDetalle.Rows.Clear(); total = 0;
            foreach (var d in detalle)
            {
                var pr = dgvProductos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["id"].Value?.ToString() == d.idProducto.ToString());
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
            if (cboProveedor.SelectedIndex == -1 || detalle.Count == 0) { MessageBox.Show("Faltan datos"); return; }
            var sb = new StringBuilder("[");
            for (int i = 0; i < detalle.Count; i++)
            {
                var d = detalle[i]; sb.Append($"{{\"idProducto\":{d.idProducto},\"cantidad\":{d.cantidad},\"precioUnitario\":{d.precioUnitario},\"total\":{d.total}}}");
                if (i < detalle.Count - 1) sb.Append(",");
            }
            sb.Append("]");
            try { CompraCln.registrar((int)cboProveedor.SelectedValue, 1000, sb.ToString()); MessageBox.Show("Registrado"); detalle.Clear(); refrescarDetalle(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnCerrar_Click(object sender, EventArgs e) => Close();
        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
    }
}