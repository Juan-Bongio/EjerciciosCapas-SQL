using System;
using System.Collections.Generic;
using Agenda.Negocio;

public class Program
{
    public static void Main()
    {
        AgendaNegocio negocio = new AgendaNegocio();

        int op = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("                AGENDA");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Agregar persona");
            Console.WriteLine("2. Buscar persona");
            Console.WriteLine("3. Modificar persona");
            Console.WriteLine("4. Eliminar persona");
            Console.WriteLine("5. Salir");
            Console.WriteLine("======================================");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("===== AGREGAR PERSONA =====");

                    Console.Write("DNI: ");
                    int dni = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();

                    Console.Write("Nombres: ");
                    string nombres = Console.ReadLine();

                    Console.Write("Calle: ");
                    string calle = Console.ReadLine();

                    Console.Write("Depto: ");
                    string depto = Console.ReadLine();

                    Console.Write("Piso: ");
                    string piso = Console.ReadLine();

                    Console.Write("Ciudad: ");
                    string ciudad = Console.ReadLine();

                    Console.Write("Telefono: ");
                    int telefono = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Persona personaAgregar = new Persona
                    {
                        DNI = dni,
                        Apellido = apellido,
                        Nombres = nombres,
                        Calle = calle,
                        Depto = depto,
                        Piso = piso,
                        Ciudad = ciudad,
                        Telefono = telefono,
                        Email = email
                    };

                    bool resultado = negocio.AgregarPersona(personaAgregar);

                    Console.WriteLine();

                    if (resultado)
                        Console.WriteLine("Persona agregada correctamente.");
                    else
                        Console.WriteLine("No se pudo agregar la persona.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 2:
                    Console.Clear();

                    Console.WriteLine("===== BUSCAR PERSONA =====");
                    Console.WriteLine("1. Buscar por DNI");
                    Console.WriteLine("2. Buscar por Apellido");
                    Console.WriteLine("3. Buscar por Nombres");
                    Console.WriteLine("4. Buscar por Calle");
                    Console.WriteLine();

                    Console.Write("Seleccione una opcion: ");
                    int tipoBusqueda = Convert.ToInt32(Console.ReadLine());

                    if (tipoBusqueda == 1)
                    {
                        Console.Write("Ingrese DNI: ");
                        dni = Convert.ToInt32(Console.ReadLine());

                        Persona persona = negocio.ObtenerPorDni(dni);

                        if (persona != null)
                        {
                            MostrarPersona(persona);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No existe una persona con ese DNI.");
                        }
                    }
                    else if (tipoBusqueda == 2)
                    {
                        Console.Write("Ingrese Apellido: ");
                        apellido = Console.ReadLine();

                        List<Persona> personas = negocio.BuscarPorApellido(apellido);

                        MostrarPersonas(personas);
                    }
                    else if (tipoBusqueda == 3)
                    {
                        Console.Write("Ingrese Nombres: ");
                        nombres = Console.ReadLine();

                        List<Persona> personas = negocio.BuscarPorNombres(nombres);

                        MostrarPersonas(personas);
                    }
                    else if (tipoBusqueda == 4)
                    {
                        Console.Write("Ingrese Calle: ");
                        calle = Console.ReadLine();

                        List<Persona> personas = negocio.BuscarPorCalle(calle);

                        MostrarPersonas(personas);
                    }
                    else
                    {
                        Console.WriteLine("Opcion de busqueda invalida.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 3:
                    Console.Clear();

                    Console.WriteLine("===== MODIFICAR PERSONA =====");

                    Console.Write("Ingrese DNI: ");
                    dni = Convert.ToInt32(Console.ReadLine());

                    Persona personaModificar = negocio.ObtenerPorDni(dni);

                    if (personaModificar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Persona encontrada:");
                        MostrarPersona(personaModificar);

                        Console.WriteLine();
                        Console.WriteLine("Ingrese los nuevos datos:");

                        Console.Write("Nuevo Apellido: ");
                        apellido = Console.ReadLine();

                        Console.Write("Nuevos Nombres: ");
                        nombres = Console.ReadLine();

                        Console.Write("Nueva Calle: ");
                        calle = Console.ReadLine();

                        Console.Write("Nuevo Depto: ");
                        depto = Console.ReadLine();

                        Console.Write("Nuevo Piso: ");
                        piso = Console.ReadLine();

                        Console.Write("Nueva Ciudad: ");
                        ciudad = Console.ReadLine();

                        Console.Write("Nuevo Telefono: ");
                        telefono = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Nuevo Email: ");
                        email = Console.ReadLine();

                        Persona personaModificada = new Persona
                        {
                            DNI = dni,
                            Apellido = apellido,
                            Nombres = nombres,
                            Calle = calle,
                            Depto = depto,
                            Piso = piso,
                            Ciudad = ciudad,
                            Telefono = telefono,
                            Email = email
                        };

                        resultado = negocio.ModificarPersona(personaModificada);

                        Console.WriteLine();

                        if (resultado)
                            Console.WriteLine("Persona modificada correctamente.");
                        else
                            Console.WriteLine("No se pudo modificar la persona.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No existe una persona con ese DNI.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 4:
                    Console.Clear();

                    Console.WriteLine("===== ELIMINAR PERSONA =====");

                    Console.Write("Ingrese DNI de la persona a eliminar: ");
                    dni = Convert.ToInt32(Console.ReadLine());

                    bool eliminado = negocio.EliminarPersona(dni);

                    Console.WriteLine();

                    if (eliminado)
                        Console.WriteLine("Persona eliminada correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar la persona.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 5:
                    Console.Clear();
                    Console.WriteLine("Saliendo del sistema...");
                    break;


                default:
                    Console.WriteLine("Opcion invalida.");
                    Console.ReadKey();
                    break;
            }

        } while (op != 5);
    }

    public static void MostrarPersona(Persona persona)
    {
        Console.WriteLine();
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"DNI: {persona.DNI}");
        Console.WriteLine($"Apellido: {persona.Apellido}");
        Console.WriteLine($"Nombres: {persona.Nombres}");
        Console.WriteLine($"Calle: {persona.Calle}");
        Console.WriteLine($"Depto: {persona.Depto}");
        Console.WriteLine($"Piso: {persona.Piso}");
        Console.WriteLine($"Ciudad: {persona.Ciudad}");
        Console.WriteLine($"Telefono: {persona.Telefono}");
        Console.WriteLine($"Email: {persona.Email}");
        Console.WriteLine("-------------------------------");
    }

    public static void MostrarPersonas(List<Persona> personas)
    {
        Console.WriteLine();

        if (personas.Count == 0)
        {
            Console.WriteLine("No se encontraron personas.");
            return;
        }

        Console.WriteLine($"Se encontraron {personas.Count} persona(s).");

        foreach (Persona persona in personas)
        {
            MostrarPersona(persona);
        }
    }
}