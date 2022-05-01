using System;
using System.Collections.Generic;
using System.Text;

namespace console.project._02._05._22.models
{
    class Department
    {
        private string _name;

        private int _workerLimit;

        private double _salaryLimit;

        public Employee[] Employees;
        public double SalaryLimit
        {
            get => _salaryLimit;
            set
            {
                while (value < (_workerLimit * 250))
                {
                    Console.WriteLine("Mass limitini duzgun qeyd et");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salaryLimit = value;
            }
        }
        public int WorkerLimit
        {
            get => _workerLimit;
            set
            {
                while (value < 2)
                {
                    Console.WriteLine("Minimum isci sayi 10 ola biler");
                    int workerLimit;
                    if (int.TryParse(Console.ReadLine(), out workerLimit))
                    {
                        value = workerLimit;
                    }
                    else
                    {
                        Console.WriteLine("Herf daxil etmek olmaz");
                    }
                }
                _workerLimit = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                while (NameChecker(value))
                {
                    Console.WriteLine("Ad minimum 2 herfden ibaret ola biler");
                    value = Console.ReadLine();
                }
                if (NameChecker(value))
                {
                    value = Name;
                }
                _name = value;
            }
        }
        public bool NameChecker(string name)
        {
            if (name.Length >= 2)
            {
                foreach (var item in name)
                {
                    if (!char.IsLetter(item))
                    {
                        return false;
                    }
                }
                return false;
            }
            return false;
        }
        public Department(string name, int workerLimit, double salaryLimit)
        {
            Employees = new Employee[0];
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
            Name = name;
        }
        public double CalcSalaryAvarage()
        {
            double sum = 0;
            int count = 0;
            foreach (Employee employee in Employees)
            {
                if (employee != null)
                {
                    sum += employee.Salary;
                    count++;
                }
            }
            return sum > 0 ? sum / count : 0;
        }

        public override string ToString()
        {
            return $"Departmentin adi: {Name} \nDepartmentin isci limiti: {WorkerLimit} \nDeparmentin isci maas limiti: {SalaryLimit}";
        }
    }

}