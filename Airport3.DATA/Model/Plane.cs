using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DATA.Model
{
    public class Plane
    {
        public int Id { get; set; }
        public string ModelOfPlane { get; set; }
        public int PassengerCapacity { get; set; }

        public virtual ICollection <Flight> Flights { get; set; }
    }
}
