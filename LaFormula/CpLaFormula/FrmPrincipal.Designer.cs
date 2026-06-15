namespace CpLaFormula
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panelPrinci = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.c1Ribbon1 = new C1.Win.Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.Ribbon.RibbonApplicationMenu();
            this.ribbonBottomToolBar1 = new C1.Win.Ribbon.RibbonBottomToolBar();
            this.ribbonConfigToolBar1 = new C1.Win.Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.Ribbon.RibbonQat();
            this.rinInventario = new C1.Win.Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.Ribbon.RibbonGroup();
            this.btnProducto = new C1.Win.Ribbon.RibbonButton();
            this.rinAdministracion = new C1.Win.Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.Ribbon.RibbonGroup();
            this.btnEmpleados = new C1.Win.Ribbon.RibbonButton();
            this.rinCompreVenta = new C1.Win.Ribbon.RibbonTab();
            this.ribbonGroup3 = new C1.Win.Ribbon.RibbonGroup();
            this.btnCompra = new C1.Win.Ribbon.RibbonButton();
            this.btnVenta = new C1.Win.Ribbon.RibbonButton();
            this.btnRegistroVenta = new C1.Win.Ribbon.RibbonButton();
            this.ribbonTopToolBar1 = new C1.Win.Ribbon.RibbonTopToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrinci
            // 
            this.panelPrinci.BackgroundImage = global::CpLaFormula.Properties.Resources.finasl;
            this.panelPrinci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrinci.Location = new System.Drawing.Point(0, 201);
            this.panelPrinci.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPrinci.Name = "panelPrinci";
            this.panelPrinci.Size = new System.Drawing.Size(1067, 353);
            this.panelPrinci.TabIndex = 3;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Image = global::CpLaFormula.Properties.Resources.sesions;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1011, 44);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(56, 52);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1Ribbon1.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1Ribbon1.HeaderWatermark = global::CpLaFormula.Properties.Resources.Gemini_Generated_Image_fyee99fyee99fyee;
            this.c1Ribbon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.c1Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.c1Ribbon1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Size = new System.Drawing.Size(1067, 201);
            this.c1Ribbon1.Tabs.Add(this.rinInventario);
            this.c1Ribbon1.Tabs.Add(this.rinAdministracion);
            this.c1Ribbon1.Tabs.Add(this.rinCompreVenta);
            this.c1Ribbon1.TopToolBarHolder = this.ribbonTopToolBar1;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonBottomToolBar1
            // 
            this.ribbonBottomToolBar1.Name = "ribbonBottomToolBar1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // rinInventario
            // 
            this.rinInventario.Groups.Add(this.ribbonGroup1);
            this.rinInventario.Name = "rinInventario";
            this.rinInventario.Text = "Invnetario";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnProducto);
            this.ribbonGroup1.Name = "ribbonGroup1";
            // 
            // btnProducto
            // 
            this.btnProducto.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnProducto.IconSet")))));
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Text = "Productos";
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // rinAdministracion
            // 
            this.rinAdministracion.Groups.Add(this.ribbonGroup2);
            this.rinAdministracion.Name = "rinAdministracion";
            this.rinAdministracion.Text = "Administracón";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.btnEmpleados);
            this.ribbonGroup2.Name = "ribbonGroup2";
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnEmpleados.IconSet")))));
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // rinCompreVenta
            // 
            this.rinCompreVenta.Groups.Add(this.ribbonGroup3);
            this.rinCompreVenta.Name = "rinCompreVenta";
            this.rinCompreVenta.Text = "Compra y venta";
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Items.Add(this.btnCompra);
            this.ribbonGroup3.Items.Add(this.btnVenta);
            this.ribbonGroup3.Items.Add(this.btnRegistroVenta);
            this.ribbonGroup3.Name = "ribbonGroup3";
            // 
            // btnCompra
            // 
            this.btnCompra.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(33, 33), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCompra.IconSet")))));
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Text = "Compra";
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(33, 33), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnVenta.IconSet")))));
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Text = "Venta";
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnRegistroVenta
            // 
            this.btnRegistroVenta.IconSet.Add(new C1.Framework.C1BitmapIcon("RecentDocuments", new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, "Preset_LargeImages", 226));
            this.btnRegistroVenta.Name = "btnRegistroVenta";
            this.btnRegistroVenta.Text = "Registo de venta";
            this.btnRegistroVenta.Click += new System.EventHandler(this.btnRegistroVenta_Click);
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelPrinci);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.c1Ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.Ribbon.RibbonQat ribbonQat1;
        private C1.Win.Ribbon.RibbonTab rinInventario;
        private C1.Win.Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.Ribbon.RibbonTopToolBar ribbonTopToolBar1;
        private C1.Win.Ribbon.RibbonTab rinAdministracion;
        private C1.Win.Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.Ribbon.RibbonTab rinCompreVenta;
        private C1.Win.Ribbon.RibbonGroup ribbonGroup3;
        private C1.Win.Ribbon.RibbonButton btnProducto;
        private C1.Win.Ribbon.RibbonButton btnEmpleados;
        private C1.Win.Ribbon.RibbonButton btnCompra;
        private C1.Win.Ribbon.RibbonButton btnVenta;
        private C1.Win.Ribbon.RibbonButton btnRegistroVenta;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelPrinci;
    }
}