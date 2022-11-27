
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

            bool finish=false;
            do
            {
                Console.WriteLine("Enter Option: 1- Tour,  2-Customer, 3- Employee");
                int Menue = Convert.ToInt32(Console.ReadLine());
                switch (Menue)
                {
                    case 1:
                        Console.WriteLine("Enter Option: 1- Create, 2-Read, 3-Update, 4-Remove");
                        int oneMenue= Convert.ToInt32(Console.ReadLine());
                        switch (oneMenue)
                        {
                            case 1:
                                MytourHandler.Addition();
                                break;
                            case 2:
                                MytourHandler.DisplayTour();
                                Console.WriteLine("/////////////////////////////////////");
                                MytourHandler.ListTour();
                                break;
                            case 3:
                                Console.WriteLine("Input Customer Name:");
                                string cName = Console.ReadLine();
                                MycustomerHandler.updateTour(cName);
                                break;
                            case 4:
                                Console.WriteLine("Input Tour Id to delete:");
                                int input = Convert.ToInt32(Console.ReadLine());
                                MytourHandler.deletion(input); 
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Option: 1- Create, 2-Read, 3-Update, 4-Remove");
                        int tMenue = Convert.ToInt32(Console.ReadLine());
                        switch (tMenue)
                        {
                            case 1:
                               MycustomerHandler.DisplayCustomer();
                                break;
                            case 2:
                                MycustomerHandler.ListCustomer();
                                break;
                                case 3:
                                Console.WriteLine("Input Customer Name:");
                                string cName=Console.ReadLine();
                                MycustomerHandler.updateTour(cName);
                                break;
                                case 4:
                                Console.WriteLine("Input Customer Id:");
                                int custId=Convert.ToInt32(Console.ReadLine());
                                MycustomerHandler.deletion(custId);
                                break;  
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Option: 1- Create, 2-Read, 3-Update, 4-Remove");
                        int eMenue = Convert.ToInt32(Console.ReadLine());
                        switch (eMenue)
                        {
                            case 1:
                                MyemployeeHandler.DisplayEmployee();
                                MyemployeeHandler.Addition();
                                break;
                            case 2:
                                MyemployeeHandler.DisplayCustomerList();
                                break;
                            case 3:
                                Console.WriteLine("Input Customer Id to change the employee:");
                                int cID = Convert.ToInt32(Console.ReadLine());
                                MyemployeeHandler.updateCustomer(cID);
                                break;
                            case 4:
                                Console.WriteLine("Input Employee Id:");
                                int eID = Convert.ToInt32(Console.ReadLine());
                                MyemployeeHandler.delCustomer(eID);
                                break;
                        }
                        break;

                }

                Console.WriteLine("Restart r/ Close c:");
                char option = Convert.ToChar(Console.ReadLine());
                if (option == 'r')
                    finish = false;
                if (option == 'c')
                    finish = true;

            } while(!finish);

            
        }



    }
}
