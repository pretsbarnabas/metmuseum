using museum_api.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace museum_api.ViewModel.Helpers
{
    public class MuseumVM
    {
        public SearchCommand SearchCommand { get; set; }
        public MuseumVM() 
        {
            SearchCommand = new SearchCommand(this);
        }
        public async void MakeQuery()
        {
            var response = await API_Helper.GetArt("asd");
        }
    }
}
