using System;
using System.Collections.Generic;
using AgendaCuentaCte.Datos;
using AgendaCuentaCte.Negocio;

public class Program
{
    public static void Main()
    {
        AgendaNegocio negocio = new AgendaNegocio();
        int op = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("              AGENDA");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Agregar persona");
            Console.WriteLine("2. Buscar persona");
            Console.WriteLine("3. Modificar persona");
            Console.WriteLine("4. Eliminar persona");
            Console.WriteLine("5. Salir");
            Console.WriteLine("========================================");

            Console.Write("Seleccione una opcion: ");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Agregar(negocio);
                    break;

                case 2:
                    Buscar(negocio);
                    break;

                case 3:
                    Modificar(negocio);
                    break;

                case 4:
                    Eliminar(negocio);
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida.");
                    Console.ReadKey();
                    break;
            }

        } while (op != 5);
    }

    // AGREGAR
    private static void Agregar(AgendaNegocio negocio)
    {
        Console.Clear();
        Console.WriteLine("========== AGREGAR PERSONA ==========");

        Persona persona = CargarPersona();

        Console.WriteLine();
        Console.Write("¿Desea crear una Cuenta Corriente? (Si/No): ");
        string respuesta = Console.ReadLine().ToUpper();

        if (respuesta == "SI")
        {
            persona.CuentaCte = CargarCuentaCte(persona.DNI);
        }

        bool resultado = negocio.AgregarPersona(persona);
        Console.WriteLine();

        if (resultado)
        {
            Console.WriteLine("Persona agregada correctamente.");

            if (persona.CuentaCte != null)
            {
                Console.WriteLine("Cuenta Corriente agregada correctamente.");
            }
        }
        else
        {
            Console.WriteLine("No se pudo agregar la persona.");
        }

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    // BUSCAR
    private static void Buscar(AgendaNegocio negocio)
    {
        Console.Clear();
        Console.WriteLine("========== BUSCAR PERSONA ==========");
        Console.WriteLine("1. Buscar por DNI");
        Console.WriteLine("2. Buscar por Apellido");
        Console.WriteLine("3. Buscar por Nombres");
        Console.WriteLine("4. Buscar por Calle");
        Console.WriteLine();

        Console.Write("Seleccione una opcion: ");
        int op = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
            case 1:

                Console.Write("Ingrese DNI: ");
                int dni = Convert.ToInt32(Console.ReadLine());

                Persona persona = negocio.ObtenerPorDni(dni);

                Console.Clear();

                if (persona != null)
                {
                    MostrarPersona(persona);
                }
                else
                {
                    Console.WriteLine("DNI invalido o persona inexistente.");
                }
                break;

            case 2:

                Console.Write("Ingrese Apellido: ");
                string apellido = Console.ReadLine();

                List<Persona> personasApellido = negocio.BuscarPorApellido(apellido);

                Console.Clear();

                MostrarResultados(personasApellido);
                break;


            case 3:

                Console.Write("Ingrese Nombres: ");
                string nombres = Console.ReadLine();

                List<Persona> personasNombres = negocio.BuscarPorNombres(nombres);

                Console.Clear();

                MostrarResultados(personasNombres);
                break;

            case 4:

                Console.Write("Ingrese Calle: ");
                string calle = Console.ReadLine();

                List<Persona> personasCalle = negocio.BuscarPorCalle(calle);

                Console.Clear();

                MostrarResultados(personasCalle);
                break;

            default:
                Console.WriteLine("Opcion invalida.");
                break;
        }

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    // MODIFICAR
    private static void Modificar(AgendaNegocio negocio)
    {
        Console.Clear();
        Console.WriteLine("========== MODIFICAR PERSONA ==========");
        Console.Write("Ingrese DNI: ");
        int dni = Convert.ToInt32(Console.ReadLine());

        Persona persona = negocio.ObtenerPorDni(dni);

        if (persona == null)
        {
            Console.WriteLine();
            Console.WriteLine("DNI invalido o persona inexistente.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Persona encontrada.");
        Console.WriteLine();
        Console.WriteLine("Ingrese los nuevos datos.");
        Console.WriteLine();

        persona = CargarPersonaParaModificar(persona);

        // CUENTA CORRIENTE
        Console.WriteLine();

        if (persona.CuentaCte != null)
        {
            Console.WriteLine("La persona posee Cuenta Corriente.");
            Console.WriteLine();
            Console.WriteLine("1. Modificar Cuenta Corriente");
            Console.WriteLine("2. Eliminar Cuenta Corriente");
            Console.WriteLine("3. Mantener Cuenta Corriente");
            Console.WriteLine();

            Console.Write("Seleccione una opcion: ");
            int opcionCuenta = Convert.ToInt32(Console.ReadLine());

            if (opcionCuenta == 1)
            {
                persona.CuentaCte = CargarCuentaCte(persona.DNI);
            }
            else if (opcionCuenta == 2)
            {
                bool eliminada = negocio.EliminarCuentaCte(persona.DNI);

                if (eliminada)
                {
                    persona.CuentaCte = null;
                    Console.WriteLine("Cuenta Corriente eliminada.");
                }
            }
        }
        else
        {
            Console.Write("La persona no posee Cuenta Corriente. ");
            Console.Write("¿Desea crear una? (Si/No): ");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "SI")
            {
                persona.CuentaCte = CargarCuentaCte(persona.DNI);
            }
        }

        bool resultado = negocio.ModificarPersona(persona);
        Console.WriteLine();

        if (resultado)
        {
            Console.WriteLine("Persona modificada correctamente.");
        }
        else
        {
            Console.WriteLine("No se pudo modificar la persona.");
        }

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    // ELIMINAR
    private static void Eliminar(AgendaNegocio negocio)
    {
        Console.Clear();
        Console.WriteLine("========== ELIMINAR PERSONA ==========");
        Console.Write("Ingrese DNI: ");
        int dni = Convert.ToInt32(Console.ReadLine());

        Persona persona = negocio.ObtenerPorDni(dni);

        if (persona == null)
        {
            Console.WriteLine();
            Console.WriteLine("Persona inexistente.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Persona encontrada:");
        Console.WriteLine($"Nombre: {persona.Nombres}");
        Console.WriteLine($"Apellido: {persona.Apellido}");
        Console.WriteLine();

        Console.Write("¿Seguro que desea eliminarla? (Si/No): ");
        string respuesta = Console.ReadLine().ToUpper();

        if (respuesta == "SI")
        {
            bool resultado = negocio.EliminarPersona(dni);
            Console.WriteLine();

            if (resultado)
            {
                Console.WriteLine("Persona eliminada correctamente.");

                Console.WriteLine("Su Cuenta Corriente tambien fue eliminada.");
            }
            else
            {
                Console.WriteLine("No se pudo eliminar la persona.");
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Operacion cancelada.");
        }

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    // CARGAR PERSONA
    private static Persona CargarPersona()
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

        Console.Write("Fecha de Alta (dd/mm/yyyy): ");
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

        Console.Write("Estado (Activo/Inactivo): ");
        persona.Estado = Console.ReadLine();

        Console.Write("Metodo de Pago Preferido: ");
        persona.MetodoPagoPreferido = Console.ReadLine();

        Console.Write("Observaciones: ");
        persona.Observaciones = Console.ReadLine();

        return persona;
    }

    // CARGAR CUENTA CORRIENTE
    private static CuentaCteDatos CargarCuentaCte(int dni)
    {
        CuentaCteDatos cuenta = new CuentaCteDatos();

        cuenta.DNI = dni;

        Console.WriteLine();
        Console.WriteLine("========== CUENTA CORRIENTE ==========");
        Console.Write("Fecha de Apertura (dd/mm/yyyy): ");
        cuenta.FechaApertura = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Limite de Credito: ");
        cuenta.LimiteCredito = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Estado del Credito (Activo/Suspendido): ");
        cuenta.EstadoCredito = Console.ReadLine();

        return cuenta;
    }

    // CARGAR DATOS PARA MODIFICAR
    private static Persona CargarPersonaParaModificar(Persona persona)
    {
        Console.WriteLine("Presione ENTER para mantener el dato actual.");
        Console.WriteLine();

        Console.Write($"Apellido ({persona.Apellido}): ");
        string dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Apellido = dato;

        Console.Write($"Nombres ({persona.Nombres}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Nombres = dato;

        Console.Write($"Calle ({persona.Calle}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Calle = dato;

        Console.Write($"Depto ({persona.Depto}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Depto = dato;

        Console.Write($"Piso ({persona.Piso}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Piso = Convert.ToInt32(dato);

        Console.Write($"Ciudad ({persona.Ciudad}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Ciudad = dato;

        Console.Write($"Telefono ({persona.Telefono}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Telefono = Convert.ToInt32(dato);

        Console.Write($"Email ({persona.Email}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Email = dato;

        Console.Write($"Fecha Alta ({persona.FechaAlta:dd/MM/yyyy}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.FechaAlta =
                Convert.ToDateTime(dato);

        Console.Write($"Estado Civil ({persona.EstadoCivil}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.EstadoCivil = dato;

        Console.Write($"Nacionalidad ({persona.Nacionalidad}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Nacionalidad = dato;

        Console.Write($"Provincia ({persona.Provincia}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Provincia = dato;

        Console.Write($"Codigo Postal ({persona.CodigoPostal}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.CodigoPostal = Convert.ToInt32(dato);

        Console.Write($"Barrio ({persona.Barrio}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Barrio = dato;

        Console.Write($"Telefono Alternativo ({persona.TelefonoAlternativo}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.TelefonoAlternativo =
                Convert.ToInt32(dato);

        Console.Write($"Instagram ({persona.Instagram}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Instagram = dato;

        Console.Write($"Profesion/Ocupacion ({persona.ProfesionOcupacion}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.ProfesionOcupacion = dato;

        Console.Write($"Empresa/Lugar de Trabajo ({persona.EmpresaLugarTrabajo}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.EmpresaLugarTrabajo = dato;

        Console.Write($"Nivel de Estudios ({persona.NivelEstudios}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.NivelEstudios = dato;

        Console.Write($"Estado ({persona.Estado}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Estado = dato;

        Console.Write($"Metodo de Pago ({persona.MetodoPagoPreferido}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.MetodoPagoPreferido = dato;

        Console.Write($"Observaciones ({persona.Observaciones}): ");
        dato = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(dato))
            persona.Observaciones = dato;

        return persona;
    }

    // MOSTRAR PERSONA
    private static void MostrarPersona(Persona persona)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          DATOS DE LA PERSONA");
        Console.WriteLine("========================================");
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
        Console.WriteLine($"Metodo de Pago: {persona.MetodoPagoPreferido}");
        Console.WriteLine($"Observaciones: {persona.Observaciones}");
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("          CUENTA CORRIENTE");
        Console.WriteLine("========================================");

        if (persona.CuentaCte != null)
        {
            Console.WriteLine($"ID Cuenta: {persona.CuentaCte.IdCuentaCte}");
            Console.WriteLine($"Fecha de Apertura: {persona.CuentaCte.FechaApertura:dd/MM/yyyy}");
            Console.WriteLine($"Limite de Credito: ${persona.CuentaCte.LimiteCredito}");
            Console.WriteLine($"Estado del Credito: {persona.CuentaCte.EstadoCredito}");
        }
        else
        {
            Console.WriteLine("Esta persona no posee Cuenta Corriente.");
        }
        Console.WriteLine("========================================");
    }

    // MOSTRAR RESULTADOS
    private static void MostrarResultados(List<Persona> personas)
    {
        if (personas.Count == 0)
        {
            Console.WriteLine("No se encontraron personas.");
            return;
        }

        Console.WriteLine($"Se encontraron {personas.Count} persona(s).");
        Console.WriteLine();

        foreach (Persona persona in personas)
        {
            MostrarPersona(persona);
            Console.WriteLine();
        }
    }
}