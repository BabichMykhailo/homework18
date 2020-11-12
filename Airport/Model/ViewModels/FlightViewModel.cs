using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.ViewModels
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string FlightCity { get; set; }
        public DateTime FlightTime { get; set; }

        public ICollection<PilotViewModel> Pilots { get; set; }

        public int PlaneId { get; set; }
        public PlaneViewModel Plane { get; set; }
    }
}
