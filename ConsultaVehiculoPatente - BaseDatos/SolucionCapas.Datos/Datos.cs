using MySql.Data.MySqlClient;
using System;

namespace SolucionCapas.Datos
{
    public class VehiculosDatos
    {
        private string _conexionString = "Server=localhost;Port=3306;Database=capas;Uid=root;Pwd=;";

        // BUSCAR
        public (string Patente, string Modelo, bool TieneDeuda)? BuscarPorPatente(string patente)
        {
            string query = "SELECT Patente, Modelo, TieneDeuda FROM vehiculos WHERE Patente = @Patente";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Patente", patente);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string patenteDb = Convert.ToString(reader["Patente"]);
                        string modeloDb = Convert.ToString(reader["Modelo"]);
                        bool tieneDeudaDb = Convert.ToBoolean(reader["TieneDeuda"]);

                        return (patenteDb, modeloDb, tieneDeudaDb);
                    }
                }
            }

            return null;
        }

        // AGREGAR
        public bool Agregar(string patente, string modelo, bool tieneDeuda)
        {
            string query = "INSERT INTO vehiculos (Patente, Modelo, TieneDeuda) VALUES (@Patente, @Modelo, @TieneDeuda)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Patente", patente);
                comando.Parameters.AddWithValue("@Modelo", modelo);
                comando.Parameters.AddWithValue("@TieneDeuda", tieneDeuda);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(string patente, string modelo, bool tieneDeuda)
        {
            string query = "UPDATE vehiculos SET Modelo = @Modelo, TieneDeuda = @TieneDeuda WHERE Patente = @Patente";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Patente", patente);
                comando.Parameters.AddWithValue("@Modelo", modelo);
                comando.Parameters.AddWithValue("@TieneDeuda", tieneDeuda);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(string patente)
        {
            string query = "DELETE FROM vehiculos WHERE Patente = @Patente";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Patente", patente);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}