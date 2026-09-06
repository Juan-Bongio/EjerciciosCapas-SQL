using System;
using SolucionCapas.Negocio;

public class Program
{
    public static void Main()
    {
        string patente;
        string modelo;
        bool tieneDeuda;

        VehiculosNegocio negocio = new VehiculosNegocio();

        int op = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("      SISTEMA DE VEHICULOS");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Buscar vehiculo");
            Console.WriteLine("2. Agregar vehiculo");
            Console.WriteLine("3. Modificar vehiculo");
            Console.WriteLine("4. Eliminar vehiculo");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=================================");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    // BUSCAR

                    Console.Clear();

                    Console.WriteLine("===== BUSCAR VEHICULO =====");

                    Console.Write("Ingrese Patente: ");
                    patente = Console.ReadLine().ToUpper();

                    Vehiculo vehiculoBuscar = negocio.ObtenerVehiculo(patente);

                    if (vehiculoBuscar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Vehiculo encontrado");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine($"Patente: {vehiculoBuscar.Patente}");
                        Console.WriteLine($"Modelo: {vehiculoBuscar.Modelo}");

                        if (vehiculoBuscar.TieneDeuda)
                            Console.WriteLine("Tiene deuda: Si");
                        else
                            Console.WriteLine("Tiene deuda: No");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Patente invalida o vehiculo inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 2:
                    // AGREGAR

                    Console.Clear();

                    Console.WriteLine("===== AGREGAR VEHICULO =====");

                    Console.Write("Ingrese Patente: ");
                    patente = Console.ReadLine();

                    Console.Write("Ingrese Modelo: ");
                    modelo = Console.ReadLine();

                    Console.Write("¿Tiene deuda? (Si/No): ");
                    string deuda = Console.ReadLine();

                    if (deuda.ToUpper() == "SI")
                        tieneDeuda = true;
                    else
                        tieneDeuda = false;

                    Vehiculo vehiculoAgregar = new Vehiculo
                    {
                        Patente = patente,
                        Modelo = modelo,
                        TieneDeuda = tieneDeuda
                    };

                    bool resultado = negocio.AgregarVehiculo(vehiculoAgregar);

                    Console.WriteLine();

                    if (resultado)
                        Console.WriteLine("Vehiculo agregado correctamente.");
                    else
                        Console.WriteLine("No se pudo agregar el vehiculo.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 3:
                    // MODIFICAR

                    Console.Clear();

                    Console.WriteLine("===== MODIFICAR VEHICULO =====");

                    Console.Write("Ingrese Patente: ");
                    patente = Console.ReadLine();

                    Vehiculo vehiculoModificar = negocio.ObtenerVehiculo(patente);

                    if (vehiculoModificar != null)
                    {
                        Console.Write("Ingrese nuevo Modelo: ");
                        modelo = Console.ReadLine();

                        Console.Write("¿Tiene deuda? (Si/No): ");
                        string nuevaDeuda = Console.ReadLine();

                        if (nuevaDeuda.ToUpper() == "SI")
                            tieneDeuda = true;
                        else
                            tieneDeuda = false;

                        Vehiculo vehiculoModificado = new Vehiculo
                        {
                            Patente = patente,
                            Modelo = modelo,
                            TieneDeuda = tieneDeuda
                        };

                        resultado = negocio.ModificarVehiculo(vehiculoModificado);

                        Console.WriteLine();

                        if (resultado)
                            Console.WriteLine("Vehiculo modificado correctamente.");
                        else
                            Console.WriteLine("No se ha podido modificar el vehiculo.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Patente invalida o vehiculo inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 4:
                    // ELIMINAR

                    Console.Clear();

                    Console.WriteLine("===== ELIMINAR VEHICULO =====");

                    Console.Write("Ingrese la Patente del vehiculo a eliminar: ");
                    patente = Console.ReadLine();

                    bool eliminado = negocio.EliminarVehiculo(patente);

                    Console.WriteLine();

                    if (eliminado)
                        Console.WriteLine("Vehiculo eliminado correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar el vehiculo.");

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
}