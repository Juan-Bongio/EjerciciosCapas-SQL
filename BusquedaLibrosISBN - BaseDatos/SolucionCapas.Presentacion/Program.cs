using System;
using SolucionCapas.Negocio;

public class Program
{
    public static void Main()
    {
        int isbn = 0;
        string titulo;
        string autor;
        string disponibilidad;

        LibrosNegocio negocio = new LibrosNegocio();

        int op = 0;
        do
        {
            Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Agregar libro");
            Console.WriteLine("3. Modificar libro");
            Console.WriteLine("4. Eliminar libro");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    // BUSCAR
                    Console.Write("Ingrese ISBN: ");
                    isbn = Convert.ToInt32(Console.ReadLine());
                    bool resultado = false;

                    Libro libroBuscar = negocio.ObtenerLibro(Convert.ToInt32(isbn));

                    if (libroBuscar != null)
                    {
                        Console.WriteLine($"Titulo: {libroBuscar.Titulo}");
                        Console.WriteLine($"Autor: {libroBuscar.Autor}");

                        if (libroBuscar.Disponible == "Si" || libroBuscar.Disponible == "si")
                            Console.WriteLine("Estado: Disponible");
                        else
                            Console.WriteLine("Estado: Prestado");
                    }
                    else
                        Console.WriteLine("ISBN invalido o libro inexistente.");

                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 2:
                    // AGREGAR
                    Console.Write("Ingrese ISBN: ");
                    isbn = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese titulo: ");
                    titulo = Console.ReadLine();

                    Console.Write("Ingrese autor: ");
                    autor = Console.ReadLine();

                    Console.Write("Ingrese disponibilidad (Si/No): ");
                    disponibilidad = Console.ReadLine();

                    Libro libroAgregar = new Libro
                    {
                        Isbn = isbn,
                        Titulo = titulo,
                        Autor = autor,
                        Disponible = disponibilidad
                    };

                    resultado = negocio.AgregarLibro(libroAgregar);

                    if (resultado)
                        Console.WriteLine("Libro agregado correctamente.");
                    else
                        Console.WriteLine("No se pudo agregar el libro.");

                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    // MODIFICAR
                    Console.Write("Ingrese ISBN: ");
                    isbn = Convert.ToInt32(Console.ReadLine());
                    resultado = false;

                    Libro libroModificar = negocio.ObtenerLibro(isbn);

                    if (libroModificar != null)
                    {
                        Console.Write("Ingrese nuevo titulo: ");
                        titulo = Console.ReadLine();

                        Console.Write("Ingrese nuevo autor: ");
                        autor = Console.ReadLine();

                        Console.Write("Ingrese disponibilidad (Si/No): ");
                        disponibilidad = Console.ReadLine();

                        Libro libroModificado = new Libro
                        {
                            Isbn = isbn,
                            Titulo = titulo,
                            Autor = autor,
                            Disponible = disponibilidad
                        };

                        resultado = negocio.ModificarLibro(libroModificar);

                        if (resultado)
                        {
                            Console.WriteLine("Libro modificado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido modificar.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN invalido o libro inexistente.");
                    }

                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 4:
                    // ELIMINAR
                    Console.Write("Ingrese ISBN del libro a eliminar: ");
                    isbn = Convert.ToInt32(Console.ReadLine());

                    bool eliminado = negocio.EliminarLibro(Convert.ToInt32(isbn));

                    if (eliminado)
                        Console.WriteLine("Libro eliminado correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar el libro.");

                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 5:
                    // SALIR
                    Console.WriteLine("Saliendo... Presione una tecla para salir");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        } while (op != 5);
    }
}