using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace museum_api.Model
{
    public class IdListing
    {
        public int total { get; set; }
        public ObservableCollection<int> objectIDs { get; set; }
    }
}
