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

        Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => Set(ref selectedEmployee, value);
        }


        List<Employee> resultSearch;
        public List<Employee> ResultSearch
        {
            get => resultSearch;
            set => Set(ref resultSearch, value);
        }

        string search;
        public string Search
        {
            get => search;
            set
            {
                Set(ref search, value);
                if (value != string.Empty)
                {
                    ResultSearch = UpdateListEmployee();
                }
                else
                {
                    ResultSearch = null;
                }
            }
        }

        public MainWindowViewModel()
        {
            Employees = EmployeesDB.GetEmployees().ToList();
        }
        /// <summary>
        /// поиск по ФИО, должности, логину, номеру телефона
        /// </summary>
        /// <returns>список совпадений</returns>
        List<Employee> UpdateListEmployee()
        {
            var result = EmployeesDB.GetEmployees().Where(x => search == string.Empty || search == null
            || x.Name.ToLower().Contains(search.ToLower())
            || x.Surname.ToLower().Contains(search.ToLower())
            || x.Patronymic.ToLower().Contains(search.ToLower())
            || x.Login.ToLower().Contains(search.ToLower())
            || x.PhoneNumber.ToLower().Contains(search.ToLower())).ToList();

            return result;
        }
    }
}
