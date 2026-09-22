using MySql.Data.MySqlClient;

namespace SolucionCapas.Datos
{
    public class LibrosDatos
    {
        private string _conexionString = "Server=localhost;Port=3307;Database=capas;Uid=root;Pwd=;";

        // BUSCAR
        public (int Isbn, string Titulo, string Autor, string Disponible)? BuscarPorIsbn(string Isbn)
        {
            string query = "SELECT Isbn, Titulo, Autor, Disponible FROM biblioteca WHERE Isbn = @Isbn";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Isbn", Isbn);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int isbnDb = Convert.ToInt32(reader["Isbn"]);
                        string tituloDb = Convert.ToString(reader["Titulo"]);
                        string autorDb = Convert.ToString(reader["Autor"]);
                        string disponibleDb = Convert.ToString(reader["Disponible"]);

                        return (isbnDb, tituloDb, autorDb, disponibleDb);
                    }
                }
            }

            return null;
        }

        // AGREGAR
        public bool Agregar(int isbn, string titulo, string autor, string disponible)
        {
            string query = "INSERT INTO biblioteca (Isbn, Titulo, Autor, Disponible) VALUES (@Isbn, @Titulo, @Autor, @Disponible)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Isbn", isbn);
                comando.Parameters.AddWithValue("@Titulo", titulo);
                comando.Parameters.AddWithValue("@Autor", autor);
                comando.Parameters.AddWithValue("@Disponible", disponible);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(int isbn, string titulo, string autor, string disponible)
        {
            string query = "UPDATE biblioteca SET Titulo = @Titulo, Autor = @Autor, Disponible = @Disponible WHERE Isbn = @Isbn";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Isbn", isbn);
                comando.Parameters.AddWithValue("@Titulo", titulo);
                comando.Parameters.AddWithValue("@Autor", autor);
                comando.Parameters.AddWithValue("@Disponible", disponible);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(int isbn)
        {
            string query = "DELETE FROM biblioteca WHERE Isbn = @Isbn";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Isbn", isbn);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}