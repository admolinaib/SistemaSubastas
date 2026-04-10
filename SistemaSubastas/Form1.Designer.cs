namespace SistemaSubastas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvSubastas = new System.Windows.Forms.DataGridView();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnOfertar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblPrecioFinal = new System.Windows.Forms.Label();
            this.lblGanador = new System.Windows.Forms.Label();
            this.cmbTipoSubasta = new System.Windows.Forms.ComboBox();
            this.cmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.btnCrearSubasta = new System.Windows.Forms.Button();
            this.lblTipoSubasta = new System.Windows.Forms.Label();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.timerSubasta = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubastas
            // 
            this.dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubastas.Location = new System.Drawing.Point(188, 102);
            this.dgvSubastas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSubastas.Name = "dgvSubastas";
            this.dgvSubastas.ReadOnly = true;
            this.dgvSubastas.RowTemplate.Height = 24;
            this.dgvSubastas.Size = new System.Drawing.Size(332, 144);
            this.dgvSubastas.TabIndex = 0;
            this.dgvSubastas.Visible = false;
            this.dgvSubastas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubastas_CellClick);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(230, 312);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(76, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.Visible = false;
            // 
            // btnOfertar
            // 
            this.btnOfertar.Location = new System.Drawing.Point(366, 311);
            this.btnOfertar.Margin = new System.Windows.Forms.Padding(2);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(56, 19);
            this.btnOfertar.TabIndex = 2;
            this.btnOfertar.Text = "Ofertar";
            this.btnOfertar.UseVisualStyleBackColor = true;
            this.btnOfertar.Visible = false;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(134, 278);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 4;
            this.lblProducto.Text = "Producto";
            this.lblProducto.Visible = false;
            // 
            // lblPrecioFinal
            // 
            this.lblPrecioFinal.AutoSize = true;
            this.lblPrecioFinal.Location = new System.Drawing.Point(134, 317);
            this.lblPrecioFinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecioFinal.Name = "lblPrecioFinal";
            this.lblPrecioFinal.Size = new System.Drawing.Size(59, 13);
            this.lblPrecioFinal.TabIndex = 5;
            this.lblPrecioFinal.Text = "Precio final";
            this.lblPrecioFinal.Visible = false;
            // 
            // lblGanador
            // 
            this.lblGanador.AutoSize = true;
            this.lblGanador.Location = new System.Drawing.Point(134, 354);
            this.lblGanador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGanador.Name = "lblGanador";
            this.lblGanador.Size = new System.Drawing.Size(48, 13);
            this.lblGanador.TabIndex = 6;
            this.lblGanador.Text = "Ganador";
            this.lblGanador.Visible = false;
            // 
            // cmbTipoSubasta
            // 
            this.cmbTipoSubasta.FormattingEnabled = true;
            this.cmbTipoSubasta.Location = new System.Drawing.Point(136, 31);
            this.cmbTipoSubasta.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoSubasta.Name = "cmbTipoSubasta";
            this.cmbTipoSubasta.Size = new System.Drawing.Size(92, 21);
            this.cmbTipoSubasta.TabIndex = 7;
            this.cmbTipoSubasta.SelectedIndexChanged += new System.EventHandler(this.cmbTipoSubasta_SelectedIndexChanged);
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new System.Drawing.Point(386, 31);
            this.cmbTipoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new System.Drawing.Size(92, 21);
            this.cmbTipoProducto.TabIndex = 8;
            this.cmbTipoProducto.Visible = false;
            this.cmbTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProducto_SelectedIndexChanged);
            // 
            // btnCrearSubasta
            // 
            this.btnCrearSubasta.Location = new System.Drawing.Point(532, 28);
            this.btnCrearSubasta.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearSubasta.Name = "btnCrearSubasta";
            this.btnCrearSubasta.Size = new System.Drawing.Size(89, 24);
            this.btnCrearSubasta.TabIndex = 9;
            this.btnCrearSubasta.Text = "Crear subasta";
            this.btnCrearSubasta.UseVisualStyleBackColor = true;
            this.btnCrearSubasta.Visible = false;
            this.btnCrearSubasta.Click += new System.EventHandler(this.btnCrearSubasta_Click);
            // 
            // lblTipoSubasta
            // 
            this.lblTipoSubasta.AutoSize = true;
            this.lblTipoSubasta.Location = new System.Drawing.Point(28, 33);
            this.lblTipoSubasta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoSubasta.Name = "lblTipoSubasta";
            this.lblTipoSubasta.Size = new System.Drawing.Size(86, 13);
            this.lblTipoSubasta.TabIndex = 10;
            this.lblTipoSubasta.Text = "Tipo de subasta:";
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(278, 33);
            this.lblTipoProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(91, 13);
            this.lblTipoProducto.TabIndex = 11;
            this.lblTipoProducto.Text = "Tipo de producto:";
            this.lblTipoProducto.Visible = false;
            // 
            // timerSubasta
            // 
            this.timerSubasta.Enabled = true;
            this.timerSubasta.Interval = 1000;
            this.timerSubasta.Tick += new System.EventHandler(this.timerSubasta_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 441);
            this.Controls.Add(this.lblTipoProducto);
            this.Controls.Add(this.lblTipoSubasta);
            this.Controls.Add(this.btnCrearSubasta);
            this.Controls.Add(this.cmbTipoProducto);
            this.Controls.Add(this.cmbTipoSubasta);
            this.Controls.Add(this.lblGanador);
            this.Controls.Add(this.lblPrecioFinal);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.btnOfertar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dgvSubastas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnOfertar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblPrecioFinal;
        private System.Windows.Forms.Label lblGanador;
        private System.Windows.Forms.ComboBox cmbTipoSubasta;
        private System.Windows.Forms.ComboBox cmbTipoProducto;
        private System.Windows.Forms.Button btnCrearSubasta;
        private System.Windows.Forms.Label lblTipoSubasta;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.Timer timerSubasta;
    }
}

