﻿namespace ProyRestMatrizArray
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.textBoxClave = new System.Windows.Forms.TextBox();
			this.textBoxRut = new System.Windows.Forms.TextBox();
			this.buttonIngresar = new System.Windows.Forms.Button();
			this.hora = new System.Windows.Forms.Label();
			this.fecha = new System.Windows.Forms.Label();
			this.horayfecha = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// textBoxClave
			// 
			this.textBoxClave.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxClave.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxClave.Location = new System.Drawing.Point(266, 236);
			this.textBoxClave.Multiline = true;
			this.textBoxClave.Name = "textBoxClave";
			this.textBoxClave.Size = new System.Drawing.Size(174, 39);
			this.textBoxClave.TabIndex = 0;
			this.textBoxClave.Text = "Clave";
			this.textBoxClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxRut
			// 
			this.textBoxRut.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxRut.Location = new System.Drawing.Point(267, 181);
			this.textBoxRut.Multiline = true;
			this.textBoxRut.Name = "textBoxRut";
			this.textBoxRut.Size = new System.Drawing.Size(173, 39);
			this.textBoxRut.TabIndex = 1;
			this.textBoxRut.Text = "Rut";
			this.textBoxRut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonIngresar
			// 
			this.buttonIngresar.BackgroundImage = global::ProyRestMatrizArray.Properties.Resources.triangle_abstract_gradient_soft_gradient_wallpaper_preview;
			this.buttonIngresar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonIngresar.Location = new System.Drawing.Point(477, 291);
			this.buttonIngresar.Name = "buttonIngresar";
			this.buttonIngresar.Size = new System.Drawing.Size(174, 39);
			this.buttonIngresar.TabIndex = 2;
			this.buttonIngresar.Text = "Ingresar";
			this.buttonIngresar.UseVisualStyleBackColor = true;
			this.buttonIngresar.Click += new System.EventHandler(this.buttonIngresar_Click);
			// 
			// hora
			// 
			this.hora.AutoSize = true;
			this.hora.BackColor = System.Drawing.Color.Transparent;
			this.hora.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hora.ForeColor = System.Drawing.Color.White;
			this.hora.Location = new System.Drawing.Point(508, 9);
			this.hora.Name = "hora";
			this.hora.Size = new System.Drawing.Size(60, 29);
			this.hora.TabIndex = 3;
			this.hora.Text = "Hora";
			// 
			// fecha
			// 
			this.fecha.AutoSize = true;
			this.fecha.BackColor = System.Drawing.Color.Transparent;
			this.fecha.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fecha.ForeColor = System.Drawing.Color.White;
			this.fecha.Location = new System.Drawing.Point(35, 9);
			this.fecha.Name = "fecha";
			this.fecha.Size = new System.Drawing.Size(69, 29);
			this.fecha.TabIndex = 4;
			this.fecha.Text = "Fecha";
			// 
			// horayfecha
			// 
			this.horayfecha.Enabled = true;
			this.horayfecha.Tick += new System.EventHandler(this.Horayfecha_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(446, 194);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(217, 26);
			this.label1.TabIndex = 5;
			this.label1.Text = "Formato (XX.XXX.XXX-X)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(116, 218);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 26);
			this.label2.TabIndex = 6;
			this.label2.Text = "Rut y Clave";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Cambria", 56.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.label3.Location = new System.Drawing.Point(130, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(491, 88);
			this.label3.TabIndex = 8;
			this.label3.Text = "BIENVENIDOS";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(36)))));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(729, 382);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fecha);
			this.Controls.Add(this.hora);
			this.Controls.Add(this.buttonIngresar);
			this.Controls.Add(this.textBoxRut);
			this.Controls.Add(this.textBoxClave);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Acceso";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.TextBox textBoxRut;
        private System.Windows.Forms.Button buttonIngresar;
        private System.Windows.Forms.Label hora;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Timer horayfecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

