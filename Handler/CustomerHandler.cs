using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace TravelAgency.Handler
{
    public class CustomerHandler
    {
        List<Tour> tourList = new List<Tour>();
        Customer newCustomer = new Customer();


        //Read Customers
        public List<Customer> GetAllCustomer()
        {
            using (TourContext db = new TourContext())
            {
                var allCustomers = db.Customers.Include(b => b.Reservations).ThenInclude(d => d.Tour).ToList();
                return allCustomers;
            }
        }



        //Create the Customer Table
        public void AddCustomer(Customer dCustomer, int tourId)
        {
            using (TourContext db = new TourContext())
            {
                Tour tour = db.Tours.Where(d => d.Id == tourId).FirstOrDefault();

                if (dCustomer.EmployeeId != null)
                {
                    if (tour != null)
                    {
                        db.Customers.Add(dCustomer);
                        db.SaveChanges();

                        Reservations reservations = new Reservations();
                        reservations.TourID = tour.Id;
                        reservations.CustomerId = dCustomer.Id;
                        db.Reservations.Add(reservations);
                        db.SaveChanges();
                    }
                    else
                    {
                        //add new tour
                    }

                }
                else
                {
                   /* var employeeID = db.Employee.Where(b => b.Id==employeeID);
                    if (employeeID != dCustomer.Id)
                    {
                        Console.WriteLine("Add new Employee");
                        //add Employee

                    }*/
                    if (tour != null)
                    {
                        
                        db.Customers.Add(dCustomer);
                        db.SaveChanges();

                        Reservations reservations = new Reservations();
                        reservations.TourID = tour.Id;
                        reservations.CustomerId = dCustomer.Id;
                        db.Reservations.Add(reservations);
                        db.SaveChanges();
                    }
                    else
                    {
                        //add Tour

                    }


                }
            }
        }
  
      
        
        //Read and Display from Customer Table
        public void ListCustomer()
        {
            using (TourContext db = new TourContext())
            {
                var CustomersList = db.Customers.Include(x => x.Reservations).ThenInclude(d=>d.Tour);
               

                foreach (var customer in CustomersList)
                {
                    string tourName = "";
                    foreach (var reservation in customer.Reservations)
                    {

                        tourName += reservation.Tour.Description;
                    }
                    Console.WriteLine("Customer:" +" "+ customer.Name +" "+ "Tour:"+" " + tourName);
                }
            }
        }

        //Update the Customer Table
        public void DisplayCustomer()
        {
            Console.WriteLine("Input the new Customer Name");
            string name= newCustomer.Name = Console.ReadLine();
            Console.Write("National ID:");
            /*newCustomer.NationalID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Phone Number:");
            newCustomer.Phone = Convert.ToInt32(Console.ReadLine());
            Console.Write("Address");
            newCustomer.Address = Console.ReadLine();*/
            Console.WriteLine("Eployee Id:");
            newCustomer.EmployeeId= Convert.ToInt32(Console.ReadLine());
            Console.Write("Tour ID:");
            int tourId = Convert.ToInt32(Console.ReadLine());
            //string tourname= Console.ReadLine();
            AddCustomer(newCustomer, tourId); 
            //Console.WriteLine("Customer Name:"+ newCustomer.Name+" "+" Tour ID: "+tourId);

        }

        public void CURD(int aOperation)
        {
            switch (aOperation)
            {
                case 0:
                    ListCustomer();//Read 
                    break;
                    case 1:
                    DisplayCustomer();//Update & Create
                    break;


            }
            


        }

        //public enum operations { Create, Update, Read, Delete }

        //Create / Wrtie 
        /* public Customer CURD(Customer customer, operations aOperation)
          {

              switch (aOperation)
              {
                  case operations.Create:
                    return  Create(customer);
                      break;
                  case operations.Update:
                      return Update  (customer);
                      break;
                  case operations.Read:
                      return Read(customer);
                      break;
                  case operations.Delete:
                      return Delete(customer);
                      break;
                  default:
                      break;
              }
              return new Customer();

          }

          private Customer Create(Customer aCustomer)
          {

              using (TourContext db = new TourContext())
              {
                  db.Customers.Add(aCustomer);
                  db.SaveChanges();
              }
              return aCustomer;
          }

          private Customer Update(Customer aCustomer)
          {
              Customer cus = Read(aCustomer);
              using (TourContext db = new TourContext())
              {
                  db.Entry(aCustomer).State = EntityState.Modified;
                  db.Customers.Update(cus);
                  db.SaveChanges();
              }
              return cus;
          }

          public Customer Read(Customer aCustomer)
          {
              using (TourContext db = new TourContext())
              {
                  var customer = db.Customers.Find(aCustomer.Id);
                  return customer;
              }
          }

          private Customer Delete(Customer aCustomer)
          {

              Customer cus = Read(aCustomer);
              using (TourContext db = new TourContext())
              {
                  db.Entry(cus).State = EntityState.Modified;
                  db.Customers.Remove(cus);
                  db.SaveChanges();
              }
              return aCustomer;
          }*/

        //Update

        //Remove / Delete 


    }
}
