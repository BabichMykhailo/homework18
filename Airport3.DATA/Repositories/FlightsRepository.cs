using Airport.DATA;
using Airport.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DATA.Repositories
{
    public class FlightsRepository
    {
        private readonly AirportDBContext _ctx;
        public FlightsRepository()
        {
            _ctx = new AirportDBContext();
        }

        public void DeleteById(int id)
        {
            var entity = _ctx.Flights.FirstOrDefault(x => x.Id == id);
            _ctx.Flights.Remove(entity);
            _ctx.SaveChanges();
        }

        public Flight Create(Flight model)
        {
            _ctx.Flights.Add(model);
            _ctx.SaveChanges();
            return model;
        }
    }
}
