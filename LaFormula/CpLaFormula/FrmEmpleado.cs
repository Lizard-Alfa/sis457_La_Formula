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
    public partial class FrmEmpleado : Form
    {
        private bool esNuevo = false;
        public FrmEmpleado()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = EmpleadoCln.listarEn(txtParametro.Text);
            dgvListar.DataSource = lista;
            dgvListar.Columns["id"].Visible = false;
            dgvListar.Columns["cedulaIdentidad"].HeaderText = "Cédula de Identidad";
            dgvListar.Columns["nombres"].HeaderText = "Nombres";
            dgvListar.Columns["primerApellido"].HeaderText = "Primer Apellido";
            dgvListar.Columns["segundoApellido"].HeaderText = "Segundo Apellido";
            dgvListar.Columns["fechaNacimiento"].HeaderText = "Fecha de Nacimiento";
            dgvListar.Columns["direccion"].HeaderText = "Dirección";
            dgvListar.Columns["celular"].HeaderText = "Celular";
            dgvListar.Columns["cargo"].HeaderText = "Cargo";
            if (lista.Count > 0) dgvListar.CurrentCell = dgvListar.Rows[0].Cells["cedulaIdentidad"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            Size = new Size(1116, 463);
            listar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnAcionesEm.Enabled = false;
            Size = new Size(1116, 610);
            limpiar();
            txtCedulaIdentidad.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnAcionesEm.Enabled = false;
            Size = new Size(1116, 610);
            resetearErrores();
            int id = (int)dgvListar.CurrentRow.Cells["id"].Value;
            var empleado = EmpleadoCln.obtenerUno(id);
            txtCedulaIdentidad.Text = empleado.cedulaIdentidad;
            txtNombre.Text = empleado.nombres;
            txtPrimerApellido.Text = empleado.primerApellido;
            txtSegundoApellido.Text = empleado.segundoApellido;
            dtpFechaNaciemiento.Value = empleado.fechaNacimiento;
            txtDireccion.Text = empleado.direccion;
            txtCelular.Text = empleado.celular;
            txtCargo.Text = empleado.cargo;

            txtCedulaIdentidad.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnAcionesEm.Enabled = true;
            Size = new Size(1116, 463);
        }
        private bool validar()
        {
            bool esValido = true;
            resetearErrores();

            if (string.IsNullOrWhiteSpace(txtCedulaIdentidad.Text))
            {
                erpCi.SetError(txtCedulaIdentidad, "La cedula de identidad es obligatoria");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El nombre es obligatorio");
                esValido = false;
            }
            // Comparamos la fecha seleccionada con la fecha actual
            if (dtpFechaNaciemiento.Value.Date == DateTime.Now.Date)
            {
                erpFechaNaciento.SetError(dtpFechaNaciemiento, "Debe seleccionar una fecha de nacimiento válida (no puede ser hoy)");
                esValido = false;
            }
            else if (DateTime.Now.Year - dtpFechaNaciemiento.Value.Year < 18)
            {
                // Opcional: Validar que sea mayor de 18 años
                erpFechaNaciento.SetError(dtpFechaNaciemiento, "El empleado debe ser mayor de edad");
                esValido = false;
            }
            else
            {
                // Si todo está bien, limpiamos el error
                erpFechaNaciento.SetError(dtpFechaNaciemiento, "");
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                erpDireccion.SetError(txtDireccion, "La dirección es obligatoria");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                erpCelular.SetError(txtCelular, "El numero de celular es obligatorio");
                esValido = false;
            }
            return esValido;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string ciIngresada = txtCedulaIdentidad.Text.Trim();
                int idActual = esNuevo ? 0 : (int)dgvListar.CurrentRow.Cells["id"].Value;

                // VALIDACIÓN: ¿Hay otro empleado ACTIVO con esta cédula?
                using (var db = new LabLaFormulaEntities())
                {
                    // Buscamos si alguien más tiene esta CI y está activo (estado 1)
                    bool yaExisteActivo = db.Empleado.Any(x => x.cedulaIdentidad == ciIngresada &&
                                                              x.id != idActual &&
                                                              x.estado == 1);

                    if (yaExisteActivo)
                    {
                        MessageBox.Show("Error: Ya existe un empleado activo con esta Cédula.",
                            "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCedulaIdentidad.Focus();
                        return; // Detenemos el guardado
                    }
                }
                var empleado = new Empleado()
                {
                    cedulaIdentidad = txtCedulaIdentidad.Text.Trim(),
                    nombres = txtNombre.Text.Trim(),
                    primerApellido = txtPrimerApellido.Text.Trim(),
                    segundoApellido = txtSegundoApellido.Text.Trim(),
                    fechaNacimiento = dtpFechaNaciemiento.Value.Date,
                    direccion = txtDireccion.Text.Trim(),
                    celular = txtCelular.Text.Trim(),
                    cargo = txtCargo.Text.Trim(),
                    usuarioRegistro = Util.usuario.usuario1
                };

                if (esNuevo)
                {
                    empleado.fechaRegistro = DateTime.Now;
                    empleado.estado = 1;
                    EmpleadoCln.crear(empleado);
                }
                else
                {
                    empleado.id = (int)dgvListar.CurrentRow.Cells["id"].Value;
                    EmpleadoCln.modificar(empleado);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Empleado guardado correctamente", "::: Mensaje - La Formula :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
        private void resetearErrores()
        {
            erpCi.Clear();
            erpNombre.Clear();
            erpCelular.Clear();
            erpDireccion.Clear();
            erpFechaNaciento.Clear();
        }
        private void limpiar()
        {
            txtCedulaIdentidad.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            dtpFechaNaciemiento.Value = DateTime.Now;
            txtDireccion.Clear();
            txtCelular.Clear();
            txtCargo.Clear();
            resetearErrores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            int id = (int)dgvListar.CurrentRow.Cells["id"].Value;
            string cedulaIdentendad = dgvListar.CurrentRow.Cells["cedulaIdentidad"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"Está seguro que desea eliminar el empleado {cedulaIdentendad}",
                "::: Mensaje - La Formula :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                EmpleadoCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Empleado dado de baja correctamente", "::: Mensaje - La Formula :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
}
