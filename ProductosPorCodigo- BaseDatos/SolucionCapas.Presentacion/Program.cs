using System;
using SolucionCapas.Negocio;

public class Program
{
    public static void Main()
    {
        string codigo;
        string nombre;
        decimal precio;

        ProductoNegocio negocio = new ProductoNegocio();

        int op = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("      SISTEMA DE PRODUCTOS");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Buscar producto");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=================================");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:

                    Console.Clear();

                    Console.WriteLine("===== BUSCAR PRODUCTO =====");
                    Console.Write("Ingrese el Codigo: ");

                    codigo = Console.ReadLine();

                    Producto productoBuscar = negocio.ObtenerProducto(codigo);

                    if (productoBuscar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Producto encontrado");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine($"Codigo: {productoBuscar.Codigo}");
                        Console.WriteLine($"Nombre: {productoBuscar.Nombre}");
                        Console.WriteLine($"Precio: ${productoBuscar.Precio}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Codigo invalido o producto inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 2:

                    Console.Clear();

                    Console.WriteLine("===== AGREGAR PRODUCTO =====");

                    Console.Write("Ingrese el Codigo (PROD-xxx): ");
                    codigo = Console.ReadLine();

                    Console.Write("Ingrese el Nombre: ");
                    nombre = Console.ReadLine();

                    Console.Write("Ingrese el Precio: ");
                    precio = Convert.ToDecimal(Console.ReadLine());

                    Producto productoAgregar = new Producto
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Precio = precio
                    };

                    bool resultado = negocio.AgregarProducto(productoAgregar);

                    Console.WriteLine();

                    if (resultado)
                        Console.WriteLine("Producto agregado correctamente.");
                    else
                        Console.WriteLine("No se pudo agregar el producto.");

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 3:

                    Console.Clear();

                    Console.WriteLine("===== MODIFICAR PRODUCTO =====");

                    Console.Write("Ingrese el Codigo (PROD-xxx): ");
                    codigo = Console.ReadLine();

                    Producto productoModificar = negocio.ObtenerProducto(codigo);

                    if (productoModificar != null)
                    {
                        Console.Write("Ingrese el nuevo Nombre: ");
                        nombre = Console.ReadLine();

                        Console.Write("Ingrese el nuevo Precio: ");

                        if (!decimal.TryParse(Console.ReadLine(), out precio))
                        {
                            Console.WriteLine("Precio invalido.");
                            Console.ReadKey();
                            break;
                        }

                        Producto productoModificado = new Producto
                        {
                            Codigo = codigo,
                            Nombre = nombre,
                            Precio = precio
                        };

                        resultado = negocio.ModificarProducto(productoModificado);

                        Console.WriteLine();

                        if (resultado)
                            Console.WriteLine("Producto modificado correctamente.");
                        else
                            Console.WriteLine("No se ha podido modificar el producto.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Codigo invalido o producto inexistente.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                case 4:

                    Console.Clear();

                    Console.WriteLine("===== ELIMINAR PRODUCTO =====");

                    Console.Write("Ingrese el Codigo del producto a eliminar: ");
                    codigo = Console.ReadLine();

                    bool eliminado = negocio.EliminarProducto(codigo);

                    Console.WriteLine();

                    if (eliminado)
                        Console.WriteLine("Producto eliminado correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar el producto.");

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