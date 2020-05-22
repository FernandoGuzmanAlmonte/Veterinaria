/*
 * Created by SharpDevelop.
 * User: FernandoGA
 * Date: 20/05/2020
 * Time: 08:08 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Veterinaria
{
	partial class InicioDeSesion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioDeSesion));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonPowerOff = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.TextBoxCorreo = new ns1.BunifuMetroTextbox();
            this.TextBoxContrasenia = new ns1.BunifuMetroTextbox();
            this.ButtonIniciarSesion = new ns1.BunifuThinButton2();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(91, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "ETSCARE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(164, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inicio de Sesión";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.ButtonPowerOff);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 60);
            this.panel2.TabIndex = 3;
            // 
            // ButtonPowerOff
            // 
            this.ButtonPowerOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonPowerOff.FlatAppearance.BorderSize = 0;
            this.ButtonPowerOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonPowerOff.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPowerOff.Image")));
            this.ButtonPowerOff.Location = new System.Drawing.Point(481, 12);
            this.ButtonPowerOff.Name = "ButtonPowerOff";
            this.ButtonPowerOff.Size = new System.Drawing.Size(38, 41);
            this.ButtonPowerOff.TabIndex = 8;
            this.ButtonPowerOff.UseVisualStyleBackColor = true;
            this.ButtonPowerOff.Click += new System.EventHandler(this.ButtonPowerOff_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 45;
            this.bunifuElipse1.TargetControl = this;
            // 
            // TextBoxCorreo
            // 
            this.TextBoxCorreo.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.TextBoxCorreo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.TextBoxCorreo.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.TextBoxCorreo.BorderThickness = 3;
            this.TextBoxCorreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxCorreo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextBoxCorreo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TextBoxCorreo.isPassword = false;
            this.TextBoxCorreo.Location = new System.Drawing.Point(98, 119);
            this.TextBoxCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxCorreo.Name = "TextBoxCorreo";
            this.TextBoxCorreo.Size = new System.Drawing.Size(314, 31);
            this.TextBoxCorreo.TabIndex = 7;
            this.TextBoxCorreo.Text = "Correo Electronico";
            this.TextBoxCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxCorreo.Enter += new System.EventHandler(this.TextBoxCorreo_Enter);
            // 
            // TextBoxContrasenia
            // 
            this.TextBoxContrasenia.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.TextBoxContrasenia.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.TextBoxContrasenia.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.TextBoxContrasenia.BorderThickness = 3;
            this.TextBoxContrasenia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxContrasenia.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextBoxContrasenia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TextBoxContrasenia.isPassword = false;
            this.TextBoxContrasenia.Location = new System.Drawing.Point(98, 158);
            this.TextBoxContrasenia.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxContrasenia.Name = "TextBoxContrasenia";
            this.TextBoxContrasenia.Size = new System.Drawing.Size(314, 31);
            this.TextBoxContrasenia.TabIndex = 7;
            this.TextBoxContrasenia.Text = "Contraseña";
            this.TextBoxContrasenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxContrasenia.Enter += new System.EventHandler(this.TextBoxContrasenia_Enter);
            // 
            // ButtonIniciarSesion
            // 
            this.ButtonIniciarSesion.ActiveBorderThickness = 1;
            this.ButtonIniciarSesion.ActiveCornerRadius = 20;
            this.ButtonIniciarSesion.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.ButtonIniciarSesion.ActiveForecolor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonIniciarSesion.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(111)))));
            this.ButtonIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ButtonIniciarSesion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonIniciarSesion.BackgroundImage")));
            this.ButtonIniciarSesion.ButtonText = "Iniciar sesión";
            this.ButtonIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonIniciarSesion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonIniciarSesion.ForeColor = System.Drawing.Color.SeaGreen;
            this.ButtonIniciarSesion.IdleBorderThickness = 1;
            this.ButtonIniciarSesion.IdleCornerRadius = 20;
            this.ButtonIniciarSesion.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.ButtonIniciarSesion.IdleForecolor = System.Drawing.SystemColors.Window;
            this.ButtonIniciarSesion.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.ButtonIniciarSesion.Location = new System.Drawing.Point(98, 219);
            this.ButtonIniciarSesion.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonIniciarSesion.Name = "ButtonIniciarSesion";
            this.ButtonIniciarSesion.Size = new System.Drawing.Size(314, 41);
            this.ButtonIniciarSesion.TabIndex = 9;
            this.ButtonIniciarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonIniciarSesion.Click += new System.EventHandler(this.ButtonIniciarSesion_Click);
            // 
            // InicioDeSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(531, 274);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ButtonIniciarSesion);
            this.Controls.Add(this.TextBoxContrasenia);
            this.Controls.Add(this.TextBoxCorreo);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InicioDeSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Button ButtonPowerOff;
        private ns1.BunifuElipse bunifuElipse1;
        private ns1.BunifuMetroTextbox TextBoxCorreo;
        private ns1.BunifuMetroTextbox TextBoxContrasenia;
        private ns1.BunifuThinButton2 ButtonIniciarSesion;
    }
}
