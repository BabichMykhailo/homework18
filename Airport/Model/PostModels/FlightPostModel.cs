using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.PostModels
{
    public class FlightPostModel
    {
        public string FlightCity { get; set; }
        public DateTime FlightTime { get; set; }

        public ICollection<PilotPostModel> Pilots { get; set; }

        public int PlaneId { get; set; }
        public PlanePostModel Plane { get; set; }
    }
}
