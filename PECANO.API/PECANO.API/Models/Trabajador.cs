namespace PECANO.API.Models
{
    public enum TipoTrabajador
    {
        Obrero = 0,
        Supervisor = 1,
        Gerente = 2
    }

    public class Trabajador
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public TipoTrabajador TipoTrabajador { get; set; }
        public decimal HorasLaboradas { get; set; }
        public int DiasLaborados { get; set; }
        public decimal Sueldo { get; set; }
    }
}
