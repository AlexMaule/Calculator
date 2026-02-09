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
            OperationCommand = new RelayCommand(ExecuteOperation);
            EqualCommand = new RelayCommand(ExecuteEqual);
            ClearCommand = new RelayCommand(ExecuteClear);

        }

        // Methods.
        private void ExecuteDigit(object? parameter)
        {
            string digit = parameter?.ToString() ?? "0";

            // Update if is a new entry, append otherwise.
            if (_isNewEntry)
            {
                DisplayText = digit;
                _isNewEntry = false;
            }
            else DisplayText = _displayText + digit;
        }

        private void ExecuteOperation(object? parameter)
        {
            _lastNumber = double.Parse(DisplayText);
            _operation = parameter?.ToString() ?? "";
            _isNewEntry = true;
        }

        private void ExecuteEqual(object? parameter)
        {
            double currentValue = double.Parse(DisplayText);

            // Calculate based on the Operation.
            double result = _operation switch
            {
                "+" => CalculatorModel.Add(_lastNumber, currentValue),
                "-" => CalculatorModel.Subtract(_lastNumber, currentValue),
                "*" => CalculatorModel.Multiply(_lastNumber, currentValue),
                "/" => CalculatorModel.Divide(_lastNumber, currentValue),
                _ => currentValue
            };

            DisplayText = result.ToString();
            _isNewEntry = true;
        }

        private void ExecuteClear(object? parameter)
        {
            // Reset to initial state.
            DisplayText = "0";
            _operation = "";
            _lastNumber = 0;
            _isNewEntry = true;
        }

        // Method to let UI know when one of its items changed.
        private void OnPropertyChanged([CallerMemberName] string? property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
