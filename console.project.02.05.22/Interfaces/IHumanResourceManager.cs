using console.project._02._05._22.Interfaces;
using console.project._02._05._22.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace console.project._02._05._22.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        public void AddDepartment(string name, int workerLimit, double salaryLimit);
        public void AddEmployee(string fullName, string position, double salary, string departmentName);
        public void EditDepartments(string name, string newname);
        public Department FindName(string name);
        public void EditEmployee(string departmentName, string no, double salary, string position);
        public Department[] GetDepartments();
        public void RemoveEmployee(string no, string departmentName);
    }
}