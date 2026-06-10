using CadLaFormula;
using ClnLaFormula;
using System;
using System.Windows.Forms;

namespace CpLaFormula
{
    public partial class FrmClienteRapido : Form
    {
        public int IdClienteCreado { get; private set; }

        public FrmClienteRapido()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void FrmClienteRapido_Load(object sender, EventArgs e)
        {
            txtNombres.Focus();
        }
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtApellidos.Focus(); }
        }
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtCi.Focus(); }
        }
        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtTelefono.Focus(); }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; btnGuardar.Focus(); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese nombres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtCi.Text))
            {
                MessageBox.Show("Ingrese CI (Cédula de Identidad)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCi.Focus(); return;
            }

            try
            {
                string usuarioReg = "SYSTEM";
                if (Util.usuario != null && !string.IsNullOrWhiteSpace(Util.usuario.usuario1))
                {
                    usuarioReg = Util.usuario.usuario1;
                }

                var cliente = new Cliente
                {
                    nombres = txtNombres.Text.Trim(),
                    primerApellido = txtApellidos.Text.Trim(),
                    cedulaIdentidad = txtCi.Text.Trim(),
                    celular = txtTelefono.Text.Trim(),
                    direccion = "S/N",  // Por defecto
                    email = "",
                    usuarioRegistro = Util.usuario != null ? Util.usuario.usuario1 : "admin",
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };

                IdClienteCreado = ClienteCln.registrar(cliente);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { string mensajeCompleto = $"Error: {ex.Message}";
                if (ex.InnerException != null) { mensajeCompleto += $"\n\nInner Exception: {ex.InnerException.Message}";
                 if (ex.InnerException.InnerException != null) { mensajeCompleto += $"\n\nInner Exception 2: {ex.InnerException.InnerException.Message}";
                    }
                }
                MessageBox.Show(mensajeCompleto, "Error Detallado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}