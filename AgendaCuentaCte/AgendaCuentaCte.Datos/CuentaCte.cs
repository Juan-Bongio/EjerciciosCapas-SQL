using System;

namespace AgendaCuentaCte.Datos 
{ 
    public class CuentaCteDatos 
    { 
        public int IdCuentaCte { get; set; } 
        public int DNI { get; set; } 
        public DateTime FechaApertura { get; set; } 
        public decimal LimiteCredito { get; set; } 
        public string EstadoCredito { get; set; } } 
}