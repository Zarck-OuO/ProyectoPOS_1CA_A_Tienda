namespace ProyectoPOS_1CA_A.CapaPresentacion
{
    partial class FrmPruebas
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
            this.btnStock = new System.Windows.Forms.Button();
            this.btnClientesActivos = new System.Windows.Forms.Button();
            this.btnProbarPagos = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnValidarVentas = new System.Windows.Forms.Button();
            this.btnPruebaVentaRapida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Location = new System.Drawing.Point(45, 22);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(115, 41);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnClientesActivos
            // 
            this.btnClientesActivos.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientesActivos.Location = new System.Drawing.Point(181, 22);
            this.btnClientesActivos.Name = "btnClientesActivos";
            this.btnClientesActivos.Size = new System.Drawing.Size(115, 41);
            this.btnClientesActivos.TabIndex = 1;
            this.btnClientesActivos.Text = "Clientes Activos";
            this.btnClientesActivos.UseVisualStyleBackColor = true;
            this.btnClientesActivos.Click += new System.EventHandler(this.btnClientesActivos_Click);
            // 
            // btnProbarPagos
            // 
            this.btnProbarPagos.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbarPagos.Location = new System.Drawing.Point(317, 22);
            this.btnProbarPagos.Name = "btnProbarPagos";
            this.btnProbarPagos.Size = new System.Drawing.Size(115, 41);
            this.btnProbarPagos.TabIndex = 3;
            this.btnProbarPagos.Text = "Probar Pagos";
            this.btnProbarPagos.UseVisualStyleBackColor = true;
            this.btnProbarPagos.Click += new System.EventHandler(this.btnProbarPagos_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(181, 192);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 41);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnValidarVentas
            // 
            this.btnValidarVentas.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarVentas.Location = new System.Drawing.Point(55, 83);
            this.btnValidarVentas.Name = "btnValidarVentas";
            this.btnValidarVentas.Size = new System.Drawing.Size(115, 64);
            this.btnValidarVentas.TabIndex = 6;
            this.btnValidarVentas.Text = "Validar Ventas";
            this.btnValidarVentas.UseVisualStyleBackColor = true;
            this.btnValidarVentas.Click += new System.EventHandler(this.btnValidarVentas_Click);
            // 
            // btnPruebaVentaRapida
            // 
            this.btnPruebaVentaRapida.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPruebaVentaRapida.Location = new System.Drawing.Point(181, 83);
            this.btnPruebaVentaRapida.Name = "btnPruebaVentaRapida";
            this.btnPruebaVentaRapida.Size = new System.Drawing.Size(115, 64);
            this.btnPruebaVentaRapida.TabIndex = 7;
            this.btnPruebaVentaRapida.Text = "Pruba de Venta";
            this.btnPruebaVentaRapida.UseVisualStyleBackColor = true;
            this.btnPruebaVentaRapida.Click += new System.EventHandler(this.btnPruebaVentaRapida_Click);
            // 
            // FrmPruebas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 282);
            this.Controls.Add(this.btnPruebaVentaRapida);
            this.Controls.Add(this.btnValidarVentas);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnProbarPagos);
            this.Controls.Add(this.btnClientesActivos);
            this.Controls.Add(this.btnStock);
            this.Name = "FrmPruebas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPruebas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnClientesActivos;
        private System.Windows.Forms.Button btnProbarPagos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnValidarVentas;
        private System.Windows.Forms.Button btnPruebaVentaRapida;
    }
}