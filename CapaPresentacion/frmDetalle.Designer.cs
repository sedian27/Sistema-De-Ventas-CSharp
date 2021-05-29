
namespace CapaPresentacion
{
    partial class frmDetalle
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
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.clCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AllowUserToOrderColumns = true;
            this.DgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCliente,
            this.clProducto,
            this.clCantidad,
            this.clTotal});
            this.DgvDetalle.GridColor = System.Drawing.SystemColors.Window;
            this.DgvDetalle.Location = new System.Drawing.Point(12, 12);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.RowHeadersWidth = 51;
            this.DgvDetalle.RowTemplate.Height = 24;
            this.DgvDetalle.Size = new System.Drawing.Size(1322, 833);
            this.DgvDetalle.TabIndex = 0;
            // 
            // clCliente
            // 
            this.clCliente.FillWeight = 108.11F;
            this.clCliente.HeaderText = "Cliente";
            this.clCliente.MinimumWidth = 6;
            this.clCliente.Name = "clCliente";
            this.clCliente.ReadOnly = true;
            // 
            // clProducto
            // 
            this.clProducto.FillWeight = 244.8706F;
            this.clProducto.HeaderText = "Producto";
            this.clProducto.MinimumWidth = 6;
            this.clProducto.Name = "clProducto";
            this.clProducto.ReadOnly = true;
            // 
            // clCantidad
            // 
            this.clCantidad.FillWeight = 25.67546F;
            this.clCantidad.HeaderText = "Cantidad";
            this.clCantidad.MinimumWidth = 6;
            this.clCantidad.Name = "clCantidad";
            this.clCantidad.ReadOnly = true;
            // 
            // clTotal
            // 
            this.clTotal.FillWeight = 25.67546F;
            this.clTotal.HeaderText = "Total S/";
            this.clTotal.MinimumWidth = 6;
            this.clTotal.Name = "clTotal";
            this.clTotal.ReadOnly = true;
            // 
            // frmDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(1352, 856);
            this.Controls.Add(this.DgvDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTotal;
    }
}