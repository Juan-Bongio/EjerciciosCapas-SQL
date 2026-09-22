using MySql.Data.MySqlClient;

namespace SolucionCapas.Datos
{
    public class EmpleadosDatos
    {
        private string _conexionString = "Server=localhost;Port=3306;Database=capas;Uid=root;Pwd=;";

        // BUSCAR
        public (int Id, string Nombre, string Puesto, string Departamento)? BuscarPorId(int id)
        {
            string query = "SELECT Id, Nombre, Puesto, Departamento FROM empleados WHERE Id = @Id";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idDb = Convert.ToInt32(reader["Id"]);
                        string nombreDb = Convert.ToString(reader["Nombre"]);
                        string puestoDb = Convert.ToString(reader["Puesto"]);
                        string departamentoDb = Convert.ToString(reader["Departamento"]);

                        return (idDb, nombreDb, puestoDb, departamentoDb);
                    }
                }
            }

            return null;
        }

        // AGREGAR
        public bool Agregar(int id, string nombre, string puesto, string departamento)
        {
            string query = "INSERT INTO empleados (Id, Nombre, Puesto, Departamento) VALUES (@Id, @Nombre, @Puesto, @Departamento)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Puesto", puesto);
                comando.Parameters.AddWithValue("@Departamento", departamento);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(int id, string nombre, string puesto, string departamento)
        {
            string query = "UPDATE empleados SET Nombre = @Nombre, Puesto = @Puesto, Departamento = @Departamento WHERE Id = @Id";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Puesto", puesto);
                comando.Parameters.AddWithValue("@Departamento", departamento);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(int id)
        {
            string query = "DELETE FROM empleados WHERE Id = @Id";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}