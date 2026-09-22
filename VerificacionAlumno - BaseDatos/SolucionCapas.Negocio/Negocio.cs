using System;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Condicion { get; set; }
    }

    public class AlumnosNegocio
    {
        private AlumnosDatos _datos = new AlumnosDatos();

        // BUSCAR
        public Alumno ObtenerAlumno(int legajo)
        {
            if (legajo <= 0)
                return null;

            var resultado = _datos.BuscarPorLegajo(legajo);

            if (resultado == null)
                return null;

            return new Alumno
            {
                Legajo = resultado.Value.Legajo,
                Nombre = resultado.Value.Nombre,
                Condicion = resultado.Value.Condicion
            };
        }

        // AGREGAR
        public bool AgregarAlumno(Alumno alumno)
        {
            if (alumno == null)
                return false;

            if (alumno.Legajo <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(alumno.Nombre))
                return false;

            if (string.IsNullOrWhiteSpace(alumno.Condicion))
                return false;

            if (_datos.BuscarPorLegajo(alumno.Legajo) != null)
                return false;

            return _datos.Agregar(
                alumno.Legajo,
                alumno.Nombre,
                alumno.Condicion
            );
        }

        // MODIFICAR
        public bool ModificarAlumno(Alumno alumno)
        {
            if (alumno == null)
                return false;

            if (alumno.Legajo <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(alumno.Nombre))
                return false;

            if (string.IsNullOrWhiteSpace(alumno.Condicion))
                return false;

            if (_datos.BuscarPorLegajo(alumno.Legajo) == null)
                return false;

            return _datos.Modificar(
                alumno.Legajo,
                alumno.Nombre,
                alumno.Condicion
            );
        }

        // ELIMINAR
        public bool EliminarAlumno(int legajo)
        {
            if (legajo <= 0)
                return false;

            return _datos.Eliminar(legajo);
        }
    }
}