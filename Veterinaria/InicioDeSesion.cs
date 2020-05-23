/*
 * Created by SharpDevelop.
 * User: FernandoGA
 * Date: 20/05/2020
 * Time: 08:08 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Veterinaria
{
	/// <summary>
	/// Description of InicioDeSesion.
	/// </summary>
	public partial class InicioDeSesion : Form
	{
		public InicioDeSesion()
		{
		
			InitializeComponent();

		}
		
        // LOGICA DE DISEÑO - INICIO
        private void ButtonPowerOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TextBoxCorreo_Enter(object sender, EventArgs e)
        {
            TextBoxCorreo.Text = "";
        }
        private void TextBoxContrasenia_Enter(object sender, EventArgs e)
        {
            TextBoxContrasenia.Text = "";
            TextBoxContrasenia.isPassword = true;
        }
        // LOGICA DE DISEÑO - FIN

        private void ButtonIniciarSesion_Click(object sender, EventArgs e)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            Usuario usuarioActual = new Usuario();
            String correo = TextBoxCorreo.Text;
            String contra = TextBoxContrasenia.Text;
            if (adminUsuario.existeUsuario(correo, contra))
            {
                usuarioActual = adminUsuario.consultarUsuario(correo);
                if (usuarioActual.dameTipoUsuario() == "Super Usuario")
                {
                    MenuUsuarios menuUsuarios = new MenuUsuarios();
                    menuUsuarios.Show();
                }
                else if (usuarioActual.dameTipoUsuario() == "Enfermero" ||
                         usuarioActual.dameTipoUsuario() == "Recepcionista" ||
                         usuarioActual.dameTipoUsuario() == "Veterinario")
                {
                    MenuMascotas menuMascotas = new MenuMascotas(usuarioActual.dameTipoUsuario());
                    menuMascotas.Show();
                }
                this.Close();
            }
            else MessageBox.Show("Alejate de la maquina que va a explotar metiche");

            
        }

        
    }
}
