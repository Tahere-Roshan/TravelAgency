using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Model;

namespace TravelAgency.Handler
{
    public class EmployeeHandler
    {
        //Read Employee Table
        public List<Employee> GetAllEmployee()
        {
            List<Employee> allEmployee = new List<Employee>();
            using (TourContext db = new TourContext())
            {
                allEmployee = db.Employee.ToList();
                return allEmployee;

            }
        }

        //Update Employee Table
        public void AddEmployee(Employee employee)
        {
            using (TourContext db = new TourContext())
            {
                db.Employee.Add(employee);
                db.SaveChanges();
            }

        }


        //Read and Display Employee Table
        public void DisplayEmployee()
        {
            List<Employee> employeelist = GetAllEmployee();
            foreach (var item in GetAllEmployee())
            {
                Console.WriteLine(item.Id + "   " + item.Name);

            }
        }

        //Create new Employee
        public void Addition()
        {
            Employee newEmployee = new Employee();
            Console.WriteLine("Input the new Employee Name:");
            newEmployee.Name = Console.ReadLine();
            AddEmployee(newEmployee);
            DisplayEmployee();

        }


        //Read Customer list  of one employee: one to Many Relatioh

        public List<Customer> GetCustomerList()  {
            using (TourContext db = new TourContext())
            {
                var allcustomer = db.Customers.Include(b => b.Employee).ToList();
                return allcustomer;
            }

        }
        public void DisplayCustomerList()
        {
            List<Customer> customerlistemployee = GetCustomerList();
            Employee employee = new Employee();
            foreach (var customer in customerlistemployee)
            {
                Console.WriteLine("Eployee Id:" + " " + customer.EmployeeId + "" + "Customer Name:" + " " + customer.Name);
            }
        }




        public void delCustomer(int employeId)
        {

            List<Customer> dCustomer = GetCustomerList();
            using (TourContext db = new TourContext())
            {
                var demployeeId = db.Customers.FirstOrDefault(x => x.EmployeeId == employeId);


                foreach (var cust in dCustomer)
                {

                    db.Customers.Remove(cust);
                    db.SaveChanges();

                }
                DisplayEmployee();
                DisplayCustomerList();

            }

        }

        public void updateCustomer(int customID)
        {

            using(TourContext db=new TourContext())
            {
                var customer=db.Customers.FirstOrDefault(x=>x.Id==customID);
                Console.WriteLine("Input the Employee Id to change:");
                int newEmId = Convert.ToInt32(Console.ReadLine());
                customer.EmployeeId=newEmId;
                db.SaveChanges();
              }

        }
    }
}
