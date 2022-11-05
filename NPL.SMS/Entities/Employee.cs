using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training
{
    internal class Employee
    {
        private int employeeId;
        private string employeeName;
        private double salary;
        private int spvId;

        public Employee() { }
        public Employee(int employeeId,string employeeName,double salary,int spvId)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.salary = salary;
            this.spvId = spvId;
        }

        public int EmployeeId
        {
            set => employeeId = value;
            get => employeeId;
        }
        public string EmployeeName
        {
            set => employeeName = value;
            get => employeeName;
        }
        public double Salary
        {
            set => salary = value;
            get => salary;
        }
        public int SpvId
        {
            set => spvId = value;
            get => spvId;
        }
    }
}
