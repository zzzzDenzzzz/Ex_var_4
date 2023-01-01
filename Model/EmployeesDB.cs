using System.Collections.ObjectModel;

namespace Ex_var_4.Model
{
    internal class EmployeesDB
    {
        /// <summary>
        /// создает список сотрудников
        /// </summary>
        /// <returns>список сотрудников</returns>
        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            for (int i = 1; i <= 9; i++)
            {
                employees.Add(new Employee()
                {
                    Surname = $"surname_{i}",
                    Name = $"name_{i}",
                    Patronymic = $"patronymic_{i}",
                    PhoneNumber = $"{i}{i}-{i}{i}-{i}{i}",
                    JobTitle = $"jobTitle_{i}",
                    Departament = $"departament_{i}",
                    Login = $"login_{i}",
                    Password = $"password_{i}",
                    EMail = $"email_{i}",
                });
            }

            return employees;
        }
    }
}
