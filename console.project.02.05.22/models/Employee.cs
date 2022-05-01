using System;
using System.Collections.Generic;
using System.Text;

namespace console.project._02._05._22.models
{
    class Employee
    {
        private static int _count;

        private readonly string _no;

        private int _id;
        public string FullName { get; set; }
        public string DepartmentName { get; set; }

        private string _position;

        private double _salary;

        public string No { get; set; }

        public bool CheckPosition(string position)
        {
            bool checkLetter = false;

            if (position.Length >= 2)
            {
                foreach (char item in position)
                {
                    if (!char.IsLetter(item))
                    {
                        checkLetter = false;
                        return checkLetter;
                    }
                    else
                    {
                        checkLetter = true;
                    }
                }
            }
            return checkLetter;
        }

        public double Salary
        {
            get => _salary;
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("Minimum maas 250 ola biler");
                    int salary;
                    if (int.TryParse(Console.ReadLine(), out salary))
                    {
                        value = salary;
                    }
                    else
                    {
                        Console.WriteLine("Herf daxil etmek olmaz");
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
                while (!CheckPosition(value))
                {
                    Console.WriteLine("Duzgun daxil et");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }
        static Employee()
        {
            _count = 1000;
        }

        public Employee(string fullName, string position, double salary, string departmentName)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
            _count++;
            No = $"{departmentName.Substring(0, 2).ToUpper()}{_count}";
            Console.WriteLine(No);
        }
        public override string ToString()
        {
            string[] NameSurname = FullName.Split(" ");
            NameSurname[0].ToUpper();
            NameSurname[1].ToUpper();
            return $"Iscinin adi: {NameSurname[0]} Iscinin soyadi:{NameSurname[1]} Iscinin vezifesi: {_position} iscinin maasi: {_salary} {No}";
        }
    }
}