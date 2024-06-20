using PECANO.API.Domain.Models;
using PECANO.API.Domain.Repository;

namespace PECANO.API.Persistence.Repository
{
    public class TrabajadorRepository : ITrabajadorRepository
    {

        Task<Trabajador> ITrabajadorRepository.FindByDNIAsync(string dni)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Trabajador>> ITrabajadorRepository.ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
