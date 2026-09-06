using System;
using SolucionCapas.Negocio;

public class Program
{
    public static void Main()
    {
        int id;
        string nombre;
        string puesto;
        string departamento;

        EmpleadosNegocio negocio = new EmpleadosNegocio();

        int op = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("       SISTEMA DE EMPLEADOS");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Buscar empleado");
            Console.WriteLine("2. Agregar empleado");
            Console.WriteLine("3. Modificar empleado");
            Console.WriteLine("4. Eliminar empleado");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=================================");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                // BUSCAR
                case 1:
                    Console.Clear();

                    Console.WriteLine("===== BUSCAR EMPLEADO =====");

                    Console.Write("Ingrese ID de Empleado: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Empleado empleadoBuscar = negocio.ObtenerEmpleado(id);

                    if (empleadoBuscar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Empleado encontrado");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine($"ID: {empleadoBuscar.Id}");
                        Console.WriteLine($"Nombre Completo: {empleadoBuscar.Nombre}");
                        Console.WriteLine($"Puesto: {empleadoBuscar.Puesto}");
                        Console.WriteLine($"Departamento: {empleadoBuscar.Departamento}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("ID invalido o empleado inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // AGREGAR
                case 2:
                    Console.Clear();

                    Console.WriteLine("===== AGREGAR EMPLEADO =====");

                    Console.Write("Ingrese ID de Empleado: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese Nombre Completo: ");
                    nombre = Console.ReadLine();

                    Console.Write("Ingrese Puesto: ");
                    puesto = Console.ReadLine();

                    Console.Write("Ingrese Departamento: ");
                    departamento = Console.ReadLine();

                    Empleado empleadoAgregar = new Empleado
                    {
                        Id = id,
                        Nombre = nombre,
                        Puesto = puesto,
                        Departamento = departamento
                    };

                    bool resultado = negocio.AgregarEmpleado(empleadoAgregar);

                    Console.WriteLine();

                    if (resultado)
                        Console.WriteLine("Empleado agregado correctamente.");
                    else
                        Console.WriteLine("No se pudo agregar el empleado.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // MODIFICAR
                case 3:
                    Console.Clear();

                    Console.WriteLine("===== MODIFICAR EMPLEADO =====");

                    Console.Write("Ingrese ID del empleado: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Empleado empleadoModificar = negocio.ObtenerEmpleado(id);

                    if (empleadoModificar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Empleado encontrado: {empleadoModificar.Nombre}");
                        Console.WriteLine();

                        Console.Write("Ingrese nuevo Nombre Completo: ");
                        nombre = Console.ReadLine();

                        Console.Write("Ingrese nuevo Puesto: ");
                        puesto = Console.ReadLine();

                        Console.Write("Ingrese nuevo Departamento: ");
                        departamento = Console.ReadLine();

                        Empleado empleadoModificado = new Empleado
                        {
                            Id = id,
                            Nombre = nombre,
                            Puesto = puesto,
                            Departamento = departamento
                        };

                        resultado = negocio.ModificarEmpleado(empleadoModificado);

                        Console.WriteLine();

                        if (resultado)
                            Console.WriteLine("Empleado modificado correctamente.");
                        else
                            Console.WriteLine("No se ha podido modificar el empleado.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("ID invalido o empleado inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // ELIMINAR
                case 4:
                    Console.Clear();

                    Console.WriteLine("===== ELIMINAR EMPLEADO =====");

                    Console.Write("Ingrese el ID del empleado a eliminar: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    bool eliminado = negocio.EliminarEmpleado(id);

                    Console.WriteLine();

                    if (eliminado)
                        Console.WriteLine("Empleado eliminado correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar el empleado.");

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