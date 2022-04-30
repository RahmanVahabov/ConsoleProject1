using System;
namespace console.project._02._05._22.models
{
    public class Employee
    {
        public Employee()
        {

        }
            private static int _count;

            private readonly string _no;

            private int _id;

            public string FullName { get; set; }

            public string DepartmentName { get; set; }

            private string _position;

            private double _salary;

            public string No { get; set; }

            public bool ChekPosition(string position)
        {
            bool chekLetter = false;

            if (position.Length > -2)
            {
                foreach(char item in position)
                {
                    if (!char.IsLetter(item))
                    {
                        chekLetter = false;
                        return chekLetter;
                    }

                    else
                    {
                        chekLetter = true;
                    }
                }
            }
            return chekLetter;
        }
        public double Salary
        {
            get => _salary;
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("minimum maas 250 dir");
                    int salary;
                    if (int.TryParse(Console.ReadLine(),out salary))
                    {
                        value = salary;
                    }
                    else
                    {
                        Console.WriteLine("duzgun daxil et yalniz reqem olmalidir");
                    }
                }
                _salary = value;
            }
        }
        public string Position
        {
            get => _position;
            set
            {
                while (!ChekPosition(value))
                {
                    Console.WriteLine("duzgun daxil et");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }
        static Employee()
        {
            _count = 1000;
        }
        public Employee(string fullName , string position , int salary , string no , string departmentName)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
            _count++;
            No = $"{Position.Substring(0, 2)}{_count}";
            No = no;
        }
      







    }
}
