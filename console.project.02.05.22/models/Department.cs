using System;
namespace console.project._02._05._22.models
{
    public class department
    {
            public string _name;

            private int _workerlimit;

            private double _salarylimit;

            public Employee[] Employees;

        public double SalaryLimit
        {
            get => _salarylimit;
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("minmum maas 250 olmalidir");
                    if (int.TryParse(Console.ReadLine(), out int salaryLimit))
                    {
                        value = salaryLimit;
                    }
                    else
                    {
                        Console.WriteLine("Herf daxil etmek olmaz");
                    }
                }
                _salarylimit = value;
            }
        }

        public int Workerlimit
        {
            get => _workerlimit; 

            set
            {
                while (value < 10)
                {
                    Console.WriteLine("Minimum isci sayi 10");
                    int workerLimit;
                    if(int.TryParse(Console.ReadLine(), out workerLimit))
                    {
                        value = workerLimit;
                    }
                    else
                    {
                        Console.WriteLine("Herf daxil etmek olmaz");
                    }
                }
                _workerlimit = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                while (value.Length < 2)
                {
                    Console.WriteLine("ad minimum 2 herfden ibaret olamlidir");
                    value = Console.ReadLine();
                }
                _name = value;
            }
        }

      
        public department(string name, int workerLimit, double salaryLimit)
        {
            Employee[] employe = new Employee[0];
                 Workerlimit = workerLimit;
                SalaryLimit = salaryLimit;
                Name = name;

        }

        public double CalcSalaryAvarage()
        {
            double total = 0;
            foreach(Employee employe in Employees)
            {
                total += employe.Salary;
            }
            total = total / Employees.Length;
            return total;
        }
    }

 
}
