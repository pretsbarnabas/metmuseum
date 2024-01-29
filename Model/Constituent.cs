using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace museum_api.Model
{
    public class Constituent
    {
        public int constituentID { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string constituentULAN_URL { get; set; }
        public string constituentWikidata_URL { get; set; }
        public string gender { get; set; }
    }
}
