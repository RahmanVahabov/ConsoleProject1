using console.project._02._05._22;
using console.project._02._05._22;
using console.project._02._05._22.models;
using console.project._02._05._22.Service;
using System;

namespace console.project._02._05._22
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("=====Welcome Human Resource Manager=====\n");
                Console.WriteLine("Etmek istediyiniz emeliyyatin reqemini daxil edin\n");

                Console.WriteLine("1. Departamenet yaratmaq: ");
                Console.WriteLine("2. Isci elave etmek: ");
                Console.WriteLine("3. Departamentdeki iscilerin siyahisini gostermrek: ");
                Console.WriteLine("4. Departameantlerin siyahisini gostermek: ");
                Console.WriteLine("5. Departmanetde deyisiklik etmek: ");
                Console.WriteLine("6. Isci uzerinde deyisiklik etmek: ");
                Console.WriteLine("7. Iscilerin siyahisini gostermek: ");
                Console.WriteLine("8. Departamentden isci silinmesi: ");
                Console.WriteLine("9. Sistemden cix");

                string choose = Console.ReadLine();
                int chooseNum;
                while (!int.TryParse(choose, out chooseNum) || chooseNum > 9 || chooseNum < 1)

                {
                    Console.WriteLine("Zehmet olmasa duzgun secim edin");
                    choose = Console.ReadLine();
                }
                Console.Clear();

                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        ShowEmoloyeByDepartmentName(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        ShowAllEmploye(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        return;
                }
            } while (true);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }
        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Departmentin adini daxil edin");
            string chooseDepartment = Console.ReadLine();

            Console.WriteLine("Departmentin isci limitini daxil edin");
            int.TryParse(Console.ReadLine(), out int workerlimit);

            Console.WriteLine("Departmentin budcesini elave et");
            double.TryParse(Console.ReadLine(), out double salarylimit);

            humanResourceManager.AddDepartment(chooseDepartment, workerlimit, salarylimit);
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }
        }
        static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Departmentler siyahisinda deyisiklik etmek istediyiniz departmentin adini secin");
            string chooseDepartmentName = Console.ReadLine();
            Console.WriteLine("Yeni adi daxil edin");
            string chooseNewDepartmentName = Console.ReadLine();
            humanResourceManager.EditDepartments(chooseDepartmentName, chooseNewDepartmentName);
        }
        static void ShowEmoloyeByDepartmentName(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Istediyiniz departmenti secin");
            string departmentName = Console.ReadLine();
            if (humanResourceManager.GetDepartments().Length < 0)
            {
                Console.WriteLine("Departmaent yoxdur");
            }
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Silmek istediyiniz departmentin nomresini daxil edin");
            string employeeNo = Console.ReadLine();

            Console.WriteLine("Silmek istediyiniz departmentin adini daxil edin");
            string departmentName = Console.ReadLine();

            humanResourceManager.RemoveEmployee(employeeNo, departmentName);
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Departmentin adini daxil edin");
            string departmentName = Console.ReadLine();
            Console.WriteLine("Adinizi ve soyadinizi daxil edin");
            string fullName = Console.ReadLine();
            while (!fullName.TrimStart().TrimEnd().Contains(" "))
            {
                Console.WriteLine("zehmet olmasa ad ve soyadi duzgun daxil edin");
                fullName = Console.ReadLine();
            }
            Console.WriteLine("Iscinin vezifesini daxil edin");
            string position = Console.ReadLine();
            Console.WriteLine("Iscinin maasini daxil edin");
            double.TryParse(Console.ReadLine(), out double salary);

            humanResourceManager.AddEmployee(fullName, position, salary, departmentName.ToUpper());
        }
        static void ShowAllEmploye(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("Deyismek istdeyiniz iacinin qrupunu daxil edin");
            string departmentName = Console.ReadLine();
            foreach (Department department1 in humanResourceManager.Departments)
            {
                foreach (Employee employee in department1.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("Deyismek istediyiniz isci npmresini daxil edin ");
            string no = Console.ReadLine();
            Console.WriteLine("Isicinin gelirini daxul edin");
            double.TryParse(Console.ReadLine(), out double employeSalary);
            Console.WriteLine("iscinin vezifesini daxil edin");
            string employeposition = Console.ReadLine();

            humanResourceManager.EditEmployee(departmentName, no, employeSalary, employeposition);
        }
    }
}