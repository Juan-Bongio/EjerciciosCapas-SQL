using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class AgendaDatos
    {
        public class PersonaDatos
        {
            public int DNI { get; set; }
            public long CuilCuit { get; set; }
            public string Apellido { get; set; }
            public string Nombres { get; set; }
            public string Calle { get; set; }
            public string Depto { get; set; }
            public int Piso { get; set; }
            public string Ciudad { get; set; }
            public int Telefono { get; set; }
            public string Email { get; set; }
            public DateTime FechaAlta { get; set; }
            public string EstadoCivil { get; set; }
            public string Nacionalidad { get; set; }
            public string Provincia { get; set; }
            public int CodigoPostal { get; set; }
            public string Barrio { get; set; }
            public int TelefonoAlternativo { get; set; }
            public string Instagram { get; set; }
            public string ProfesionOcupacion { get; set; }
            public string EmpresaLugarTrabajo { get; set; }
            public string NivelEstudios { get; set; }
            public string Estado { get; set; }
            public string MetodoPagoPreferido { get; set; }
            public string Observaciones { get; set; }
        }

        private string _conexionString = "Server=localhost;Port=3306;Database=agenda;Uid=root;Pwd=;";

        // BUSCAR POR DNI
        public PersonaDatos BuscarPorDni(int dni)
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
        public List<PersonaDatos> BuscarPorApellido(string apellido)
        {
            List<PersonaDatos> lista = new List<PersonaDatos>();

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
        public List<PersonaDatos> BuscarPorNombres(string nombres)
        {
            List<PersonaDatos> lista = new List<PersonaDatos>();

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
        public List<PersonaDatos> BuscarPorCalle(string calle)
        {
            List<PersonaDatos> lista = new List<PersonaDatos>();

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
        public bool Agregar(PersonaDatos persona)
        {
            string query = @"INSERT INTO agenda
                (DNI, CUIL_CUIT, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email, FechaAlta, EstadoCivil,
                Nacionalidad, Provincia, CodigoPostal, Barrio, TelefonoAlternativo, Instagram, ProfesionOcupacion,
                EmpresaLugarTrabajo, NivelEstudios, Estado, MetodoPagoPreferido, Observaciones)
                VALUES
                (@DNI, @CUIL_CUIT, @Apellido, @Nombres, @Calle, @Depto, @Piso, @Ciudad, @Telefono, @Email, @FechaAlta,
                @EstadoCivil, @Nacionalidad, @Provincia, @CodigoPostal, @Barrio, @TelefonoAlternativo, @Instagram,
                @ProfesionOcupacion, @EmpresaLugarTrabajo, @NivelEstudios, @Estado, @MetodoPagoPreferido, @Observaciones)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", persona.DNI);
                comando.Parameters.AddWithValue("@CUIL_CUIT", persona.CuilCuit);
                comando.Parameters.AddWithValue("@Apellido", persona.Apellido);
                comando.Parameters.AddWithValue("@Nombres", persona.Nombres);
                comando.Parameters.AddWithValue("@Calle", persona.Calle);
                comando.Parameters.AddWithValue("@Depto", persona.Depto);
                comando.Parameters.AddWithValue("@Piso", persona.Piso);
                comando.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                comando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                comando.Parameters.AddWithValue("@Email", persona.Email);
                comando.Parameters.AddWithValue("@FechaAlta", persona.FechaAlta);
                comando.Parameters.AddWithValue("@EstadoCivil", persona.EstadoCivil);
                comando.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);
                comando.Parameters.AddWithValue("@Provincia", persona.Provincia);
                comando.Parameters.AddWithValue("@CodigoPostal", persona.CodigoPostal);
                comando.Parameters.AddWithValue("@Barrio", persona.Barrio);
                comando.Parameters.AddWithValue("@TelefonoAlternativo", persona.TelefonoAlternativo);
                comando.Parameters.AddWithValue("@Instagram", persona.Instagram);
                comando.Parameters.AddWithValue("@ProfesionOcupacion", persona.ProfesionOcupacion);
                comando.Parameters.AddWithValue("@EmpresaLugarTrabajo", persona.EmpresaLugarTrabajo);
                comando.Parameters.AddWithValue("@NivelEstudios", persona.NivelEstudios);
                comando.Parameters.AddWithValue("@Estado", persona.Estado);
                comando.Parameters.AddWithValue("@MetodoPagoPreferido", persona.MetodoPagoPreferido);
                comando.Parameters.AddWithValue("@Observaciones", persona.Observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        // MODIFICAR
        public bool Modificar(PersonaDatos persona)
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

                comando.Parameters.AddWithValue("@DNI", persona.DNI);
                comando.Parameters.AddWithValue("@CUIL_CUIT", persona.CuilCuit);
                comando.Parameters.AddWithValue("@Apellido", persona.Apellido);
                comando.Parameters.AddWithValue("@Nombres", persona.Nombres);
                comando.Parameters.AddWithValue("@Calle", persona.Calle);
                comando.Parameters.AddWithValue("@Depto", persona.Depto);
                comando.Parameters.AddWithValue("@Piso", persona.Piso);
                comando.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                comando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                comando.Parameters.AddWithValue("@Email", persona.Email);
                comando.Parameters.AddWithValue("@FechaAlta", persona.FechaAlta);
                comando.Parameters.AddWithValue("@EstadoCivil", persona.EstadoCivil);
                comando.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);
                comando.Parameters.AddWithValue("@Provincia", persona.Provincia);
                comando.Parameters.AddWithValue("@CodigoPostal", persona.CodigoPostal);
                comando.Parameters.AddWithValue("@Barrio", persona.Barrio);
                comando.Parameters.AddWithValue("@TelefonoAlternativo", persona.TelefonoAlternativo);
                comando.Parameters.AddWithValue("@Instagram", persona.Instagram);
                comando.Parameters.AddWithValue("@ProfesionOcupacion", persona.ProfesionOcupacion);
                comando.Parameters.AddWithValue("@EmpresaLugarTrabajo", persona.EmpresaLugarTrabajo);
                comando.Parameters.AddWithValue("@NivelEstudios", persona.NivelEstudios);
                comando.Parameters.AddWithValue("@Estado", persona.Estado);
                comando.Parameters.AddWithValue("@MetodoPagoPreferido", persona.MetodoPagoPreferido);
                comando.Parameters.AddWithValue("@Observaciones", persona.Observaciones);

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

        // CREAR OBJETO PERSONA
        private PersonaDatos CrearPersona(MySqlDataReader reader)
        {
            return new PersonaDatos
            {
                DNI = Convert.ToInt32(reader["DNI"]),
                CuilCuit = Convert.ToInt64(reader["CUIL_CUIT"]),
                Apellido = Convert.ToString(reader["Apellido"]),
                Nombres = Convert.ToString(reader["Nombres"]),
                Calle = Convert.ToString(reader["Calle"]),
                Depto = Convert.ToString(reader["Depto"]),
                Piso = Convert.ToInt32(reader["Piso"]),
                Ciudad = Convert.ToString(reader["Ciudad"]),
                Telefono = Convert.ToInt32(reader["Telefono"]),
                Email = Convert.ToString(reader["Email"]),
                FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                EstadoCivil = Convert.ToString(reader["EstadoCivil"]),
                Nacionalidad = Convert.ToString(reader["Nacionalidad"]),
                Provincia = Convert.ToString(reader["Provincia"]),
                CodigoPostal = Convert.ToInt32(reader["CodigoPostal"]),
                Barrio = Convert.ToString(reader["Barrio"]),
                TelefonoAlternativo = Convert.ToInt32(reader["TelefonoAlternativo"]),
                Instagram = Convert.ToString(reader["Instagram"]),
                ProfesionOcupacion = Convert.ToString(reader["ProfesionOcupacion"]),
                EmpresaLugarTrabajo = Convert.ToString(reader["EmpresaLugarTrabajo"]),
                NivelEstudios = Convert.ToString(reader["NivelEstudios"]),
                Estado = Convert.ToString(reader["Estado"]),
                MetodoPagoPreferido = Convert.ToString(reader["MetodoPagoPreferido"]),
                Observaciones = Convert.ToString(reader["Observaciones"])
            };
        }
    }
}