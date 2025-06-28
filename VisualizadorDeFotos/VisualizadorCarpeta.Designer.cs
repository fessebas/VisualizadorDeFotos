namespace VisualizadorDeFotos
{
    partial class SelecImagen
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
            this.PIzquierdo = new System.Windows.Forms.Panel();
            this.treeViewDirectorios = new System.Windows.Forms.TreeView();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnFavoritos = new System.Windows.Forms.Button();
            this.BtnAbrirCarpeta = new System.Windows.Forms.Button();
            this.BtnGaleria = new System.Windows.Forms.Button();
            this.PImagenes = new System.Windows.Forms.Panel();
            this.lblInfoCarpeta = new System.Windows.Forms.Label();
            this.FlypGaleria = new System.Windows.Forms.FlowLayoutPanel();
            this.PIzquierdo.SuspendLayout();
            this.PImagenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // PIzquierdo
            // 
            this.PIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PIzquierdo.Controls.Add(this.treeViewDirectorios);
            this.PIzquierdo.Controls.Add(this.panelSuperior);
            this.PIzquierdo.Controls.Add(this.panel1);
            this.PIzquierdo.Controls.Add(this.BtnFavoritos);
            this.PIzquierdo.Controls.Add(this.BtnAbrirCarpeta);
            this.PIzquierdo.Controls.Add(this.BtnGaleria);
            this.PIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.PIzquierdo.Name = "PIzquierdo";
            this.PIzquierdo.Size = new System.Drawing.Size(201, 656);
            this.PIzquierdo.TabIndex = 2;
            // 
            // treeViewDirectorios
            // 
            this.treeViewDirectorios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.treeViewDirectorios.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewDirectorios.ForeColor = System.Drawing.Color.White;
            this.treeViewDirectorios.Location = new System.Drawing.Point(0, 188);
            this.treeViewDirectorios.Name = "treeViewDirectorios";
            this.treeViewDirectorios.Size = new System.Drawing.Size(201, 468);
            this.treeViewDirectorios.TabIndex = 4;
            this.treeViewDirectorios.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDirectorios_AfterSelect);
            // 
            // panelSuperior
            // 
            this.panelSuperior.Location = new System.Drawing.Point(201, 4);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(317, 37);
            this.panelSuperior.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(201, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 32);
            this.panel1.TabIndex = 3;
            // 
            // BtnFavoritos
            // 
            this.BtnFavoritos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFavoritos.FlatAppearance.BorderSize = 0;
            this.BtnFavoritos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnFavoritos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFavoritos.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFavoritos.ForeColor = System.Drawing.Color.White;
            this.BtnFavoritos.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_me_gusta;
            this.BtnFavoritos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFavoritos.Location = new System.Drawing.Point(0, 140);
            this.BtnFavoritos.Name = "BtnFavoritos";
            this.BtnFavoritos.Size = new System.Drawing.Size(201, 42);
            this.BtnFavoritos.TabIndex = 3;
            this.BtnFavoritos.Text = "Favoritos";
            this.BtnFavoritos.UseVisualStyleBackColor = false;
            // 
            // BtnAbrirCarpeta
            // 
            this.BtnAbrirCarpeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnAbrirCarpeta.FlatAppearance.BorderSize = 0;
            this.BtnAbrirCarpeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnAbrirCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbrirCarpeta.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_agregar_carpeta;
            this.BtnAbrirCarpeta.Location = new System.Drawing.Point(147, 79);
            this.BtnAbrirCarpeta.Name = "BtnAbrirCarpeta";
            this.BtnAbrirCarpeta.Size = new System.Drawing.Size(54, 43);
            this.BtnAbrirCarpeta.TabIndex = 2;
            this.BtnAbrirCarpeta.UseVisualStyleBackColor = false;
            this.BtnAbrirCarpeta.Click += new System.EventHandler(this.BtnAbrirCarpeta_Click_1);
            // 
            // BtnGaleria
            // 
            this.BtnGaleria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnGaleria.FlatAppearance.BorderSize = 0;
            this.BtnGaleria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnGaleria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGaleria.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGaleria.ForeColor = System.Drawing.Color.White;
            this.BtnGaleria.Image = global::VisualizadorDeFotos.Properties.Resources.icons8_galería;
            this.BtnGaleria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGaleria.Location = new System.Drawing.Point(0, 79);
            this.BtnGaleria.Name = "BtnGaleria";
            this.BtnGaleria.Size = new System.Drawing.Size(201, 43);
            this.BtnGaleria.TabIndex = 0;
            this.BtnGaleria.Text = "Galeria";
            this.BtnGaleria.UseVisualStyleBackColor = false;
            // 
            // PImagenes
            // 
            this.PImagenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PImagenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PImagenes.Controls.Add(this.lblInfoCarpeta);
            this.PImagenes.Controls.Add(this.FlypGaleria);
            this.PImagenes.Location = new System.Drawing.Point(201, 0);
            this.PImagenes.Name = "PImagenes";
            this.PImagenes.Size = new System.Drawing.Size(892, 656);
            this.PImagenes.TabIndex = 3;
            // 
            // lblInfoCarpeta
            // 
            this.lblInfoCarpeta.AutoSize = true;
            this.lblInfoCarpeta.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCarpeta.ForeColor = System.Drawing.Color.White;
            this.lblInfoCarpeta.Location = new System.Drawing.Point(5, 43);
            this.lblInfoCarpeta.Name = "lblInfoCarpeta";
            this.lblInfoCarpeta.Size = new System.Drawing.Size(0, 22);
            this.lblInfoCarpeta.TabIndex = 3;
            // 
            // FlypGaleria
            // 
            this.FlypGaleria.AutoScroll = true;
            this.FlypGaleria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FlypGaleria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlypGaleria.Location = new System.Drawing.Point(-1, 78);
            this.FlypGaleria.Name = "FlypGaleria";
            this.FlypGaleria.Size = new System.Drawing.Size(892, 577);
            this.FlypGaleria.TabIndex = 2;
            // 
            // SelecImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1093, 656);
            this.Controls.Add(this.PImagenes);
            this.Controls.Add(this.PIzquierdo);
            this.Name = "SelecImagen";
            this.Text = " ";
            this.PIzquierdo.ResumeLayout(false);
            this.PImagenes.ResumeLayout(false);
            this.PImagenes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PIzquierdo;
        private System.Windows.Forms.Panel PImagenes;
        private System.Windows.Forms.Button BtnGaleria;
        private System.Windows.Forms.Button BtnAbrirCarpeta;
        private System.Windows.Forms.Button BtnFavoritos;
        private System.Windows.Forms.FlowLayoutPanel FlypGaleria;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewDirectorios;
        private System.Windows.Forms.Label lblInfoCarpeta;
    }
}

