using System.Globalization;
using PECANO.API.Models;

namespace PECANO.API.Service
{
    public class TrabajadorService
    {
        private readonly List<Trabajador> _trabajadores;

        public TrabajadorService()
        {
            _trabajadores = LeerCsv("D:/TRABAJAR/HEARTBIT/ANGULAR NET/Examen PECANO/data-trabajadores.csv");
        }

        private List<Trabajador> LeerCsv(string path)
        {
            var trabajadores = new List<Trabajador>();

            using (var reader = new StreamReader(path))
            {

                var header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('|');

                    var trabajador = new Trabajador
                    {
                        DNI = values[0],
                        Nombre = values[1],
                        TipoTrabajador = (TipoTrabajador)Enum.Parse(typeof(TipoTrabajador), values[2]),
                        HorasLaboradas = decimal.Parse(values[3], CultureInfo.InvariantCulture),
                        DiasLaborados = int.Parse(values[4], CultureInfo.InvariantCulture),
                        Sueldo = CalcularSueldo((TipoTrabajador)Enum.Parse(typeof(TipoTrabajador), values[2]), decimal.Parse(values[3], CultureInfo.InvariantCulture), int.Parse(values[4], CultureInfo.InvariantCulture))
                    };

                    trabajadores.Add(trabajador);
                }
            }

            return trabajadores;
        }

        private decimal CalcularSueldo(TipoTrabajador tipo, decimal horas, int dias)
        {
            var tarifaBase = tipo switch
            {
                TipoTrabajador.Obrero => 20m,
                TipoTrabajador.Supervisor => 30m,
                TipoTrabajador.Gerente => 40m,
                _ => 0m
            };

            return tarifaBase * horas * dias;
        }

        public IEnumerable<Trabajador> ObtenerTodos()
        {
            return _trabajadores;
        }

        public Trabajador ObtenerPorDNI(string dni)
        {
            return _trabajadores.FirstOrDefault(t => t.DNI == dni);
        }
    }
}
