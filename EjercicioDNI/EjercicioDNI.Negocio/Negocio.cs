using System;
using System.Collections.Generic;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
    }

    public class PersonaNegocio
    {
        private PersonaDatos _datos = new PersonaDatos();

        // BUSCAR POR DNI
        public Persona ObtenerPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            var resultado = _datos.BuscarPorDni(dni);

            if (resultado == null)
                return null;

            return new Persona
            {
                DNI = resultado.Value.Dni,
                Nombre = resultado.Value.Nombre
            };
        }

        // AGREGAR
        public bool AgregarPersona(Persona persona)
        {
            if (persona == null)
                return false;

            if (string.IsNullOrWhiteSpace(persona.DNI))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Nombre))
                return false;

            if (_datos.BuscarPorDni(persona.DNI) != null)
                return false;

            return _datos.Agregar(persona.DNI, persona.Nombre);
        }

        // MODIFICAR
        public bool ModificarPersona(Persona persona)
        {
            if (persona == null)
                return false;

            if (string.IsNullOrWhiteSpace(persona.DNI))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Nombre))
                return false;

            if (_datos.BuscarPorDni(persona.DNI) == null)
                return false;

            return _datos.Modificar(persona.DNI, persona.Nombre);
        }

        // ELIMINAR
        public bool EliminarPersona(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            return _datos.Eliminar(dni);
        }
    }
}
