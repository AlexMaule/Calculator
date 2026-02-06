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
            ClearCommand = new RelayCommand(ExecuteClear);
            ClearEntryCommand = new RelayCommand(ExecuteClearEntry);
            PercentageCommand = new RelayCommand(ExecutePercentage);
            OperationCommand = new RelayCommand(ExecuteOperation);
            DigitCommand = new RelayCommand(ExecuteDigit);
            DecimalCommand = new RelayCommand(ExecuteDecimal);
            SignCommand = new RelayCommand(ExecuteSign);
            EqualCommand = new RelayCommand(ExecuteEqual);
        }

        
        // Methods.

        private void ExecuteEqual(object? parameter)
        {
            double currentValue = double.Parse(DisplayText);

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

        private void ExecuteSign(object? parameter)
        {
            if (DisplayText != "0")
            {
                double currentValue = double.Parse(DisplayText);
                DisplayText = CalculatorModel.ChangeSign(currentValue).ToString();
            }
        }

        private void ExecuteDecimal(object? parameter)
        {
            if (_isNewEntry)
            {
                DisplayText = "0.";
                _isNewEntry = false;
            }
            else if (!DisplayText.Contains("."))
            {
                DisplayText += ".";
            }
        }

        public void ExecuteDigit(object? parameter)
        {
            string digit = parameter?.ToString() ?? "Error";
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
            _operation = parameter?.ToString() ?? "Error";
            _isNewEntry = true;
        }

        private void ExecutePercentage(object? parameter)
        {
            double currentValue = double.Parse(DisplayText);
            double result = CalculatorModel.Percentage(currentValue);
            DisplayText = result.ToString();
        }

        private void ExecuteClearEntry(object? parameter)
        {
            if (_displayText != "0")
            {
                DisplayText = "0";
                _isNewEntry = true;
            }
        }

        private void ExecuteClear(object? parameter)
        {
            DisplayText = "0";
            _lastNumber = 0;
            _operation = "";
            _isNewEntry = true;
        }

        // Notify the UI to refresh.
        private void OnPropertyChanged([CallerMemberName] string? property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}