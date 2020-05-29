using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Veterinaria
{
    class DAOMascota
    {
        //Datos para realizar la conexión
        const String HOST = "127.0.0.1";
        const String PUERTO = "3306";
        const String NOMBRE_USUARIO_BDD = "root";
        const String CONTRASENIA = "qweasd123";

        //Datos para ejecutar querys
        const String NOMBRE_DE_LA_BDD = "veterinaria";
        const String NOMBRE_DE_LA_TABLA = "mascota";

        MySqlConnection conexion;
        public DAOMascota()
        {
            conectarBDD();
        }
        ~DAOMascota()
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

        public bool existeMascota(String id)
        {
            bool laMascotaExiste = false;
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT * FROM " + NOMBRE_DE_LA_TABLA + " WHERE id_mascota = "+ id +";";

            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);

            if (resultadoQuery.HasRows)//Comprobamos si la tabla resultante tiene datos
            {
                laMascotaExiste = true;
            }
            resultadoQuery.Close(); //Es necesario cerrar el MySqlDataReader sino marca error

            return laMascotaExiste;
        }

        public bool eliminar(String id)
        {
            bool seEliminoConExito = false;
            String query =
                "USE " + NOMBRE_DE_LA_BDD + "; " +
                "DELETE FROM " + NOMBRE_DE_LA_TABLA + " WHERE " +
                "id_mascota = " + id + ";";

            if (existeMascota(id))
            {
                obtenerResultadoDelQuery(query).Close();
                seEliminoConExito = true;
            }

            return seEliminoConExito;
        }
        public bool actualizar(Mascota mascota)
        {
            bool seActualizoConExito = false;
            String query =
               "USE " + NOMBRE_DE_LA_BDD + ";" +
               "UPDATE " + NOMBRE_DE_LA_TABLA +
               " SET nombre  = '" + mascota.dameNombre() + "'," +
               " edad  = '" + mascota.dameEdad() + "'," +
               " especie  = '" + mascota.dameEspecie() + "'," +
               " raza = '" + mascota.dameRaza() + "'," +
               " peso  = '" + mascota.damePeso() + "'," +
               " estatura  = '" + mascota.dameEstatura() + "'," +
               " nombre_duenio    = '" + mascota.dameNombreDuenio() + "'" +
               " WHERE id_mascota  = " + mascota.dameId() + ";";

            if (existeMascota(mascota.dameId()))
            {
                MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);
                resultadoQuery.Read();
                resultadoQuery.Close();
                seActualizoConExito = true;
            }

            return seActualizoConExito;
        }

        public Mascota consultarMascota(String id)
        {
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT * FROM " + NOMBRE_DE_LA_TABLA + " WHERE id_mascota = " + id + ";";

            Mascota mascota;

            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);
            resultadoQuery.Read();
            

            if (resultadoQuery.HasRows)
            {
                mascota = new Mascota( id,
                                       resultadoQuery["nombre"].ToString(),
                                       resultadoQuery["especie"].ToString(),
                                       resultadoQuery["raza"].ToString(),
                                       Convert.ToInt32(resultadoQuery["edad"].ToString()),
                                       Convert.ToDouble(resultadoQuery["peso"].ToString()),
                                       Convert.ToDouble(resultadoQuery["estatura"].ToString()),
                                       resultadoQuery["nombre_duenio"].ToString());
            }
            else
            {
                mascota = null;
            }
            resultadoQuery.Close();

            return mascota;
        }

        public List<Mascota> consultarMascotas()
        {
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "SELECT * FROM " + NOMBRE_DE_LA_TABLA + ";";

            List<Mascota> mascotas = new List<Mascota>();

            MySqlDataReader resultadoQuery = obtenerResultadoDelQuery(query);

            if (resultadoQuery.HasRows)
            {
                while (resultadoQuery.Read())
                {
                    Mascota mascota =  new Mascota(resultadoQuery["id_mascota"].ToString(),
                                                   resultadoQuery["nombre"].ToString(),
                                                   resultadoQuery["especie"].ToString(),
                                                   resultadoQuery["raza"].ToString(),
                                                   Convert.ToInt32(resultadoQuery["edad"].ToString()),
                                                   Convert.ToDouble(resultadoQuery["peso"].ToString()),
                                                   Convert.ToDouble(resultadoQuery["estatura"].ToString()),
                                                   resultadoQuery["nombre_duenio"].ToString());
                    mascotas.Add(mascota);
                }

            }
            else
            {
                mascotas = null;
            }

            resultadoQuery.Close();

            return mascotas;
        }

        public bool agregar(Mascota mascota)
        {
            bool seAgregoConExito = true;
            String query =
                "USE " + NOMBRE_DE_LA_BDD + ";" +
                "INSERT INTO " + NOMBRE_DE_LA_TABLA +
                "(nombre, edad, especie, raza, peso, estatura, nombre_duenio)" +
                " VALUES ('" + mascota.dameNombre() + "', "
                          + mascota.dameEdad() + ", '"
                          + mascota.dameEspecie() + "', '"
                          + mascota.dameRaza() + "', '"
                          + mascota.damePeso() + "', '"
                          + mascota.dameEstatura() + "', '"
                          + mascota.dameNombreDuenio() + "');";

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
