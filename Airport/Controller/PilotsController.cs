using Airport.Domain.Models;
using Airport.Domain.Services;
using Airport.Model.PostModels;
using Airport.Model.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controller
{
    public class PilotsController    {
        private readonly PilotsService _airportPilotsService;
        private readonly IMapper _mapper;
        public PilotsController()
        {
            _airportPilotsService = new PilotsService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PilotPostModel, PilotModel>();
                cfg.CreateMap<PilotViewModel, PilotModel>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public PilotViewModel Create(PilotPostModel model)
        {
            var pilot = _mapper.Map<PilotModel>(model);
            var created= _airportPilotsService.Create(pilot);
            var result = _mapper.Map<PilotViewModel>(created);
            return result;
        }

        public void DeleteById(int id)
        {
            _airportPilotsService.DeleteById(id);
        }
    }
}
