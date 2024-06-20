namespace PECANO.API.Util
{
    public interface ICalculoSueldoStrategy
    {
        decimal CalcularSueldo(int horasLaboradas, int diasLaborados, int faltas);
    }

    public class ObreroCalculoSueldoStrategy : ICalculoSueldoStrategy
    {
        public decimal CalcularSueldo(int horasLaboradas, int diasLaborados, int faltas)
        {
            decimal paso1 = horasLaboradas * 15.00m;
            decimal paso2 = paso1 - (faltas * 120.00m);
            decimal paso3 = paso2 + 130.00m;
            decimal paso4 =  paso3 * 0.88m;

            return paso4;
        }
    }

    public class SupervisorCalculoSueldoStrategy : ICalculoSueldoStrategy
    {
        public decimal CalcularSueldo(int horasLaboradas, int diasLaborados,int faltas)
        {
            decimal paso1 = horasLaboradas * 35.00m;
            decimal paso2 = paso1 - (faltas * 280.00m);
            decimal paso3 = paso2 + 200.00m;
            decimal paso4 = paso3 * 0.84m;

            return paso4;
        }
    }

    public class GerenteCalculoSueldoStrategy : ICalculoSueldoStrategy
    {
        public decimal CalcularSueldo(int horasLaboradas, int diasLaborados, int faltas)
        {
            decimal paso1 = horasLaboradas * 85.00m;
            decimal paso2 = paso1 - (faltas * 680.00m);
            decimal paso3 = paso2 + 350.00m;
            decimal paso4 = paso3 * 0.82m;

            return paso4;
        }
    }

}
