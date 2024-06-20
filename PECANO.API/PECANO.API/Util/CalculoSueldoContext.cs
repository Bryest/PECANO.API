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

        public decimal CalcularSueldo(TipoTrabajador tipo, decimal horas, int dias)
        {
            return _strategies[tipo].CalcularSueldo(horas, dias);
        }
    }
}
