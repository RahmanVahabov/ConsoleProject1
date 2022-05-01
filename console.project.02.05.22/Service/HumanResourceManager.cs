using console.project._02._05._22.Interfaces;
using console.project._02._05._22.models;
using console.project._02._05._22.Service;
using console.project._02._05._22.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace console.project._02._05._22.Service
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;


        public HumanResourceManager()
        {
            _departments = new Department[0];

        }
        public void AddDepartment(string name, int workerLimit, double salaryLimit)
        {
            Department department = FindName(name);
            if (department == null)
            {
                Department departments = new Department(name, workerLimit, salaryLimit);
                Array.Resize(ref _departments, _departments.Length + 1);
                _departments[_departments.Length - 1] = departments;
                return;
            }
            else
            {
                Console.WriteLine("Eyni adda ikinci sirket ola bulmez");
            }

        }
        public void AddEmployee(string fullName, string position, double salary, string departmentName)
        {
            Department checkdepartment = null;

            foreach (Department department in _departments)
            {
                if (department != null && department.Name.ToUpper() == departmentName.Trim().ToUpper())
                {
                    checkdepartment = department;
                    break;
                }
            }

            if (checkdepartment != null)
            {
                int employeeCount = 0;
                foreach (Employee employee in checkdepartment.Employees)
                {
                    if (employee != null)
                    {
                        employeeCount++;
                    }
                }

                if (employeeCount < checkdepartment.WorkerLimit)
                {
                    if (((checkdepartment.CalcSalaryAvarage() * employeeCount) + salary) <= checkdepartment.SalaryLimit)
                    {
                        Array.Resize(ref checkdepartment.Employees, checkdepartment.Employees.Length + 1);
                        checkdepartment.Employees[checkdepartment.Employees.Length - 1] = new Employee(fullName.Trim(), position.Trim(), salary, checkdepartment.Name);
                        Console.WriteLine("Added Sucsesfly");
                        return;
                    }
                }
                else Console.WriteLine("Ischiler limitten choxdur");
                return;
            }
            Console.WriteLine("Departament Tapilmadi");
        }

        public void EditDepartments(string name, string newname)
        {
            Department department = FindName(name);
            Department department1 = FindName(newname);

            if (department != null)
            {
                if (department1 != null)
                {
                    Console.WriteLine("bu adda department var artiq");
                    newname = Console.ReadLine();
                }

                department.Name = newname;
                foreach (Employee employee in department.Employees)
                {
                    employee.DepartmentName = newname;
                    employee.No = employee.DepartmentName.Substring(0, 2).ToUpper() + employee.No.Substring(2);
                    return;
                }
            }
            Console.WriteLine($"{name} adli department tapilmadi");
        }

        public Department FindName(string name)
        {
            foreach (Department department in _departments)
            {
                if (department.Name.ToUpper() == name.ToUpper())
                {
                    return department;
                }
            }
            return null;
        }

        public void EditEmployee(string departmentName, string no, double salary, string position)
        {
            Department department = FindName(departmentName);
            if (department != null)
            {
                foreach (Employee employe in department.Employees)
                {
                    if (employe.No == no.ToUpper())
                    {
                        if (((department.CalcSalaryAvarage() * department.Employees.Length) - employe.Salary) + salary > department.SalaryLimit)
                        {
                            Console.WriteLine("Maas heddi asildi");
                            return;
                        }
                        employe.Position = position;
                        employe.Salary = salary;
                        employe.DepartmentName = departmentName;
                    }
                }
                Console.WriteLine($"{no} nomreli isci tapilmadi");
                return;
            }
            Console.WriteLine($"{department} adinda department tapilmadi");
        }

        public Department[] GetDepartments()
        {
            return _departments;
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            Department department = FindName(departmentName);
            if (department != null)
            {

                if (departmentName.ToUpper() == departmentName.ToUpper())
                {
                    for (int i = 0; i < department.Employees.Length; i++)
                    {
                        if (department.Employees[i].No == no)
                        {
                            department.Employees[i] = department.Employees[department.Employees.Length - 1];
                            Array.Resize(ref department.Employees, department.Employees.Length - 1);
                            return;
                        }
                    }
                    Console.WriteLine($"{no} isci yoxdur");
                }

                Console.WriteLine($"{departmentName} adli department tapilmadi");
                return;
            }
            Console.WriteLine($"{departmentName} adli department tapilmadi");

        }

    }
}