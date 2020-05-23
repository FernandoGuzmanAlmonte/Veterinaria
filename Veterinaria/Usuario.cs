using System;
using System.Collections.Generic;
using System.Text;

namespace Veterinaria
{
    class Usuario
    {
        private String correoElectronico;
        private String contrasenia;
        private String nombre;
        private String apellidoPaterno;
        private String apellidoMaterno;
        private String telefono;
        private String fechaContrato;
        private String tipoUsuario;

        public Usuario() { }

        public Usuario(String correoElectronico, String contrasenia, String nombre,
            String apellidoPaterno, String apellidoMaterno, String telefono, String fechaContrato,
            String tipoUsuario)
        {
            this.correoElectronico = correoElectronico;
            this.contrasenia = contrasenia;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.telefono = telefono;
            this.fechaContrato = fechaContrato;
            this.tipoUsuario = tipoUsuario;
        }

        ~Usuario() { }

        public void fijaCorreoElectronico(String correoElectronico)
        {
            this.correoElectronico = correoElectronico;
        }

        public void fijaContrasenia(String contrasenia)
        {
            this.contrasenia = contrasenia;
        }

        public void fijaNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void fijaApellidoPaterno(String apellidoPaterno)
        {
            this.apellidoPaterno = apellidoPaterno;
        }

        public void fijaApellidoMaterno(String apellidoMaterno)
        {
            this.apellidoMaterno = apellidoMaterno;
        }

        public void fijaTelefono(String telefono)
        {
            this.telefono = telefono;
        }

        public void fijaFechaContrato(String fechaContrato)
        {
            this.fechaContrato = fechaContrato;
        }

        public void fijaTipoUsuario(String tipoUsuario)
        {
            this.tipoUsuario = tipoUsuario;
        }

        public String dameCorreoElectronico() => correoElectronico;

        public String dameContrasenia() => contrasenia;

        public String dameNombre() => nombre;

        public String dameApellidoPaterno() => apellidoPaterno;

        public String dameApellidoMaterno() => apellidoMaterno;

        public String dameTelefono() => telefono;

        public String dameFechaContrato() => fechaContrato;

        public String dameTipoUsuario() => tipoUsuario;
    }
}
