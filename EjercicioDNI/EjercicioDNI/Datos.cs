using MySql.Data.MySqlClient;

namespace SolucionCapas.Datos
{
    public class PersonaDatos
    {
        private string _conexionString = "Server=localhost;Database=biblioteca;Uid=root;Pwd=;";

        // BUSCAR
        public (string Dni, string Nombre)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Nombre FROM autor WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string dniDb = reader["Dni"].ToString();
                        string nombreDb = reader["Nombre"].ToString();

                        return (dniDb, nombreDb);
                    }
                }
            }

            return null;
        }

        // AGREGAR
        public bool Agregar(string dni, string nombre)
        {
            string query = "INSERT INTO autor (Dni, Nombre) VALUES (@Dni, @Nombre)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Nombre", nombre);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(string dni, string nuevoNombre)
        {
            string query = "UPDATE autor SET Nombre = @Nombre WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM autor WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}
