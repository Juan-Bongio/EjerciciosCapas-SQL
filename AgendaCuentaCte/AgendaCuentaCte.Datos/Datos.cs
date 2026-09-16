using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AgendaCuentaCte.Entidades;

namespace AgendaCuentaCte.Datos
{
    public class Datos
    {
        private string conexion = "Server=localhost;Port=3307;Database=agenda;Uid=root;Pwd=;";

        public Persona BuscarPorDni(int dni)
        {
            Persona persona = null;

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"SELECT Agenda.*,
                                      CuentaCte.IdCuentaCte,
                                      CuentaCte.FechaApertura,
                                      CuentaCte.LimiteCredito,
                                      CuentaCte.EstadoCredito
                               FROM Agenda
                               LEFT JOIN CuentaCte
                               ON Agenda.DNI = CuentaCte.DNI
                               WHERE Agenda.DNI = @DNI";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@DNI", dni);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    persona = CrearPersona(reader);
                }

                reader.Close();
            }

            return persona;
        }

        public List<Persona> BuscarPorApellido(string apellido)
        {
            List<Persona> personas = new List<Persona>();

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"SELECT Agenda.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura,
                             CuentaCte.LimiteCredito, CuentaCte.EstadoCredito
                             FROM Agenda
                             LEFT JOIN CuentaCte ON Agenda.DNI = CuentaCte.DNI
                             WHERE Agenda.Apellido LIKE @Apellido";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Apellido", "%" + apellido + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    personas.Add(CrearPersona(reader));
                }

                reader.Close();
            }

            return personas;
        }

        public List<Persona> BuscarPorNombres(string nombres)
        {
            List<Persona> personas = new List<Persona>();

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"SELECT Agenda.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura,
                             CuentaCte.LimiteCredito, CuentaCte.EstadoCredito
                             FROM Agenda
                             LEFT JOIN CuentaCte ON Agenda.DNI = CuentaCte.DNI
                             WHERE Agenda.Nombres LIKE @Nombres";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Nombres", "%" + nombres + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    personas.Add(CrearPersona(reader));
                }

                reader.Close();
            }

            return personas;
        }

        public List<Persona> BuscarPorCalle(string calle)
        {
            List<Persona> personas = new List<Persona>();

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"SELECT Agenda.*, CuentaCte.IdCuentaCte, CuentaCte.FechaApertura,
                             CuentaCte.LimiteCredito, CuentaCte.EstadoCredito
                             FROM Agenda
                             LEFT JOIN CuentaCte ON Agenda.DNI = CuentaCte.DNI
                             WHERE Agenda.Calle LIKE @Calle";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Calle", "%" + calle + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    personas.Add(CrearPersona(reader));
                }

                reader.Close();
            }

            return personas;
        }

        public void Agregar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                MySqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sqlPersona = @"INSERT INTO agenda_cuenta
                    (DNI, CUIL_CUIT, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email, FechaAlta, EstadoCivil,
                    Nacionalidad, Provincia, CodigoPostal, Barrio, TelefonoAlternativo, Instagram, ProfesionOcupacion,
                    EmpresaLugarTrabajo, NivelEstudios, Estado, MetodoPagoPreferido, Observaciones)
                    VALUES
                    (@DNI, @CUIL_CUIT, @Apellido, @Nombres, @Calle, @Depto, @Piso, @Ciudad, @Telefono, @Email, @FechaAlta,
                    @EstadoCivil, @Nacionalidad, @Provincia, @CodigoPostal, @Barrio, @TelefonoAlternativo, @Instagram,
                    @ProfesionOcupacion, @EmpresaLugarTrabajo, @NivelEstudios, @Estado, @MetodoPagoPreferido, @Observaciones)";

                    MySqlCommand cmdPersona = new MySqlCommand(sqlPersona, cn, transaccion);

                    AgregarParametrosPersona(cmdPersona, persona);

                    cmdPersona.ExecuteNonQuery();

                    if (persona.CuentaCte != null)
                    {
                        string sqlCuenta = @"INSERT INTO CuentaCte
                        (DNI, FechaApertura, LimiteCredito, EstadoCredito)
                        VALUES
                        (@DNI, @FechaApertura, @LimiteCredito, @EstadoCredito)";

                        MySqlCommand cmdCuenta = new MySqlCommand(sqlCuenta, cn, transaccion);

                        cmdCuenta.Parameters.AddWithValue("@DNI", persona.DNI);
                        cmdCuenta.Parameters.AddWithValue("@FechaApertura", persona.CuentaCte.FechaApertura);
                        cmdCuenta.Parameters.AddWithValue("@LimiteCredito", persona.CuentaCte.LimiteCredito);
                        cmdCuenta.Parameters.AddWithValue("@EstadoCredito", persona.CuentaCte.EstadoCredito);

                        cmdCuenta.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        public void Modificar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                MySqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sqlPersona = @"UPDATE Agenda SET
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

                    MySqlCommand cmdPersona = new MySqlCommand(sqlPersona, cn, transaccion);

                    AgregarParametrosPersona(cmdPersona, persona);

                    cmdPersona.ExecuteNonQuery();

                    if (persona.CuentaCte != null)
                    {
                        string sqlExiste = @"SELECT COUNT(*)
                                             FROM CuentaCte
                                             WHERE DNI = @DNI";

                        MySqlCommand cmdExiste = new MySqlCommand(sqlExiste, cn, transaccion);
                        cmdExiste.Parameters.AddWithValue("@DNI", persona.DNI);

                        int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

                        if (existe > 0)
                        {
                            string sqlCuenta = @"UPDATE CuentaCte SET
                                    FechaApertura = @FechaApertura,
                                    LimiteCredito = @LimiteCredito,
                                    EstadoCredito = @EstadoCredito
                                    WHERE DNI = @DNI";

                            MySqlCommand cmdCuenta = new MySqlCommand(sqlCuenta, cn, transaccion);

                            cmdCuenta.Parameters.AddWithValue("@DNI", persona.DNI);
                            cmdCuenta.Parameters.AddWithValue("@FechaApertura", persona.CuentaCte.FechaApertura);
                            cmdCuenta.Parameters.AddWithValue("@LimiteCredito", persona.CuentaCte.LimiteCredito);
                            cmdCuenta.Parameters.AddWithValue("@EstadoCredito", persona.CuentaCte.EstadoCredito);

                            cmdCuenta.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlCuenta = @"INSERT INTO CuentaCte
                                (DNI, FechaApertura, LimiteCredito, EstadoCredito)
                                VALUES
                                (@DNI, @FechaApertura, @LimiteCredito, @EstadoCredito)";

                            MySqlCommand cmdCuenta = new MySqlCommand(sqlCuenta, cn, transaccion);

                            cmdCuenta.Parameters.AddWithValue("@DNI", persona.DNI);
                            cmdCuenta.Parameters.AddWithValue("@FechaApertura", persona.CuentaCte.FechaApertura);
                            cmdCuenta.Parameters.AddWithValue("@LimiteCredito", persona.CuentaCte.LimiteCredito);
                            cmdCuenta.Parameters.AddWithValue("@EstadoCredito", persona.CuentaCte.EstadoCredito);

                            cmdCuenta.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        public void Eliminar(int dni)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = "DELETE FROM Agenda WHERE DNI = @DNI";

                MySqlCommand cmd = new MySqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@DNI", dni);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCuentaCte(int dni)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = "DELETE FROM CuentaCte WHERE DNI = @DNI";

                MySqlCommand cmd = new MySqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@DNI", dni);

                cmd.ExecuteNonQuery();
            }
        }

        private void AgregarParametrosPersona(MySqlCommand cmd, Persona persona)
        {
            cmd.Parameters.AddWithValue("@DNI", persona.DNI);
            cmd.Parameters.AddWithValue("@CUIL_CUIT", persona.CuilCuit);
            cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
            cmd.Parameters.AddWithValue("@Nombres", persona.Nombres);
            cmd.Parameters.AddWithValue("@Calle", persona.Calle);
            cmd.Parameters.AddWithValue("@Depto", persona.Depto);
            cmd.Parameters.AddWithValue("@Piso", persona.Piso);
            cmd.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
            cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
            cmd.Parameters.AddWithValue("@Email", persona.Email);
            cmd.Parameters.AddWithValue("@FechaAlta", persona.FechaAlta);
            cmd.Parameters.AddWithValue("@EstadoCivil", persona.EstadoCivil);
            cmd.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);
            cmd.Parameters.AddWithValue("@Provincia", persona.Provincia);
            cmd.Parameters.AddWithValue("@CodigoPostal", persona.CodigoPostal);
            cmd.Parameters.AddWithValue("@Barrio", persona.Barrio);
            cmd.Parameters.AddWithValue("@TelefonoAlternativo", persona.TelefonoAlternativo);
            cmd.Parameters.AddWithValue("@Instagram", persona.Instagram);
            cmd.Parameters.AddWithValue("@ProfesionOcupacion", persona.ProfesionOcupacion);
            cmd.Parameters.AddWithValue("@EmpresaLugarTrabajo", persona.EmpresaLugarTrabajo);
            cmd.Parameters.AddWithValue("@NivelEstudios", persona.NivelEstudios);
            cmd.Parameters.AddWithValue("@Estado", persona.Estado);
            cmd.Parameters.AddWithValue("@MetodoPagoPreferido", persona.MetodoPagoPreferido);
            cmd.Parameters.AddWithValue("@Observaciones", persona.Observaciones);
        }

        private Persona CrearPersona(MySqlDataReader reader)
        {
            Persona persona = new Persona();

            if (reader["DNI"] != DBNull.Value)
                persona.DNI = Convert.ToInt32(reader["DNI"]);
            else
                persona.DNI = 0;

            if (reader["CUIL_CUIT"] != DBNull.Value)
                persona.CuilCuit = Convert.ToInt64(reader["CUIL_CUIT"]);
            else
                persona.CuilCuit = 0;

            if (reader["Apellido"] != DBNull.Value)
                persona.Apellido = Convert.ToString(reader["Apellido"]);
            else
                persona.Apellido = "";

            if (reader["Nombres"] != DBNull.Value)
                persona.Nombres = Convert.ToString(reader["Nombres"]);
            else
                persona.Nombres = "";

            if (reader["Calle"] != DBNull.Value)
                persona.Calle = Convert.ToString(reader["Calle"]);
            else
                persona.Calle = "";

            if (reader["Depto"] != DBNull.Value)
                persona.Depto = Convert.ToString(reader["Depto"]);
            else
                persona.Depto = "";

            if (reader["Piso"] != DBNull.Value)
                persona.Piso = Convert.ToInt32(reader["Piso"]);
            else
                persona.Piso = 0;

            if (reader["Ciudad"] != DBNull.Value)
                persona.Ciudad = Convert.ToString(reader["Ciudad"]);
            else
                persona.Ciudad = "";

            if (reader["Telefono"] != DBNull.Value)
                persona.Telefono = Convert.ToInt32(reader["Telefono"]);
            else
                persona.Telefono = 0;

            if (reader["Email"] != DBNull.Value)
                persona.Email = Convert.ToString(reader["Email"]);
            else
                persona.Email = "";

            if (reader["FechaAlta"] != DBNull.Value)
                persona.FechaAlta = Convert.ToDateTime(reader["FechaAlta"]);
            else
                persona.FechaAlta = DateTime.MinValue;

            if (reader["EstadoCivil"] != DBNull.Value)
                persona.EstadoCivil = Convert.ToString(reader["EstadoCivil"]);
            else
                persona.EstadoCivil = "";

            if (reader["Nacionalidad"] != DBNull.Value)
                persona.Nacionalidad = Convert.ToString(reader["Nacionalidad"]);
            else
                persona.Nacionalidad = "";

            if (reader["Provincia"] != DBNull.Value)
                persona.Provincia = Convert.ToString(reader["Provincia"]);
            else
                persona.Provincia = "";

            if (reader["CodigoPostal"] != DBNull.Value)
                persona.CodigoPostal = Convert.ToInt32(reader["CodigoPostal"]);
            else
                persona.CodigoPostal = 0;

            if (reader["Barrio"] != DBNull.Value)
                persona.Barrio = Convert.ToString(reader["Barrio"]);
            else
                persona.Barrio = "";

            if (reader["TelefonoAlternativo"] != DBNull.Value)
                persona.TelefonoAlternativo = Convert.ToInt32(reader["TelefonoAlternativo"]);
            else
                persona.TelefonoAlternativo = 0;

            if (reader["Instagram"] != DBNull.Value)
                persona.Instagram = Convert.ToString(reader["Instagram"]);
            else
                persona.Instagram = "";

            if (reader["ProfesionOcupacion"] != DBNull.Value)
                persona.ProfesionOcupacion = Convert.ToString(reader["ProfesionOcupacion"]);
            else
                persona.ProfesionOcupacion = "";

            if (reader["EmpresaLugarTrabajo"] != DBNull.Value)
                persona.EmpresaLugarTrabajo = Convert.ToString(reader["EmpresaLugarTrabajo"]);
            else
                persona.EmpresaLugarTrabajo = "";

            if (reader["NivelEstudios"] != DBNull.Value)
                persona.NivelEstudios = Convert.ToString(reader["NivelEstudios"]);
            else
                persona.NivelEstudios = "";

            if (reader["Estado"] != DBNull.Value)
                persona.Estado = Convert.ToString(reader["Estado"]);
            else
                persona.Estado = "";

            if (reader["MetodoPagoPreferido"] != DBNull.Value)
                persona.MetodoPagoPreferido = Convert.ToString(reader["MetodoPagoPreferido"]);
            else
                persona.MetodoPagoPreferido = "";

            if (reader["Observaciones"] != DBNull.Value)
                persona.Observaciones = Convert.ToString(reader["Observaciones"]);
            else
                persona.Observaciones = "";

            if (reader["IdCuentaCte"] != DBNull.Value)
            {
                CuentaCte cuenta = new CuentaCte();

                cuenta.IdCuentaCte = Convert.ToInt32(reader["IdCuentaCte"]);
                cuenta.DNI = persona.DNI;

                if (reader["FechaApertura"] != DBNull.Value)
                    cuenta.FechaApertura = Convert.ToDateTime(reader["FechaApertura"]);
                else
                    cuenta.FechaApertura = DateTime.MinValue;

                if (reader["LimiteCredito"] != DBNull.Value)
                    cuenta.LimiteCredito = Convert.ToDecimal(reader["LimiteCredito"]);
                else
                    cuenta.LimiteCredito = 0;

                if (reader["EstadoCredito"] != DBNull.Value)
                    cuenta.EstadoCredito = Convert.ToString(reader["EstadoCredito"]);
                else
                    cuenta.EstadoCredito = "";

                persona.CuentaCte = cuenta;
            }

            return persona;
        }
    }
}