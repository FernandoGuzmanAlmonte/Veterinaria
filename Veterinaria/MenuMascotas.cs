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
using System.Collections.Generic;

namespace Veterinaria
{
	/// <summary>
	/// Description of MenuMascotas.
	/// </summary>
	public partial class MenuMascotas : Form
	{
        private String tipoUsuario;

        public MenuMascotas(String tipoUsuario)
        {
            this.tipoUsuario = tipoUsuario;
            InitializeComponent();
            PanelDeDesplazamiento.Visible = false;
            accesosUsuarios();
        }

        public void accesosUsuarios()
        {
            if (tipoUsuario == "Enfermero") ButtonAgregar.Visible = false;
            else ButtonAgregar.Visible = true;

            if (tipoUsuario == "Veterinario") ButtonModificar.Visible = true;
            else ButtonModificar.Visible = false;

            if (tipoUsuario == "Veterinario") ButtonEliminar.Visible = true;
            else ButtonEliminar.Visible = false;

            if (tipoUsuario == "Veterinario") ButtonListar.Visible = false;
            else ButtonListar.Visible = true;
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
            this.WindowState = FormWindowState.Minimized;
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

        private void ButtonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = TextBoxAgregarNombre.Text;
            String especie = TextBoxAgregarEspecie.Text;
            String raza = TextBoxAgregarRaza.Text;
            int edad = Int32.Parse(TextBoxAgregarEdad.Text);
            double peso = double.Parse(TextBoxAgregarPeso.Text);
            double estatura = double.Parse(TextBoxAgregarEstatura.Text);
            String nombreDuenio = TextBoxAgregarDueño.Text;
            if (nombre.Length>2 && especie.Length > 2 && raza.Length > 2 && 
                nombreDuenio.Length > 3)
            {
                AdminMascotas adminMascota = new AdminMascotas();
                if (adminMascota.agregarMascota(nombre, especie, raza, edad, peso, estatura,
                    nombreDuenio))
                {
                    MessageBox.Show(" Se han guardado los datos");
                    TextBoxAgregarNombre.Clear();
                    TextBoxAgregarEspecie.Clear();
                    TextBoxAgregarRaza.Clear();
                    TextBoxAgregarEdad.Clear();
                    TextBoxAgregarPeso.Clear();
                    TextBoxAgregarEstatura.Clear();
                    TextBoxAgregarDueño.Clear();
                    TextBoxAgregarEnfermedad.Clear();
                }
                else
                {
                    MessageBox.Show(" No se han podido guardar los cambios");
                }
            }
            else
            {
                MessageBox.Show("Favor de verificar los datos");
            }
        }

        private void ButtonLimpiarDeAgregar_Click(object sender, EventArgs e)
        {
            TextBoxAgregarNombre.Clear();
            TextBoxAgregarEspecie.Clear();
            TextBoxAgregarRaza.Clear();
            TextBoxAgregarEdad.Clear();
            TextBoxAgregarPeso.Clear();
            TextBoxAgregarEstatura.Clear();
            TextBoxAgregarDueño.Clear();
            TextBoxAgregarEnfermedad.Clear();
        }

        private void ButtonBuscarDeConsultar_Click(object sender, EventArgs e)
        {
            AdminMascotas adminMascotas = new AdminMascotas();
            Mascota mascota = new Mascota();
            String id = TextBoxConsultaID.Text;
            if(adminMascotas.existeMascota(id))
            {
                mascota = adminMascotas.consultarMascota(id);
                LabelConsultaEspecie.Text = mascota.dameEspecie();
                LabelConsultaRaza.Text = mascota.dameRaza();
                LabelConsultaEdad.Text = mascota.dameEdad().ToString();
                LabelConsultaPeso.Text = mascota.damePeso().ToString();
                LabelConsultaEstatura.Text = mascota.dameEstatura().ToString();
                LabelConsultaDuenio.Text = mascota.dameNombreDuenio();
                label51.Text = mascota.dameNombre();
            }
            else
            {
                MessageBox.Show("No se encontró el registro");
            }
            
            //LabelConsultaEnfermedad.Text = "Peditos Fuertes";                         PIDU QUIERE PONER LA PEDORRERA Y YO DIGO QUE NO
        }

        private void ButtonBuscarDeModificar_Click(object sender, EventArgs e)
        {
            AdminMascotas adminMascota = new AdminMascotas();
            Mascota mascota = new Mascota();
            String id = TextBoxIDModificar.Text;
            if(adminMascota.existeMascota(id))
            {
                mascota = adminMascota.consultarMascota(id);
                textBoxNombre.Text = mascota.dameNombre();
                TextBoxEspecieModificar.Text = mascota.dameEspecie();
                TextBoxRazaModificar.Text = mascota.dameRaza();
                TextBoxEdadModificar.Text = mascota.dameEdad().ToString();
                TextBoxPesoModificar.Text = mascota.damePeso().ToString();
                TextBoxEstaturaModificar.Text = mascota.dameEstatura().ToString();
                TextBoxNombreDuenioModificar.Text = mascota.dameNombreDuenio().ToString();
            }
            else
            {
                MessageBox.Show("No se encontró la mascota");
            }
            
            //TextBoxEnfermedadModificar.Text = "Peditos Olorosos";                     PIDU QUIERE PONER LA PEDORRERA Y YO DIGO QUE NO
        }

