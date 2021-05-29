
namespace CapaPresentacion
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.Arrow = new System.Windows.Forms.PictureBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.Ventas = new System.Windows.Forms.PictureBox();
            this.Entradas = new System.Windows.Forms.PictureBox();
            this.Deudores = new System.Windows.Forms.PictureBox();
            this.Clientes = new System.Windows.Forms.PictureBox();
            this.Productos = new System.Windows.Forms.PictureBox();
            this.RegistroVentas = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Arrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Entradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deudores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistroVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Arrow
            // 
            this.Arrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Arrow.Image = global::CapaPresentacion.Properties.Resources.right_arrow;
            this.Arrow.Location = new System.Drawing.Point(4, 45);
            this.Arrow.Margin = new System.Windows.Forms.Padding(4);
            this.Arrow.Name = "Arrow";
            this.Arrow.Size = new System.Drawing.Size(56, 47);
            this.Arrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Arrow.TabIndex = 1;
            this.Arrow.TabStop = false;
            this.Arrow.Visible = false;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Close.Image = global::CapaPresentacion.Properties.Resources._041_signboard;
            this.Close.Location = new System.Drawing.Point(68, 727);
            this.Close.Margin = new System.Windows.Forms.Padding(4);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(127, 111);
            this.Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close.TabIndex = 1;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Ventas
            // 
            this.Ventas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Ventas.Image = global::CapaPresentacion.Properties.Resources._001_paper;
            this.Ventas.Location = new System.Drawing.Point(68, 608);
            this.Ventas.Margin = new System.Windows.Forms.Padding(4);
            this.Ventas.Name = "Ventas";
            this.Ventas.Size = new System.Drawing.Size(127, 111);
            this.Ventas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ventas.TabIndex = 1;
            this.Ventas.TabStop = false;
            this.Ventas.Click += new System.EventHandler(this.Ventas_Click);
            // 
            // Entradas
            // 
            this.Entradas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Entradas.Image = global::CapaPresentacion.Properties.Resources._026_open_box;
            this.Entradas.Location = new System.Drawing.Point(68, 489);
            this.Entradas.Margin = new System.Windows.Forms.Padding(4);
            this.Entradas.Name = "Entradas";
            this.Entradas.Size = new System.Drawing.Size(127, 111);
            this.Entradas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Entradas.TabIndex = 1;
            this.Entradas.TabStop = false;
            // 
            // Deudores
            // 
            this.Deudores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Deudores.Image = global::CapaPresentacion.Properties.Resources._010_banknote;
            this.Deudores.Location = new System.Drawing.Point(68, 370);
            this.Deudores.Margin = new System.Windows.Forms.Padding(4);
            this.Deudores.Name = "Deudores";
            this.Deudores.Size = new System.Drawing.Size(127, 111);
            this.Deudores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Deudores.TabIndex = 1;
            this.Deudores.TabStop = false;
            // 
            // Clientes
            // 
            this.Clientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Clientes.Image = global::CapaPresentacion.Properties.Resources._014_id_card;
            this.Clientes.Location = new System.Drawing.Point(68, 251);
            this.Clientes.Margin = new System.Windows.Forms.Padding(4);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(127, 111);
            this.Clientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Clientes.TabIndex = 1;
            this.Clientes.TabStop = false;
            this.Clientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // Productos
            // 
            this.Productos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.Productos.Image = global::CapaPresentacion.Properties.Resources._028_parcel;
            this.Productos.Location = new System.Drawing.Point(68, 132);
            this.Productos.Margin = new System.Windows.Forms.Padding(4);
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(127, 111);
            this.Productos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Productos.TabIndex = 1;
            this.Productos.TabStop = false;
            this.Productos.Click += new System.EventHandler(this.Productos_Click);
            // 
            // RegistroVentas
            // 
            this.RegistroVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.RegistroVentas.Image = ((System.Drawing.Image)(resources.GetObject("RegistroVentas.Image")));
            this.RegistroVentas.Location = new System.Drawing.Point(68, 13);
            this.RegistroVentas.Margin = new System.Windows.Forms.Padding(4);
            this.RegistroVentas.Name = "RegistroVentas";
            this.RegistroVentas.Size = new System.Drawing.Size(127, 111);
            this.RegistroVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RegistroVentas.TabIndex = 1;
            this.RegistroVentas.TabStop = false;
            this.RegistroVentas.Click += new System.EventHandler(this.RegistroVentas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.pictureBox1.Location = new System.Drawing.Point(-19, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 856);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.Location = new System.Drawing.Point(275, -2);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1345, 856);
            this.PanelContenedor.TabIndex = 2;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(1620, 850);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.Arrow);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Ventas);
            this.Controls.Add(this.Entradas);
            this.Controls.Add(this.Deudores);
            this.Controls.Add(this.Clientes);
            this.Controls.Add(this.Productos);
            this.Controls.Add(this.RegistroVentas);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Arrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Entradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deudores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistroVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox RegistroVentas;
        private System.Windows.Forms.PictureBox Arrow;
        private System.Windows.Forms.PictureBox Productos;
        private System.Windows.Forms.PictureBox Clientes;
        private System.Windows.Forms.PictureBox Deudores;
        private System.Windows.Forms.PictureBox Entradas;
        private System.Windows.Forms.PictureBox Ventas;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.Panel PanelContenedor;
    }
}