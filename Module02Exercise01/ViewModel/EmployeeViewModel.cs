using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _manager;

        public EmployeeViewModel()
        {
            // Initialize a sample employee manager model
            _manager = new Employee
            {
                FirstName = "Cristan Josh",
                LastName = "Nuguid",
                Position = "Manager",
                Department = "IT",
                IsActive = true
            };

            // UI Thread Management
            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            // Initial list of employees
            Employees = new ObservableCollection<Employee>
            {
                new Employee { FirstName = "Lorenzo", LastName = "Sangalang", Position = "Developer", Department = "IT", IsActive = true },
                new Employee { FirstName = "Richard", LastName = "Sy", Position = "Developer", Department = "IT", IsActive = true },
                new Employee { FirstName = "Mark", LastName = "Soberano", Position = "Analyst", Department = "Finance", IsActive = true },
                new Employee { FirstName = "Derick", LastName = "Pangilinan", Position = "Support", Department = "Customer Service", IsActive = false }
            };
        }

        public ObservableCollection<Employee> Employees { get; set; }

        private string _managerName;
        public string ManagerName
        {
            get => _managerName;
            set
            {
                if (_managerName != value)
                {
                    _managerName = value;
                    OnPropertyChanged(nameof(ManagerName));
                }
            }
        }

        public ICommand LoadEmployeeDataCommand { get; }

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000);
            ManagerName = $"{_manager.FullName} ({_manager.Position})";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}