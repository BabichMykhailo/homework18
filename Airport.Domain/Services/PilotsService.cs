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
    public class PilotsService
    {
        private readonly PilotsRepository _airportPilotsRepository;
        private readonly IMapper _mapper;
        public PilotsService()
        {

            _airportPilotsRepository = new PilotsRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PilotModel, Pilot>();
                cfg.CreateMap<PilotModel, Pilot>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void DeleteById(int id)
        {
            _airportPilotsRepository.DeleteById(id);
        }

        public PilotModel Create(PilotModel model)
        {
            var pilot = _mapper.Map<Pilot>(model);
            var created = _airportPilotsRepository.Create(pilot);
            var result = _mapper.Map<PilotModel>(created);
            return result;
        }
    }
}
