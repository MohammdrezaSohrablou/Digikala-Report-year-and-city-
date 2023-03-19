using finaldigikala.Model;
using finaldigikala.DigikalaOperations;
using System;
using finaldigikala.Operations.CitesAndYearsInfo;


internal class Program
{
    private static void Main(string[] args)
    {
        //Variables
        string address = @"D:\orders.csv";
        int Year;
        int Cid;
        int Iid;
        int Oid;
        string city;
        string key;
        string key1;
        string key2;
        bool a;
        bool b;
        bool c;
        //Using classes
        GetDataContext context = new GetDataContext(address);
        DigikalaOperations op = new DigikalaOperations(context.Digikaladata);
        CitesAndYearsInfo output = new CitesAndYearsInfo();
        //Display
        do
        {
            Console.WriteLine("- Digikala Sales Report -");
            Console.WriteLine("enter your choice :");
            Console.WriteLine("1.search by customerID , orderID and itemID :");
            Console.WriteLine("2.total sales search by cities , years and item :");
            Console.WriteLine("3.output all of the cities information in a CSV file :");
            Console.WriteLine("4.output all of the years information in a CSV file");
            Console.WriteLine("5.* press space to exit * ");
            do
            {
                LkForNumAndInput();
            } while (a);

            if (key == "1")
            {   
                Console.WriteLine("search by ...");
                Console.WriteLine("1.customerID - 2.orderID - 3.itemID :");
                Search();
            }
            else if (key == "2")
            {
                Console.WriteLine("total sales search by ...");
                Console.WriteLine("1. cities - 2. years - 3. item :");
                TotalSalesSearch();
            }
            else if(key == "3")
            {
                Console.WriteLine("are you sure to start the process ? y/n");
                do
                {
                    key2 = Console.ReadKey(true).KeyChar.ToString();
                    if (key2.ToLower() == "y" || key2.ToLower() == "n")
                    {
                        c = false;
                    }
                    else
                    {
                        c = true;
                    }
                } while (c);  
                if (key2.ToLower() == "y")
                {
                    Console.WriteLine("processing ...");
                    output.CityReport(address);
                    Console.WriteLine("done!");
                }
                else if (key2.ToLower() == "n")
                {
                    break;
                }

            }
            //!
            else if (key == "4")
            {
                Console.WriteLine("are you sure to start the process ? y/n");
                do
                {
                    key2 = Console.ReadKey(true).KeyChar.ToString();
                    if (key2.ToLower() == "y" || key2.ToLower() == "n")
                    {
                        c = false;
                    }
                    else
                    {
                        c = true;
                    }
                } while (c);
                if (key2.ToLower() == "y")
                {
                    Console.WriteLine("processing ...");
                    output.YearsReport(address);
                    Console.WriteLine("done!");
                }
                else if (key2.ToLower() == "n")
                {
                    break;
                }

            }
            else if (key == " ")
            {
                break;
            }
        } while (true);
        Console.WriteLine("Good Luck !");
        
        void Search()
        {
            do
            {
                key1 = Console.ReadKey(true).KeyChar.ToString();
                if (key1 == "1" || key1 == "2" || key1 == "3")
                {
                    b = false;
                }
                else
                {
                    b = true;
                }
            } while (b);
            //!
            if (key1 == "1")
            {
                Console.WriteLine("enter customerID :");
                Cid = int.Parse(Console.ReadLine());
                Console.WriteLine($"the first order for {Cid} are {op.CustomerSearch(Cid)}");
                Console.WriteLine(" ");

            }
            else if (key1 == "2")//!
            {
                Console.WriteLine("enter orderID :");
                Oid = int.Parse(Console.ReadLine());
                Console.WriteLine($"orders for {Oid} are {op.OrderSearch(Oid)}");
                Console.WriteLine(" ");
            }
            else if (key1 == "3")//!
            {
                Console.WriteLine("enter itemID :");
                Iid = int.Parse(Console.ReadLine());
                Console.WriteLine($"orders for {Iid} are {op.ItemSearch(Iid)}");
                Console.WriteLine(" ");
            }
        }
        void TotalSalesSearch()
        {
            do
            {
                key1 = Console.ReadKey(true).KeyChar.ToString();
                if (key1 == "1" || key1 == "2" || key1 == "3")
                {
                    b = false;
                }
                else
                {
                    b = true;
                }
            } while (b);
            
            if (key1 == "1")
            {
                Console.WriteLine("enter the cityname: ");
                city = Console.ReadLine();
                Console.WriteLine($"total sales for {city} is {op.SumSalesByCities(city)} IR Rials");
                Console.WriteLine(" ");
            }
            else if (key1 == "2")
            {
                Console.WriteLine("enter the year :");
                Year = int.Parse(Console.ReadLine());
                Console.WriteLine($"total sales for {Year} is {op.SumSalesByYear(Year)} IR Rials ");
                Console.WriteLine(" ");
            }
            else if (key1 == "3")
            {
                Console.WriteLine("enter the itemID :");
                Iid = int.Parse(Console.ReadLine());
                Console.WriteLine($"total sales for {Iid} is {op.SumSalesByItem(Iid)} IR Rials");
                Console.WriteLine(" ");
            }
        }
        void LkForNumAndInput()
        {
            key = Console.ReadKey(true).KeyChar.ToString();
            if (key == "1" || key == "2" || key == "3" || key == "4" || key == " ")
            {
                Console.WriteLine("----------------------------------------------------");
                a = false;
            }
            else
            {
                a = true;
                //Console.WriteLine("invalid number ! please enter 1 to 4 or press space to exit. :");
            }
        }
        
        
    }
}



