using System;
using System.Collections.Generic;
using AgendaCuentaCte.Datos;
using static AgendaCuentaCte.Datos.AgendaDatos;

namespace AgendaCuentaCte.Negocio
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
        public CuentaCteDatos CuentaCte { get; set; }
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

        // ELIMINAR PERSONA + CUENTA CTE
        public bool EliminarPersona(int dni)
        {
            if (dni <= 0)
                return false;

            return _datos.Eliminar(dni);
        }

        // ELIMINAR CUENTA CTE
        public bool EliminarCuentaCte(int dni)
        {
            if (dni <= 0)
                return false;

            return _datos.EliminarCuentaCte(dni);
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

            if (persona.CuentaCte != null)
            {
                if (persona.CuentaCte.LimiteCredito < 0)
                    return false;

                if (persona.CuentaCte.EstadoCredito != "Activo" && persona.CuentaCte.EstadoCredito != "Suspendido")
                    return false;
            }

            return true;
        }

        // PERSONA A SQL
        private PersonaDatos ConvertirDatos(Persona persona)
        {
            PersonaDatos datos = new PersonaDatos();

            datos.DNI = persona.DNI;
            datos.CuilCuit = persona.CuilCuit;
            datos.Apellido = persona.Apellido;
            datos.Nombres = persona.Nombres;
            datos.Calle = persona.Calle;
            datos.Depto = persona.Depto;
            datos.Piso = persona.Piso;
            datos.Ciudad = persona.Ciudad;
            datos.Telefono = persona.Telefono;
            datos.Email = persona.Email;
            datos.FechaAlta = persona.FechaAlta;
            datos.EstadoCivil = persona.EstadoCivil;
            datos.Nacionalidad = persona.Nacionalidad;
            datos.Provincia = persona.Provincia;
            datos.CodigoPostal = persona.CodigoPostal;
            datos.Barrio = persona.Barrio;
            datos.TelefonoAlternativo = persona.TelefonoAlternativo;
            datos.Instagram = persona.Instagram;
            datos.ProfesionOcupacion = persona.ProfesionOcupacion;
            datos.EmpresaLugarTrabajo = persona.EmpresaLugarTrabajo;
            datos.NivelEstudios = persona.NivelEstudios;
            datos.Estado = persona.Estado;
            datos.MetodoPagoPreferido = persona.MetodoPagoPreferido;
            datos.Observaciones = persona.Observaciones;

            if (persona.CuentaCte != null)
            {
                datos.CuentaCte = new CuentaCteDatos();

                datos.CuentaCte.IdCuentaCte = persona.CuentaCte.IdCuentaCte;
                datos.CuentaCte.DNI = persona.CuentaCte.DNI;
                datos.CuentaCte.FechaApertura = persona.CuentaCte.FechaApertura;
                datos.CuentaCte.LimiteCredito = persona.CuentaCte.LimiteCredito;
                datos.CuentaCte.EstadoCredito = persona.CuentaCte.EstadoCredito;
            }

            return datos;
        }

        // SQL A PERSONA
        private Persona ConvertirPersona(PersonaDatos datos)
        {
            Persona persona = new Persona();

            persona.DNI = datos.DNI;
            persona.CuilCuit = datos.CuilCuit;
            persona.Apellido = datos.Apellido;
            persona.Nombres = datos.Nombres;
            persona.Calle = datos.Calle;
            persona.Depto = datos.Depto;
            persona.Piso = datos.Piso;
            persona.Ciudad = datos.Ciudad;
            persona.Telefono = datos.Telefono;
            persona.Email = datos.Email;
            persona.FechaAlta = datos.FechaAlta;
            persona.EstadoCivil = datos.EstadoCivil;
            persona.Nacionalidad = datos.Nacionalidad;
            persona.Provincia = datos.Provincia;
            persona.CodigoPostal = datos.CodigoPostal;
            persona.Barrio = datos.Barrio;
            persona.TelefonoAlternativo = datos.TelefonoAlternativo;
            persona.Instagram = datos.Instagram;
            persona.ProfesionOcupacion = datos.ProfesionOcupacion;
            persona.EmpresaLugarTrabajo = datos.EmpresaLugarTrabajo;
            persona.NivelEstudios = datos.NivelEstudios;
            persona.Estado = datos.Estado;
            persona.MetodoPagoPreferido = datos.MetodoPagoPreferido;
            persona.Observaciones = datos.Observaciones;

            if (datos.CuentaCte != null)
            {
                persona.CuentaCte = new CuentaCteDatos();
                persona.CuentaCte.IdCuentaCte = datos.CuentaCte.IdCuentaCte;
                persona.CuentaCte.DNI = datos.CuentaCte.DNI;
                persona.CuentaCte.FechaApertura = datos.CuentaCte.FechaApertura;
                persona.CuentaCte.LimiteCredito = datos.CuentaCte.LimiteCredito;
                persona.CuentaCte.EstadoCredito = datos.CuentaCte.EstadoCredito;
            }

            return persona;
        }
    }
}