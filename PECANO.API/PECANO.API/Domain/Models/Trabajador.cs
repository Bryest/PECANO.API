using System.Net;

namespace PECANO.API.Domain.Models
{
    public class Trabajador
    {
        public string dni { get; set; }
        public int horas_laboradas { get; set; }
        public int días_laborados { get; set; }
        public int faltas { get; set; }
        public int tipo_de_trabajador { get; set; }

    }
}
