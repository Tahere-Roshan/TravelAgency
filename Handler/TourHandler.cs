using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TravelAgency.Model;

namespace TravelAgency.Handler
{
    public class TourHandler
    {

        // Only for Tour Table
        public List<Tour> GetAllTour()//Show Tour List
        {
            List<Tour> allTours = new List<Tour>();
            using (TourContext db = new TourContext())
            {
                allTours = db.Tours.ToList();
                return allTours;

            }
        }

        public void AddTour(Tour tour)
        {
            using (TourContext db = new TourContext())
            {
                db.Tours.Add(tour);
                db.SaveChanges();
            }

        }

        public void DeleteTour(Tour tour)
        {
            using (TourContext db = new TourContext())
            {
                db.Tours.Remove(tour);
                db.SaveChanges();
            }
        }


        public void DisplayTour()
        {
            List<Tour> TourList = GetAllTour();
            foreach (var item in GetAllTour())
            {
                Console.WriteLine(item.Id + "   " + item.Description);

            }
        }

        public void Addition()
        {
            Tour newTour = new Tour();
            Console.WriteLine("Input the new Tour");
            newTour.Description = Console.ReadLine();
            newTour.Date = DateTime.Now.ToString();
            AddTour(newTour);
            DisplayTour();

        }

        public void RemoveTour()
        {
            Tour rTour = new Tour();
            Console.WriteLine("Input Tour Id to remove:");
            rTour.Id = Convert.ToInt32(Console.ReadLine());
            DeleteTour(rTour);
            DisplayTour();
        }




        /// <summary>
        /// /////////////////////////////////////////////
        /// //For Many-to-Many relationship (Tour-Customer)
        /// </summary>


        /* public List<Tour> ReadTour()//Read TourList with its customer
        {
            using (TourContext db = new TourContext())
            {
                var allTours = db.Tours.Include(b => b.Reservations).ThenInclude(d => d.Customer).ToList();
                return allTours;
            }
        }*/

        public void CreateTour(Tour ctour, int customerID)
        {
            using (TourContext db = new TourContext())
            {
                Customer customer = db.Customers.Where(c => c.Id == customerID).FirstOrDefault();
                if (customer != null)
                {
                    db.Tours.Add(ctour);
                    db.SaveChanges();

                    Reservations reservations = new Reservations();
                    reservations.CustomerId = customer.Id;
                    reservations.TourID = ctour.Id;
                    db.Reservations.Add(reservations);
                    db.SaveChanges();
                }
                else
                    Console.WriteLine("There is no Reservation.");

            }

        }



        public void AddTourCustomer(string TourName, string CustomerName)
        {
            using (TourContext db = new TourContext())
            {
                Customer customer = db.Customers.Where(c => c.Name == CustomerName).FirstOrDefault();
                if (customer != null)
                {
           
                    Reservations reservations = new Reservations();

                    var tourentity = db.Tours.Where(t=>t.Description==TourName).FirstOrDefault();
                    
                    reservations.CustomerId = customer.Id;
                    reservations.TourID = tourentity.Id;
                    db.Reservations.Add(reservations);
                    db.SaveChanges();
                }
                else
                    Console.WriteLine("There is no Reservation.");

            }

        }

        //Raad and Display the Tour Table with their customer
        public void ListTour()
        {
            using (TourContext db = new TourContext())
            {
                var tourlist = db.Tours.Include(x => x.Reservations).ThenInclude(d => d.Customer);


                foreach (var tour in tourlist)
                {
                    string customername = "";
                    foreach (var reservation in tour.Reservations)
                    {

                        customername += reservation.Customer.Name;
                    }
                    Console.WriteLine("Tour:" + " " + tour.Description + " " + "Customer:" + " " + customername);
                }
            }
        }

        //Update the cu
       /* public void updateTour()
        {
            //Tour newtour= new Tour();
            DisplayTour();
            Console.WriteLine("Enter Tour Description:");
            int tourId = Convert.ToInt32(Console.ReadLine());
            //CreateTour(tourId);
        }*/


        //Remove one tour with its customer
        public void deletion(int tourID)
        {
            using (TourContext db = new TourContext())
            {
                // Reservations reservations = new Reservations();
                // var customerlist = db.Customers.Include(x => x.Reservations).ThenInclude(y => y.Tour);//match customers and tours
                Tour aTour = new Tour();
                aTour.Id = tourID;
                var dtourId = db.Tours.Include(x=>x.Reservations).FirstOrDefault(y=>y.Id==tourID);
          
                db.Tours.Remove(dtourId);
                db.SaveChanges();
                

            }
            DisplayTour();
            ListTour();

        }

        //remove one customer from one tour


        
    }
}


