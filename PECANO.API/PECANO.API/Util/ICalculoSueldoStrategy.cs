namespace PECANO.API.Util
{
    public interface ICalculoSueldoStrategy
    {
        decimal CalcularSueldo(decimal horas, int dias);
    }

    public class ObreroCalculoSueldoStrategy : ICalculoSueldoStrategy
    {
        public decimal CalcularSueldo(decimal horas, int dias)
        {
            return 20m * horas * dias;
        }
    }

    public class SupervisorCalculoSueldoStrategy : ICalculoSueldoStrategy
    {
        public decimal CalcularSueldo(decimal horas, int dias)
        {
            return 30m * horas * dias;
        }
    }

    public class GerenteCalculoSueldoStrategy : ICalculoSueldoStrategy
    {
        public decimal CalcularSueldo(decimal horas, int dias)
        {
            return 40m * horas * dias;
        }
    }

}
