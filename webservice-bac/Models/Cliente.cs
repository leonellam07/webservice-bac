using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice_bac.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string ApellidoCasada { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono1 { get; set; }
        public decimal Telefono2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string  Identificacion { get; set; }

    }
}