using PECANO.API.Models;

namespace PECANO.API.Dto
{
    public class TrabajadorDto
    {
        public string DNI { get; set; }
        public TipoTrabajador TipoTrabajador { get; set; }
        public decimal Sueldo { get; set; }
    }
}
