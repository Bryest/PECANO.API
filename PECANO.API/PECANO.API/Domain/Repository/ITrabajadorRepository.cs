using PECANO.API.Domain.Models;

namespace PECANO.API.Domain.Repository
{
    public interface ITrabajadorRepository
    {
        Task<IEnumerable<Trabajador>> ListAsync();
        Task<Trabajador> FindByDNIAsync(string dni);
    }
}
