using System;
using System.Collections.Generic;
using AgendaCuentaCte.Datos;
using AgendaCuentaCte.Entidades;

namespace AgendaCuentaCte.Negocio
{
    public class AgendaNegocio
    {
        private AgendaCuentaCte.Datos.Datos datos = new AgendaCuentaCte.Datos.Datos();

        public Persona ObtenerPorDni(int dni)
        {
            if (dni <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            return datos.BuscarPorDni(dni);
        }

        public List<Persona> BuscarPorApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Debe ingresar un apellido.");

            return datos.BuscarPorApellido(apellido);
        }

        public List<Persona> BuscarPorNombres(string nombres)
        {
            if (string.IsNullOrWhiteSpace(nombres))
                throw new Exception("Debe ingresar un nombre.");

            return datos.BuscarPorNombres(nombres);
        }

        public List<Persona> BuscarPorCalle(string calle)
        {
            if (string.IsNullOrWhiteSpace(calle))
                throw new Exception("Debe ingresar una calle.");

            return datos.BuscarPorCalle(calle);
        }

        public void AgregarPersona(Persona persona)
        {
            ValidarPersona(persona);

            Persona existente = datos.BuscarPorDni(persona.DNI);

            if (existente != null)
                throw new Exception("Ya existe una persona con ese DNI.");

            datos.Agregar(persona);
        }

        public void ModificarPersona(Persona persona)
        {
            ValidarPersona(persona);

            Persona existente = datos.BuscarPorDni(persona.DNI);

            if (existente == null)
                throw new Exception("No existe una persona con ese DNI.");

            datos.Modificar(persona);
        }

        public void EliminarPersona(int dni)
        {
            if (dni <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            Persona persona = datos.BuscarPorDni(dni);

            if (persona == null)
                throw new Exception("No existe una persona con ese DNI.");

            datos.Eliminar(dni);
        }

        public void EliminarCuentaCte(int dni)
        {
            if (dni <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            datos.EliminarCuentaCte(dni);
        }

        private void ValidarPersona(Persona persona)
        {
            if (persona == null)
                throw new Exception("La persona no puede ser nula.");

            if (persona.DNI <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.Nombres))
                throw new Exception("Los nombres son obligatorios.");

            if (string.IsNullOrWhiteSpace(persona.Calle))
                throw new Exception("La calle es obligatoria.");
        }
    }
}