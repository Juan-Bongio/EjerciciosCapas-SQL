using System;
using SolucionCapas.Negocio;

namespace SolucionCapas.Presentacion
{
    public class Program
    {
        public static void Main()
        {
            PersonaNegocio negocio = new PersonaNegocio();

            int op = 0;

            do
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("            PERSONAS");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Agregar persona");
                Console.WriteLine("2. Buscar persona por DNI");
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
                        string dni = Console.ReadLine();

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Persona personaAgregar = new Persona
                        {
                            DNI = dni,
                            Nombre = nombre
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

                        Console.Write("Ingrese DNI: ");
                        dni = Console.ReadLine();

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

                        Console.WriteLine();
                        Console.WriteLine("Presione una tecla para volver al menu...");
                        Console.ReadKey();

                        break;

                    case 3:
                        Console.Clear();

                        Console.WriteLine("===== MODIFICAR PERSONA =====");

                        Console.Write("Ingrese DNI de la persona a modificar: ");
                        dni = Console.ReadLine();

                        Persona personaModificar = negocio.ObtenerPorDni(dni);

                        if (personaModificar != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Persona encontrada:");
                            MostrarPersona(personaModificar);

                            Console.WriteLine();
                            Console.WriteLine("Ingrese el nuevo nombre:");

                            Console.Write("Nuevo Nombre: ");
                            nombre = Console.ReadLine();

                            Persona personaModificada = new Persona
                            {
                                DNI = dni,
                                Nombre = nombre
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
                        dni = Console.ReadLine();

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
            Console.WriteLine($"Nombre: {persona.Nombre}");
            Console.WriteLine("-------------------------------");
        }
    }
}
