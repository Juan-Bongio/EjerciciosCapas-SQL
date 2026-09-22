using MySql.Data.MySqlClient;

namespace SolucionCapas.Datos
{
    public class AlumnosDatos
    {
        private string _conexionString = "Server=localhost;Port=3306;Database=capas;Uid=root;Pwd=;";

        // BUSCAR
        public (int Legajo, string Nombre, string Condicion)? BuscarPorLegajo(int legajo)
        {
            string query = "SELECT Legajo, Nombre, Condicion FROM alumnos WHERE Legajo = @Legajo";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Legajo", legajo);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int legajoDb = Convert.ToInt32(reader["Legajo"]);
                        string nombreDb = Convert.ToString(reader["Nombre"]);
                        string condicionDb = Convert.ToString(reader["Condicion"]);

                        return (legajoDb, nombreDb, condicionDb);
                    }
                }
            }

            return null;
        }

        // AGREGAR
        public bool Agregar(int legajo, string nombre, string condicion)
        {
            string query = "INSERT INTO alumnos (Legajo, Nombre, Condicion) VALUES (@Legajo, @Nombre, @Condicion)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Legajo", legajo);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Condicion", condicion);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(int legajo, string nombre, string condicion)
        {
            string query = "UPDATE alumnos SET Nombre = @Nombre, Condicion = @Condicion WHERE Legajo = @Legajo";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Legajo", legajo);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Condicion", condicion);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(int legajo)
        {
            string query = "DELETE FROM alumnos WHERE Legajo = @Legajo";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Legajo", legajo);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}