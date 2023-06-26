using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CalculatorApp
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand ClearCommand { get; }

        public CalculatorViewModel()
        {
            Result = "";

            NumberCommand = new RelayCommand<string>(AppendNumber);
            OperatorCommand = new RelayCommand<string>(AppendOperator);
            EqualsCommand = new RelayCommand<string>(CalculateResult);
            ClearCommand = new RelayCommand<string>(Clear);
        }

        private void AppendNumber(string number)
        {
            Result += number;
        }

        private void AppendOperator(string op)
        {
            Result += " " + op + " ";
        }

        private void CalculateResult(string _)
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(Result, "");
                Result = result.ToString();
            }
            catch (Exception)
            {
                Result = "Error";
            }
        }

        private void Clear(string _)
        {
            Result = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
