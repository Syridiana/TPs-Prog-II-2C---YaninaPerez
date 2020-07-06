namespace YaninaPerez_2doC_TP4
{
    partial class FrmPpal
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
            this.groupBoxEstadoPaquetes = new System.Windows.Forms.GroupBox();
            this.lblEstadoEntregado = new System.Windows.Forms.Label();
            this.lblEstadoEnViaje = new System.Windows.Forms.Label();
            this.lblEstadoIngresado = new System.Windows.Forms.Label();
            this.listEstadoEntregado = new System.Windows.Forms.ListBox();
            this.listEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.listEstadoIngresado = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxPaquete = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingId = new System.Windows.Forms.Label();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.groupBoxEstadoPaquetes.SuspendLayout();
            this.groupBoxPaquete.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEstadoPaquetes
            // 
            this.groupBoxEstadoPaquetes.Controls.Add(this.lblEstadoEntregado);
            this.groupBoxEstadoPaquetes.Controls.Add(this.lblEstadoEnViaje);
            this.groupBoxEstadoPaquetes.Controls.Add(this.lblEstadoIngresado);
            this.groupBoxEstadoPaquetes.Controls.Add(this.listEstadoEntregado);
            this.groupBoxEstadoPaquetes.Controls.Add(this.listEstadoEnViaje);
            this.groupBoxEstadoPaquetes.Controls.Add(this.listEstadoIngresado);
            this.groupBoxEstadoPaquetes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEstadoPaquetes.Name = "groupBoxEstadoPaquetes";
            this.groupBoxEstadoPaquetes.Size = new System.Drawing.Size(776, 261);
            this.groupBoxEstadoPaquetes.TabIndex = 0;
            this.groupBoxEstadoPaquetes.TabStop = false;
            this.groupBoxEstadoPaquetes.Text = "Estados Paquetes";
            // 
            // lblEstadoEntregado
            // 
            this.lblEstadoEntregado.AutoSize = true;
            this.lblEstadoEntregado.Location = new System.Drawing.Point(523, 33);
            this.lblEstadoEntregado.Name = "lblEstadoEntregado";
            this.lblEstadoEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEstadoEntregado.TabIndex = 1;
            this.lblEstadoEntregado.Text = "Entregado";
            // 
            // lblEstadoEnViaje
            // 
            this.lblEstadoEnViaje.AutoSize = true;
            this.lblEstadoEnViaje.Location = new System.Drawing.Point(269, 33);
            this.lblEstadoEnViaje.Name = "lblEstadoEnViaje";
            this.lblEstadoEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEstadoEnViaje.TabIndex = 1;
            this.lblEstadoEnViaje.Text = "En Viaje";
            // 
            // lblEstadoIngresado
            // 
            this.lblEstadoIngresado.AutoSize = true;
            this.lblEstadoIngresado.Location = new System.Drawing.Point(16, 33);
            this.lblEstadoIngresado.Name = "lblEstadoIngresado";
            this.lblEstadoIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblEstadoIngresado.TabIndex = 1;
            this.lblEstadoIngresado.Text = "Ingresado";
            // 
            // listEstadoEntregado
            // 
            this.listEstadoEntregado.FormattingEnabled = true;
            this.listEstadoEntregado.Location = new System.Drawing.Point(523, 58);
            this.listEstadoEntregado.Name = "listEstadoEntregado";
            this.listEstadoEntregado.Size = new System.Drawing.Size(234, 186);
            this.listEstadoEntregado.TabIndex = 0;
            // 
            // listEstadoEnViaje
            // 
            this.listEstadoEnViaje.FormattingEnabled = true;
            this.listEstadoEnViaje.Location = new System.Drawing.Point(268, 58);
            this.listEstadoEnViaje.Name = "listEstadoEnViaje";
            this.listEstadoEnViaje.Size = new System.Drawing.Size(234, 186);
            this.listEstadoEnViaje.TabIndex = 0;
            // 
            // listEstadoIngresado
            // 
            this.listEstadoIngresado.FormattingEnabled = true;
            this.listEstadoIngresado.Location = new System.Drawing.Point(16, 58);
            this.listEstadoIngresado.Name = "listEstadoIngresado";
            this.listEstadoIngresado.Size = new System.Drawing.Size(234, 186);
            this.listEstadoIngresado.TabIndex = 0;
            // 
            // groupBoxPaquete
            // 
            this.groupBoxPaquete.Controls.Add(this.txtDireccion);
            this.groupBoxPaquete.Controls.Add(this.mtxtTrackingID);
            this.groupBoxPaquete.Controls.Add(this.lblDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblTrackingId);
            this.groupBoxPaquete.Controls.Add(this.btnMostrarTodos);
            this.groupBoxPaquete.Controls.Add(this.btnAgregar);
            this.groupBoxPaquete.Location = new System.Drawing.Point(473, 279);
            this.groupBoxPaquete.Name = "groupBoxPaquete";
            this.groupBoxPaquete.Size = new System.Drawing.Size(315, 159);
            this.groupBoxPaquete.TabIndex = 0;
            this.groupBoxPaquete.TabStop = false;
            this.groupBoxPaquete.Text = "Paquete";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(20, 118);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(154, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(18, 60);
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(154, 20);
            this.mtxtTrackingID.TabIndex = 2;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(17, 99);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblTrackingId
            // 
            this.lblTrackingId.AutoSize = true;
            this.lblTrackingId.Location = new System.Drawing.Point(15, 38);
            this.lblTrackingId.Name = "lblTrackingId";
            this.lblTrackingId.Size = new System.Drawing.Size(69, 13);
            this.lblTrackingId.TabIndex = 1;
            this.lblTrackingId.Text = "Trancking ID";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(201, 101);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(99, 40);
            this.btnMostrarTodos.TabIndex = 0;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(201, 52);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(99, 40);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Enabled = false;
            this.rtbMostrar.Location = new System.Drawing.Point(12, 279);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(446, 159);
            this.rtbMostrar.TabIndex = 1;
            this.rtbMostrar.Text = "";
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.groupBoxPaquete);
            this.Controls.Add(this.groupBoxEstadoPaquetes);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Yanina Perez 2do C";
            this.groupBoxEstadoPaquetes.ResumeLayout(false);
            this.groupBoxEstadoPaquetes.PerformLayout();
            this.groupBoxPaquete.ResumeLayout(false);
            this.groupBoxPaquete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEstadoPaquetes;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxPaquete;
        private System.Windows.Forms.ListBox listEstadoEntregado;
        private System.Windows.Forms.ListBox listEstadoEnViaje;
        private System.Windows.Forms.ListBox listEstadoIngresado;
        private System.Windows.Forms.Label lblEstadoEntregado;
        private System.Windows.Forms.Label lblEstadoEnViaje;
        private System.Windows.Forms.Label lblEstadoIngresado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingId;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.RichTextBox rtbMostrar;
    }
}