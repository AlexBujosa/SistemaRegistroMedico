using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSistemadeRegistroMedico
{
    public class Paciente
    {
        public string NombreCompletoPaciente { get; set; }
        public string SexoPaciente { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Direccion { get; set; }
        public string NumeroDeTelefono { get; set; }
        public string SeguroMedico { get; set; }
        public string Alergias { get; set; }
        public string MedicamentosRecetados { get; set; }
        public string AntecedentesDeEnfermedadesFamiliares { get; set; }
        public string InformacionDeContactoDeEmergencia { get; set; }
        public string VacunasInmunizaciones { get; set; }
        public string InformacionRelevante { get; set; }
    }
}
