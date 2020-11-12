using Airport.DATA.Model;
using Airport.Domain.Models;
using Airport.DATA.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Services
{
    public class PlanesService
    {
        private readonly PlanesRepository _airportPlanesRepository;
        private readonly IMapper _mapper;
        public PlanesService()
        {

            _airportPlanesRepository = new PlanesRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlaneModel, Plane>();
                cfg.CreateMap<PlaneModel, Plane>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void DeleteById(int id)
        {
            _airportPlanesRepository.DeleteById(id);
        }

        public PlaneModel Create(PlaneModel model)
        {
            var plane = _mapper.Map<Plane>(model);
            var createdPlane = _airportPlanesRepository.Create(plane);
            var result = _mapper.Map<PlaneModel>(createdPlane);
            return result;
        }
    }
}
