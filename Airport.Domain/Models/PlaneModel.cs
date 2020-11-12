using Airport.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Models
{
    public class PlaneModel
    {
        public int Id { get; set; }
        public string ModelOfPlane { get; set; }
        public int PassengerCapacity { get; set; }

        public ICollection<FlightModel> Flights { get; set; }
    }
}
