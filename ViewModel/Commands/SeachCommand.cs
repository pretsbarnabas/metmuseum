using museum_api.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace museum_api.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public MuseumVM VM { get; set; }
        public SearchCommand(MuseumVM vm)
        {
            VM = vm;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return true;
        }

        void ICommand.Execute(object? parameter)
        {
            VM.MakeQuery();
        }

   
    }
}
