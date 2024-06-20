using System.Globalization;
using System.IO;
using PECANO.API.Dto;
using PECANO.API.Models;
using PECANO.API.Util;

namespace PECANO.API.Service
{
    public class TrabajadorService
    {
        private readonly List<TrabajadorDto> _trabajadores;
        private readonly CalculoSueldoContext _calculoSueldoContext;

        public TrabajadorService(CalculoSueldoContext calculoSueldoContext)
        {
            _calculoSueldoContext = calculoSueldoContext;
            _trabajadores = LeerCsv("D:/TRABAJAR/HEARTBIT/ANGULAR NET/Examen PECANO/data-trabajadores.csv");
        }

        private List<TrabajadorDto> LeerCsv(string path)
        {
            var trabajadores = new List<TrabajadorDto>();

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

                    var trabajador = new TrabajadorDto
                    {
                        DNI = values[0],
                        TipoTrabajador = _tipoTrabajador,
                        Sueldo = _calculoSueldoContext.CalcularSueldo(_tipoTrabajador, _horasLaboradas, _diasLaborados, _faltas)
                    };

                    trabajadores.Add(trabajador);
                }
            }

            return trabajadores;
        }

        public IEnumerable<TrabajadorDto> ObtenerTodos()
        {
            return _trabajadores;
        }

        public TrabajadorDto ObtenerPorDNI(string dni)
        {
            return _trabajadores.FirstOrDefault(t => t.DNI == dni);
        }
    }
}
