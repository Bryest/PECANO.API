using PECANO.API.Domain.Models;
using PECANO.API.Domain.Repository;

namespace PECANO.API.Services
{
    public class TrabajadorService
    {
        private readonly ITrabajadorRepository _trabajadorRepository;

        public TrabajadorService(ITrabajadorRepository trabajadorRepository)
        {
            this._trabajadorRepository = trabajadorRepository;
        }

        public async Task<IEnumerable<Trabajador>> ListAsync()
        {
            return await _trabajadorRepository.ListAsync();
        }
        public async Task<Trabajador> FindByDNIAsync(string dni)
        {
            return await _trabajadorRepository.FindByDNIAsync(dni);
        }
    }
}
