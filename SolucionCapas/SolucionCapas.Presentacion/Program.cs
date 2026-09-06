using System;
using SolucionCapas.Negocio;

public class Program
{
    public static void Main()
    {
        Console.Write("Ingrese DNI: ");
        int dni = Convert.ToInt32(Console.ReadLine());

        PersonaNegocio negocio = new PersonaNegocio();

        Persona persona = negocio.ObtenerPersona(dni);

        if (persona != null)
        {
            Console.WriteLine();
            Console.WriteLine("Persona encontrada");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"DNI: {persona.Dni}");
            Console.WriteLine($"Nombre: {persona.Nombre}");
            Console.WriteLine($"Telefono: {persona.Telefono}");
            Console.WriteLine($"Direccion: {persona.Direccion}");
            Console.WriteLine($"Ciudad: {persona.Ciudad}");
        }
        else
        {
            Console.WriteLine("No existe.");
        }
    }
}