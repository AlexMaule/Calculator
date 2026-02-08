using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Calculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Class Variables.
        private string _displayText = "0";
        private string _operation = "";
        private double _lastNumber = 0;
        private bool _isNewEntry = true;

        // Class Properties.
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand? ClearCommand { get; }
        public ICommand? ClearEntryCommand { get; }
        public ICommand? PercentageCommand { get; }
        public ICommand? OperationCommand { get; }
        public ICommand? DigitCommand { get; }
        public ICommand? DecimalCommand { get; }
        public ICommand? SignCommand { get; }
        public ICommand? EqualCommand { get; }

        // Constructor.
        public CalculatorViewModel()
        {
            DigitCommand = new RelayCommand(ExecuteDigit);
            //ClearCommand = new RelayCommand(ExecuteClear);
            //ClearEntryCommand = new RelayCommand(ExecuteClearEntry);
            //PercentageCommand = new RelayCommand(ExecutePercentage);
            //OperationCommand = new RelayCommand(ExecuteOperation);
            
            //DecimalCommand = new RelayCommand(ExecuteDecimal);
            //SignCommand = new RelayCommand(ExecuteSign);
            //EqualCommand = new RelayCommand(ExecuteEqual);
        }

        // Methods.
        public void ExecuteDigit(object? parameter)
        {
            string digit = parameter?.ToString() ?? "0";

            if (_isNewEntry)
            {
                DisplayText = digit;
                _isNewEntry = false;
            }
            else DisplayText = _displayText + digit;
        }


        private void OnPropertyChanged([CallerMemberName] string? property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
