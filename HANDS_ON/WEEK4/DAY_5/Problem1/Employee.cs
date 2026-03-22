using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Employee
    {
        private String _fullName;
        private int _Age;
        private decimal _Salary;
        private readonly String _employeeId;

        public String FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Full name cannot be empty or null");

                }
                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (!(value >= 18 && value <= 80))
                {
                    throw new ArgumentException("Age should be between 18  and 80");

                }
                _Age = value;

            }
        }

        public decimal Salary
        {
            get
            {
                return _Salary;
            }
            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Minimum balance should be greater than 1000");
                }
                _Salary = value;

            }
        }
        public String EmployeeId
        {
            get { return _employeeId; }

        }
        public Employee(String fullName,decimal salary,int age,string employeeId=null)
        {
            // Auto generate Employee ID if not provided
            _employeeId = employeeId ?? "E" + Guid.NewGuid().ToString().Substring(0, 6);  //The null-coalescing operator.
                                                                                          //if employeeid is null it will auto id

            _fullName =fullName;   
            _Salary=salary;
            _Age=age;   
        }

        public void GiveRaise(decimal percantage)
        {
            if (!(percantage > 0 && percantage <= 30))
                throw new ArgumentException("Raise percantage must between 0 and 30");

            decimal increase = Salary * (percantage / 100);
            Salary += increase;
            Console.WriteLine($"Salary increased by {percantage}% . New Salary: {Salary}");

        }
        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Penalty amount must be positive.");

            if (Salary - amount < 1000)
            {
                Console.WriteLine("Penalty rejected. Salary cannot go below 1000.");
                return false;
            }

            Salary -= amount;

            Console.WriteLine($"Penalty deducted: {amount}. New Salary: {Salary}");
            return true;
        }


    }
 
    
}
