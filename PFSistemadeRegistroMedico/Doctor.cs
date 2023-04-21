using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSistemadeRegistroMedico
{
    public class Doctor
    {
        public string NombreCompletoDoctor { get; set; }
        public string SexoDoctor { get; set; }
        public int NumeroDeLicencia { get; set; }
        public string EspecialidadMedica { get; set; }
        public string Notas { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string DuraccionDeConsulta { get; set; }
        public string ResultadoDePruebasExamenes { get; set; }
        public string Diagnostico { get; set; }
        public string InformacionSobreMedicamentos { get; set; }
    }
}
