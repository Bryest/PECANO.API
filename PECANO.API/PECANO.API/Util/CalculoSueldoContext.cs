using PECANO.API.Models;

namespace PECANO.API.Util
{
    public class CalculoSueldoContext
    {
        private readonly Dictionary<TipoTrabajador, ICalculoSueldoStrategy> _strategies;

        public CalculoSueldoContext(ObreroCalculoSueldoStrategy obreroStrategy,
            SupervisorCalculoSueldoStrategy supervisorStrategy,
            GerenteCalculoSueldoStrategy gerenteStrategy)
        {
            _strategies = new Dictionary<TipoTrabajador, ICalculoSueldoStrategy>
            {
                { TipoTrabajador.Obrero, obreroStrategy },
                { TipoTrabajador.Supervisor, supervisorStrategy },
                { TipoTrabajador.Gerente, gerenteStrategy }
            };
        }
        
        public decimal CalcularSueldo(TipoTrabajador tipoTrabajador, int horasLaboradas, int diasLaborados, int faltas)
        {
            return _strategies[tipoTrabajador].CalcularSueldo(horasLaboradas, diasLaborados, faltas);
        }
    }
}
