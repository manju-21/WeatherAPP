using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;


namespace Weatherapp.ViewModel.Command
{
   public class SearchCommand : ICommand
    {


        public WeatherVM VM { get; set; }
        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;
            if (string.IsNullOrWhiteSpace(query))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MakeQuery();
        }
    }
}
