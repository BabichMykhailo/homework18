using Airport.DATA;
using Airport.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DATA.Repositories
{
    public class PilotsRepository
    {
        private readonly AirportDBContext _ctx;
        public PilotsRepository()
        {
            _ctx = new AirportDBContext();
        }

        public void DeleteById(int id)
        {
            var entity = _ctx.Pilots.FirstOrDefault(x => x.Id == id);
            _ctx.Pilots.Remove(entity);
            _ctx.SaveChanges();
        }

        public Pilot Create(Pilot model)
        {
            _ctx.Pilots.Add(model);
            _ctx.SaveChanges();
            return model;
        }
    }
}
