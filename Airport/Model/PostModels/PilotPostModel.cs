using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.PostModels
{
    public class PilotPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<FlightPostModel> Flights { get; set; }
    }
}
