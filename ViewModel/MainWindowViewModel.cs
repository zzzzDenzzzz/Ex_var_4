using Ex_var_4.Model;
using Ex_var_4.ViewModel.NotifyPropertyChanged;
using System.Collections.ObjectModel;

namespace Ex_var_4.ViewModel
{
    internal class MainWindowViewModel : NotifyPropertyChangedClass
    {
        ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => Set(ref employees, value);
        }

        Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => Set(ref selectedEmployee, value);
        }

        public MainWindowViewModel()
        {
            Employees = EmployeesDB.GetEmployees(9);
        }
    }
}
