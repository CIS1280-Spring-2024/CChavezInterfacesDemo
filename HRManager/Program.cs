﻿using System.Numerics;

namespace HRManager
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            HourlyEmployee hourEmp = new HourlyEmployee(2, "Bill", "Gates", 15.00M);
            hourEmp.Hours.Add(80.0);
            hourEmp.Hours.Add(90.0);
            hourEmp.Hours.Add(70.0);
            hourEmp.Phone = "867-5309";
            hourEmp.Email = "bigdaddy@microsoft.com";

            DisplayEmployeeInfo(hourEmp, 0, 3);

            SalaryEmployee salaryEmp = new SalaryEmployee();
            salaryEmp.EmpNum = 2;
            salaryEmp.FirstName = "Alan";
            salaryEmp.LastName = "Turing";
            salaryEmp.Phone = "1-800-FLOWERS";
            salaryEmp.Email = "aitester@Microsoft.com";
            salaryEmp.Salary = 40000.0M;
            salaryEmp.Hours.Add(80.0);
            salaryEmp.Hours.Add(80.0);
            salaryEmp.Hours.Add(80.0);

            DisplayEmployeeInfo(salaryEmp, 0, 3);

            List<Employee> myEmployees = new List<Employee>();
            myEmployees.Add(salaryEmp);
            myEmployees.Add(hourEmp);
            decimal payroll = 0;
            foreach (Employee employee in myEmployees)
            {
                payroll += employee.Pay(0, 3);
            }
            Console.WriteLine("Payroll total for 0-2: " + payroll.ToString("c"));
            Console.WriteLine();

            foreach (Employee employee in myEmployees)
            {

                Console.WriteLine("Employee: " + employee);
                if (employee is HourlyEmployee)
                {
                    //HourlyEmployee hourlyEmp = employee as HourlyEmployee;
                    HourlyEmployee hourlyEmp = (HourlyEmployee)employee;
                    Console.WriteLine("Hourly rate: " + hourlyEmp.HourlyRate);
                }
                if (employee is SalaryEmployee)
                {
                    SalaryEmployee salEmp = employee as SalaryEmployee;
                    Console.WriteLine("Salary: " + salEmp.Salary);
                }
            }

            PhoneBook phoneBook = new PhoneBook();

            Department department = new Department("Microsoft");

            department.Phone = "555-555";
            department.Description = "We believe in what people make possible.";
            department.Email = "customerservice@microsoft.com";
            department.WebSite = "www.microsoft.com";

            phoneBook.PhoneBookEntries.Add(hourEmp);
            phoneBook.PhoneBookEntries.Add(salaryEmp);
            phoneBook.PhoneBookEntries.Add(department);

            Console.Write("\n\n---Phonebook---\n\n");
            Console.WriteLine(phoneBook.GetPhoneBook());

            Console.Write("Press any key to quit...");
            Console.ReadKey();
        }

        private static void DisplayEmployeeInfo(Employee emp, int payStart, int payEnd)
        {
            Console.WriteLine(emp.ToString());
            Console.WriteLine(emp.PaySummary);
            Console.WriteLine("Pay for periods " + payStart + "-" + payEnd + ": "
                + emp.Pay(payStart, payEnd).ToString("c"));
            Console.WriteLine();
        }
    }
}
