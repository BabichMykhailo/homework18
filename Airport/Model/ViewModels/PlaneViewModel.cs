using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.ViewModels
{
    public class PlaneViewModel
    {
        public int Id { get; set; }
        public string ModelOfPlane { get; set; }
        public int PassengerCapacity { get; set; }

        public ICollection<FlightViewModel> Flights { get; set; }
    }
}
