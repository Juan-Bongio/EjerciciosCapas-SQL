using System;
using System.Collections.Generic;
using AgendaCuentaCte.Entidades;
using AgendaCuentaCte.Negocio;

namespace AgendaCuentaCte
{
    internal class Program
    {
        static AgendaNegocio negocio = new AgendaNegocio();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine("          AGENDA");
                Console.WriteLine("==================================");
                Console.WriteLine("1 - Agregar persona");
                Console.WriteLine("2 - Buscar persona");
                Console.WriteLine("3 - Modificar persona");
                Console.WriteLine("4 - Eliminar persona");
                Console.WriteLine("5 - Salir");
                Console.WriteLine("==================================");
                Console.Write("Seleccione una opcion: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarPersona();
                        break;

                    case 2:
                        BuscarPersona();
                        break;

                    case 3:
                        ModificarPersona();
                        break;

                    case 4:
                        EliminarPersona();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        static void AgregarPersona()
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine("       AGREGAR PERSONA");
            Console.WriteLine("==================================");

            Persona persona = CargarPersona();

            Console.Write("¿Desea agregar una Cuenta Corriente? (Si/No): ");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "SI")
            {
                persona.CuentaCte = CargarCuentaCte(persona.DNI);
            }

            try
            {
                negocio.AgregarPersona(persona);

                Console.WriteLine();
                Console.WriteLine("Persona agregada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void BuscarPersona()
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine("       BUSCAR PERSONA");
            Console.WriteLine("==================================");

            Console.WriteLine("1 - Buscar por DNI");
            Console.WriteLine("2 - Buscar por Apellido");
            Console.WriteLine("3 - Buscar por Nombres");
            Console.WriteLine("4 - Buscar por Calle");
            Console.Write("Seleccione una opcion: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (opcion == 1)
                {
                    Console.Write("Ingrese DNI: ");
                    int dni = Convert.ToInt32(Console.ReadLine());

                    Persona persona = negocio.ObtenerPorDni(dni);

                    if (persona == null)
                    {
                        Console.WriteLine("No se encontro la persona.");
                    }
                    else
                    {
                        MostrarPersona(persona);
                    }
                }
                else if (opcion == 2)
                {
                    Console.Write("Ingrese apellido: ");
                    string apellido = Console.ReadLine();

                    List<Persona> personas = negocio.BuscarPorApellido(apellido);

                    MostrarResultados(personas);
                }
                else if (opcion == 3)
                {
                    Console.Write("Ingrese nombres: ");
                    string nombres = Console.ReadLine();

                    List<Persona> personas = negocio.BuscarPorNombres(nombres);

                    MostrarResultados(personas);
                }
                else if (opcion == 4)
                {
                    Console.Write("Ingrese calle: ");
                    string calle = Console.ReadLine();

                    List<Persona> personas = negocio.BuscarPorCalle(calle);

                    MostrarResultados(personas);
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ModificarPersona()
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine("       MODIFICAR PERSONA");
            Console.WriteLine("==================================");

            Console.Write("Ingrese DNI de la persona: ");
            int dni = Convert.ToInt32(Console.ReadLine());

            try
            {
                Persona persona = negocio.ObtenerPorDni(dni);

                if (persona == null)
                {
                    Console.WriteLine("No se encontro la persona.");
                    return;
                }

                MostrarPersona(persona);

                Console.WriteLine();
                Console.WriteLine("Ingrese los nuevos datos:");

                Persona nuevaPersona = CargarPersonaParaModificar(dni);

                Console.WriteLine();

                if (persona.CuentaCte != null)
                {
                    Console.WriteLine("La persona tiene Cuenta Corriente.");
                    Console.WriteLine("1 - Modificar Cuenta Corriente");
                    Console.WriteLine("2 - Eliminar Cuenta Corriente");
                    Console.WriteLine("3 - Mantener Cuenta Corriente");
                    Console.Write("Seleccione una opcion: ");

                    int opcionCuenta = Convert.ToInt32(Console.ReadLine());

                    if (opcionCuenta == 1)
                    {
                        nuevaPersona.CuentaCte = CargarCuentaCte(dni);
                    }
                    else if (opcionCuenta == 2)
                    {
                        nuevaPersona.CuentaCte = null;
                        negocio.EliminarCuentaCte(dni);
                    }
                    else
                    {
                        nuevaPersona.CuentaCte = persona.CuentaCte;
                    }
                }
                else
                {
                    Console.Write("¿Desea crear una Cuenta Corriente? (Si/No): ");
                    string respuesta = Console.ReadLine().ToUpper();

                    if (respuesta == "SI")
                    {
                        nuevaPersona.CuentaCte = CargarCuentaCte(dni);
                    }
                }

                negocio.ModificarPersona(nuevaPersona);

                Console.WriteLine();
                Console.WriteLine("Persona modificada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void EliminarPersona()
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine("       ELIMINAR PERSONA");
            Console.WriteLine("==================================");

            Console.Write("Ingrese DNI: ");
            int dni = Convert.ToInt32(Console.ReadLine());

            try
            {
                Persona persona = negocio.ObtenerPorDni(dni);

                if (persona == null)
                {
                    Console.WriteLine("No se encontro la persona.");
                    return;
                }

                MostrarPersona(persona);

                Console.WriteLine();
                Console.Write("¿Esta seguro de eliminar esta persona? (Si/No): ");

                string respuesta = Console.ReadLine().ToUpper();

                if (respuesta == "SI")
                {
                    negocio.EliminarPersona(dni);

                    Console.WriteLine("Persona eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("Operacion cancelada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static Persona CargarPersona()
        {
            Persona persona = new Persona();

            Console.Write("DNI: ");
            persona.DNI = Convert.ToInt32(Console.ReadLine());

            Console.Write("CUIL/CUIT: ");
            persona.CuilCuit = Convert.ToInt64(Console.ReadLine());

            Console.Write("Apellido: ");
            persona.Apellido = Console.ReadLine();

            Console.Write("Nombres: ");
            persona.Nombres = Console.ReadLine();

            Console.Write("Calle: ");
            persona.Calle = Console.ReadLine();

            Console.Write("Depto: ");
            persona.Depto = Console.ReadLine();

            Console.Write("Piso: ");
            persona.Piso = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ciudad: ");
            persona.Ciudad = Console.ReadLine();

            Console.Write("Telefono: ");
            persona.Telefono = Convert.ToInt32(Console.ReadLine());

            Console.Write("Email: ");
            persona.Email = Console.ReadLine();

            Console.Write("Fecha de alta (dd/MM/yyyy): ");
            persona.FechaAlta = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Estado civil: ");
            persona.EstadoCivil = Console.ReadLine();

            Console.Write("Nacionalidad: ");
            persona.Nacionalidad = Console.ReadLine();

            Console.Write("Provincia: ");
            persona.Provincia = Console.ReadLine();

            Console.Write("Codigo postal: ");
            persona.CodigoPostal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Barrio: ");
            persona.Barrio = Console.ReadLine();

            Console.Write("Telefono alternativo: ");
            persona.TelefonoAlternativo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Instagram: ");
            persona.Instagram = Console.ReadLine();

            Console.Write("Profesion/Ocupacion: ");
            persona.ProfesionOcupacion = Console.ReadLine();

            Console.Write("Empresa/Lugar de trabajo: ");
            persona.EmpresaLugarTrabajo = Console.ReadLine();

            Console.Write("Nivel de estudios: ");
            persona.NivelEstudios = Console.ReadLine();

            Console.Write("Estado (ACTIVO/INACTIVO): ");
            persona.Estado = Console.ReadLine();

            Console.Write("Metodo de pago preferido: ");
            persona.MetodoPagoPreferido = Console.ReadLine();

            Console.Write("Observaciones: ");
            persona.Observaciones = Console.ReadLine();

            return persona;
        }

        static CuentaCte CargarCuentaCte(int dni)
        {
            CuentaCte cuenta = new CuentaCte();

            cuenta.DNI = dni;

            Console.Write("Fecha de apertura (dd/MM/yyyy): ");
            cuenta.FechaApertura = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Limite de credito: ");
            cuenta.LimiteCredito = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Estado del credito (Activo/Suspendido): ");
            cuenta.EstadoCredito = Console.ReadLine();

            return cuenta;
        }

        static Persona CargarPersonaParaModificar(int dni)
        {
            Persona persona = new Persona();

            persona.DNI = dni;

            Console.Write("CUIL/CUIT: ");
            persona.CuilCuit = Convert.ToInt64(Console.ReadLine());

            Console.Write("Apellido: ");
            persona.Apellido = Console.ReadLine();

            Console.Write("Nombres: ");
            persona.Nombres = Console.ReadLine();

            Console.Write("Calle: ");
            persona.Calle = Console.ReadLine();

            Console.Write("Depto: ");
            persona.Depto = Console.ReadLine();

            Console.Write("Piso: ");
            persona.Piso = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ciudad: ");
            persona.Ciudad = Console.ReadLine();

            Console.Write("Telefono: ");
            persona.Telefono = Convert.ToInt32(Console.ReadLine());

            Console.Write("Email: ");
            persona.Email = Console.ReadLine();

            Console.Write("Fecha de alta (dd/MM/yyyy): ");
            persona.FechaAlta = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Estado civil: ");
            persona.EstadoCivil = Console.ReadLine();

            Console.Write("Nacionalidad: ");
            persona.Nacionalidad = Console.ReadLine();

            Console.Write("Provincia: ");
            persona.Provincia = Console.ReadLine();

            Console.Write("Codigo postal: ");
            persona.CodigoPostal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Barrio: ");
            persona.Barrio = Console.ReadLine();

            Console.Write("Telefono alternativo: ");
            persona.TelefonoAlternativo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Instagram: ");
            persona.Instagram = Console.ReadLine();

            Console.Write("Profesion/Ocupacion: ");
            persona.ProfesionOcupacion = Console.ReadLine();

            Console.Write("Empresa/Lugar de trabajo: ");
            persona.EmpresaLugarTrabajo = Console.ReadLine();

            Console.Write("Nivel de estudios: ");
            persona.NivelEstudios = Console.ReadLine();

            Console.Write("Estado (ACTIVO/INACTIVO): ");
            persona.Estado = Console.ReadLine();

            Console.Write("Metodo de pago preferido: ");
            persona.MetodoPagoPreferido = Console.ReadLine();

            Console.Write("Observaciones: ");
            persona.Observaciones = Console.ReadLine();

            return persona;
        }

        static void MostrarPersona(Persona persona)
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("          DATOS PERSONALES");
            Console.WriteLine("==================================");

            Console.WriteLine("DNI: " + persona.DNI);
            Console.WriteLine("CUIL/CUIT: " + persona.CuilCuit);
            Console.WriteLine("Apellido: " + persona.Apellido);
            Console.WriteLine("Nombres: " + persona.Nombres);
            Console.WriteLine("Calle: " + persona.Calle);
            Console.WriteLine("Depto: " + persona.Depto);
            Console.WriteLine("Piso: " + persona.Piso);
            Console.WriteLine("Ciudad: " + persona.Ciudad);
            Console.WriteLine("Telefono: " + persona.Telefono);
            Console.WriteLine("Email: " + persona.Email);
            Console.WriteLine("Fecha de alta: " + persona.FechaAlta.ToShortDateString());
            Console.WriteLine("Estado civil: " + persona.EstadoCivil);
            Console.WriteLine("Nacionalidad: " + persona.Nacionalidad);
            Console.WriteLine("Provincia: " + persona.Provincia);
            Console.WriteLine("Codigo postal: " + persona.CodigoPostal);
            Console.WriteLine("Barrio: " + persona.Barrio);
            Console.WriteLine("Telefono alternativo: " + persona.TelefonoAlternativo);
            Console.WriteLine("Instagram: " + persona.Instagram);
            Console.WriteLine("Profesion/Ocupacion: " + persona.ProfesionOcupacion);
            Console.WriteLine("Empresa/Lugar de trabajo: " + persona.EmpresaLugarTrabajo);
            Console.WriteLine("Nivel de estudios: " + persona.NivelEstudios);
            Console.WriteLine("Estado: " + persona.Estado);
            Console.WriteLine("Metodo de pago: " + persona.MetodoPagoPreferido);
            Console.WriteLine("Observaciones: " + persona.Observaciones);

            Console.WriteLine();

            Console.WriteLine("==================================");
            Console.WriteLine("       CUENTA CORRIENTE");
            Console.WriteLine("==================================");

            if (persona.CuentaCte != null)
            {
                Console.WriteLine("ID Cuenta: " + persona.CuentaCte.IdCuentaCte);
                Console.WriteLine("DNI: " + persona.CuentaCte.DNI);
                Console.WriteLine("Fecha apertura: " + persona.CuentaCte.FechaApertura.ToShortDateString());
                Console.WriteLine("Limite credito: " + persona.CuentaCte.LimiteCredito);
                Console.WriteLine("Estado credito: " + persona.CuentaCte.EstadoCredito);
            }
            else
            {
                Console.WriteLine("La persona no posee Cuenta Corriente.");
            }
        }

        static void MostrarResultados(List<Persona> personas)
        {
            if (personas.Count == 0)
            {
                Console.WriteLine("No se encontraron resultados.");
                return;
            }

            foreach (Persona persona in personas)
            {
                MostrarPersona(persona);
                Console.WriteLine();
            }
        }
    }
}