/*
 * Created by SharpDevelop.
 * User: FernandoGA
 * Date: 21/05/2020
 * Time: 12:28 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Veterinaria
{
	/// <summary>
	/// Description of MenuMascotas.
	/// </summary>
	public partial class MenuMascotas : Form
	{	
		public MenuMascotas()
		{
			
			InitializeComponent();
			PanelDeDesplazamiento.Visible = false;
		}

        // LOGICA DE DISEÑO - FIN
        void desplazarPanelDeDesplazamiento(int altura, int posicionParteSuperior)
		{
			PanelDeDesplazamiento.Visible = true;
			PanelDeDesplazamiento.Height = altura + 30;
			PanelDeDesplazamiento.Top = posicionParteSuperior - 15;
		}
		
		
		void LabelPetscareClick(object sender, EventArgs e)
		{
			TabuladorABC.SelectTab(0);
			PanelDeDesplazamiento.Visible = false;
		}
		void ButtonAgregarClick(object sender, EventArgs e)
		{
			TabuladorABC.SelectTab(1); // Cambiamos de pestaña a la pestaña 1(Agregar) del TabControl
			desplazarPanelDeDesplazamiento(ButtonAgregar.Height, ButtonAgregar.Top);
		}
		void ButtonConsultarClick(object sender, EventArgs e)
		{
			TabuladorABC.SelectTab(2); // Cambiamos de pestaña a la pestaña 2(Consultar) del TabControl
			desplazarPanelDeDesplazamiento(ButtonConsultar.Height, ButtonConsultar.Top);
		}
		void ButtonModificarClick(object sender, EventArgs e)
		{
			TabuladorABC.SelectTab(3); // Cambiamos de pestaña a la pestaña 3(Modificar) del TabControl
			desplazarPanelDeDesplazamiento(ButtonModificar.Height, ButtonModificar.Top);
		}
		void ButtonEliminarClick(object sender, EventArgs e)
		{
			TabuladorABC.SelectTab(4); // Cambiamos de pestaña a la pestaña 4(Eliminar) del TabControl
			desplazarPanelDeDesplazamiento(ButtonEliminar.Height, ButtonEliminar.Top);
		}
		void ButtonListarClick(object sender, EventArgs e)
		{
			TabuladorABC.SelectTab(5); // Cambiamos de pestaña a la pestaña 4(Listar) del TabControl
			desplazarPanelDeDesplazamiento(ButtonListar.Height, ButtonListar.Top);
		}
        void ButtonSalirClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonListar2_Click(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(5);
            PanelDeDesplazamiento.Visible = false;
        }
        private void ButtonConsultar2_Click(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(2);
            PanelDeDesplazamiento.Visible = false;
        }
        private void ButtonEliminar2_Click(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(4);
            PanelDeDesplazamiento.Visible = false;
        }
        private void ButtonAgregar2_Click(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(1);
            PanelDeDesplazamiento.Visible = false;
        }
        private void ButtonModificar2_Click(object sender, EventArgs e)
        {
            TabuladorABC.SelectTab(3);
            PanelDeDesplazamiento.Visible = false;
        }
        private void ButtonMinimizar_Click(object sender, EventArgs e)
        {
            
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
