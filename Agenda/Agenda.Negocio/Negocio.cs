using System;
using System.Collections.Generic;
using Agenda.Datos;

namespace Agenda.Negocio
{
    public class Persona
    {
        public int DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Calle { get; set; }
        public string Depto { get; set; }
        public string Piso { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
    }

    public class AgendaNegocio
    {
        private AgendaDatos _datos = new AgendaDatos();

        // BUSCAR POR DNI
        public Persona ObtenerPorDni(int dni)
        {
            if (dni <= 0)
                return null;

            var resultado = _datos.BuscarPorDni(dni);

            if (resultado == null)
                return null;

            return new Persona
            {
                DNI = resultado.Value.DNI,
                Apellido = resultado.Value.Apellido,
                Nombres = resultado.Value.Nombres,
                Calle = resultado.Value.Calle,
                Depto = resultado.Value.Depto,
                Piso = resultado.Value.Piso,
                Ciudad = resultado.Value.Ciudad,
                Telefono = resultado.Value.Telefono,
                Email = resultado.Value.Email
            };
        }

        // BUSCAR POR APELLIDO
        public List<Persona> BuscarPorApellido(string apellido)
        {
            List<Persona> personas = new List<Persona>();

            if (string.IsNullOrWhiteSpace(apellido))
                return personas;

            var resultados = _datos.BuscarPorApellido(apellido);

            foreach (var resultado in resultados)
            {
                personas.Add(new Persona
                {
                    DNI = resultado.DNI,
                    Apellido = resultado.Apellido,
                    Nombres = resultado.Nombres,
                    Calle = resultado.Calle,
                    Depto = resultado.Depto,
                    Piso = resultado.Piso,
                    Ciudad = resultado.Ciudad,
                    Telefono = resultado.Telefono,
                    Email = resultado.Email
                });
            }

            return personas;
        }

        // BUSCAR POR NOMBRES
        public List<Persona> BuscarPorNombres(string nombres)
        {
            List<Persona> personas = new List<Persona>();

            if (string.IsNullOrWhiteSpace(nombres))
                return personas;

            var resultados = _datos.BuscarPorNombres(nombres);

            foreach (var resultado in resultados)
            {
                personas.Add(new Persona
                {
                    DNI = resultado.DNI,
                    Apellido = resultado.Apellido,
                    Nombres = resultado.Nombres,
                    Calle = resultado.Calle,
                    Depto = resultado.Depto,
                    Piso = resultado.Piso,
                    Ciudad = resultado.Ciudad,
                    Telefono = resultado.Telefono,
                    Email = resultado.Email
                });
            }

            return personas;
        }

        // BUSCAR POR CALLE
        public List<Persona> BuscarPorCalle(string calle)
        {
            List<Persona> personas = new List<Persona>();

            if (string.IsNullOrWhiteSpace(calle))
                return personas;

            var resultados = _datos.BuscarPorCalle(calle);

            foreach (var resultado in resultados)
            {
                personas.Add(new Persona
                {
                    DNI = resultado.DNI,
                    Apellido = resultado.Apellido,
                    Nombres = resultado.Nombres,
                    Calle = resultado.Calle,
                    Depto = resultado.Depto,
                    Piso = resultado.Piso,
                    Ciudad = resultado.Ciudad,
                    Telefono = resultado.Telefono,
                    Email = resultado.Email
                });
            }

            return personas;
        }

        // AGREGAR
        public bool AgregarPersona(Persona persona)
        {
            if (persona == null)
                return false;

            if (persona.DNI <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Nombres))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Calle))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Ciudad))
                return false;

            if (persona.Telefono <= 0)
                return false;

            if (_datos.BuscarPorDni(persona.DNI) != null)
                return false;

            return _datos.Agregar(
                persona.DNI,
                persona.Apellido,
                persona.Nombres,
                persona.Calle,
                persona.Depto,
                persona.Piso,
                persona.Ciudad,
                persona.Telefono,
                persona.Email
            );
        }

        // MODIFICAR
        public bool ModificarPersona(Persona persona)
        {
            if (persona == null)
                return false;

            if (persona.DNI <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Nombres))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Calle))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Ciudad))
                return false;

            if (persona.Telefono <= 0)
                return false;

            if (_datos.BuscarPorDni(persona.DNI) == null)
                return false;

            return _datos.Modificar(
                persona.DNI,
                persona.Apellido,
                persona.Nombres,
                persona.Calle,
                persona.Depto,
                persona.Piso,
                persona.Ciudad,
                persona.Telefono,
                persona.Email
            );
        }

        // ELIMINAR
        public bool EliminarPersona(int dni)
        {
            if (dni <= 0)
                return false;

            return _datos.Eliminar(dni);
        }
    }
}