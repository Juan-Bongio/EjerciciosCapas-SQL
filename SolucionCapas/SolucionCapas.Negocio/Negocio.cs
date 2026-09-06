using System;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Persona
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
    }

    public class PersonaNegocio
    {
        private PersonaDatos _datos = new PersonaDatos();

        public Persona ObtenerPersona(int dni)
        {
            if (dni <= 0)
                return null;

            var resultado = _datos.BuscarPorDni(dni);

            if (resultado == null)
                return null;

            return new Persona
            {
                Dni = Convert.ToInt32(resultado.Value.Dni),
                Nombre = resultado.Value.Nombre,
                Telefono = resultado.Value.Telefono,
                Direccion = resultado.Value.Direccion,
                Ciudad = resultado.Value.Ciudad
            };
        }
    }
}