using System;
using System.Collections.Generic;
using Agenda.Datos;

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

            var resultado = _datos.BuscarPorDni(dni);

            if (resultado == null)
                return null;

            return ConvertirPersona(resultado.Value);
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

            var resultados = _datos.BuscarPorNombres(nombres);

            foreach (var resultado in resultados)
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

            var resultados = _datos.BuscarPorCalle(calle);

            foreach (var resultado in resultados)
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

            return _datos.Agregar(
                persona.DNI,
                persona.CuilCuit,
                persona.Apellido,
                persona.Nombres,
                persona.Calle,
                persona.Depto,
                persona.Piso,
                persona.Ciudad,
                persona.Telefono,
                persona.Email,
                persona.FechaAlta,
                persona.EstadoCivil,
                persona.Nacionalidad,
                persona.Provincia,
                persona.CodigoPostal,
                persona.Barrio,
                persona.TelefonoAlternativo,
                persona.Instagram,
                persona.ProfesionOcupacion,
                persona.EmpresaLugarTrabajo,
                persona.NivelEstudios,
                persona.Estado,
                persona.MetodoPagoPreferido,
                persona.Observaciones
            );
        }

        // MODIFICAR
        public bool ModificarPersona(Persona persona)
        {
            if (!ValidarPersona(persona))
                return false;

            if (_datos.BuscarPorDni(persona.DNI) == null)
                return false;

            return _datos.Modificar(
                persona.DNI,
                persona.CuilCuit,
                persona.Apellido,
                persona.Nombres,
                persona.Calle,
                persona.Depto,
                persona.Piso,
                persona.Ciudad,
                persona.Telefono,
                persona.Email,
                persona.FechaAlta,
                persona.EstadoCivil,
                persona.Nacionalidad,
                persona.Provincia,
                persona.CodigoPostal,
                persona.Barrio,
                persona.TelefonoAlternativo,
                persona.Instagram,
                persona.ProfesionOcupacion,
                persona.EmpresaLugarTrabajo,
                persona.NivelEstudios,
                persona.Estado,
                persona.MetodoPagoPreferido,
                persona.Observaciones
            );
        }

        // ELIMINAR
        public bool EliminarPersona(int dni)
        {
            if (dni <= 0)
                return false;

            return _datos.Eliminar(dni);
        }

        // VALIDAR
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

        // CONVERTIR RESULTADO A PERSONA
        private Persona ConvertirPersona(
            (int DNI, long CuilCuit, string Apellido, string Nombres, string Calle, string Depto, int Piso,
            string Ciudad, int Telefono, string Email, DateTime FechaAlta, string EstadoCivil,
            string Nacionalidad, string Provincia, int CodigoPostal, string Barrio, int TelefonoAlternativo,
            string Instagram, string ProfesionOcupacion, string EmpresaLugarTrabajo, string NivelEstudios,
            string Estado, string MetodoPagoPreferido, string Observaciones) resultado)
        {
            return new Persona
            {
                DNI = resultado.DNI,
                CuilCuit = resultado.CuilCuit,
                Apellido = resultado.Apellido,
                Nombres = resultado.Nombres,
                Calle = resultado.Calle,
                Depto = resultado.Depto,
                Piso = resultado.Piso,
                Ciudad = resultado.Ciudad,
                Telefono = resultado.Telefono,
                Email = resultado.Email,
                FechaAlta = resultado.FechaAlta,
                EstadoCivil = resultado.EstadoCivil,
                Nacionalidad = resultado.Nacionalidad,
                Provincia = resultado.Provincia,
                CodigoPostal = resultado.CodigoPostal,
                Barrio = resultado.Barrio,
                TelefonoAlternativo = resultado.TelefonoAlternativo,
                Instagram = resultado.Instagram,
                ProfesionOcupacion = resultado.ProfesionOcupacion,
                EmpresaLugarTrabajo = resultado.EmpresaLugarTrabajo,
                NivelEstudios = resultado.NivelEstudios,
                Estado = resultado.Estado,
                MetodoPagoPreferido = resultado.MetodoPagoPreferido,
                Observaciones = resultado.Observaciones
            };
        }
    }
}