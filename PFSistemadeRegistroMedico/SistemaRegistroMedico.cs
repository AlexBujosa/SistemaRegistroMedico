using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;
namespace PFSistemadeRegistroMedico
{
    public class SistemaRegistroMedico
    {
        List<Paciente> pacientes;
        List<Doctor> doctores;
        public SistemaRegistroMedico()
        {
            pacientes = new List<Paciente>();
            doctores = new List<Doctor>();  
        }
        public void Main(string[] args)
        {
            
            int opcion = 0;
            while(opcion != 4)
            {
                Console.WriteLine("Bienvenido al sistema de registro médico");
                Console.WriteLine("¿Qué desea hacer?");
                Console.WriteLine("1. Hacer un registro.");
                Console.WriteLine("2. Eliminar Registros.");
                Console.WriteLine("3. Ver Registros.");
                Console.WriteLine("4. Salir.");
                Console.Write("Ingrese la opción deseada ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        RegistrarPaciente();
                        RegistrarDoctor();
                        Esperar5Segundos();
                        break;
                    case 2:
                        EliminarRegistro();
                        Esperar5Segundos();
                        break;
                    case 3:
                        MostrarRegistro();
                        Esperar5Segundos();
                        break;
                }

                if(opcion != 1 && opcion != 2 && opcion != 3 && opcion !=4)
                {
                    Console.Write("Opcion no valida");
                }
            }
           

            Console.WriteLine("Gracias por usar el sistema.");
            Console.ReadKey();
        } 

        public void Esperar5Segundos()
        {
            Console.WriteLine();
            Console.WriteLine("Esperar 5 segundos... Se limpiara la pantalla");

            Thread.Sleep(5000);
            Console.Clear();
        }
        public void RegistrarDoctor()
        {
            Doctor doctor = new Doctor();   

            Console.WriteLine("\nContinuemos con los datos del doctor encargado.");
            Console.WriteLine("Introduzca los siguientes datos: ");
            Console.Write("Nombre completo: ");
            doctor.NombreCompletoDoctor = Console.ReadLine();
            Console.Write("Sexo: ");
            doctor.SexoDoctor = Console.ReadLine();
            Console.Write("Número de licencia: ");
            doctor.NumeroDeLicencia = int.Parse(Console.ReadLine());
            Console.Write("Especialidad: ");
            doctor.EspecialidadMedica = Console.ReadLine();
            Console.Write("Notas: ");
            doctor.Notas = Console.ReadLine();
            Console.Write("Fecha de ingreso: ");
            doctor.FechaDeIngreso = DateTime.Now;
            Console.Write("Duración de la consulta: ");
            doctor.DuraccionDeConsulta = Console.ReadLine();
            Console.Write("Resultado pruebas de examenes: ");
            doctor.ResultadoDePruebasExamenes = Console.ReadLine();
            Console.Write("Diagnóstico: ");
            doctor.Diagnostico = Console.ReadLine();
            Console.Write("Información sobre medicamentos: ");
            doctor.InformacionSobreMedicamentos = Console.ReadLine();
            doctores.Add(doctor);
        }
        public void RegistrarPaciente()
        {
            Paciente paciente = new Paciente();
            Console.WriteLine("Comenzemos con los datos del paciente.");
            Console.WriteLine("Introduzca los siguientes datos: ");
            Console.Write("Nombre completo: ");
            paciente.NombreCompletoPaciente = Console.ReadLine();
            Console.Write("Sexo: ");
            paciente.SexoPaciente = Console.ReadLine();
            Console.Write("Fecha de nacimiento: ");
            paciente.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());
            Console.Write("Dirección: ");
            paciente.Direccion = Console.ReadLine();
            bool numeroValido = false;
            string numeroTelefono = "";
            while (!numeroValido)
            {
                Console.Write("Número de Teléfono: ");
                numeroTelefono = Console.ReadLine();
                numeroValido  = ValidatePhoneNumber(numeroTelefono);
                if (!numeroValido)
                {
                    Console.WriteLine("upps Numero de telefono no valido, por favor ingrese de nuevo");
                }

            }
            paciente.NumeroDeTelefono = numeroTelefono;
            Console.Write("Nombre de seguro médico: ");
            paciente.SeguroMedico = Console.ReadLine();
            Console.Write("Alergias: ");
            paciente.Alergias = Console.ReadLine();
            Console.Write("Medicamentos recetados: ");
            paciente.MedicamentosRecetados = Console.ReadLine();
            Console.Write("Antecedentes de enfermedades familiares: ");
            paciente.AntecedentesDeEnfermedadesFamiliares = Console.ReadLine();
            Console.Write("Información de contacto de emergencia: ");
            paciente.InformacionDeContactoDeEmergencia= Console.ReadLine();
            Console.Write("Vacunas e inmunizaciones: ");
            paciente.VacunasInmunizaciones = Console.ReadLine();
            Console.Write("Información relevante sobre el caso:");
            paciente.InformacionRelevante = Console.ReadLine();
            pacientes.Add(paciente);
            
        }    
        public void EliminarRegistro()
        {
            Console.WriteLine("Ingrese el nombre completo del paciente que desea eliminar: ");
            Paciente pacienteAEliminar = pacientes.Find(p => p.NombreCompletoPaciente == Console.ReadLine());
            if(pacienteAEliminar == null)
            {
                Console.WriteLine("No se encontró el paciente.");
            }
            else
            {
                pacientes.Remove(pacienteAEliminar);
                Console.WriteLine("El paciente ha sido eliminado.");
            }
            Console.WriteLine("Ingrese el nombre completo del doctor que desea eliminar: ");
            Doctor doctorAEliminar = doctores.Find(d => d.NombreCompletoDoctor == Console.ReadLine());
            if (doctorAEliminar == null)
            {
                Console.WriteLine("No se encontró el doctor.");
            }
            else
            {
                doctores.Remove(doctorAEliminar);
                Console.WriteLine("El doctor ha sido eliminado.");
            }
        }

        public void MostrarRegistro()
        {
            var tablaPaciente = new ConsoleTable("Nombre", "Sexo", "Fecha de Nacimiento", "Direccion", "Numero de Telefono", "Seguro Medico", "Alergias", "Medicamento Recetados");
            foreach (var item in pacientes)
            {
                tablaPaciente.AddRow(item.NombreCompletoPaciente, item.SexoPaciente, item.FechaDeNacimiento, item.Direccion, item.NumeroDeTelefono, item.SeguroMedico, item.Alergias, item.MedicamentosRecetados);
            }

            var tablaDoctor = new ConsoleTable("Nombre", "Sexo", "Numero de Licencia", "Especialidad", "Notas", "Fecha de Ingreso", "Duracion de consulta", "Resultado de Prueba");
            foreach (var item in doctores) 
            {
                tablaDoctor.AddRow(item.NombreCompletoDoctor, item.SexoDoctor, item.NumeroDeLicencia, item.EspecialidadMedica, item.Notas, item.FechaDeIngreso.ToShortDateString(), item.DuraccionDeConsulta, item.ResultadoDePruebasExamenes);
            }

            Console.WriteLine("Tabla Registro Paciente");
            tablaPaciente.Write(Format.MarkDown);
            Console.WriteLine("Tabla Registro Doctor");
            tablaDoctor.Write(Format.MarkDown);
        }

        static bool ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+?\d{0,2}\s?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$"; // The regular expression pattern to validate the phone number

            Regex regex = new Regex(pattern); // Create a new Regex object with the pattern

            return regex.IsMatch(phoneNumber); // Return true if the phone number matches the pattern, false otherwise
        }
    }
}
