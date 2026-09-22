using MySql.Data.MySqlClient;
using System;

namespace SolucionCapas.Datos
{
    public class ProductosDatos
    {
        private string _conexionString = "Server=localhost;Port=3306;Database=capas;Uid=root;Pwd=;";

        // BUSCAR
        public (string Codigo, string Nombre, decimal Precio)? BuscarPorCodigo(string codigo)
        {
            string query = "SELECT Codigo, Nombre, Precio FROM productos WHERE Codigo = @Codigo";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Codigo", codigo);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string codigoDb = Convert.ToString(reader["Codigo"]);
                        string nombreDb = Convert.ToString(reader["Nombre"]);
                        decimal precioDb = Convert.ToDecimal(reader["Precio"]);

                        return (codigoDb, nombreDb, precioDb);
                    }
                }
            }

            return null;
        }

        // AGREGAR
        public bool Agregar(string codigo, string nombre, decimal precio)
        {
            string query = "INSERT INTO productos (Codigo, Nombre, Precio) VALUES (@Codigo, @Nombre, @Precio)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Codigo", codigo);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Precio", precio);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(string codigo, string nombre, decimal precio)
        {
            string query = "UPDATE productos SET Nombre = @Nombre, Precio = @Precio WHERE Codigo = @Codigo";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Codigo", codigo);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Precio", precio);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(string codigo)
        {
            string query = "DELETE FROM productos WHERE Codigo = @Codigo";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Codigo", codigo);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}