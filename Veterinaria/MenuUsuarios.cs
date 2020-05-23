using System;
using System.Drawing;
using System.Windows.Forms;
using Veterinaria;
using System.Collections.Generic;

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

            //inicializamos combo box
            TextBoxAgregarTipoUsuario.Items.Add("Veterinario");
            TextBoxAgregarTipoUsuario.Items.Add("Enfermero");
            TextBoxAgregarTipoUsuario.Items.Add("Recepcionista");
            TextBoxAgregarTipoUsuario.Items.Add("Super Usuario");

            TextBoxTipoUsuMod.Items.Add("Veterinario");
            TextBoxTipoUsuMod.Items.Add("Enfermero");
            TextBoxTipoUsuMod.Items.Add("Recepcionista");
            TextBoxTipoUsuMod.Items.Add("Super Usuario");
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
            TabuladorABC.SelectTab(4); // Cambiamos de pestaña a la pestaña 5(Listar) del TabControl
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

        private void ButtonGuardar_Click(object sender, EventArgs e)
        {
            String correoElectronico = TextBoxAgregarCorreoElectronico.Text;
            String contrasenia = TextBoxAgregarContrasenia.Text;
            String nombre = TextBoxAgregarNombre.Text;
            String apellidoPaterno = TextBoxAgregarApePaterno.Text;
            String apellidoMaterno = TextBoxAgregarApeMaterno.Text;
            String telefono = TextBoxAgregarTelefono.Text;
            String fechaContrato = TextBoxAgregarFechaContrato.Text;
            String tipoUsuario = TextBoxAgregarTipoUsuario.Text;

            if(correoElectronico.Length>10 && contrasenia.Length > 6 && nombre.Length > 2 && 
                apellidoPaterno.Length > 2 && apellidoMaterno.Length > 2 && telefono.Length == 10 && 
                fechaContrato.Length == 10 && tipoUsuario.Length > 2)
            {
                AdminUsuario adminUsuario = new AdminUsuario();
                if (adminUsuario.agregarUsuario(correoElectronico, contrasenia, nombre, 
                    apellidoMaterno, apellidoMaterno, telefono, fechaContrato, tipoUsuario))
                {
                    MessageBox.Show(" Se ha agregado con tu permiso");
                    TextBoxAgregarCorreoElectronico.Clear();
                    TextBoxAgregarContrasenia.Clear();
                    TextBoxAgregarNombre.Clear();
                    TextBoxAgregarApePaterno.Clear();
                    TextBoxAgregarApeMaterno.Clear();
                    TextBoxAgregarTelefono.Clear();
                    TextBoxAgregarFechaContrato.Clear();
                    TextBoxAgregarTipoUsuario.Text = "";
                }
                else MessageBox.Show(" No se ha podido guardar tus datos ");
            }
            else
            {
                MessageBox.Show("Faltan datos favor de compleatar o verificar la informacion (Amen)");
            }

            
        }

        private void ButtonLimpiarDeAgregar_Click(object sender, EventArgs e)
        {
            TextBoxAgregarCorreoElectronico.Clear();
            TextBoxAgregarContrasenia.Clear();
            TextBoxAgregarNombre.Clear();
            TextBoxAgregarApePaterno.Clear();
            TextBoxAgregarApeMaterno.Clear();
            TextBoxAgregarTelefono.Clear();
            TextBoxAgregarFechaContrato.Clear();
            TextBoxAgregarTipoUsuario.Text = "";
        }

        private void ButtonBuscarDeConsultar_Click(object sender, EventArgs e)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            Usuario usuario = new Usuario();
            String correo = TextBoxConsultaCorreo.Text;
            usuario = adminUsuario.consultarUsuario(correo);
            LabelConsultarNombre.Text = usuario.dameNombre();
            LabelApePatConsultar.Text = usuario.dameApellidoPaterno();
            LabelApeMatConsultar.Text = usuario.dameApellidoMaterno();
            LabelTelefConsultar.Text = usuario.dameTelefono();
            LabelFeContConsultar.Text = usuario.dameFechaContrato();
            LabelTipoUsConsultar.Text = usuario.dameTipoUsuario();
            LabelCorreoElecConsultar.Text = usuario.dameCorreoElectronico();
            LabelContraConsultar.Text = usuario.dameContrasenia();
        }

        private void BotonConsultaMod_Click(object sender, EventArgs e)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            Usuario controlarUsuario = new Usuario();
            String correo = TextBoxCorreoMod.Text;
            controlarUsuario = adminUsuario.consultarUsuario(correo);
            TextBoxNomMod.Text = controlarUsuario.dameNombre();
            TextBoxApePatMod.Text = controlarUsuario.dameApellidoPaterno();
            TextBoxApeMatMod.Text = controlarUsuario.dameApellidoMaterno();
            TextBoxTelefMod.Text = controlarUsuario.dameTelefono();
            TextBoxFeContMod.Text = controlarUsuario.dameFechaContrato();
            TextBoxTipoUsuMod.Text = controlarUsuario.dameTipoUsuario();
            TextBoxContraMod.Text = controlarUsuario.dameContrasenia();
        }

        private void ButtonActualizar_Click(object sender, EventArgs e)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            String correo = TextBoxCorreoMod.Text;
            String contrasenia = TextBoxContraMod.Text;
            String nombre = TextBoxNomMod.Text;
            String apellidoPaterno = TextBoxApePatMod.Text;
            String apellidoMaterno = TextBoxApeMatMod.Text;
            String telefono = TextBoxTelefMod.Text;
            String fechaContrato = TextBoxFeContMod.Text;
            String tipoUsuario = TextBoxTipoUsuMod.Text;
            if (contrasenia.Length > 6 && nombre.Length > 2 &&
                apellidoPaterno.Length > 2 && apellidoMaterno.Length > 2 && telefono.Length == 10 &&
                fechaContrato.Length == 10 && tipoUsuario.Length > 2) {
                if(adminUsuario.modificarUsuario(correo, contrasenia, nombre,
                    apellidoPaterno, apellidoMaterno, telefono, fechaContrato, tipoUsuario))
                {
                    MessageBox.Show(" Se ha guardado tus datos ");
                    TextBoxCorreoMod.Clear();
                    TextBoxContraMod.Clear();
                    TextBoxNomMod.Clear();
                    TextBoxApePatMod.Clear();
                    TextBoxApeMatMod.Clear();
                    TextBoxTelefMod.Clear();
                    TextBoxFeContMod.Clear();
                    TextBoxTipoUsuMod.Text = "";
                    
                }
                else
                {
                    MessageBox.Show(" El coronavairus evito que esto se guardara");
                }
            }
            else
            {
                MessageBox.Show("Datos incompletos favor de verificar");
            }
        }

        private void ButtonLimpiarDeModificar_Click(object sender, EventArgs e)
        {
            TextBoxCorreoMod.Clear();
            TextBoxContraMod.Clear();
            TextBoxNomMod.Clear();
            TextBoxApePatMod.Clear();
            TextBoxApeMatMod.Clear();
            TextBoxTelefMod.Clear();
            TextBoxFeContMod.Clear();
            TextBoxTipoUsuMod.Text = "";
        }

        private void ButtonBorrar_Click(object sender, EventArgs e)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            Usuario usuario = new Usuario();
            String correo = TextBoxEliminarCons.Text;
            usuario = adminUsuario.consultarUsuario(correo);
            if (adminUsuario.eliminarUsuario(correo))
            {
                MessageBox.Show(" Te Convertiste en lo que juraste destruir ");
                TextBoxEliminarCons.Clear();
                LabelEliminarNombre.Text = "...";
                LabelEliminarApePat.Text = "...";
                LabelEliminarApeMat.Text = "...";
                LabelEliminarTel.Text = "...";
                LabelEliminarFeCont.Text = "...";
                LabelEliminarTipoUs.Text = "...";
                LabelEliminarCorreo.Text = "...";
                LabelEliminarContras.Text = "...";
                ButtonBorrar.Enabled = false;
            }
        }

        private void BotonConsultarElim_Click(object sender, EventArgs e)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            Usuario usuario = new Usuario();
            String correo = TextBoxEliminarCons.Text;
            usuario = adminUsuario.consultarUsuario(correo);
            if (usuario != null)
            {
                ButtonBorrar.Enabled = true;
                LabelEliminarNombre.Text = usuario.dameNombre();
                LabelEliminarApePat.Text = usuario.dameApellidoPaterno();
                LabelEliminarApeMat.Text = usuario.dameApellidoMaterno();
                LabelEliminarTel.Text = usuario.dameTelefono();
                LabelEliminarFeCont.Text = usuario.dameFechaContrato();
                LabelEliminarTipoUs.Text = usuario.dameTipoUsuario();
                LabelEliminarCorreo.Text = usuario.dameCorreoElectronico();
                LabelEliminarContras.Text = usuario.dameContrasenia();
            }
            else
            {
                MessageBox.Show("No se ha encontrado el usuario");
            }
        }

        private void BotonListarUsuarios_Click(object sender, EventArgs e)
        {
            AdminUsuario admin = new AdminUsuario();
            DataGridListar.Rows.Clear();
            List<Usuario> usuarios = admin.listarUsuarios();

            foreach (Usuario usuario in usuarios)
            {
                DataGridListar.Rows.Add(new object[] {
                    usuario.dameCorreoElectronico(),
                    usuario.dameNombre(),
                    usuario.dameTipoUsuario()
                });
            }
        }
        // LOGICA DE DATOS - FIN
    }
}
