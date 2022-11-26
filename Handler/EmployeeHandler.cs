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

        //Update Employee Table - Add Employee
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
            using (TourContext db = new TourContext())
            {
                //Employee employee = new Employee();
                foreach (var customer in GetCustomerList())
                {
                    Employee employee = db.Employee.Find(customer.EmployeeId);
                    Console.WriteLine(customer.EmployeeId + "-" + employee.Name + "," + "Customer Name:" + " " + customer.Name);
                }
            }
        }



        //reference-https://stackoverflow.com/questions/2519866/how-do-i-delete-multiple-rows-in-entity-framework-without-foreach
        //Delete list of customers by the same employeeID (by input one employee ID)
        public void delCustomer(int employeId)
        {

            using (TourContext db = new TourContext())
            {

                db.Customers.RemoveRange(db.Customers.Where(x => x.EmployeeId == employeId));
                db.SaveChanges();
                DisplayEmployee();
                DisplayCustomerList();
            }

        }



        //update 1M relationship
        public void updateCustomer(int customID)
        {

            using(TourContext db=new TourContext())
            {
                
                var customer = db.Customers.Include(x => x.Employee).FirstOrDefault(y => y.Id == customID);
                Employee employee = db.Employee.Find(customer.EmployeeId);
                Console.WriteLine("Customer Name:"+"   "+customer.Name+"  "+"Employee Name:"+" "+ employee.Name);
                Console.WriteLine("Input the Employee Id to change:");
                int newEmId = Convert.ToInt32(Console.ReadLine());
                customer.EmployeeId=newEmId;
                db.SaveChanges();
              }

        }
    }
}
