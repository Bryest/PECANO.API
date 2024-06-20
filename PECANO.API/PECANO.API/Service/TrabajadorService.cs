using System.Globalization;
using PECANO.API.Models;
using PECANO.API.Util;

namespace PECANO.API.Service
{
    public class TrabajadorService
    {
        private readonly List<Trabajador> _trabajadores;
        private readonly CalculoSueldoContext _calculoSueldoContext;

        public TrabajadorService(CalculoSueldoContext calculoSueldoContext)
        {
            _calculoSueldoContext = calculoSueldoContext;
            _trabajadores = LeerCsv("D:/TRABAJAR/HEARTBIT/ANGULAR NET/Examen PECANO/data-trabajadores.csv");
        }

        private List<Trabajador> LeerCsv(string path)
        {
            var trabajadores = new List<Trabajador>();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"El archivo especificado no se encontró: {path}");
            }

            using (var reader = new StreamReader(path))
            {

                var header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('|');

                    var _horasLaboradas = int.Parse(values[1], CultureInfo.InvariantCulture);
                    var _diasLaborados = int.Parse(values[2], CultureInfo.InvariantCulture);
                    var _faltas = int.Parse(values[3], CultureInfo.InvariantCulture);
                    var _tipoTrabajador = (TipoTrabajador)Enum.Parse(typeof(TipoTrabajador), values[4]);

                    var trabajador = new Trabajador
                    {
                        DNI = values[0],
                        HorasLaboradas = _horasLaboradas,
                        DiasLaborados = _diasLaborados,
                        Faltas = _faltas,
                        TipoTrabajador = _tipoTrabajador,
                        Sueldo = _calculoSueldoContext.CalcularSueldo(_tipoTrabajador, _horasLaboradas, _diasLaborados, _faltas)
                        
                    };

                    trabajadores.Add(trabajador);
                }
            }

            return trabajadores;
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
