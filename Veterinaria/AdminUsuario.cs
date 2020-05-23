using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Veterinaria
{
    class AdminUsuario
    {

        private DAOUsuario daoUsuario = new DAOUsuario();

        public bool existeUsuario(String correo, String contra)
        {
            return daoUsuario.existeUsuario(correo, contra);
        }
        public bool existeUsuario(String correoElectronico)
        {
            if (daoUsuario.existeUsuario(correoElectronico)) return true;
            else return false;
        }

        public List<Usuario> listarUsuarios()
        {
            return daoUsuario.consultarUsuarios();
        }

        public Usuario consultarUsuario(String correo)
        {
            return daoUsuario.consultarUsuario(correo);
        }

        public AdminUsuario() { }
        ~AdminUsuario() { }

        public bool agregarUsuario(String correoElectronico, String contrasenia, String nombre,
            String apellidoPaterno, String apellidoMaterno, String telefono, String fechaContrato,
            String tipoUsuario)
        {
            Usuario usuario = new Usuario(correoElectronico, contrasenia, nombre, apellidoPaterno, 
                apellidoMaterno, telefono, fechaContrato, tipoUsuario);

            if (daoUsuario.agregar(usuario)) return true;
            else return false;
        }

        public bool modificarUsuario(String correoElectroico, String contrasenia, String nombre,
            String apellidoPaterno, String apellidoMaterno, String telefono, String fechaContrato,
            String tipoUsuario)
        {
            if (daoUsuario.actualizar(new Usuario(correoElectroico, contrasenia, nombre,
                apellidoPaterno, apellidoMaterno, telefono, fechaContrato, tipoUsuario))) return true;
            else return false;
        }

        public bool eliminarUsuario(String correo)
        {
            if (daoUsuario.eliminar(correo)) return true;
            else return false;
        }
            
        }
}
