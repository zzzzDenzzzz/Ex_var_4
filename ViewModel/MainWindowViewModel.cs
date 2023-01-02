using Ex_var_4.Model;
using Ex_var_4.ViewModel.Command;
using Ex_var_4.ViewModel.NotifyPropertyChanged;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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


        ObservableCollection<Employee> resultSearch;
        public ObservableCollection<Employee> ResultSearch
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
                    ResultSearch = UpdateCollectionEmployee();
                }
                else
                {
                    ResultSearch = null;
                }
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand ChangeCommand { get; private set; }

        public MainWindowViewModel()
        {
            Employees = EmployeesDB.GetEmployees();
            AddCommand = new CommandClass(AddEmployee);
            RemoveCommand = new CommandClass(RemoveEmployee, CanRemoveEmployee);
            ChangeCommand = new CommandClass(ChangeEmployee, CanChangeEmployee);
        }

        void ChangeEmployee(object obj)
        {
            Search = string.Empty;
            MessageBox.Show("Изменения сохранены");
        }

        bool CanChangeEmployee(object arg)
        {
            return (arg as Employee) != null;
        }

        bool CanRemoveEmployee(object arg)
        {
            return (arg as Employee) != null;
        }

        void RemoveEmployee(object obj)
        {
            Employees.Remove(obj as Employee);
            Search = string.Empty;
        }

        void AddEmployee(object obj)
        {
            Employees.Add(new Employee()
            {
                Surname = "new_surname_1",
                Name = "new_name_1",
                Patronymic = "new_patronymic_1",
                PhoneNumber = "1234567890",
                JobTitle = "new_jobTitle_1",
                Departament = "new_departament_1",
                Login = "new_login_1",
                Password = "new_password_1",
                EMail = "new_email_1"
            });
        }

        /// <summary>
        /// поиск по ФИО, должности, логину, номеру телефона
        /// </summary>
        /// <returns>список совпадений</returns>
        ObservableCollection<Employee> UpdateCollectionEmployee()
        {
            var result = new ObservableCollection<Employee>(Employees.ToList().Where(x => search == string.Empty || search == null
            || x.Name.ToLower().Contains(search.ToLower())
            || x.Surname.ToLower().Contains(search.ToLower())
            || x.Patronymic.ToLower().Contains(search.ToLower())
            || x.Login.ToLower().Contains(search.ToLower())
            || x.PhoneNumber.ToLower().Contains(search.ToLower())).ToList());

            return result;
        }
    }
}
