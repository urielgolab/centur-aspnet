namespace Servicios
{
    partial class wMensaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wMensaje));
            this.gEquipos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dpMensajesPrecargados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btEnviar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gEquipos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gEquipos
            // 
            this.gEquipos.AllowUserToAddRows = false;
            this.gEquipos.AllowUserToDeleteRows = false;
            this.gEquipos.AllowUserToResizeColumns = false;
            this.gEquipos.AllowUserToResizeRows = false;
            this.gEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEquipos.Location = new System.Drawing.Point(12, 12);
            this.gEquipos.MultiSelect = false;
            this.gEquipos.Name = "gEquipos";
            this.gEquipos.ReadOnly = true;
            this.gEquipos.RowHeadersVisible = false;
            this.gEquipos.Size = new System.Drawing.Size(69, 224);
            this.gEquipos.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dpMensajesPrecargados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.btEnviar);
            this.groupBox1.Controls.Add(this.txtMensaje);
            this.groupBox1.Location = new System.Drawing.Point(87, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 224);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensaje";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(359, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Max: 80 caracteres";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dpMensajesPrecargados
            // 
            this.dpMensajesPrecargados.DisplayMember = "Descripcion";
            this.dpMensajesPrecargados.FormattingEnabled = true;
            this.dpMensajesPrecargados.Location = new System.Drawing.Point(77, 188);
            this.dpMensajesPrecargados.Name = "dpMensajesPrecargados";
            this.dpMensajesPrecargados.Size = new System.Drawing.Size(228, 21);
            this.dpMensajesPrecargados.TabIndex = 7;
            this.dpMensajesPrecargados.ValueMember = "Codigo";
            this.dpMensajesPrecargados.SelectedIndexChanged += new System.EventHandler(this.dpMensajesPrecargados_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mensajes precargados:";
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(397, 178);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(61, 40);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btEnviar
            // 
            this.btEnviar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btEnviar.Location = new System.Drawing.Point(320, 178);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(61, 39);
            this.btEnviar.TabIndex = 5;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold);
            this.txtMensaje.Location = new System.Drawing.Point(6, 19);
            this.txtMensaje.MaxLength = 80;
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(452, 121);
            this.txtMensaje.TabIndex = 0;
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            // 
            // wMensaje
            // 
            this.AcceptButton = this.btEnviar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(559, 244);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gEquipos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wMensaje";
            this.Text = "Enviar Mensaje";
            this.Load += new System.EventHandler(this.wMensaje_Load);
            this.Shown += new System.EventHandler(this.wMensaje_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gEquipos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gEquipos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.ComboBox dpMensajesPrecargados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}