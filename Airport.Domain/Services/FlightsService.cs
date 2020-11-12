using Airport.DATA.Model;
using Airport.Domain.Model;
using Airport.DATA.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Domain.Models;

namespace Airport.Domain.Services
{
    public class FlightsService
    {
        private readonly FlightsRepository _airportFlightsRepository;
        private readonly IMapper _mapper;
        public FlightsService()
        {

            _airportFlightsRepository = new FlightsRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FlightModel, Flight>();
                cfg.CreateMap<FlightModel, Flight>().ReverseMap();
                cfg.CreateMap<PilotModel, Pilot>();
                cfg.CreateMap<PilotModel, Pilot>().ReverseMap();
                cfg.CreateMap<PlaneModel, Plane>();
                cfg.CreateMap<PlaneModel, Plane>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void DeleteById(int id)
        {
            _airportFlightsRepository.DeleteById(id);
        }

        public FlightModel Create(FlightModel model)
        {
            var flight = _mapper.Map<Flight>(model);
            var created = _airportFlightsRepository.Create(flight);
            var result = _mapper.Map<FlightModel>(created);
            return result;
        }
    }
}
