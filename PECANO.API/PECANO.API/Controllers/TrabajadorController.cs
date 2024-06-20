using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PECANO.API.Domain.Models;
using PECANO.API.Resources;
using PECANO.API.Services;
using PECANO.API.Shared.CSV;

namespace PECANO.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class TrabajadorController
    {
        private readonly ITrabajadorService _trabajadorService;
        private readonly IMapper _mapper;
        private readonly CsvReaderService _csvReaderService;

        public TrabajadorController(TrabajadorService trabajadorService, IMapper mapper, CsvReaderService csvReaderService)
        {
            _trabajadorService = trabajadorService;
            _mapper = mapper;
            _csvReaderService = csvReaderService;
        }

        /*
        [HttpGet]
        public async Task<IEnumerable<TrabajadorResource>> GetAllAsync()
        {
            var file = "D:\\TRABAJAR\\HEARTBIT\\ANGULAR NET\\Examen PECANO\\data-trabajadores.csv"; 
            var employees = _csvReaderService.ReadCsvFile(file);



            var result = await _trabajadorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Trabajador>,IEnumerable<TrabajadorResource>>(result);
                
            return employees;
        }
        */
        [HttpGet]
        public async Task<IEnumerable<TrabajadorResource>> Get()
        {
            var filePath = "D:\\TRABAJAR\\HEARTBIT\\ANGULAR NET\\Examen PECANO\\data-trabajadores.csv"; // Replace with the actual path to your CSV file
            var trabajadores = _csvReaderService.ReadCsvFile(filePath);

            //...Logica de los datos
            

            var resource = _mapper.Map<IEnumerable<Trabajador>, IEnumerable<TrabajadorResource>>(trabajadores);
            return resource;
        }


        [HttpGet("{dni}")]
        public async Task<TrabajadorResource> GetByIdAsync(string id)
        {
            var user = await _trabajadorService.FindByDNIAsync(id);
            var resources = _mapper.Map<Trabajador, TrabajadorResource>(user);

            return resources;
        }
    }
}
