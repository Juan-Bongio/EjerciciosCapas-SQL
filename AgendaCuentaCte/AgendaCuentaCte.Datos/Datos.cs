using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;

namespace AgendaCuentaCte.Datos
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
            public CuentaCteDatos CuentaCte { get; set; }
        }

        private string _conexionString = "Server=localhost;Port=3307;Database=agenda_cuenta;Uid=root;Pwd=;";


        // BUSCAR POR DNI
        public PersonaDatos BuscarPorDni(int dni)
        {
            string query = @"SELECT agenda_cuenta.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura, CuentaCte.LimiteCredito, CuentaCte.EstadoCredito 
            FROM agenda_cuenta 
            LEFT JOIN CuentaCte ON agenda_cuenta.DNI = CuentaCte.DNI
            WHERE agenda_cuenta.DNI = @DNI";

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

            string query = @"SELECT agenda_cuenta.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura, CuentaCte.LimiteCredito, CuentaCte.EstadoCredito 
            FROM agenda_cuenta 
            LEFT JOIN CuentaCte ON agenda_cuenta.DNI = CuentaCte.DNI
            WHERE agenda_cuenta.Apellido LIKE @Apellido";

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

            string query = @"SELECT agenda_cuenta.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura, CuentaCte.LimiteCredito, CuentaCte.EstadoCredito 
            FROM agenda_cuenta 
            LEFT JOIN CuentaCte ON agenda_cuenta.DNI = CuentaCte.DNI
            WHERE agenda_cuenta.Nombres LIKE @Nombres";

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

            string query = @"SELECT agenda_cuenta.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura, CuentaCte.LimiteCredito, CuentaCte.EstadoCredito 
            FROM agenda_cuenta 
            LEFT JOIN CuentaCte ON agenda_cuenta.DNI = CuentaCte.DNI
            WHERE agenda_cuenta.Calle LIKE @Calle";

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
            string queryAgenda = @"INSERT INTO agenda_cuenta
            (DNI, CUIL_CUIT, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email, FechaAlta, EstadoCivil,
            Nacionalidad, Provincia, CodigoPostal, Barrio, TelefonoAlternativo, Instagram, ProfesionOcupacion,
            EmpresaLugarTrabajo, NivelEstudios, Estado, MetodoPagoPreferido, Observaciones)
            VALUES
            (@DNI, @CUIL_CUIT, @Apellido, @Nombres, @Calle, @Depto, @Piso, @Ciudad, @Telefono, @Email, @FechaAlta,
            @EstadoCivil, @Nacionalidad, @Provincia, @CodigoPostal, @Barrio, @TelefonoAlternativo, @Instagram,
            @ProfesionOcupacion, @EmpresaLugarTrabajo, @NivelEstudios, @Estado, @MetodoPagoPreferido, @Observaciones)";

            string queryCuenta = @"INSERT INTO CuentaCte
            (DNI, FechaApertura, LimiteCredito, EstadoCredito)
            VALUES
            (@DNI, @FechaApertura, @LimiteCredito, @EstadoCredito)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    MySqlCommand comandoPersona = new MySqlCommand(queryAgenda, conexion, transaccion);

                    AgregarParametrosPersona(comandoPersona, persona);

                    comandoPersona.ExecuteNonQuery();


                    if (persona.CuentaCte != null)
                    {
                        MySqlCommand comandoCuenta = new MySqlCommand(queryCuenta, conexion, transaccion);

                        comandoCuenta.Parameters.AddWithValue("@DNI", persona.DNI);
                        comandoCuenta.Parameters.AddWithValue("@FechaApertura", persona.CuentaCte.FechaApertura);
                        comandoCuenta.Parameters.AddWithValue("@LimiteCredito", persona.CuentaCte.LimiteCredito);
                        comandoCuenta.Parameters.AddWithValue("@EstadoCredito", persona.CuentaCte.EstadoCredito);

                        comandoCuenta.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }


        // MODIFICAR
        public bool Modificar(PersonaDatos persona)
        {
            string queryPersona = @"UPDATE agenda_cuenta SET
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

            string queryCuentaExiste = @"SELECT COUNT(*) FROM CuentaCte WHERE DNI = @DNI";

            string queryCuentaModificar = @"UPDATE CuentaCte SET
                FechaApertura = @FechaApertura,
                LimiteCredito = @LimiteCredito,
                EstadoCredito = @EstadoCredito
                WHERE DNI = @DNI";

            string queryCuentaAgregar = @"INSERT INTO CuentaCte
            (DNI, FechaApertura, LimiteCredito, EstadoCredito)
            VALUES
            (@DNI, @FechaApertura, @LimiteCredito, @EstadoCredito)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    MySqlCommand comandoPersona = new MySqlCommand(queryPersona, conexion, transaccion);

                    AgregarParametrosPersona(comandoPersona, persona);

                    comandoPersona.ExecuteNonQuery();

                    if (persona.CuentaCte != null)
                    {
                        MySqlCommand comandoExiste = new MySqlCommand(queryCuentaExiste, conexion, transaccion);

                        comandoExiste.Parameters.AddWithValue("@DNI", persona.DNI);

                        int existe = Convert.ToInt32(comandoExiste.ExecuteScalar());

                        string queryCuenta;

                        if (existe > 0) queryCuenta = queryCuentaModificar;
                        else queryCuenta = queryCuentaAgregar;


                        MySqlCommand comandoCuenta = new MySqlCommand(queryCuenta, conexion, transaccion);

                        comandoCuenta.Parameters.AddWithValue("@DNI", persona.DNI);
                        comandoCuenta.Parameters.AddWithValue("@FechaApertura", persona.CuentaCte.FechaApertura);
                        comandoCuenta.Parameters.AddWithValue("@LimiteCredito", persona.CuentaCte.LimiteCredito);
                        comandoCuenta.Parameters.AddWithValue("@EstadoCredito", persona.CuentaCte.EstadoCredito);

                        comandoCuenta.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }

        // ELIMINAR PERSONA + CUENTA
        public bool Eliminar(int dni)
        {
            string query = "DELETE FROM agenda_cuenta WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        // ELIMINAR SOLO CUENTA
        public bool EliminarCuentaCte(int dni)
        {
            string query = "DELETE FROM CuentaCte WHERE DNI = @DNI";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        // AGREGAR PARAMETROS DE PERSONA
        private void AgregarParametrosPersona(MySqlCommand comando, PersonaDatos persona)
        {
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
        }

        // CREAR PERSONA DESDE MYSQL
        private PersonaDatos CrearPersona(
            MySqlDataReader reader)
        {
            PersonaDatos persona = new PersonaDatos();

            persona.DNI = Convert.ToInt32(reader["DNI"]);
            persona.CuilCuit = Convert.ToInt64(reader["CUIL_CUIT"]);
            persona.Apellido = Convert.ToString(reader["Apellido"]);
            persona.Nombres = Convert.ToString(reader["Nombres"]);
            persona.Calle = Convert.ToString(reader["Calle"]);
            persona.Depto = Convert.ToString(reader["Depto"]);
            persona.Piso = Convert.ToInt32(reader["Piso"]);
            persona.Ciudad = Convert.ToString(reader["Ciudad"]);
            persona.Telefono = Convert.ToInt32(reader["Telefono"]);
            persona.Email = Convert.ToString(reader["Email"]);
            persona.FechaAlta = Convert.ToDateTime(reader["FechaAlta"]);
            persona.EstadoCivil = Convert.ToString(reader["EstadoCivil"]);
            persona.Nacionalidad = Convert.ToString(reader["Nacionalidad"]);
            persona.Provincia = Convert.ToString(reader["Provincia"]);
            persona.CodigoPostal = Convert.ToInt32(reader["CodigoPostal"]);
            persona.Barrio = Convert.ToString(reader["Barrio"]);
            persona.TelefonoAlternativo = Convert.ToInt32(reader["TelefonoAlternativo"]);
            persona.Instagram = Convert.ToString(reader["Instagram"]);
            persona.ProfesionOcupacion = Convert.ToString(reader["ProfesionOcupacion"]);
            persona.EmpresaLugarTrabajo = Convert.ToString(reader["EmpresaLugarTrabajo"]);
            persona.NivelEstudios = Convert.ToString(reader["NivelEstudios"]);
            persona.Estado = Convert.ToString(reader["Estado"]);
            persona.MetodoPagoPreferido = Convert.ToString(reader["MetodoPagoPreferido"]);
            persona.Observaciones = Convert.ToString(reader["Observaciones"]);

            // CUENTA CORRIENTE

            if (reader["IdCuentaCte"] != DBNull.Value)
            {
                persona.CuentaCte = new CuentaCteDatos();

                persona.CuentaCte.IdCuentaCte = Convert.ToInt32(reader["IdCuentaCte"]);
                persona.CuentaCte.DNI = persona.DNI;
                persona.CuentaCte.FechaApertura = Convert.ToDateTime(reader["FechaApertura"]);
                persona.CuentaCte.LimiteCredito = Convert.ToDecimal(reader["LimiteCredito"]);
                persona.CuentaCte.EstadoCredito = Convert.ToString(reader["EstadoCredito"]);
            }

            return persona;
        }
    }
}