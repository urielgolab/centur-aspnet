namespace Servicios
{
    partial class wTren
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wTren));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSolapas = new System.Windows.Forms.TabControl();
            this.tbDatosGenerales = new System.Windows.Forms.TabPage();
            this.dgTren = new System.Windows.Forms.DataGridView();
            this.tbProgramacion = new System.Windows.Forms.TabPage();
            this.grdActProg = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.grdPasadasProg = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFicha = new System.Windows.Forms.TabPage();
            this.dgFicha = new System.Windows.Forms.DataGridView();
            this.tbFormacion = new System.Windows.Forms.TabPage();
            this.grdPersonal = new System.Windows.Forms.DataGridView();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.grdUFT = new System.Windows.Forms.DataGridView();
            this.lblUFT = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grdEquipos = new System.Windows.Forms.DataGridView();
            this.tbPasadas = new System.Windows.Forms.TabPage();
            this.dgPasadas = new System.Windows.Forms.DataGridView();
            this.tbAsignaciones = new System.Windows.Forms.TabPage();
            this.grdAsignaciones = new System.Windows.Forms.DataGridView();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.dgLog = new System.Windows.Forms.DataGridView();
            this.tbSolapas.SuspendLayout();
            this.tbDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTren)).BeginInit();
            this.tbProgramacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActProg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPasadasProg)).BeginInit();
            this.tbFicha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFicha)).BeginInit();
            this.tbFormacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEquipos)).BeginInit();
            this.tbPasadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPasadas)).BeginInit();
            this.tbAsignaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsignaciones)).BeginInit();
            this.tbLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datos del Tren";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ultima Ficha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pasadas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Log de Transacciones";
            // 
            // tbSolapas
            // 
            this.tbSolapas.Controls.Add(this.tbDatosGenerales);
            this.tbSolapas.Controls.Add(this.tbProgramacion);
            this.tbSolapas.Controls.Add(this.tbFicha);
            this.tbSolapas.Controls.Add(this.tbFormacion);
            this.tbSolapas.Controls.Add(this.tbPasadas);
            this.tbSolapas.Controls.Add(this.tbAsignaciones);
            this.tbSolapas.Controls.Add(this.tbLog);
            this.tbSolapas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSolapas.Location = new System.Drawing.Point(0, 0);
            this.tbSolapas.Name = "tbSolapas";
            this.tbSolapas.SelectedIndex = 0;
            this.tbSolapas.Size = new System.Drawing.Size(791, 497);
            this.tbSolapas.TabIndex = 8;
            // 
            // tbDatosGenerales
            // 
            this.tbDatosGenerales.Controls.Add(this.dgTren);
            this.tbDatosGenerales.Location = new System.Drawing.Point(4, 22);
            this.tbDatosGenerales.Name = "tbDatosGenerales";
            this.tbDatosGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tbDatosGenerales.Size = new System.Drawing.Size(783, 471);
            this.tbDatosGenerales.TabIndex = 0;
            this.tbDatosGenerales.Text = "Datos Generales";
            this.tbDatosGenerales.UseVisualStyleBackColor = true;
            this.tbDatosGenerales.Enter += new System.EventHandler(this.tbDatosGenerales_Enter);
            // 
            // dgTren
            // 
            this.dgTren.AllowUserToAddRows = false;
            this.dgTren.AllowUserToDeleteRows = false;
            this.dgTren.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgTren.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTren.ColumnHeadersVisible = false;
            this.dgTren.Location = new System.Drawing.Point(8, 6);
            this.dgTren.Name = "dgTren";
            this.dgTren.ReadOnly = true;
            this.dgTren.RowHeadersVisible = false;
            this.dgTren.Size = new System.Drawing.Size(769, 457);
            this.dgTren.TabIndex = 1;
            // 
            // tbProgramacion
            // 
            this.tbProgramacion.Controls.Add(this.grdActProg);
            this.tbProgramacion.Controls.Add(this.label8);
            this.tbProgramacion.Controls.Add(this.grdPasadasProg);
            this.tbProgramacion.Controls.Add(this.label9);
            this.tbProgramacion.Location = new System.Drawing.Point(4, 22);
            this.tbProgramacion.Name = "tbProgramacion";
            this.tbProgramacion.Padding = new System.Windows.Forms.Padding(3);
            this.tbProgramacion.Size = new System.Drawing.Size(783, 471);
            this.tbProgramacion.TabIndex = 6;
            this.tbProgramacion.Text = "Programación";
            this.tbProgramacion.UseVisualStyleBackColor = true;
            this.tbProgramacion.Enter += new System.EventHandler(this.tbProgramacion_Enter);
            // 
            // grdActProg
            // 
            this.grdActProg.AllowUserToAddRows = false;
            this.grdActProg.AllowUserToDeleteRows = false;
            this.grdActProg.AllowUserToOrderColumns = true;
            this.grdActProg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdActProg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdActProg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdActProg.Location = new System.Drawing.Point(0, 257);
            this.grdActProg.Name = "grdActProg";
            this.grdActProg.ReadOnly = true;
            this.grdActProg.RowHeadersVisible = false;
            this.grdActProg.Size = new System.Drawing.Size(780, 195);
            this.grdActProg.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label8.Location = new System.Drawing.Point(6, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Actividades Programadas";
            // 
            // grdPasadasProg
            // 
            this.grdPasadasProg.AllowUserToAddRows = false;
            this.grdPasadasProg.AllowUserToDeleteRows = false;
            this.grdPasadasProg.AllowUserToOrderColumns = true;
            this.grdPasadasProg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPasadasProg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPasadasProg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPasadasProg.Location = new System.Drawing.Point(0, 36);
            this.grdPasadasProg.Name = "grdPasadasProg";
            this.grdPasadasProg.ReadOnly = true;
            this.grdPasadasProg.RowHeadersVisible = false;
            this.grdPasadasProg.Size = new System.Drawing.Size(780, 180);
            this.grdPasadasProg.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label9.Location = new System.Drawing.Point(6, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "Pasadas Programadas";
            // 
            // tbFicha
            // 
            this.tbFicha.Controls.Add(this.dgFicha);
            this.tbFicha.Location = new System.Drawing.Point(4, 22);
            this.tbFicha.Name = "tbFicha";
            this.tbFicha.Padding = new System.Windows.Forms.Padding(3);
            this.tbFicha.Size = new System.Drawing.Size(783, 471);
            this.tbFicha.TabIndex = 1;
            this.tbFicha.Text = "Ficha";
            this.tbFicha.UseVisualStyleBackColor = true;
            this.tbFicha.Enter += new System.EventHandler(this.tbFicha_Enter);
            // 
            // dgFicha
            // 
            this.dgFicha.AllowUserToAddRows = false;
            this.dgFicha.AllowUserToDeleteRows = false;
            this.dgFicha.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgFicha.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgFicha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgFicha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFicha.ColumnHeadersVisible = false;
            this.dgFicha.Location = new System.Drawing.Point(3, 6);
            this.dgFicha.Name = "dgFicha";
            this.dgFicha.ReadOnly = true;
            this.dgFicha.RowHeadersVisible = false;
            this.dgFicha.Size = new System.Drawing.Size(772, 459);
            this.dgFicha.TabIndex = 5;
            // 
            // tbFormacion
            // 
            this.tbFormacion.Controls.Add(this.grdPersonal);
            this.tbFormacion.Controls.Add(this.lblPersonal);
            this.tbFormacion.Controls.Add(this.grdUFT);
            this.tbFormacion.Controls.Add(this.lblUFT);
            this.tbFormacion.Controls.Add(this.label5);
            this.tbFormacion.Controls.Add(this.grdEquipos);
            this.tbFormacion.Location = new System.Drawing.Point(4, 22);
            this.tbFormacion.Name = "tbFormacion";
            this.tbFormacion.Padding = new System.Windows.Forms.Padding(3);
            this.tbFormacion.Size = new System.Drawing.Size(783, 471);
            this.tbFormacion.TabIndex = 5;
            this.tbFormacion.Text = "Detalle Formación";
            this.tbFormacion.UseVisualStyleBackColor = true;
            this.tbFormacion.Enter += new System.EventHandler(this.tbFormacion_Enter);
            // 
            // grdPersonal
            // 
            this.grdPersonal.AllowUserToAddRows = false;
            this.grdPersonal.AllowUserToDeleteRows = false;
            this.grdPersonal.AllowUserToOrderColumns = true;
            this.grdPersonal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPersonal.Location = new System.Drawing.Point(0, 331);
            this.grdPersonal.Name = "grdPersonal";
            this.grdPersonal.ReadOnly = true;
            this.grdPersonal.RowHeadersVisible = false;
            this.grdPersonal.Size = new System.Drawing.Size(780, 115);
            this.grdPersonal.TabIndex = 6;
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.lblPersonal.Location = new System.Drawing.Point(6, 310);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(62, 18);
            this.lblPersonal.TabIndex = 5;
            this.lblPersonal.Text = "Personal";
            // 
            // grdUFT
            // 
            this.grdUFT.AllowUserToAddRows = false;
            this.grdUFT.AllowUserToDeleteRows = false;
            this.grdUFT.AllowUserToOrderColumns = true;
            this.grdUFT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUFT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdUFT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUFT.Location = new System.Drawing.Point(0, 174);
            this.grdUFT.Name = "grdUFT";
            this.grdUFT.ReadOnly = true;
            this.grdUFT.RowHeadersVisible = false;
            this.grdUFT.Size = new System.Drawing.Size(780, 115);
            this.grdUFT.TabIndex = 4;
            // 
            // lblUFT
            // 
            this.lblUFT.AutoSize = true;
            this.lblUFT.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.lblUFT.Location = new System.Drawing.Point(6, 153);
            this.lblUFT.Name = "lblUFT";
            this.lblUFT.Size = new System.Drawing.Size(43, 18);
            this.lblUFT.TabIndex = 3;
            this.lblUFT.Text = "UFTs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Equipos";
            // 
            // grdEquipos
            // 
            this.grdEquipos.AllowUserToAddRows = false;
            this.grdEquipos.AllowUserToDeleteRows = false;
            this.grdEquipos.AllowUserToOrderColumns = true;
            this.grdEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEquipos.Location = new System.Drawing.Point(0, 27);
            this.grdEquipos.Name = "grdEquipos";
            this.grdEquipos.ReadOnly = true;
            this.grdEquipos.RowHeadersVisible = false;
            this.grdEquipos.Size = new System.Drawing.Size(780, 115);
            this.grdEquipos.TabIndex = 0;
            // 
            // tbPasadas
            // 
            this.tbPasadas.Controls.Add(this.dgPasadas);
            this.tbPasadas.Location = new System.Drawing.Point(4, 22);
            this.tbPasadas.Name = "tbPasadas";
            this.tbPasadas.Size = new System.Drawing.Size(783, 471);
            this.tbPasadas.TabIndex = 2;
            this.tbPasadas.Text = "Pasadas, Actividades y Observaciones";
            this.tbPasadas.UseVisualStyleBackColor = true;
            this.tbPasadas.Enter += new System.EventHandler(this.tbPasadas_Enter);
            // 
            // dgPasadas
            // 
            this.dgPasadas.AllowUserToAddRows = false;
            this.dgPasadas.AllowUserToDeleteRows = false;
            this.dgPasadas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgPasadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPasadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPasadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPasadas.Location = new System.Drawing.Point(3, 3);
            this.dgPasadas.Name = "dgPasadas";
            this.dgPasadas.ReadOnly = true;
            this.dgPasadas.RowHeadersVisible = false;
            this.dgPasadas.Size = new System.Drawing.Size(777, 465);
            this.dgPasadas.TabIndex = 8;
            this.dgPasadas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgPasadas_DataBindingComplete);
            // 
            // tbAsignaciones
            // 
            this.tbAsignaciones.Controls.Add(this.grdAsignaciones);
            this.tbAsignaciones.Location = new System.Drawing.Point(4, 22);
            this.tbAsignaciones.Name = "tbAsignaciones";
            this.tbAsignaciones.Size = new System.Drawing.Size(783, 471);
            this.tbAsignaciones.TabIndex = 3;
            this.tbAsignaciones.Text = "Asignaciones";
            this.tbAsignaciones.UseVisualStyleBackColor = true;
            this.tbAsignaciones.Enter += new System.EventHandler(this.tbAsignaciones_Enter);
            // 
            // grdAsignaciones
            // 
            this.grdAsignaciones.AllowUserToAddRows = false;
            this.grdAsignaciones.AllowUserToDeleteRows = false;
            this.grdAsignaciones.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdAsignaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAsignaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAsignaciones.Location = new System.Drawing.Point(3, 3);
            this.grdAsignaciones.Name = "grdAsignaciones";
            this.grdAsignaciones.RowHeadersVisible = false;
            this.grdAsignaciones.Size = new System.Drawing.Size(777, 460);
            this.grdAsignaciones.TabIndex = 0;
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.dgLog);
            this.tbLog.Location = new System.Drawing.Point(4, 22);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(783, 471);
            this.tbLog.TabIndex = 4;
            this.tbLog.Text = "Log";
            this.tbLog.UseVisualStyleBackColor = true;
            this.tbLog.Enter += new System.EventHandler(this.tbLog_Enter);
            // 
            // dgLog
            // 
            this.dgLog.AllowUserToAddRows = false;
            this.dgLog.AllowUserToDeleteRows = false;
            this.dgLog.AllowUserToOrderColumns = true;
            this.dgLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLog.Location = new System.Drawing.Point(3, 3);
            this.dgLog.Name = "dgLog";
            this.dgLog.ReadOnly = true;
            this.dgLog.RowHeadersVisible = false;
            this.dgLog.Size = new System.Drawing.Size(777, 460);
            this.dgLog.TabIndex = 8;
            this.dgLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgLog_DataBindingComplete);
            // 
            // wTren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 497);
            this.Controls.Add(this.tbSolapas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wTren";
            this.Text = "Detalles del Tren";
            this.Load += new System.EventHandler(this.wTren_Load);
            this.tbSolapas.ResumeLayout(false);
            this.tbDatosGenerales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTren)).EndInit();
            this.tbProgramacion.ResumeLayout(false);
            this.tbProgramacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActProg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPasadasProg)).EndInit();
            this.tbFicha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFicha)).EndInit();
            this.tbFormacion.ResumeLayout(false);
            this.tbFormacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEquipos)).EndInit();
            this.tbPasadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPasadas)).EndInit();
            this.tbAsignaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAsignaciones)).EndInit();
            this.tbLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tbSolapas;
        private System.Windows.Forms.TabPage tbDatosGenerales;
        private System.Windows.Forms.DataGridView dgTren;
        private System.Windows.Forms.TabPage tbFicha;
        private System.Windows.Forms.TabPage tbPasadas;
        private System.Windows.Forms.TabPage tbAsignaciones;
        private System.Windows.Forms.TabPage tbLog;
        private System.Windows.Forms.DataGridView dgFicha;
        private System.Windows.Forms.DataGridView dgPasadas;
        private System.Windows.Forms.DataGridView dgLog;
        private System.Windows.Forms.DataGridView grdAsignaciones;
        private System.Windows.Forms.TabPage tbFormacion;
        private System.Windows.Forms.TabPage tbProgramacion;
        private System.Windows.Forms.DataGridView grdEquipos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdUFT;
        private System.Windows.Forms.Label lblUFT;
        private System.Windows.Forms.DataGridView grdPersonal;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.DataGridView grdActProg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView grdPasadasProg;
        private System.Windows.Forms.Label label9;




    }
}