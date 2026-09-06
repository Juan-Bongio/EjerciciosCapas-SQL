using System;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }

    public class ProductoNegocio
    {
        private ProductosDatos _datos = new ProductosDatos();

        // BUSCAR
        public Producto ObtenerProducto(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            codigo = codigo.ToUpper();

            if (!codigo.StartsWith("PROD-"))
                return null;

            var resultado = _datos.BuscarPorCodigo(codigo);

            if (resultado == null)
                return null;

            return new Producto
            {
                Codigo = resultado.Value.Codigo,
                Nombre = resultado.Value.Nombre,
                Precio = resultado.Value.Precio
            };
        }

        // AGREGAR
        public bool AgregarProducto(Producto producto)
        {
            if (producto == null)
                return false;

            if (string.IsNullOrWhiteSpace(producto.Codigo))
                return false;

            producto.Codigo = producto.Codigo.ToUpper();

            if (!producto.Codigo.StartsWith("PROD-"))
                return false;

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                return false;

            if (producto.Precio < 0)
                return false;

            if (_datos.BuscarPorCodigo(producto.Codigo) != null)
                return false;

            return _datos.Agregar(
                producto.Codigo,
                producto.Nombre,
                producto.Precio
            );
        }

        // MODIFICAR
        public bool ModificarProducto(Producto producto)
        {
            if (producto == null)
                return false;

            if (string.IsNullOrWhiteSpace(producto.Codigo))
                return false;

            producto.Codigo = producto.Codigo.ToUpper();

            if (!producto.Codigo.StartsWith("PROD-"))
                return false;

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                return false;

            if (producto.Precio < 0)
                return false;

            if (_datos.BuscarPorCodigo(producto.Codigo) == null)
                return false;

            return _datos.Modificar(
                producto.Codigo,
                producto.Nombre,
                producto.Precio
            );
        }

        // ELIMINAR
        public bool EliminarProducto(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return false;

            codigo = codigo.ToUpper();

            if (!codigo.StartsWith("PROD-"))
                return false;

            return _datos.Eliminar(codigo);
        }
    }
}