using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Veterinaria
{

    class DAOUsuario
    {
        //Datos para realizar la conexión
        const String HOST = "127.0.0.1";
        const String PUERTO = "3306";
        const String NOMBRE_USUARIO_BDD = "root";
        const String CONTRASENIA = "qweasd123";

        //Datos para ejecutar querys
        const String NOMBRE_DE_LA_BDD = "veterinaria";
        const String NOMBRE_DE_LA_TABLA = "usuario";

        MySqlConnection conexion;

        public DAOUsuario()
        {
            conectarBDD();
        }
        ~DAOUsuario()
        {
            conexion.Close();
        }

        void conectarBDD()
        {
            String datosParaConexion =
                "datasource=" + HOST + ";" +
                "port=" + PUERTO + ";" +
                "username=" + NOMBRE_USUARIO_BDD + ";" +
                "password=" + CONTRASENIA + ";";

            conexion = new MySqlConnection(datosParaConexion);
            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error no se pudo conectar a la base de datos.\n" +
                                "Mas detalles:\n\n" + ex.ToString());
            }
        }

        MySqlDataReader obtenerResultadoDelQuery(String query)
        {
            MySqlCommand comandoMysql;
            comandoMysql = new MySqlCommand(query, conexion);//Manda el query hacia 
                                                             //la conexión hecha
            return comandoMysql.ExecuteReader(); //Devuelve la tabla(matriz) con el resultado
        }


        public bool existeUsuario(String correo, String contrasenia)
        {
            bool elUsuarioExiste = false;
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT usuario.correo_electronico, usuario.contrasenia," +
                "usuario.nombre, usuario.apellido_paterno," +
                "usuario.apellido_materno,usuario.telefono," +
                "usuario.fecha_contrato, tipo_usuario.nombre as tipo_usuario " +
                "FROM usuario INNER JOIN tipo_usuario " +
                "ON tipo_usuario.id_tipo_usuario = usuario.id_tipo_usuario " +
                "AND usuario.correo_electronico = '" + correo + "' " +
                "AND usuario.contrasenia = '" + contrasenia + "';";


            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);

            if (resultadoQuery.HasRows)//Comprobamos si la tabla resultante tiene datos
            {
                elUsuarioExiste = true;
            }
            resultadoQuery.Close(); //Es necesario cerrar el MySqlDataReader sino marca error

            return elUsuarioExiste;
        }

        public bool existeUsuario(String correo)
        {
            bool elUsuarioExiste = false;
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT usuario.correo_electronico, usuario.contrasenia," +
                "usuario.nombre, usuario.apellido_paterno," +
                "usuario.apellido_materno,usuario.telefono," +
                "usuario.fecha_contrato, tipo_usuario.nombre as tipo_usuario " +
                "FROM usuario INNER JOIN tipo_usuario " +
                "ON tipo_usuario.id_tipo_usuario = usuario.id_tipo_usuario " +
                "AND usuario.correo_electronico = '" + correo + "';";

            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);

            if (resultadoQuery.HasRows)
            {
                elUsuarioExiste = true;
            }
            resultadoQuery.Close();

            return elUsuarioExiste;
        }

        public bool eliminar(String correo)
        {
            bool seEliminoConExito = false;
            String query =
                "USE " + NOMBRE_DE_LA_BDD + "; " +
                "DELETE FROM " + NOMBRE_DE_LA_TABLA + " WHERE " +
                "correo_electronico = '" + correo + "';";

            if (existeUsuario(correo))
            {
                obtenerResultadoDelQuery(query).Close();
                seEliminoConExito = true;
            }

            return seEliminoConExito;
        }
        public bool actualizar(Usuario usuario)
        {
            bool seActualizoConExito = false;
            int idTipoUsuario;
            string tipoUsuario, query;

            tipoUsuario = usuario.dameTipoUsuario();

            if (tipoUsuario == "Veterinario") idTipoUsuario = 1;
            else if (tipoUsuario == "Enfermero") idTipoUsuario = 2;
            else if (tipoUsuario == "Recepcionista") idTipoUsuario = 3;
            else idTipoUsuario = 4;

            query =
               "USE " + NOMBRE_DE_LA_BDD + ";" +
               "UPDATE " + NOMBRE_DE_LA_TABLA +
               " SET contrasenia = '" + usuario.dameContrasenia() + "'," +
               " nombre = '" + usuario.dameNombre() + "'," +
               " apellido_materno = '" + usuario.dameApellidoMaterno() + "'," +
               " apellido_paterno = '" + usuario.dameApellidoPaterno() + "'," +
               " telefono = '" + usuario.dameTelefono() + "'," +
               " fecha_contrato = '" + usuario.dameFechaContrato() + "'," +
               " id_tipo_usuario   = '" + idTipoUsuario + "'" +
               " WHERE correo_electronico = '" + usuario.dameCorreoElectronico() + "';";

            if (existeUsuario(usuario.dameCorreoElectronico()))
            {
                MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);
                resultadoQuery.Read();
                resultadoQuery.Close();
                seActualizoConExito = true;
            }

            return seActualizoConExito;
        }

        public Usuario consultarUsuario(String correo)
        {
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT usuario.correo_electronico,usuario.contrasenia," +
                "usuario.nombre,usuario.apellido_paterno," +
                "usuario.apellido_materno,usuario.telefono," +
                "usuario.fecha_contrato, tipo_usuario.nombre as tipo_usuario " +
                "FROM usuario INNER JOIN tipo_usuario " +
                "ON tipo_usuario.id_tipo_usuario = usuario.id_tipo_usuario " +
                "AND usuario.correo_electronico = '" + correo + "';";

            Usuario usuario;

            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);
            resultadoQuery.Read();

            if (resultadoQuery.HasRows)
            {
                usuario = new Usuario(correo,
                                       resultadoQuery["contrasenia"].ToString(),
                                       resultadoQuery["nombre"].ToString(),
                                       resultadoQuery["apellido_paterno"].ToString(),
                                       resultadoQuery["apellido_materno"].ToString(),
                                       resultadoQuery["telefono"].ToString(),
                                       resultadoQuery["fecha_contrato"].ToString(),
                                       resultadoQuery["tipo_usuario"].ToString());
            }
            else
            {
                usuario = null;
            }
            resultadoQuery.Close();

            return usuario;
        }

        public List<Usuario> consultarUsuarios()
        {
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT usuario.correo_electronico, usuario.contrasenia," +
                "usuario.nombre, usuario.apellido_paterno," +
                "usuario.apellido_materno,usuario.telefono," +
                "usuario.fecha_contrato, tipo_usuario.nombre as tipo_usuario " +
                "FROM usuario INNER JOIN tipo_usuario " +
                "ON tipo_usuario.id_tipo_usuario = usuario.id_tipo_usuario;";

            List<Usuario> usuarios = new List<Usuario>();

            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);

            if (resultadoQuery.HasRows)
            {
                while (resultadoQuery.Read())
                {
                    Usuario usuario = new Usuario(resultadoQuery["correo_electronico"].ToString(),
                                              resultadoQuery["contrasenia"].ToString(),
                                              resultadoQuery["nombre"].ToString(),
                                              resultadoQuery["apellido_paterno"].ToString(),
                                              resultadoQuery["apellido_materno"].ToString(),
                                              resultadoQuery["telefono"].ToString(),
                                              resultadoQuery["fecha_contrato"].ToString(),
                                              resultadoQuery["tipo_usuario"].ToString());
                    usuarios.Add(usuario);
                }

            }
            else
            {
                usuarios = null;
            }

            resultadoQuery.Close();

            return usuarios;
        }

        public bool agregar(Usuario usuario)
        {
            bool seAgregoConExito = true;
            int idTipoUsuario;
            String tipoUsuario, query;

            tipoUsuario = usuario.dameTipoUsuario();

            if (tipoUsuario == "Veterinario") idTipoUsuario = 1;
            else if (tipoUsuario == "Enfermero") idTipoUsuario = 2;
            else if (tipoUsuario == "Recepcionista") idTipoUsuario = 3;
            else idTipoUsuario = 4;

            query =
                "USE veterinaria ;" +
                "INSERT INTO usuario VALUES('" + usuario.dameCorreoElectronico() + "'," + idTipoUsuario +
                ", '" + usuario.dameNombre() + "', '" + usuario.dameApellidoPaterno() + "', '" +
                usuario.dameApellidoMaterno() + "', '" + usuario.dameContrasenia() + "', '"
                + usuario.dameTelefono() + "', '" + usuario.dameFechaContrato() + "');";

            try
            {
                obtenerResultadoDelQuery(query).Close();
            }
            catch (MySqlException ex)
            {
                string a = ex.Message;
                seAgregoConExito = false;
            }


            return seAgregoConExito;
        }
    }
}
