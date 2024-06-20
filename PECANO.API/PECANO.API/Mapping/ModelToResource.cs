using AutoMapper;
using PECANO.API.Domain.Models;
using PECANO.API.Resources;

namespace PECANO.API.Mapping
{
    public class ModelToResource:Profile
    {
        public ModelToResource() { 
            CreateMap<Trabajador, TrabajadorResource>();
        }
    }
}
