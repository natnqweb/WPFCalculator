using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        public CalculatorViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new CalculatorViewModel();
            DataContext = ViewModel;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                switch (e.Key)
                {
                    case Key.D8:
                        ViewModel.OperatorCommand.Execute("*");
                        break;
                    case Key.D9:
                        ViewModel.OperatorCommand.Execute("(");
                        break;
                    case Key.D0:
                        ViewModel.OperatorCommand.Execute(")");
                        break;
                    case Key.OemQuestion:
                        ViewModel.OperatorCommand.Execute("/");
                        break;
                    case Key.OemPlus:
                        ViewModel.EqualsCommand.Execute(null);
                        break;
                    default:
                        break;
                }
                
                return;
            }

            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    ViewModel.NumberCommand.Execute("0");
                    break;
                case Key.D1:
                case Key.NumPad1:
                    ViewModel.NumberCommand.Execute("1");
                    break;
                case Key.D2:
                case Key.NumPad2:
                    ViewModel.NumberCommand.Execute("2");
                    break;
                case Key.D3:
                case Key.NumPad3:
                    ViewModel.NumberCommand.Execute("3");
                    break;
                case Key.D4:
                case Key.NumPad4:
                    ViewModel.NumberCommand.Execute("4");
                    break;
                case Key.D5:
                case Key.NumPad5:
                    ViewModel.NumberCommand.Execute("5");
                    break;
                case Key.D6:
                case Key.NumPad6:
                    ViewModel.NumberCommand.Execute("6");
                    break;
                case Key.D7:
                case Key.NumPad7:
                    ViewModel.NumberCommand.Execute("7");
                    break;
                case Key.D8:
                case Key.NumPad8:
                    ViewModel.NumberCommand.Execute("8");
                    break;
                case Key.D9:
                case Key.NumPad9:
                    ViewModel.NumberCommand.Execute("9");
                    break;
                case Key.Add:
                case Key.OemPlus:
                    ViewModel.OperatorCommand.Execute("+");
                    break;
                case Key.Subtract:
                case Key.OemMinus:
                    ViewModel.OperatorCommand.Execute("-");
                    break;
                case Key.Multiply:
                    ViewModel.OperatorCommand.Execute("*");
                    break;
                case Key.Divide:
                case Key.OemQuestion:
                    ViewModel.OperatorCommand.Execute("/");
                    break;
                case Key.Decimal:
                    ViewModel.NumberCommand.Execute(".");
                    break;
                case Key.Enter:
                    ViewModel.EqualsCommand.Execute(null);
                    break;
                case Key.Back:
                    ViewModel.ClearCommand.Execute(null);
                    break;
                case Key.OemOpenBrackets:
                    ViewModel.OperatorCommand.Execute("(");
                    break;
                case Key.OemCloseBrackets:
                    ViewModel.OperatorCommand.Execute(")");
                    break;
            }
        }
    }
}
