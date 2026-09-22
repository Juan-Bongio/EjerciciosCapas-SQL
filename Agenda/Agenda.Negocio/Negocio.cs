using System;
using System.Collections.Generic;
using Agenda.Datos;
using static Agenda.Datos.AgendaDatos;

namespace Agenda.Negocio
{
    public class Persona
    {
        public int DNI { get; set; }
        public long CuilCuit { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Calle { get; set; }
        public string Depto { get; set; }
        public int Piso { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public string Provincia { get; set; }
        public int CodigoPostal { get; set; }
        public string Barrio { get; set; }
        public int TelefonoAlternativo { get; set; }
        public string Instagram { get; set; }
        public string ProfesionOcupacion { get; set; }
        public string EmpresaLugarTrabajo { get; set; }
        public string NivelEstudios { get; set; }
        public string Estado { get; set; }
        public string MetodoPagoPreferido { get; set; }
        public string Observaciones { get; set; }
    }


    public class AgendaNegocio
    {
        private AgendaDatos _datos = new AgendaDatos();

        // BUSCAR POR DNI
        public Persona ObtenerPorDni(int dni)
        {
            if (dni <= 0)
                return null;

            PersonaDatos resultado = _datos.BuscarPorDni(dni);

            if (resultado == null)
                return null;

            return ConvertirPersona(resultado);
        }

        // BUSCAR POR APELLIDO
        public List<Persona> BuscarPorApellido(string apellido)
        {
            List<Persona> personas = new List<Persona>();

            if (string.IsNullOrWhiteSpace(apellido))
                return personas;

            List<PersonaDatos> resultados = _datos.BuscarPorApellido(apellido);

            foreach (PersonaDatos resultado in resultados)
            {
                personas.Add(ConvertirPersona(resultado));
            }

            return personas;
        }

        // BUSCAR POR NOMBRES
        public List<Persona> BuscarPorNombres(string nombres)
        {
            List<Persona> personas = new List<Persona>();

            if (string.IsNullOrWhiteSpace(nombres))
                return personas;

            List<PersonaDatos> resultados = _datos.BuscarPorNombres(nombres);

            foreach (PersonaDatos resultado in resultados)
            {
                personas.Add(ConvertirPersona(resultado));
            }

            return personas;
        }

        // BUSCAR POR CALLE
        public List<Persona> BuscarPorCalle(string calle)
        {
            List<Persona> personas = new List<Persona>();

            if (string.IsNullOrWhiteSpace(calle))
                return personas;

            List<PersonaDatos> resultados = _datos.BuscarPorCalle(calle);

            foreach (PersonaDatos resultado in resultados)
            {
                personas.Add(ConvertirPersona(resultado));
            }

            return personas;
        }

        // AGREGAR
        public bool AgregarPersona(Persona persona)
        {
            if (!ValidarPersona(persona))
                return false;

            if (_datos.BuscarPorDni(persona.DNI) != null)
                return false;

            PersonaDatos personaDatos = ConvertirDatos(persona);

            return _datos.Agregar(personaDatos);
        }

        // MODIFICAR
        public bool ModificarPersona(Persona persona)
        {
            if (!ValidarPersona(persona))
                return false;

            if (_datos.BuscarPorDni(persona.DNI) == null)
                return false;

            PersonaDatos personaDatos = ConvertirDatos(persona);

            return _datos.Modificar(personaDatos);
        }

        // ELIMINAR
        public bool EliminarPersona(int dni)
        {
            if (dni <= 0)
                return false;

            return _datos.Eliminar(dni);
        }

        // VALIDAR PERSONA
        private bool ValidarPersona(Persona persona)
        {
            if (persona == null)
                return false;

            if (persona.DNI <= 0)
                return false;

            if (persona.CuilCuit <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Nombres))
                return false;

            if (string.IsNullOrWhiteSpace(persona.Calle))
                return false;

            if (persona.Piso < 0)
                return false;

            if (string.IsNullOrWhiteSpace(persona.Ciudad))
                return false;

            if (persona.Telefono <= 0)
                return false;

            if (persona.CodigoPostal <= 0)
                return false;

            if (persona.TelefonoAlternativo <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(persona.Estado))
                return false;

            return true;
        }

        // PERSONA A SQL
        private PersonaDatos ConvertirDatos(Persona persona)
        {
            return new PersonaDatos
            {
                DNI = persona.DNI,
                CuilCuit = persona.CuilCuit,
                Apellido = persona.Apellido,
                Nombres = persona.Nombres,
                Calle = persona.Calle,
                Depto = persona.Depto,
                Piso = persona.Piso,
                Ciudad = persona.Ciudad,
                Telefono = persona.Telefono,
                Email = persona.Email,
                FechaAlta = persona.FechaAlta,
                EstadoCivil = persona.EstadoCivil,
                Nacionalidad = persona.Nacionalidad,
                Provincia = persona.Provincia,
                CodigoPostal = persona.CodigoPostal,
                Barrio = persona.Barrio,
                TelefonoAlternativo = persona.TelefonoAlternativo,
                Instagram = persona.Instagram,
                ProfesionOcupacion = persona.ProfesionOcupacion,
                EmpresaLugarTrabajo = persona.EmpresaLugarTrabajo,
                NivelEstudios = persona.NivelEstudios,
                Estado = persona.Estado,
                MetodoPagoPreferido = persona.MetodoPagoPreferido,
                Observaciones = persona.Observaciones
            };
        }

        // SQL A PERSONA
        private Persona ConvertirPersona(PersonaDatos persona)
        {
            return new Persona
            {
                DNI = persona.DNI,
                CuilCuit = persona.CuilCuit,
                Apellido = persona.Apellido,
                Nombres = persona.Nombres,
                Calle = persona.Calle,
                Depto = persona.Depto,
                Piso = persona.Piso,
                Ciudad = persona.Ciudad,
                Telefono = persona.Telefono,
                Email = persona.Email,
                FechaAlta = persona.FechaAlta,
                EstadoCivil = persona.EstadoCivil,
                Nacionalidad = persona.Nacionalidad,
                Provincia = persona.Provincia,
                CodigoPostal = persona.CodigoPostal,
                Barrio = persona.Barrio,
                TelefonoAlternativo = persona.TelefonoAlternativo,
                Instagram = persona.Instagram,
                ProfesionOcupacion = persona.ProfesionOcupacion,
                EmpresaLugarTrabajo = persona.EmpresaLugarTrabajo,
                NivelEstudios = persona.NivelEstudios,
                Estado = persona.Estado,
                MetodoPagoPreferido = persona.MetodoPagoPreferido,
                Observaciones = persona.Observaciones
            };
        }
    }
}