        private void ButtonActualizar_Click(object sender, EventArgs e)
        {
            AdminMascotas adminMascota = new AdminMascotas();
            Mascota mascota = new Mascota();
            String id = TextBoxIDModificar.Text;
            String nombre = textBoxNombre.Text;
            String especie = TextBoxEspecieModificar.Text;
            String raza = TextBoxRazaModificar.Text;
            int edad = Int32.Parse(TextBoxEdadModificar.Text);
            double peso = double.Parse(TextBoxPesoModificar.Text);
            double estatura = double.Parse(TextBoxEstaturaModificar.Text);
            String nombreDuenio = TextBoxNombreDuenioModificar.Text;
            String enfermedad = "a";//TextBoxEnfermedadModificar.Text;
            if (especie.Length > 2 && raza.Length > 2 && nombreDuenio.Length > 3)
            {
                if (adminMascota.modificarMascota(id, nombre, especie, raza, edad, peso, estatura,
                    nombreDuenio))
                {
                    MessageBox.Show(" Se ha guardado tus datos ");
                    TextBoxIDModificar.Clear();
                    TextBoxEspecieModificar.Clear();
                    TextBoxRazaModificar.Clear();
                    TextBoxEdadModificar.Clear();
                    TextBoxPesoModificar.Clear();
                    TextBoxEstaturaModificar.Clear();
                    TextBoxNombreDuenioModificar.Clear();
                    TextBoxEnfermedadModificar.Clear();
                    textBoxNombre.Clear();
                }
                else
                {
                    MessageBox.Show(" El coronavirus evito que esto se guardara");
                }
            }
            else
            {
                MessageBox.Show("Datos Incompletos Favor de Verificar");
            }
        }

        private void ButtonLimpiarDeModificar_Click(object sender, EventArgs e)
        {
            TextBoxIDModificar.Clear();
            TextBoxEspecieModificar.Clear();
            TextBoxRazaModificar.Clear();
            TextBoxEdadModificar.Clear();
            TextBoxPesoModificar.Clear();
            TextBoxEstaturaModificar.Clear();
            TextBoxNombreDuenioModificar.Clear();
            TextBoxEnfermedadModificar.Clear();
            textBoxNombre.Clear();
        }

        private void BotonConsultarIDEliminar_Click(object sender, EventArgs e)
        {
            AdminMascotas adminMascota = new AdminMascotas();
            Mascota mascota = new Mascota();
            String id = TextBoxIDEliminar.Text;
            mascota = adminMascota.consultarMascota(id);
            if(mascota != null)
            {
                ButtonBorrar.Enabled = true;
                LabelEliminarEspecie.Text = mascota.dameEspecie();
                LabelEliminarRaza.Text = mascota.dameRaza();
                LabelEliminarEdad.Text = mascota.dameEdad().ToString();
                LabelEliminarPeso.Text = mascota.damePeso().ToString();
                LabelEliminarEstatura.Text = mascota.dameEstatura().ToString();
                LabelEliminarNombreDuenio.Text = mascota.dameNombreDuenio().ToString();
                //LabelEliminarEnfermedad.Text = " Pedorrera Masiva";                    PIDU QUIERE PONER LA PEDORRERA Y YO DIGO QUE NO
            }
            else
            {
                MessageBox.Show(" No hay registros de la mascota");
            }
        }

        private void ButtonBorrar_Click(object sender, EventArgs e)
        {
            AdminMascotas adminMascota = new AdminMascotas();
            Mascota mascota = new Mascota();
            String id = TextBoxIDEliminar.Text;
            mascota = adminMascota.consultarMascota(id);
            if (adminMascota.eliminarMascota(id))
            {
                MessageBox.Show(" Ahora comes con el enemigo ");
                TextBoxIDEliminar.Clear();
                LabelEliminarEspecie.Text = "...";
                LabelEliminarRaza.Text = "...";
                LabelEliminarEdad.Text = "...";
                LabelEliminarPeso.Text = "...";
                LabelEliminarEstatura.Text = "...";
                LabelEliminarNombreDuenio.Text = "...";
                LabelEliminarEnfermedad.Text = "...";
                BotonConsultarIDEliminar.Enabled = false;
            }
        }

        private void BotonListarMascotas_Click(object sender, EventArgs e)
        {
            AdminMascotas admin = new AdminMascotas();
            DataGridListar.Rows.Clear();
            List<Mascota> mascotas = admin.listarMascotas();

            foreach (Mascota mascota in mascotas)
            {
                DataGridListar.Rows.Add(new object[] {
                    mascota.dameId(),
                    mascota.dameNombreDuenio(),
                    mascota.dameRaza()
                });
            }
        }

        
    
        // LOGICA DE DATOS - FIN        
    }
}
