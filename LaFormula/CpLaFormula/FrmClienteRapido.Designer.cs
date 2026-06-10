namespace CpLaFormula
{
    partial class FrmClienteRapido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblCi = new System.Windows.Forms.Label();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblNombres & txtNombres
            this.lblNombres.AutoSize = true; this.lblNombres.Location = new System.Drawing.Point(12, 15); this.lblNombres.Text = "Nombres:";
            this.txtNombres.Location = new System.Drawing.Point(90, 12); this.txtNombres.Size = new System.Drawing.Size(250, 20);
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);

            // lblApellidos & txtApellidos
            this.lblApellidos.AutoSize = true; this.lblApellidos.Location = new System.Drawing.Point(12, 45); this.lblApellidos.Text = "Apellidos:";
            this.txtApellidos.Location = new System.Drawing.Point(90, 42); this.txtApellidos.Size = new System.Drawing.Size(250, 20);
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidos_KeyPress);

            // lblCi & txtCi
            this.lblCi.AutoSize = true; this.lblCi.Location = new System.Drawing.Point(12, 75); this.lblCi.Text = "CI:";
            this.txtCi.Location = new System.Drawing.Point(90, 72); this.txtCi.Size = new System.Drawing.Size(250, 20);
            this.txtCi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCi_KeyPress);

            // lblTelefono & txtTelefono
            this.lblTelefono.AutoSize = true; this.lblTelefono.Location = new System.Drawing.Point(12, 105); this.lblTelefono.Text = "Teléfono:";
            this.txtTelefono.Location = new System.Drawing.Point(90, 102); this.txtTelefono.Size = new System.Drawing.Size(250, 20);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(90, 140); this.btnGuardar.Size = new System.Drawing.Size(100, 30); this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(200, 140); this.btnCancelar.Size = new System.Drawing.Size(100, 30); this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FrmClienteRapido
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 190);
            this.Controls.Add(this.lblNombres); this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblApellidos); this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.lblCi); this.Controls.Add(this.txtCi);
            this.Controls.Add(this.lblTelefono); this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnGuardar); this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.Name = "FrmClienteRapido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Cliente";
            this.Load += new System.EventHandler(this.FrmClienteRapido_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblCi;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}