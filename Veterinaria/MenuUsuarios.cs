/*
 * Created by SharpDevelop.
 * User: FernandoGA
 * Date: 21/05/2020
 * Time: 12:27 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Veterinaria
{
	/// <summary>
	/// Description of MenuUsuarios.
	/// </summary>
	public partial class MenuUsuarios : Form
	{
		public MenuUsuarios()
		{

			InitializeComponent();
            desplazarPanelDeDesplazamiento(ButtonAgregar.Height, ButtonAgregar.Top);

        }

        // LOGICA DE DISEÑO - FIN
        void desplazarPanelDeDesplazamiento(int altura, int posicionParteSuperior)
        {
            PanelDeDesplazamiento.Visible = true;
            PanelDeDesplazamiento.Height = altura + 30;
            PanelDeDesplazamiento.Top = posicionParteSuperior - 15;
        }

        void ButtonAgregarClick(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(0); // Cambiamos de pestaña a la pestaña 1(Agregar) del TabControl
            desplazarPanelDeDesplazamiento(ButtonAgregar.Height, ButtonAgregar.Top);
        }
        void ButtonConsultarClick(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(1); // Cambiamos de pestaña a la pestaña 2(Consultar) del TabControl
            desplazarPanelDeDesplazamiento(ButtonConsultar.Height, ButtonConsultar.Top);
        }
        void ButtonModificarClick(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(2); // Cambiamos de pestaña a la pestaña 3(Modificar) del TabControl
            desplazarPanelDeDesplazamiento(ButtonModificar.Height, ButtonModificar.Top);
        }
        void ButtonEliminarClick(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(3); // Cambiamos de pestaña a la pestaña 4(Eliminar) del TabControl
            desplazarPanelDeDesplazamiento(ButtonEliminar.Height, ButtonEliminar.Top);
        }
        void ButtonListarClick(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(4); // Cambiamos de pestaña a la pestaña 4(Listar) del TabControl
            desplazarPanelDeDesplazamiento(ButtonListar.Height, ButtonListar.Top);
        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // LOGICA DE DISEÑO - FIN

        // LOGICA DE DATOS - INICIO
        void ButtonPowerOffClick(object sender, EventArgs e)
        {
            string mensaje = "Seguro que quieres Cerrar Sesión?";
            string titulo = "Advertencia";
            MessageBoxButtons tipoDeBoton = MessageBoxButtons.YesNo;
            DialogResult respuestaUsuario;

            respuestaUsuario = MessageBox.Show(mensaje, titulo, tipoDeBoton);
            if (respuestaUsuario == DialogResult.Yes)
            {
                new InicioDeSesion().Show();
                this.Close();
            }
        }
        // LOGICA DE DATOS - FIN
    }
}
