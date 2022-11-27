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
                        TourHandler tourHandler= new TourHandler();
                        tourHandler.Addition();

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
  
      
        
        //Read and Display from Customer Table with their Reservation
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

        //Update the Customer Table by adding new one
        public void DisplayCustomer()
        {
            Console.WriteLine("Input the new Customer Name");
            string name= newCustomer.Name = Console.ReadLine();
            Console.Write("National ID:");
            newCustomer.NationalID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Phone Number:");
            newCustomer.Phone = Convert.ToInt32(Console.ReadLine());
            Console.Write("Address");
            newCustomer.Address = Console.ReadLine();
            Console.WriteLine("Eployee Id:");
            newCustomer.EmployeeId= Convert.ToInt32(Console.ReadLine());
            Console.Write("Tour ID:");
            int tourId = Convert.ToInt32(Console.ReadLine());
            //string tourname= Console.ReadLine();
            AddCustomer(newCustomer, tourId); 
            //Console.WriteLine("Customer Name:"+ newCustomer.Name+" "+" Tour ID: "+tourId);

        }


        //update tour of one customer
        public void updateTour(string customName)
        {
            TourHandler tourHandler = new TourHandler();

            using (TourContext db = new TourContext())
            {
               
                var customId = db.Customers.FirstOrDefault(x => x.Name == customName);

                var uCustomer = db.Customers.Where(x => x.Name == customName).Include(x => x.Reservations).ThenInclude(x => x.Tour);

                if (null != uCustomer)
                {
                    string tourName = "";
                    int tourID = 0;
                    foreach (var ctour in uCustomer)
                    {
                        /*string tourName = "";
                        int tourID = 0;*/
                        foreach (var reservation in ctour.Reservations)
                        {
                            tourName += reservation.Tour.Description;
                            tourID += reservation.Tour.Id;
                            
                        }
                            
                        //Console.WriteLine(tourID+":"+tourName);
                        Console.WriteLine("" + tourName + ",");
                    }

                    Console.WriteLine("Input tour to add:");
                   
                    string tname = Console.ReadLine();
                    tourHandler.AddTourCustomer(tname, customName);
                    foreach (var ctour in uCustomer)
                    {
                        /*string tourName = "";
                        int tourID = 0;*/
                        foreach (var reservation in ctour.Reservations)
                        {
                            tourName += reservation.Tour.Description;
                            tourID += reservation.Tour.Id;
                        }

                        //Console.WriteLine(tourID + ":" + tourName);
                        Console.WriteLine("" + tourName + ",");
                    }

                }
                else
                {
                    Console.WriteLine("There is no Customer");
                    
                }
                db.SaveChanges();
            }

        }

        public void deletion(int CustomerId)
        {
            using (TourContext db = new TourContext())
            {
                
                Customer aCustomer = new Customer();
                aCustomer.Id = CustomerId;
                var dCustomerId = db.Customers.Include(x => x.Reservations).FirstOrDefault(y => y.Id == CustomerId);

                db.Customers.Remove(dCustomerId);
                db.SaveChanges();


            }
            ListCustomer();

        }



    }
}
