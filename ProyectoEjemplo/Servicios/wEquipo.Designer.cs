namespace Servicios
{
    partial class wEquipo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wEquipo));
            this.dgEquipo = new System.Windows.Forms.DataGridView();
            this.dgGeocercas = new System.Windows.Forms.DataGridView();
            this.txDetalles = new System.Windows.Forms.TextBox();
            this.btVerMapa = new System.Windows.Forms.Button();
            this.btVerTren = new System.Windows.Forms.Button();
            this.btEnviarMensaje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeocercas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEquipo
            // 
            this.dgEquipo.AllowUserToAddRows = false;
            this.dgEquipo.AllowUserToDeleteRows = false;
            this.dgEquipo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgEquipo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEquipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipo.ColumnHeadersVisible = false;
            this.dgEquipo.Location = new System.Drawing.Point(16, 265);
            this.dgEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.dgEquipo.Name = "dgEquipo";
            this.dgEquipo.ReadOnly = true;
            this.dgEquipo.RowHeadersVisible = false;
            this.dgEquipo.Size = new System.Drawing.Size(357, 384);
            this.dgEquipo.TabIndex = 2;
            // 
            // dgGeocercas
            // 
            this.dgGeocercas.AllowUserToAddRows = false;
            this.dgGeocercas.AllowUserToDeleteRows = false;
            this.dgGeocercas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgGeocercas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgGeocercas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGeocercas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGeocercas.ColumnHeadersVisible = false;
            this.dgGeocercas.Location = new System.Drawing.Point(399, 18);
            this.dgGeocercas.Margin = new System.Windows.Forms.Padding(4);
            this.dgGeocercas.Name = "dgGeocercas";
            this.dgGeocercas.ReadOnly = true;
            this.dgGeocercas.RowHeadersVisible = false;
            this.dgGeocercas.Size = new System.Drawing.Size(360, 631);
            this.dgGeocercas.TabIndex = 3;
            // 
            // txDetalles
            // 
            this.txDetalles.BackColor = System.Drawing.SystemColors.Info;
            this.txDetalles.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDetalles.Location = new System.Drawing.Point(16, 17);
            this.txDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.txDetalles.Multiline = true;
            this.txDetalles.Name = "txDetalles";
            this.txDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txDetalles.Size = new System.Drawing.Size(357, 194);
            this.txDetalles.TabIndex = 4;
            // 
            // btVerMapa
            // 
            this.btVerMapa.Location = new System.Drawing.Point(240, 218);
            this.btVerMapa.Name = "btVerMapa";
            this.btVerMapa.Size = new System.Drawing.Size(133, 37);
            this.btVerMapa.TabIndex = 10;
            this.btVerMapa.Text = "Ver en el Mapa";
            this.btVerMapa.UseVisualStyleBackColor = true;
            this.btVerMapa.Click += new System.EventHandler(this.btVerMapa_Click);
            // 
            // btVerTren
            // 
            this.btVerTren.Location = new System.Drawing.Point(148, 218);
            this.btVerTren.Name = "btVerTren";
            this.btVerTren.Size = new System.Drawing.Size(86, 37);
            this.btVerTren.TabIndex = 9;
            this.btVerTren.Text = "Ver Tren";
            this.btVerTren.UseVisualStyleBackColor = true;
            this.btVerTren.Click += new System.EventHandler(this.btVerTren_Click);
            // 
            // btEnviarMensaje
            // 
            this.btEnviarMensaje.Location = new System.Drawing.Point(16, 218);
            this.btEnviarMensaje.Name = "btEnviarMensaje";
            this.btEnviarMensaje.Size = new System.Drawing.Size(126, 37);
            this.btEnviarMensaje.TabIndex = 8;
            this.btEnviarMensaje.Text = "Enviar Mensaje";
            this.btEnviarMensaje.UseVisualStyleBackColor = true;
            this.btEnviarMensaje.Click += new System.EventHandler(this.btEnviarMensaje_Click);
            // 
            // wEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 665);
            this.Controls.Add(this.btVerMapa);
            this.Controls.Add(this.btVerTren);
            this.Controls.Add(this.btEnviarMensaje);
            this.Controls.Add(this.txDetalles);
            this.Controls.Add(this.dgGeocercas);
            this.Controls.Add(this.dgEquipo);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "wEquipo";
            this.Text = "wEquipo";
            this.Load += new System.EventHandler(this.wEquipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeocercas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEquipo;
        private System.Windows.Forms.DataGridView dgGeocercas;
        private System.Windows.Forms.TextBox txDetalles;
        private System.Windows.Forms.Button btVerMapa;
        private System.Windows.Forms.Button btVerTren;
        private System.Windows.Forms.Button btEnviarMensaje;
    }
}