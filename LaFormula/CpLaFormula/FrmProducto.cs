using CadLaFormula;
using ClnLaFormula;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmProducto : Form
    {
        private bool esNuevo = false;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProductoCln.listarPorParametro(txtParametro.Text);
            dgvLista.DataSource = ProductoCln.listarPorParametro(txtParametro.Text);
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["idUnidadMedida"].Visible = false;
            dgvLista.Columns["idCategoria"].Visible = false;
            dgvLista.Columns["codigo"].HeaderText = "Codigo";
            dgvLista.Columns["descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["unidadMedida"].HeaderText = "Unidad de Medida";
            dgvLista.Columns["categoria"].HeaderText = "Categoria";
            dgvLista.Columns["marca"].HeaderText = "Marca";
            dgvLista.Columns["ubicacionBodega"].HeaderText = "Ubicaión";
            dgvLista.Columns["saldo"].HeaderText = "Saldo";
            dgvLista.Columns["precioVenta"].HeaderText = "Precio de Venta";
            dgvLista.Columns["factor"].HeaderText = "Factor";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Registrado";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";
            dgvLista.Columns["estado"].HeaderText = "Estado";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["codigo"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }
        private void cargarUnidadMedida()
        {
            cbxUnidadMedida.DataSource = UnidadMedidaCln.listar();
            cbxUnidadMedida.ValueMember = "id";
            cbxUnidadMedida.DisplayMember = "descripcion";
            cbxUnidadMedida.SelectedIndex = -1;
        }
        public void cargarCatalogo()
        {
            cbxCategoria.DataSource = CategoriaCln.listar();
            cbxCategoria.DisplayMember = "nombre";
            cbxCategoria.ValueMember = "id";
        }
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size = new Size(1128, 461);
            cargarUnidadMedida();
            cargarCatalogo();
            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            cbxUnidadMedida.SelectedIndex = -1;
            txtDescripcion.Clear();
            cbxCategoria.SelectedIndex = -1;
            txtMarca.Clear();
            txtUbicacion.Clear();
            nudSaldo.Value = 0;
            nudPrecioVenta.Value = 0;
            nudFactor.Value = 0;
            resetearErrores();
        }
        private void resetearErrores()
        {
            erpCodigo.Clear();
            erpUnidadMedida.Clear();
            erpDescripcion.Clear();
            erpCategoria.Clear();
            erpMarca.Clear();
            erpUbicacion.Clear();
            erpPrecioVenta.Clear();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            Size = new Size(1128, 610);
            limpiar();
            txtCodigo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(1128, 610);
            resetearErrores();

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var producto = ProductoCln.obtenerUno(id);
            txtCodigo.Text = producto.codigo;
            cbxUnidadMedida.SelectedValue = producto.idUnidadMedida;
            txtDescripcion.Text = producto.descripcion;
            cbxCategoria.SelectedValue = producto.idCategoria;
            txtMarca.Text = producto.marca;
            txtUbicacion.Text = producto.ubicacionBodega;
            nudSaldo.Value = producto.saldo;
            nudPrecioVenta.Value = producto.precioVenta;
            nudFactor.Value = producto.factor;

            txtCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlAcciones.Enabled = true;
            Size = new Size(1128, 461);
        }

        private bool validar()
        {
            bool esValido = true;
            resetearErrores();

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                erpCodigo.SetError(txtCodigo, "El codigo es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(cbxUnidadMedida.Text))
            {
                erpUnidadMedida.SetError(cbxUnidadMedida, "La unidad de medida es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                erpDescripcion.SetError(txtDescripcion, "La descripción es obligatoria");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(cbxCategoria.Text))
            {
                erpCategoria.SetError(cbxCategoria, "La Categoria es oblicatoria");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                erpMarca.SetError(txtMarca, "La marca es oblicatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                erpUbicacion.SetError(txtUbicacion, "El Ubicacion es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(nudPrecioVenta.Value.ToString()))
            {
                erpPrecioVenta.SetError(nudPrecioVenta, "El precio debe ser obligatorio");
                esValido = false;
            }
            if (nudPrecioVenta.Value <= 0)
            {
                erpPrecioVenta.SetError(nudPrecioVenta, "El precio de venta debe ser mayor a Cero");
                esValido = false;
            }
            //LO COMENTE POR QUE EN LA BASE NO HAY EN CREAR EL ESTADO PARA ALMACENAR
            /*if (nudEstado.Value <= 0)
            {
                erpEstado.SetError(nudEstado, "El Estado debe ser mayor a 0");
                esValido = false;
            }*/
            return esValido;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var producto = new Producto()
                {
                    codigo = txtCodigo.Text.Trim(),
                    idUnidadMedida = (int)cbxUnidadMedida.SelectedValue,
                    descripcion = txtDescripcion.Text.Trim(),
                    idCategoria = (int)cbxCategoria.SelectedValue,
                    marca = txtMarca.Text.Trim(),
                    ubicacionBodega = txtUbicacion.Text.Trim(),
                    saldo = nudSaldo.Value,
                    precioVenta = nudPrecioVenta.Value,
                    factor = nudFactor.Value,
                    //estado = nudEstado.Value,
                    usuarioRegistro = Util.usuario.usuario1,
                };

                if (esNuevo)
                {
                    producto.fechaRegistro = DateTime.Now;
                    producto.estado = 1;
                    ProductoCln.crear(producto);
                }
                else
                {
                    producto.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    ProductoCln.modificar(producto);
                }
                listar();
                    btnCancelar.PerformClick();
                    MessageBox.Show("Producto guardado correctamente", "Mensaje La Formula", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string codigo = dgvLista.CurrentRow.Cells["codigo"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"Está seguro que desea eliminar el producto {codigo}",
                "::: Mensaje - La Formula :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ProductoCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Producto dado de baja correctamente", "::: Mensaje - La Formula :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtParametro_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
    }
}
