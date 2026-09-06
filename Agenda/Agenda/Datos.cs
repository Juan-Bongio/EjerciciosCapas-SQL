using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class AgendaDatos
    {
        private string _conexionString = "Server=localhost;Port=3306;Database=agenda;Uid=root;Pwd=;";

        // BUSCAR POR DNI
        public (int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)? BuscarPorDni(int dni)
        {
            string query = "SELECT DNI, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email FROM agenda WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@DNI", dni);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int dniDb = Convert.ToInt32(reader["DNI"]);
                        string apellidoDb = Convert.ToString(reader["Apellido"]);
                        string nombresDb = Convert.ToString(reader["Nombres"]);
                        string calleDb = Convert.ToString(reader["Calle"]);
                        string deptoDb = Convert.ToString(reader["Depto"]);
                        string pisoDb = Convert.ToString(reader["Piso"]);
                        string ciudadDb = Convert.ToString(reader["Ciudad"]);
                        int telefonoDb = Convert.ToInt32(reader["Telefono"]);
                        string emailDb = Convert.ToString(reader["Email"]);

                        return (dniDb, apellidoDb, nombresDb, calleDb, deptoDb, pisoDb, ciudadDb, telefonoDb, emailDb);
                    }
                }
            }

            return null;
        }

        // BUSCAR POR APELLIDO
        public List<(int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)> BuscarPorApellido(string apellido)
        {
            List<(int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)> lista =
                new List<(int, string, string, string, string, string, string, int, string)>();

            string query = "SELECT DNI, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email FROM agenda WHERE Apellido LIKE @Apellido";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Apellido", "%" + apellido + "%");

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add((
                            Convert.ToInt32(reader["DNI"]),
                            Convert.ToString(reader["Apellido"]),
                            Convert.ToString(reader["Nombres"]),
                            Convert.ToString(reader["Calle"]),
                            Convert.ToString(reader["Depto"]),
                            Convert.ToString(reader["Piso"]),
                            Convert.ToString(reader["Ciudad"]),
                            Convert.ToInt32(reader["Telefono"]),
                            Convert.ToString(reader["Email"])
                        ));
                    }
                }
            }

            return lista;
        }

        // BUSCAR POR NOMBRES
        public List<(int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)> BuscarPorNombres(string nombres)
        {
            List<(int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)> lista =
                new List<(int, string, string, string, string, string, string, int, string)>();

            string query = "SELECT DNI, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email FROM agenda WHERE Nombres LIKE @Nombres";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombres", "%" + nombres + "%");

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add((
                            Convert.ToInt32(reader["DNI"]),
                            Convert.ToString(reader["Apellido"]),
                            Convert.ToString(reader["Nombres"]),
                            Convert.ToString(reader["Calle"]),
                            Convert.ToString(reader["Depto"]),
                            Convert.ToString(reader["Piso"]),
                            Convert.ToString(reader["Ciudad"]),
                            Convert.ToInt32(reader["Telefono"]),
                            Convert.ToString(reader["Email"])
                        ));
                    }
                }
            }

            return lista;
        }

        // BUSCAR POR CALLE
        public List<(int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)> BuscarPorCalle(string calle)
        {
            List<(int DNI, string Apellido, string Nombres, string Calle, string Depto, string Piso, string Ciudad, int Telefono, string Email)> lista =
                new List<(int, string, string, string, string, string, string, int, string)>();

            string query = "SELECT DNI, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email FROM agenda WHERE Calle LIKE @Calle";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Calle", "%" + calle + "%");

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add((
                            Convert.ToInt32(reader["DNI"]),
                            Convert.ToString(reader["Apellido"]),
                            Convert.ToString(reader["Nombres"]),
                            Convert.ToString(reader["Calle"]),
                            Convert.ToString(reader["Depto"]),
                            Convert.ToString(reader["Piso"]),
                            Convert.ToString(reader["Ciudad"]),
                            Convert.ToInt32(reader["Telefono"]),
                            Convert.ToString(reader["Email"])
                        ));
                    }
                }
            }

            return lista;
        }

        // AGREGAR
        public bool Agregar(int dni, string apellido, string nombres, string calle, string depto, string piso, string ciudad, int telefono, string email)
        {
            string query = "INSERT INTO agenda (DNI, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email) " +
                           "VALUES (@DNI, @Apellido, @Nombres, @Calle, @Depto, @Piso, @Ciudad, @Telefono, @Email)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                comando.Parameters.AddWithValue("@Calle", calle);
                comando.Parameters.AddWithValue("@Depto", depto);
                comando.Parameters.AddWithValue("@Piso", piso);
                comando.Parameters.AddWithValue("@Ciudad", ciudad);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(int dni, string apellido, string nombres, string calle, string depto, string piso, string ciudad, int telefono, string email)
        {
            string query = "UPDATE agenda SET Apellido = @Apellido, Nombres = @Nombres, Calle = @Calle, " +
                           "Depto = @Depto, Piso = @Piso, Ciudad = @Ciudad, Telefono = @Telefono, Email = @Email " +
                           "WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                comando.Parameters.AddWithValue("@Calle", calle);
                comando.Parameters.AddWithValue("@Depto", depto);
                comando.Parameters.AddWithValue("@Piso", piso);
                comando.Parameters.AddWithValue("@Ciudad", ciudad);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(int dni)
        {
            string query = "DELETE FROM agenda WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@DNI", dni);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}