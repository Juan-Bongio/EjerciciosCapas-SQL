using System;

namespace AgendaCuentaCte.Entidades
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

        public CuentaCte CuentaCte { get; set; }
    }
}