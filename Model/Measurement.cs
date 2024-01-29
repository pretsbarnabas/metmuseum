using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace museum_api.Model
{
    public class Measurement
    {
        public string elementName { get; set; }
        public object elementDescription { get; set; }
        public ElementMeasurements elementMeasurements { get; set; }
    }
}
