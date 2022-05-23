using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp20.Models;

namespace WpfApp20.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для срабатывания события
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        // свойство для 1 поля
        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }
        // свойство для 2 поля
        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }
        // свойство для 3 поля
        private double number3;
        public double Number3
        {
            get => number3;
            set
            {
                number3 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand ReduceCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        private void OnAddCommandExecute(object p)
        {
            Number3 = Ariph.Add(Number1, Number2);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (Number1 != 0 || Number2 != 0)
                return true;
            else
                return false;
        }

        private void OnReduceCommandExecute(object p)
        {
            Number3 = Ariph.Reduce(Number1, Number2);
        }
        private bool CanReduceCommandExecuted(object p)
        {
            if (Number1 != 0 || Number2 != 0)
                return true;
            else
                return false;
        }

        private void OnMultiplyCommandExecute(object p)
        {
            Number3 = Ariph.Multiply(Number1, Number2);
        }
        private bool CanMultiplyCommandExecuted(object p)
        {
            if (Number1 != 0 || Number2 != 0)
                return true;
            else
                return false;
        }

        private void OnDivideCommandExecute(object p)
        {
            Number3 = Ariph.Divide(Number1, Number2);
        }
        private bool CanDivideCommandExecuted(object p)
        {
            if (Number2 == 0)
                return false;
            else
                return true;
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
            ReduceCommand = new RelayCommand(OnReduceCommandExecute, CanReduceCommandExecuted);
            MultiplyCommand = new RelayCommand(OnMultiplyCommandExecute, CanMultiplyCommandExecuted);
            DivideCommand = new RelayCommand(OnDivideCommandExecute, CanDivideCommandExecuted);
        }
    }
}
