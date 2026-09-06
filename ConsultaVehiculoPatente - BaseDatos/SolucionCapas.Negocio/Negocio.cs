using System;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public bool TieneDeuda { get; set; }
    }

    public class VehiculosNegocio
    {
        private VehiculosDatos _datos = new VehiculosDatos();

        // BUSCAR
        public Vehiculo ObtenerVehiculo(string patente)
        {
            if (string.IsNullOrWhiteSpace(patente))
                return null;

            patente = patente.ToUpper();

            if (patente.Length < 6)
                return null;

            var resultado = _datos.BuscarPorPatente(patente);

            if (resultado == null)
                return null;

            return new Vehiculo
            {
                Patente = resultado.Value.Patente,
                Modelo = resultado.Value.Modelo,
                TieneDeuda = resultado.Value.TieneDeuda
            };
        }

        // AGREGAR
        public bool AgregarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return false;

            if (string.IsNullOrWhiteSpace(vehiculo.Patente))
                return false;

            vehiculo.Patente = vehiculo.Patente.ToUpper();

            if (vehiculo.Patente.Length < 6)
                return false;

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                return false;

            // Verificar que no exista
            if (_datos.BuscarPorPatente(vehiculo.Patente) != null)
                return false;

            return _datos.Agregar(
                vehiculo.Patente,
                vehiculo.Modelo,
                vehiculo.TieneDeuda
            );
        }

        // MODIFICAR
        public bool ModificarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return false;

            if (string.IsNullOrWhiteSpace(vehiculo.Patente))
                return false;

            vehiculo.Patente = vehiculo.Patente.ToUpper();

            if (vehiculo.Patente.Length < 6)
                return false;

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                return false;

            // Verificar que exista
            if (_datos.BuscarPorPatente(vehiculo.Patente) == null)
                return false;

            return _datos.Modificar(
                vehiculo.Patente,
                vehiculo.Modelo,
                vehiculo.TieneDeuda
            );
        }

        // ELIMINAR
        public bool EliminarVehiculo(string patente)
        {
            if (string.IsNullOrWhiteSpace(patente))
                return false;

            patente = patente.ToUpper();

            if (patente.Length < 6)
                return false;

            return _datos.Eliminar(patente);
        }
    }
}