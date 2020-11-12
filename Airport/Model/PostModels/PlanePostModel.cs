using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.PostModels
{
    public class PlanePostModel
    {
        public string ModelOfPlane { get; set; }
        public int PassengerCapacity { get; set; }

        public ICollection<FlightPostModel> Flights { get; set; }
    }
}
