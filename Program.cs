
using TravelAgency.Model;
using TravelAgency.Handler;

using System.Security.Cryptography.X509Certificates;

namespace TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //DB file path
            /*string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.ToString();
            path = path + Path.Combine(Path.DirectorySeparatorChar.ToString(), "TravelAgencyDB.db");
            Console.WriteLine(path);*/

            TourHandler MytourHandler = new TourHandler();
            CustomerHandler MycustomerHandler = new CustomerHandler();
            EmployeeHandler MyemployeeHandler= new EmployeeHandler();


            /* Console.WriteLine("Enter Option: 1- Tour,  2-Customer, 3- Employee");
             int Menue = Convert.ToInt32(Console.ReadLine());
             //Console.WriteLine("Enter to choose: 1- Create, 2-Read, 3-Update, 4-Remove");
             //int option = Convert.ToInt32(Console.ReadLine());
              switch(Menue)
             {
                 case 1:
                     MytourHandler.DisplayTour();
                     break;
                     case 2:
                     MycustomerHandler.DisplayCustomer();
                     break;
                     case 3:
                     MyemployeeHandler.DisplayEmployee(); 
                     break;

             }
 */

            ////// Menue of CRUD tables

            //MytourHandler.DisplayTour();
            //MytourHandler.Addition();
            //MycustomerHandler.AddCustomer();
            //MycustomerHandler.DisplayCustomer();
            //MycustomerHandler.ListCustomer();
            //MytourHandler.ListTour();
            //MyemployeeHandler.Addition();
            //MyemployeeHandler.DisplayCustomerList();
            /* Console.WriteLine("Input Tour Id to delete:");
             int input=Convert.ToInt32(Console.ReadLine());
             MytourHandler.deletion(input);*/

            /*Console.WriteLine("Input Employee Id to delete Customer:");
            int input=Convert.ToInt32(Console.ReadLine());
            MyemployeeHandler.delCustomer(input);*/

            Console.WriteLine("Write customer Id to update:");
            int customid = Convert.ToInt32(Console.ReadLine());
            MyemployeeHandler.updateCustomer(customid);











            //MycustomerHandler.CURD(t, CustomerHandler.operations.Create);

            //Console.WriteLine("Enter Customer ID to be deleted ");
            //string TourDesc = Console.ReadLine();
            //Console.ReadLine(); // it was not deleted because of the read line, now we run again the new id will 2 and we canc delete it its working 
            // Customer test = new Customer();
            //test.Id = int.Parse(TourDesc);
            //MycustomerHandler.CURD(test, CustomerHandler.operations.Delete);

            /*foreach (var tour in TourList)
            {
                Console.WriteLine(tour.Id + " " + tour.Description);
            }

            Console.WriteLine("Input the new Tour");
            string TourDesc = Console.ReadLine();

            Tour newTour= new Tour();
            new TourHandler().AddTour(newTour);*/



            /* Console.WriteLine("Input the new Customer Name, National-Id");
             string customerName = Console.ReadLine();
             int nashionalId = Convert.ToInt32(Console.ReadLine());*/


            /* Console.WriteLine("Input the tour id");
             var tourid = Convert.ToInt32(Console.ReadLine());

             Customer newcustomer = new Customer();
             newcustomer.Name = customerName;
             newcustomer.NationalID = nashionalId;
             newcustomer.TourId = tourid;

             List<Customer> customersList = MycustomerHandler.GetAllCustomer();
             foreach (var customer in customersList)
             {
                 Console.WriteLine(customer.Name + " " + customer.Tour.Description);
             }*/
        }



    }
}
