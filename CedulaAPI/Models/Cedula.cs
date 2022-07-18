using System;
using System.Collections.Generic;

namespace CedulaAPI.Models
{
    public partial class Cedula
    {
        public string NumeroCedula { get; set; } = null!;
        public byte[] Imagen { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string LugarNacimiento { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string? TipoSangre { get; set; }
        public string EstadoCivil { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;
        public DateTime FechaExpiracion { get; set; }
    }
}
