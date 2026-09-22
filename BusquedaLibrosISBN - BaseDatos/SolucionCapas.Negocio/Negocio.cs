using System;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Libro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Disponible { get; set; }
    }

    public class LibrosNegocio
    {
        private LibrosDatos _datos = new LibrosDatos();

        // BUSCAR
        public Libro ObtenerLibro(int isbn)
        {
            if (isbn == 0) return null;

            var resultado = _datos.BuscarPorIsbn(Convert.ToString(isbn));

            if (resultado == null) return null;

            return new Libro
            {
                Isbn = Convert.ToInt32(resultado.Value.Isbn),
                Titulo = resultado.Value.Titulo,
                Autor = resultado.Value.Autor,
                Disponible = resultado.Value.Disponible
            };
        }

        // AGREGAR
        public bool AgregarLibro(Libro libro)
        {
            if (libro == null) return false;

            if (libro.Isbn <= 0) return false;

            if (string.IsNullOrWhiteSpace(libro.Titulo)) return false;

            if (string.IsNullOrWhiteSpace(libro.Autor)) return false;

            if (string.IsNullOrWhiteSpace(libro.Disponible)) return false;

            if (_datos.BuscarPorIsbn(libro.Isbn.ToString()) != null)
                return false;

            return _datos.Agregar(
                libro.Isbn,
                libro.Titulo,
                libro.Autor,
                libro.Disponible
            );
        }

        // MODIFICAR
        public bool ModificarLibro(Libro libro)
        {
            if (libro == null) return false;

            if (libro.Isbn <= 0) return false;

            if (string.IsNullOrWhiteSpace(libro.Titulo)) return false;

            if (string.IsNullOrWhiteSpace(libro.Autor)) return false;

            if (string.IsNullOrWhiteSpace(libro.Disponible)) return false;

            return _datos.Modificar(
                libro.Isbn,
                libro.Titulo,
                libro.Autor,
                libro.Disponible
            );
        }

        // ELIMINAR
        public bool EliminarLibro(int isbn)
        {
            if (isbn == 0) return false;

            if (isbn <= 0) return false;

            return _datos.Eliminar(isbn);
        }
    }
}