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
                // AGREGAR
                case 1:
                    Console.Clear();

                    Console.WriteLine("===== AGREGAR PERSONA =====");

                    Persona personaAgregar = CargarPersona();

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


                // BUSCAR
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
                        int dni = Convert.ToInt32(Console.ReadLine());

                        Persona persona = negocio.ObtenerPorDni(dni);

                        if (persona != null)
                            MostrarPersona(persona);
                        else
                            Console.WriteLine("No existe una persona con ese DNI.");
                    }
                    else if (tipoBusqueda == 2)
                    {
                        Console.Write("Ingrese Apellido: ");
                        string apellido = Console.ReadLine();

                        List<Persona> personas = negocio.BuscarPorApellido(apellido);

                        MostrarPersonas(personas);
                    }
                    else if (tipoBusqueda == 3)
                    {
                        Console.Write("Ingrese Nombres: ");
                        string nombres = Console.ReadLine();

                        List<Persona> personas = negocio.BuscarPorNombres(nombres);

                        MostrarPersonas(personas);
                    }
                    else if (tipoBusqueda == 4)
                    {
                        Console.Write("Ingrese Calle: ");
                        string calle = Console.ReadLine();

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


                // MODIFICAR
                case 3:
                    Console.Clear();

                    Console.WriteLine("===== MODIFICAR PERSONA =====");

                    Console.Write("Ingrese DNI: ");
                    int dniModificar = Convert.ToInt32(Console.ReadLine());

                    Persona personaModificar = negocio.ObtenerPorDni(dniModificar);

                    if (personaModificar != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Persona encontrada:");
                        MostrarPersona(personaModificar);

                        Console.WriteLine();
                        Console.WriteLine("Ingrese los nuevos datos:");

                        Persona personaModificada = CargarPersona();

                        personaModificada.DNI = dniModificar;

                        resultado = negocio.ModificarPersona(personaModificada);

                        Console.WriteLine();

                        if (resultado)
                            Console.WriteLine("Persona modificada correctamente.");
                        else
                            Console.WriteLine("No se pudo modificar la persona.");
                    }
                    else
                    {
                        Console.WriteLine("No existe una persona con ese DNI.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey();

                    break;


                // ELIMINAR
                case 4:
                    Console.Clear();

                    Console.WriteLine("===== ELIMINAR PERSONA =====");

                    Console.Write("Ingrese DNI de la persona a eliminar: ");
                    int dniEliminar = Convert.ToInt32(Console.ReadLine());

                    bool eliminado = negocio.EliminarPersona(dniEliminar);

                    Console.WriteLine();

                    if (eliminado)
                        Console.WriteLine("Persona eliminada correctamente.");
                    else
                        Console.WriteLine("No se pudo eliminar la persona.");

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


    // CARGAR PERSONA
    public static Persona CargarPersona()
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

        Console.Write("Fecha de Alta (dd/MM/yyyy): ");
        persona.FechaAlta = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Estado Civil: ");
        persona.EstadoCivil = Console.ReadLine();

        Console.Write("Nacionalidad: ");
        persona.Nacionalidad = Console.ReadLine();

        Console.Write("Provincia: ");
        persona.Provincia = Console.ReadLine();

        Console.Write("Codigo Postal: ");
        persona.CodigoPostal = Convert.ToInt32(Console.ReadLine());

        Console.Write("Barrio: ");
        persona.Barrio = Console.ReadLine();

        Console.Write("Telefono Alternativo: ");
        persona.TelefonoAlternativo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Instagram: ");
        persona.Instagram = Console.ReadLine();

        Console.Write("Profesion/Ocupacion: ");
        persona.ProfesionOcupacion = Console.ReadLine();

        Console.Write("Empresa/Lugar de Trabajo: ");
        persona.EmpresaLugarTrabajo = Console.ReadLine();

        Console.Write("Nivel de Estudios: ");
        persona.NivelEstudios = Console.ReadLine();

        Console.Write("Estado (ACTIVO/INACTIVO): ");
        persona.Estado = Console.ReadLine();

        Console.Write("Metodo de Pago Preferido: ");
        persona.MetodoPagoPreferido = Console.ReadLine();

        Console.Write("Observaciones/Notas: ");
        persona.Observaciones = Console.ReadLine();

        return persona;
    }


    // MOSTRAR UNA PERSONA
    public static void MostrarPersona(Persona persona)
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"DNI: {persona.DNI}");
        Console.WriteLine($"CUIL/CUIT: {persona.CuilCuit}");
        Console.WriteLine($"Apellido: {persona.Apellido}");
        Console.WriteLine($"Nombres: {persona.Nombres}");
        Console.WriteLine($"Calle: {persona.Calle}");
        Console.WriteLine($"Depto: {persona.Depto}");
        Console.WriteLine($"Piso: {persona.Piso}");
        Console.WriteLine($"Ciudad: {persona.Ciudad}");
        Console.WriteLine($"Telefono: {persona.Telefono}");
        Console.WriteLine($"Email: {persona.Email}");
        Console.WriteLine($"Fecha de Alta: {persona.FechaAlta:dd/MM/yyyy}");
        Console.WriteLine($"Estado Civil: {persona.EstadoCivil}");
        Console.WriteLine($"Nacionalidad: {persona.Nacionalidad}");
        Console.WriteLine($"Provincia: {persona.Provincia}");
        Console.WriteLine($"Codigo Postal: {persona.CodigoPostal}");
        Console.WriteLine($"Barrio: {persona.Barrio}");
        Console.WriteLine($"Telefono Alternativo: {persona.TelefonoAlternativo}");
        Console.WriteLine($"Instagram: {persona.Instagram}");
        Console.WriteLine($"Profesion/Ocupacion: {persona.ProfesionOcupacion}");
        Console.WriteLine($"Empresa/Lugar de Trabajo: {persona.EmpresaLugarTrabajo}");
        Console.WriteLine($"Nivel de Estudios: {persona.NivelEstudios}");
        Console.WriteLine($"Estado: {persona.Estado}");
        Console.WriteLine($"Metodo de Pago Preferido: {persona.MetodoPagoPreferido}");
        Console.WriteLine($"Observaciones/Notas: {persona.Observaciones}");
        Console.WriteLine("--------------------------------------");
    }


    // MOSTRAR VARIAS PERSONAS
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