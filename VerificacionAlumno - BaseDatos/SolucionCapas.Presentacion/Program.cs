using System;
using SolucionCapas.Negocio;

public class Program
{
    public static void Main()
    {
        int legajo;
        string nombre;
        string condicion;

        AlumnosNegocio negocio = new AlumnosNegocio();

        int op = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("        SISTEMA DE ALUMNOS");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Buscar alumno");
            Console.WriteLine("2. Agregar alumno");
            Console.WriteLine("3. Modificar alumno");
            Console.WriteLine("4. Eliminar alumno");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=================================");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                // BUSCAR
                case 1:
                    Console.Clear();

                    Console.WriteLine("===== BUSCAR ALUMNO =====");

                    Console.Write("Ingrese Legajo: ");
                    legajo = Convert.ToInt32(Console.ReadLine());

                    Alumno alumnoBuscar = negocio.ObtenerAlumno(legajo);

                    if (alumnoBuscar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Alumno encontrado");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine($"Legajo: {alumnoBuscar.Legajo}");
                        Console.WriteLine($"Nombre: {alumnoBuscar.Nombre}");
                        Console.WriteLine($"Condicion: {alumnoBuscar.Condicion}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Legajo invalido o alumno inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // AGREGAR
                case 2:
                    Console.Clear();

                    Console.WriteLine("===== AGREGAR ALUMNO =====");

                    Console.Write("Ingrese Legajo: ");
                    legajo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese Nombre: ");
                    nombre = Console.ReadLine();

                    Console.Write("Ingrese Condicion: ");
                    condicion = Console.ReadLine();

                    Alumno alumnoAgregar = new Alumno
                    {
                        Legajo = legajo,
                        Nombre = nombre,
                        Condicion = condicion
                    };

                    bool resultado = negocio.AgregarAlumno(alumnoAgregar);

                    Console.WriteLine();

                    if (resultado)
                        Console.WriteLine("Alumno agregado correctamente.");
                    else
                        Console.WriteLine("No se pudo agregar el alumno.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // MODIFICAR
                case 3:
                    Console.Clear();

                    Console.WriteLine("===== MODIFICAR ALUMNO =====");

                    Console.Write("Ingrese Legajo del alumno: ");
                    legajo = Convert.ToInt32(Console.ReadLine());

                    Alumno alumnoModificar = negocio.ObtenerAlumno(legajo);

                    if (alumnoModificar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Alumno encontrado: {alumnoModificar.Nombre}");
                        Console.WriteLine();

                        Console.Write("Ingrese nuevo Nombre: ");
                        nombre = Console.ReadLine();

                        Console.Write("Ingrese nueva Condicion: ");
                        condicion = Console.ReadLine();

                        Alumno alumnoModificado = new Alumno
                        {
                            Legajo = legajo,
                            Nombre = nombre,
                            Condicion = condicion
                        };

                        resultado = negocio.ModificarAlumno(alumnoModificado);

                        Console.WriteLine();

                        if (resultado)
                            Console.WriteLine("Alumno modificado correctamente.");
                        else
                            Console.WriteLine("No se ha podido modificar el alumno.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Legajo invalido o alumno inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // ELIMINAR
                case 4:
                    Console.Clear();

                    Console.WriteLine("===== ELIMINAR ALUMNO =====");

                    Console.Write("Ingrese el Legajo del alumno a eliminar: ");
                    legajo = Convert.ToInt32(Console.ReadLine());

                    bool eliminado = negocio.EliminarAlumno(legajo);

                    Console.WriteLine();

                    if (eliminado)
                        Console.WriteLine("Alumno eliminado correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar el alumno.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // SALIR
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
}