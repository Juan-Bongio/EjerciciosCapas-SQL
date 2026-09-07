using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class AgendaDatos
    {
        private string _conexionString = "Server=localhost;Port=3306;Database=agenda;Uid=root;Pwd=;";

        // BUSCAR POR DNI
        public (int DNI, long CuilCuit, string Apellido, string Nombres, string Calle, string Depto, int Piso,
            string Ciudad, int Telefono, string Email, DateTime FechaAlta, string EstadoCivil,
            string Nacionalidad, string Provincia, int CodigoPostal, string Barrio, int TelefonoAlternativo,
            string Instagram, string ProfesionOcupacion, string EmpresaLugarTrabajo, string NivelEstudios,
            string Estado, string MetodoPagoPreferido, string Observaciones)? BuscarPorDni(int dni)
        {
            string query = "SELECT * FROM agenda WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@DNI", dni);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return CrearPersona(reader);
                    }
                }
            }

            return null;
        }

        // BUSCAR POR APELLIDO
        public List<(int DNI, long CuilCuit, string Apellido, string Nombres, string Calle, string Depto, int Piso,
            string Ciudad, int Telefono, string Email, DateTime FechaAlta, string EstadoCivil,
            string Nacionalidad, string Provincia, int CodigoPostal, string Barrio, int TelefonoAlternativo,
            string Instagram, string ProfesionOcupacion, string EmpresaLugarTrabajo, string NivelEstudios,
            string Estado, string MetodoPagoPreferido, string Observaciones)> BuscarPorApellido(string apellido)
        {
            List<(int, long, string, string, string, string, int, string, int, string, DateTime, string,
                string, string, int, string, int, string, string, string, string, string, string, string)> lista =
                new List<(int, long, string, string, string, string, int, string, int, string, DateTime, string,
                string, string, int, string, int, string, string, string, string, string, string, string)>();

            string query = "SELECT * FROM agenda WHERE Apellido LIKE @Apellido";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Apellido", "%" + apellido + "%");

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(CrearPersona(reader));
                    }
                }
            }

            return lista;
        }

        // BUSCAR POR NOMBRES
        public List<(int DNI, long CuilCuit, string Apellido, string Nombres, string Calle, string Depto, int Piso,
            string Ciudad, int Telefono, string Email, DateTime FechaAlta, string EstadoCivil,
            string Nacionalidad, string Provincia, int CodigoPostal, string Barrio, int TelefonoAlternativo,
            string Instagram, string ProfesionOcupacion, string EmpresaLugarTrabajo, string NivelEstudios,
            string Estado, string MetodoPagoPreferido, string Observaciones)> BuscarPorNombres(string nombres)
        {
            List<(int, long, string, string, string, string, int, string, int, string, DateTime, string,
            string, string, int, string, int, string, string, string, string, string, string, string)> lista =
            new List<(int, long, string, string, string, string, int, string, int, string, DateTime, string,
            string, string, int, string, int, string, string, string, string, string, string, string)>();

            string query = "SELECT * FROM agenda WHERE Nombres LIKE @Nombres";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombres", "%" + nombres + "%");

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(CrearPersona(reader));
                    }
                }
            }

            return lista;
        }

        // BUSCAR POR CALLE
        public List<(int DNI, long CuilCuit, string Apellido, string Nombres, string Calle, string Depto, int Piso,
            string Ciudad, int Telefono, string Email, DateTime FechaAlta, string EstadoCivil,
            string Nacionalidad, string Provincia, int CodigoPostal, string Barrio, int TelefonoAlternativo,
            string Instagram, string ProfesionOcupacion, string EmpresaLugarTrabajo, string NivelEstudios,
            string Estado, string MetodoPagoPreferido, string Observaciones)> BuscarPorCalle(string calle)
        {
            List<(int, long, string, string, string, string, int, string, int, string, DateTime, string,
                string, string, int, string, int, string, string, string, string, string, string, string)> lista =
                new List<(int, long, string, string, string, string, int, string, int, string, DateTime, string,
                string, string, int, string, int, string, string, string, string, string, string, string)>();

            string query = "SELECT * FROM agenda WHERE Calle LIKE @Calle";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Calle", "%" + calle + "%");

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(CrearPersona(reader));
                    }
                }
            }

            return lista;
        }

        // AGREGAR
        public bool Agregar(
            int dni,
            long cuilCuit,
            string apellido,
            string nombres,
            string calle,
            string depto,
            int piso,
            string ciudad,
            int telefono,
            string email,
            DateTime fechaAlta,
            string estadoCivil,
            string nacionalidad,
            string provincia,
            int codigoPostal,
            string barrio,
            int telefonoAlternativo,
            string instagram,
            string profesionOcupacion,
            string empresaLugarTrabajo,
            string nivelEstudios,
            string estado,
            string metodoPagoPreferido,
            string observaciones)
        {
            string query = @"INSERT INTO agenda
                (DNI, CUIL_CUIT, Apellido, Nombres, Calle, Depto, Piso, Ciudad,
                 Telefono, Email, FechaAlta, EstadoCivil, Nacionalidad, Provincia,
                 CodigoPostal, Barrio, TelefonoAlternativo, Instagram,
                 ProfesionOcupacion, EmpresaLugarTrabajo, NivelEstudios,
                 Estado, MetodoPagoPreferido, Observaciones)
                VALUES
                (@DNI, @CUIL_CUIT, @Apellido, @Nombres, @Calle, @Depto, @Piso, @Ciudad,
                 @Telefono, @Email, @FechaAlta, @EstadoCivil, @Nacionalidad, @Provincia,
                 @CodigoPostal, @Barrio, @TelefonoAlternativo, @Instagram,
                 @ProfesionOcupacion, @EmpresaLugarTrabajo, @NivelEstudios,
                 @Estado, @MetodoPagoPreferido, @Observaciones)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);
                comando.Parameters.AddWithValue("@CUIL_CUIT", cuilCuit);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                comando.Parameters.AddWithValue("@Calle", calle);
                comando.Parameters.AddWithValue("@Depto", depto);
                comando.Parameters.AddWithValue("@Piso", piso);
                comando.Parameters.AddWithValue("@Ciudad", ciudad);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@FechaAlta", fechaAlta);
                comando.Parameters.AddWithValue("@EstadoCivil", estadoCivil);
                comando.Parameters.AddWithValue("@Nacionalidad", nacionalidad);
                comando.Parameters.AddWithValue("@Provincia", provincia);
                comando.Parameters.AddWithValue("@CodigoPostal", codigoPostal);
                comando.Parameters.AddWithValue("@Barrio", barrio);
                comando.Parameters.AddWithValue("@TelefonoAlternativo", telefonoAlternativo);
                comando.Parameters.AddWithValue("@Instagram", instagram);
                comando.Parameters.AddWithValue("@ProfesionOcupacion", profesionOcupacion);
                comando.Parameters.AddWithValue("@EmpresaLugarTrabajo", empresaLugarTrabajo);
                comando.Parameters.AddWithValue("@NivelEstudios", nivelEstudios);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.Parameters.AddWithValue("@MetodoPagoPreferido", metodoPagoPreferido);
                comando.Parameters.AddWithValue("@Observaciones", observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(
            int dni,
            long cuilCuit,
            string apellido,
            string nombres,
            string calle,
            string depto,
            int piso,
            string ciudad,
            int telefono,
            string email,
            DateTime fechaAlta,
            string estadoCivil,
            string nacionalidad,
            string provincia,
            int codigoPostal,
            string barrio,
            int telefonoAlternativo,
            string instagram,
            string profesionOcupacion,
            string empresaLugarTrabajo,
            string nivelEstudios,
            string estado,
            string metodoPagoPreferido,
            string observaciones)
        {
            string query = @"UPDATE agenda SET
                CUIL_CUIT = @CUIL_CUIT,
                Apellido = @Apellido,
                Nombres = @Nombres,
                Calle = @Calle,
                Depto = @Depto,
                Piso = @Piso,
                Ciudad = @Ciudad,
                Telefono = @Telefono,
                Email = @Email,
                FechaAlta = @FechaAlta,
                EstadoCivil = @EstadoCivil,
                Nacionalidad = @Nacionalidad,
                Provincia = @Provincia,
                CodigoPostal = @CodigoPostal,
                Barrio = @Barrio,
                TelefonoAlternativo = @TelefonoAlternativo,
                Instagram = @Instagram,
                ProfesionOcupacion = @ProfesionOcupacion,
                EmpresaLugarTrabajo = @EmpresaLugarTrabajo,
                NivelEstudios = @NivelEstudios,
                Estado = @Estado,
                MetodoPagoPreferido = @MetodoPagoPreferido,
                Observaciones = @Observaciones
                WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);
                comando.Parameters.AddWithValue("@CUIL_CUIT", cuilCuit);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                comando.Parameters.AddWithValue("@Calle", calle);
                comando.Parameters.AddWithValue("@Depto", depto);
                comando.Parameters.AddWithValue("@Piso", piso);
                comando.Parameters.AddWithValue("@Ciudad", ciudad);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@FechaAlta", fechaAlta);
                comando.Parameters.AddWithValue("@EstadoCivil", estadoCivil);
                comando.Parameters.AddWithValue("@Nacionalidad", nacionalidad);
                comando.Parameters.AddWithValue("@Provincia", provincia);
                comando.Parameters.AddWithValue("@CodigoPostal", codigoPostal);
                comando.Parameters.AddWithValue("@Barrio", barrio);
                comando.Parameters.AddWithValue("@TelefonoAlternativo", telefonoAlternativo);
                comando.Parameters.AddWithValue("@Instagram", instagram);
                comando.Parameters.AddWithValue("@ProfesionOcupacion", profesionOcupacion);
                comando.Parameters.AddWithValue("@EmpresaLugarTrabajo", empresaLugarTrabajo);
                comando.Parameters.AddWithValue("@NivelEstudios", nivelEstudios);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.Parameters.AddWithValue("@MetodoPagoPreferido", metodoPagoPreferido);
                comando.Parameters.AddWithValue("@Observaciones", observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
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

                return comando.ExecuteNonQuery() > 0;
            }
        }

        // CREAR TUPLA
        private (int DNI, long CuilCuit, string Apellido, string Nombres, string Calle, string Depto, int Piso,
            string Ciudad, int Telefono, string Email, DateTime FechaAlta, string EstadoCivil,
            string Nacionalidad, string Provincia, int CodigoPostal, string Barrio, int TelefonoAlternativo,
            string Instagram, string ProfesionOcupacion, string EmpresaLugarTrabajo, string NivelEstudios,
            string Estado, string MetodoPagoPreferido, string Observaciones) CrearPersona(MySqlDataReader reader)
        {
            return (
                Convert.ToInt32(reader["DNI"]),
                Convert.ToInt64(reader["CUIL_CUIT"]),
                Convert.ToString(reader["Apellido"]),
                Convert.ToString(reader["Nombres"]),
                Convert.ToString(reader["Calle"]),
                Convert.ToString(reader["Depto"]),
                Convert.ToInt32(reader["Piso"]),
                Convert.ToString(reader["Ciudad"]),
                Convert.ToInt32(reader["Telefono"]),
                Convert.ToString(reader["Email"]),
                Convert.ToDateTime(reader["FechaAlta"]),
                Convert.ToString(reader["EstadoCivil"]),
                Convert.ToString(reader["Nacionalidad"]),
                Convert.ToString(reader["Provincia"]),
                Convert.ToInt32(reader["CodigoPostal"]),
                Convert.ToString(reader["Barrio"]),
                Convert.ToInt32(reader["TelefonoAlternativo"]),
                Convert.ToString(reader["Instagram"]),
                Convert.ToString(reader["ProfesionOcupacion"]),
                Convert.ToString(reader["EmpresaLugarTrabajo"]),
                Convert.ToString(reader["NivelEstudios"]),
                Convert.ToString(reader["Estado"]),
                Convert.ToString(reader["MetodoPagoPreferido"]),
                Convert.ToString(reader["Observaciones"])
            );
        }
    }
}