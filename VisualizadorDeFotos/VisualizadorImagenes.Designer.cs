namespace VisualizadorDeFotos
{
    partial class VisualizadorImagenes
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelAjustes = new System.Windows.Forms.Panel();
            this.trackContraste = new System.Windows.Forms.TrackBar();
            this.trackBrillo = new System.Windows.Forms.TrackBar();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.cerrarPanel = new System.Windows.Forms.Button();
            this.lblInformación = new System.Windows.Forms.Label();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.lblDimensiones = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.cmbZoomPorcentaje = new System.Windows.Forms.ComboBox();
            this.lblZoomActual = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelEditar = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblInfoImagen = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.pictureBoxVisual = new System.Windows.Forms.PictureBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.pictureBoxFavorito = new System.Windows.Forms.PictureBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnAplicarRecorte = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAjustar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRotar = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.panelAjustes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackContraste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrillo)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelEditar.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavorito)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Controls.Add(this.panelAjustes);
            this.panelContenedor.Controls.Add(this.pictureBoxVisual);
            this.panelContenedor.Controls.Add(this.panelInfo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1218, 524);
            this.panelContenedor.TabIndex = 5;
            // 
            // panelAjustes
            // 
            this.panelAjustes.Controls.Add(this.trackContraste);
            this.panelAjustes.Controls.Add(this.trackBrillo);
            this.panelAjustes.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAjustes.Location = new System.Drawing.Point(640, 0);
            this.panelAjustes.Name = "panelAjustes";
            this.panelAjustes.Size = new System.Drawing.Size(315, 524);
            this.panelAjustes.TabIndex = 7;
            this.panelAjustes.Visible = false;
            // 
            // trackContraste
            // 
            this.trackContraste.Location = new System.Drawing.Point(16, 87);
            this.trackContraste.Name = "trackContraste";
            this.trackContraste.Size = new System.Drawing.Size(247, 45);
            this.trackContraste.TabIndex = 1;
            this.trackContraste.ValueChanged += new System.EventHandler(this.trackContraste_ValueChanged);
            // 
            // trackBrillo
            // 
            this.trackBrillo.Location = new System.Drawing.Point(16, 25);
            this.trackBrillo.Name = "trackBrillo";
            this.trackBrillo.Size = new System.Drawing.Size(247, 45);
            this.trackBrillo.TabIndex = 0;
            this.trackBrillo.ValueChanged += new System.EventHandler(this.trackBrillo_ValueChanged);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.cerrarPanel);
            this.panelInfo.Controls.Add(this.lblInformación);
            this.panelInfo.Controls.Add(this.lblTamaño);
            this.panelInfo.Controls.Add(this.lblDimensiones);
            this.panelInfo.Controls.Add(this.lblFecha);
            this.panelInfo.Controls.Add(this.lblNombreArchivo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInfo.Location = new System.Drawing.Point(955, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(263, 524);
            this.panelInfo.TabIndex = 10;
            this.panelInfo.Visible = false;
            // 
            // cerrarPanel
            // 
            this.cerrarPanel.FlatAppearance.BorderSize = 0;
            this.cerrarPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrarPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarPanel.ForeColor = System.Drawing.Color.White;
            this.cerrarPanel.Location = new System.Drawing.Point(228, 3);
            this.cerrarPanel.Name = "cerrarPanel";
            this.cerrarPanel.Size = new System.Drawing.Size(21, 24);
            this.cerrarPanel.TabIndex = 5;
            this.cerrarPanel.Text = "X";
            this.cerrarPanel.UseVisualStyleBackColor = true;
            this.cerrarPanel.Click += new System.EventHandler(this.cerrarPanel_Click);
            // 
            // lblInformación
            // 
            this.lblInformación.AutoSize = true;
            this.lblInformación.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformación.ForeColor = System.Drawing.Color.White;
            this.lblInformación.Location = new System.Drawing.Point(10, 20);
            this.lblInformación.Name = "lblInformación";
            this.lblInformación.Size = new System.Drawing.Size(118, 22);
            this.lblInformación.TabIndex = 4;
            this.lblInformación.Text = "Información";
            // 
            // lblTamaño
            // 
            this.lblTamaño.AutoSize = true;
            this.lblTamaño.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamaño.ForeColor = System.Drawing.Color.White;
            this.lblTamaño.Location = new System.Drawing.Point(21, 189);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(59, 22);
            this.lblTamaño.TabIndex = 3;
            this.lblTamaño.Text = "label1";
            // 
            // lblDimensiones
            // 
            this.lblDimensiones.AutoSize = true;
            this.lblDimensiones.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimensiones.ForeColor = System.Drawing.Color.White;
            this.lblDimensiones.Location = new System.Drawing.Point(21, 150);
            this.lblDimensiones.Name = "lblDimensiones";
            this.lblDimensiones.Size = new System.Drawing.Size(59, 22);
            this.lblDimensiones.TabIndex = 2;
            this.lblDimensiones.Text = "label1";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(21, 111);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(59, 22);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "label1";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.White;
            this.lblNombreArchivo.Location = new System.Drawing.Point(21, 71);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(59, 22);
            this.lblNombreArchivo.TabIndex = 0;
            this.lblNombreArchivo.Text = "label1";
            // 
            // trackZoom
            // 
            this.trackZoom.Location = new System.Drawing.Point(979, 8);
            this.trackZoom.Maximum = 300;
            this.trackZoom.Minimum = 10;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(104, 45);
            this.trackZoom.TabIndex = 6;
            this.trackZoom.TickFrequency = 10;
            this.trackZoom.Value = 100;
            this.trackZoom.Scroll += new System.EventHandler(this.trackZoom_Scroll);
            // 
            // cmbZoomPorcentaje
            // 
            this.cmbZoomPorcentaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoomPorcentaje.FormattingEnabled = true;
            this.cmbZoomPorcentaje.Items.AddRange(new object[] {
            "[\"50%\", \"75%\", \"100%\", \"125%\", \"150%\", \"200%\", \"300%\"]"});
            this.cmbZoomPorcentaje.Location = new System.Drawing.Point(1089, 18);
            this.cmbZoomPorcentaje.Name = "cmbZoomPorcentaje";
            this.cmbZoomPorcentaje.Size = new System.Drawing.Size(81, 21);
            this.cmbZoomPorcentaje.TabIndex = 7;
            this.cmbZoomPorcentaje.SelectedIndexChanged += new System.EventHandler(this.cmbZoomPorcentaje_SelectedIndexChanged);
            // 
            // lblZoomActual
            // 
            this.lblZoomActual.AutoSize = true;
            this.lblZoomActual.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoomActual.ForeColor = System.Drawing.Color.White;
            this.lblZoomActual.Location = new System.Drawing.Point(914, 17);
            this.lblZoomActual.Name = "lblZoomActual";
            this.lblZoomActual.Size = new System.Drawing.Size(59, 22);
            this.lblZoomActual.TabIndex = 8;
            this.lblZoomActual.Text = "label1";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelEditar);
            this.panelTop.Controls.Add(this.btnEditar);
            this.panelTop.Controls.Add(this.btnEliminar);
            this.panelTop.Controls.Add(this.btnRotar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1273, 75);
            this.panelTop.TabIndex = 12;
            // 
            // panelEditar
            // 
            this.panelEditar.Controls.Add(this.btnAplicarRecorte);
            this.panelEditar.Controls.Add(this.btnGuardar);
            this.panelEditar.Controls.Add(this.btnAjustar);
            this.panelEditar.Controls.Add(this.btnRecortar);
            this.panelEditar.Location = new System.Drawing.Point(380, 12);
            this.panelEditar.Name = "panelEditar";
            this.panelEditar.Size = new System.Drawing.Size(569, 63);
            this.panelEditar.TabIndex = 6;
            this.panelEditar.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.pictureBoxFavorito);
            this.panelBottom.Controls.Add(this.lblInfoImagen);
            this.panelBottom.Controls.Add(this.btnInfo);
            this.panelBottom.Controls.Add(this.trackZoom);
            this.panelBottom.Controls.Add(this.lblZoomActual);
            this.panelBottom.Controls.Add(this.cmbZoomPorcentaje);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 599);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1273, 65);
            this.panelBottom.TabIndex = 1;
            // 
            // lblInfoImagen
            // 
            this.lblInfoImagen.AutoSize = true;
            this.lblInfoImagen.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoImagen.ForeColor = System.Drawing.Color.White;
            this.lblInfoImagen.Location = new System.Drawing.Point(508, 20);
            this.lblInfoImagen.Name = "lblInfoImagen";
            this.lblInfoImagen.Size = new System.Drawing.Size(51, 19);
            this.lblInfoImagen.TabIndex = 12;
            this.lblInfoImagen.Text = "label1";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnAnterior);
            this.panelMain.Controls.Add(this.panelContenedor);
            this.panelMain.Controls.Add(this.btnSiguiente);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1273, 524);
            this.panelMain.TabIndex = 13;
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAnterior.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_atrás_48;
            this.btnAnterior.Location = new System.Drawing.Point(0, 0);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(47, 524);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // pictureBoxVisual
            // 
            this.pictureBoxVisual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxVisual.Location = new System.Drawing.Point(256, 20);
            this.pictureBoxVisual.Name = "pictureBoxVisual";
            this.pictureBoxVisual.Size = new System.Drawing.Size(693, 464);
            this.pictureBoxVisual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxVisual.TabIndex = 0;
            this.pictureBoxVisual.TabStop = false;
            this.pictureBoxVisual.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxVisual_Paint);
            this.pictureBoxVisual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisual_MouseDown);
            this.pictureBoxVisual.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisual_MouseMove);
            this.pictureBoxVisual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisual_MouseUp);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSiguiente.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_adelante_48;
            this.btnSiguiente.Location = new System.Drawing.Point(1218, 0);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(55, 524);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // pictureBoxFavorito
            // 
            this.pictureBoxFavorito.Image = global::VisualizadorDeFotos.Properties.Resources.star_empty;
            this.pictureBoxFavorito.Location = new System.Drawing.Point(72, 14);
            this.pictureBoxFavorito.Name = "pictureBoxFavorito";
            this.pictureBoxFavorito.Size = new System.Drawing.Size(36, 32);
            this.pictureBoxFavorito.TabIndex = 13;
            this.pictureBoxFavorito.TabStop = false;
            this.pictureBoxFavorito.Click += new System.EventHandler(this.pictureBoxFavorito_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_información_642;
            this.btnInfo.Location = new System.Drawing.Point(470, 14);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(32, 32);
            this.btnInfo.TabIndex = 11;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click_1);
            // 
            // btnAplicarRecorte
            // 
            this.btnAplicarRecorte.FlatAppearance.BorderSize = 0;
            this.btnAplicarRecorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarRecorte.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_marca_de_verificación_50;
            this.btnAplicarRecorte.Location = new System.Drawing.Point(90, 27);
            this.btnAplicarRecorte.Name = "btnAplicarRecorte";
            this.btnAplicarRecorte.Size = new System.Drawing.Size(32, 30);
            this.btnAplicarRecorte.TabIndex = 3;
            this.btnAplicarRecorte.UseVisualStyleBackColor = true;
            this.btnAplicarRecorte.Click += new System.EventHandler(this.btnAplicarRecorte_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_documento_67;
            this.btnGuardar.Location = new System.Drawing.Point(444, 17);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(38, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAjustar
            // 
            this.btnAjustar.FlatAppearance.BorderSize = 0;
            this.btnAjustar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustar.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_brillo_50;
            this.btnAjustar.Location = new System.Drawing.Point(214, 26);
            this.btnAjustar.Name = "btnAjustar";
            this.btnAjustar.Size = new System.Drawing.Size(44, 31);
            this.btnAjustar.TabIndex = 1;
            this.btnAjustar.UseVisualStyleBackColor = true;
            this.btnAjustar.Click += new System.EventHandler(this.btnAjustar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.FlatAppearance.BorderSize = 0;
            this.btnRecortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecortar.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_recortar_80;
            this.btnRecortar.Location = new System.Drawing.Point(36, 26);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(43, 30);
            this.btnRecortar.TabIndex = 0;
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_editar_64;
            this.btnEditar.Location = new System.Drawing.Point(326, 29);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(35, 40);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_eliminar_481;
            this.btnEliminar.Location = new System.Drawing.Point(155, 38);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(44, 31);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRotar
            // 
            this.btnRotar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRotar.FlatAppearance.BorderSize = 0;
            this.btnRotar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotar.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotar.ForeColor = System.Drawing.Color.White;
            this.btnRotar.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_círculo_alrededor_64;
            this.btnRotar.Location = new System.Drawing.Point(205, 39);
            this.btnRotar.Name = "btnRotar";
            this.btnRotar.Size = new System.Drawing.Size(45, 30);
            this.btnRotar.TabIndex = 4;
            this.btnRotar.UseVisualStyleBackColor = false;
            this.btnRotar.Click += new System.EventHandler(this.btnRotar_Click);
            // 
            // VisualizadorImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1273, 664);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "VisualizadorImagenes";
            this.Text = "VisualizadorImagenes";
            this.Load += new System.EventHandler(this.VisualizadorImagenes_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.panelAjustes.ResumeLayout(false);
            this.panelAjustes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackContraste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrillo)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelEditar.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavorito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRotar;
        private System.Windows.Forms.PictureBox pictureBoxVisual;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.ComboBox cmbZoomPorcentaje;
        private System.Windows.Forms.Label lblZoomActual;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.Label lblDimensiones;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblInformación;
        private System.Windows.Forms.Button cerrarPanel;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelEditar;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBoxFavorito;
        private System.Windows.Forms.Label lblInfoImagen;
        private System.Windows.Forms.Button btnAplicarRecorte;
        private System.Windows.Forms.Panel panelAjustes;
        private System.Windows.Forms.TrackBar trackBrillo;
        private System.Windows.Forms.TrackBar trackContraste;
        private System.Windows.Forms.Button btnAjustar;
    }
}