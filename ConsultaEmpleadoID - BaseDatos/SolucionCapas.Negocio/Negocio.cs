using System;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
    }

    public class EmpleadosNegocio
    {
        private EmpleadosDatos _datos = new EmpleadosDatos();

        // BUSCAR
        public Empleado ObtenerEmpleado(int id)
        {
            if (id < 100 || id > 999)
                return null;

            var resultado = _datos.BuscarPorId(id);

            if (resultado == null)
                return null;

            return new Empleado
            {
                Id = resultado.Value.Id,
                Nombre = resultado.Value.Nombre,
                Puesto = resultado.Value.Puesto,
                Departamento = resultado.Value.Departamento
            };
        }

        // AGREGAR
        public bool AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                return false;

            if (empleado.Id < 100 || empleado.Id > 999)
                return false;

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                return false;

            if (string.IsNullOrWhiteSpace(empleado.Puesto))
                return false;

            if (string.IsNullOrWhiteSpace(empleado.Departamento))
                return false;

            if (_datos.BuscarPorId(empleado.Id) != null)
                return false;

            return _datos.Agregar(
                empleado.Id,
                empleado.Nombre,
                empleado.Puesto,
                empleado.Departamento
            );
        }

        // MODIFICAR
        public bool ModificarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                return false;

            if (empleado.Id < 100 || empleado.Id > 999)
                return false;

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                return false;

            if (string.IsNullOrWhiteSpace(empleado.Puesto))
                return false;

            if (string.IsNullOrWhiteSpace(empleado.Departamento))
                return false;

            if (_datos.BuscarPorId(empleado.Id) == null)
                return false;

            return _datos.Modificar(
                empleado.Id,
                empleado.Nombre,
                empleado.Puesto,
                empleado.Departamento
            );
        }

        // ELIMINAR
        public bool EliminarEmpleado(int id)
        {
            if (id < 100 || id > 999)
                return false;

            return _datos.Eliminar(id);
        }
    }
}