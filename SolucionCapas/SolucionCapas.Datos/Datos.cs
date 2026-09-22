using System.Collections.Generic;
using System.Linq;

namespace SolucionCapas.Datos
{
    public class PersonaDatos
    {
        private List<(int Dni, string Nombre, string Telefono, string Direccion, string Ciudad)> _tablaPersonas = new List<(int, string, string, string, string)>
        {
            (23269431, "Alberto", "1123456789", "Av. Siempre Viva 123", "Buenos Aires"),
            (27576691, "Noemi", "1167894321", "Calle San Martin 456", "Caseros")
        };

        public (int Dni, string Nombre, string Telefono, string Direccion, string Ciudad)? BuscarPorDni(int dni)
        {
            var resultado = _tablaPersonas.FirstOrDefault(p => p.Dni == dni);

            if (Convert.ToInt32(resultado.Dni) == null)
                return null;

            return resultado;
        }
    }
}