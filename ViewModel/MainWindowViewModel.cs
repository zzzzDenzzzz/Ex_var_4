using Ex_var_4.Model;
using Ex_var_4.ViewModel.NotifyPropertyChanged;
using System.Collections.Generic;
using System.Linq;

namespace Ex_var_4.ViewModel
{
    internal class MainWindowViewModel : NotifyPropertyChangedClass
    {
        List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set => Set(ref employees, value);
        }

        List<Employee> employeesSearch;
        public List<Employee> EmployeesSearch
        {
            get => employeesSearch;
            set => Set(ref employeesSearch, value);
        }

        Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => Set(ref selectedEmployee, value);
        }

        string searchText;
        public string SearchText
        {
            get => searchText;
            set => Set(ref searchText, value);
        }

        public MainWindowViewModel()
        {
            Employees = EmployeesDB.GetEmployees().ToList();
            EmployeesSearch = _SearchEmployees();
        }

        List<Employee> _SearchEmployees()
        {
            var e = EmployeesDB.GetEmployees().Where(x => searchText == string.Empty || searchText == null
                            || x.Surname.ToLower().Contains(searchText.ToLower())
                            || x.Name.ToLower().Contains(searchText.ToLower())
                            || x.Patronymic.ToLower().Contains(searchText.ToLower())
                            || x.JobTitle.ToLower().Contains(searchText.ToLower())
                            || x.Login.ToLower().Contains(searchText.ToLower())
                            || x.PhoneNumber.ToLower().Contains(searchText.ToLower())).ToList();
            OnPropertyChanged(nameof(EmployeesSearch));
            return e;
        }
    }
}
