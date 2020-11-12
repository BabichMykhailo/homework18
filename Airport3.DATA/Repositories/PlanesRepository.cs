using Airport.DATA;
using Airport.DATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DATA.Repositories
{
    public class PlanesRepository
    {
        private readonly AirportDBContext _ctx;
        public PlanesRepository()
        {
            _ctx = new AirportDBContext();
        }

        public Plane Create(Plane model)
        {
            _ctx.Planes.Add(model);
            _ctx.SaveChanges();
            return model;
        }

        public void DeleteById(int id)
        {
            var entity = _ctx.Planes.FirstOrDefault(x => x.Id == id);
            _ctx.Planes.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
