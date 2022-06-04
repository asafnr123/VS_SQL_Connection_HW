using Lesson_5_HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_HW
{
    internal class MyApp : IMyApp
    {

        public string GetUserEntity()
        {
            Console.WriteLine("Choose an entity:\n" +
                              "1) Customer\n" +
                              "2) Order\n");
            //Use later PrintAllEntities().Tostring();
            List<string> entitiesOptions = new List<string> { "1", "2" };
            string? userChoice = Console.ReadLine();

            while (!entitiesOptions.Contains(userChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ForegroundColor = ConsoleColor.White;
                userChoice = Console.ReadLine();
            }

            Console.WriteLine();
            return userChoice;

        }

        public void CreateEntity()
        {
            using (var Context = new StoreDataBase())
            {
                string userChoice = GetUserEntity();

                switch (userChoice)
                {
                    case "1":
                        Console.Write("Customer Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Customer Age: ");
                        int age = 0; //Default value
                        string tryParseInt = Console.ReadLine();
                        while (!int.TryParse(tryParseInt, out age))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please type a number");
                            Console.ForegroundColor = ConsoleColor.White;

                            tryParseInt = Console.ReadLine();
                            if (int.TryParse(tryParseInt, out age))
                                break;
                        }
                        if (name.Length > 1 && age > 0)
                        {
                            var customer = new Customer { Name = name, Age = age };
                            Context.Customer.Add(customer);
                            Context.SaveChanges();
                            Console.WriteLine("Successfully Created Customer to SQL Server\n");
                        }
                        break;

                    case "2":
                        Console.Write("Order Number: ");
                        int orderNumber = 0; //Default value
                        string tryParseInt2 = Console.ReadLine();
                        while (!int.TryParse(tryParseInt2, out orderNumber))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please type a number");
                            Console.ForegroundColor = ConsoleColor.White;

                            tryParseInt2 = Console.ReadLine();
                            if (int.TryParse(tryParseInt2, out orderNumber))
                                break;
                        }
                        Console.WriteLine();
                        Console.Write("Country: ");
                        string country = Console.ReadLine();

                        if (orderNumber > 0 && country.Length > 1)
                        {
                            var order = new Order { OrderNumber = orderNumber, Country = country };
                            Context.Order.Add(order);
                            Context.SaveChanges();
                            Console.WriteLine("Successfully Created Order to SQL Server\n");
                        }
                        break;
                }
            }
        }

        public void DeleteEntity()
        {
            using (var context = new StoreDataBase())
            {
                string userEntity = GetUserEntity();
                
                switch (userEntity)
                {
                    case "1":
                        context.Customer.Remove(context.Customer.ToList().ElementAt(GetElementId()));
                        context.SaveChanges();
                        Console.WriteLine("Successfully deleted customer\n");
                        break;
                    case "2":
                        context.Order.Remove(context.Order.ToList().ElementAt(GetElementId()));
                        context.SaveChanges();
                        Console.WriteLine("Successfully deleted order\n");
                        break;
                }
            }
        }

        public void PrintAllEntities()
        {
            using (var context = new StoreDataBase())
            {
                string userEntity = GetUserEntity();

                switch (userEntity)
                {
                    case "1":
                        var customer = context.Customer.ToList();
                        foreach (var cu in customer)
                        {
                            Console.WriteLine($"Name: {cu.Name}\nAge: {cu.Age}\n");
                        }
                        break;
                    case "2":
                        var order = context.Order.ToList();
                        foreach (var ord in order)
                        {
                            Console.WriteLine($"Order Number: {ord.OrderNumber}\nCountry: {ord.Country}\n");
                        }
                        break;
                }
            }
        }

        public void GetEntityDetails()
        {
            using (var context = new StoreDataBase())
            {
                string userEntity = GetUserEntity();

                switch (userEntity)
                {
                    case "1":
                        var customer = context.Customer.ToList().ElementAt(GetElementId());
                        Console.WriteLine($"Name: {customer.Name}\nAge: {customer.Age}\n");
                        break;
                    case "2":
                        var order = context.Order.ToList().ElementAt(GetElementId());
                        Console.WriteLine($"Order Number: {order.OrderNumber}\nCountry: {order.Country}\n");
                        break;
                }
                
            }
        }

        public string GetUserOption()
        {
            Console.WriteLine("What you like to do: ");
            string? userChoice = Console.ReadLine();
            Console.WriteLine();
            string[] menuOptios = new string[] { "1", "2", "3", "4", "5", "6" };
            while (!menuOptios.Contains(userChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ForegroundColor = ConsoleColor.White;
                userChoice = Console.ReadLine();
            }
            return userChoice;
        }

        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***Main Menu***");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Create An Entity\n" +
                              "2) Get Entity Details\n" +
                              "3) Update Entity\n" +
                              "4) Delete Entity\n" +
                              "5) Get All Entities Details\n" +
                              "6) Exite\n");
        }

        public void UpdateEntityDetails()
        {
            using (var context = new StoreDataBase())
            {
                string userEntity = GetUserEntity();
                switch (userEntity)
                {
                    case "1":
                        var customer = context.Customer.ToList().ElementAt(GetElementId());
                        Console.Write("Change customer name: ");
                        customer.Name = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Change customer age: ");
                        int age = 0; //Default value
                        string tryParseAge = Console.ReadLine();

                        while (!int.TryParse(tryParseAge, out age))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please type a number");
                            Console.ForegroundColor = ConsoleColor.White;
                            tryParseAge = Console.ReadLine();
                        }

                        customer.Age = age;
                        context.SaveChanges();
                        Console.WriteLine("Successfully changed customer");
                        break;

                    case "2":
                        var order = context.Order.ToList().ElementAt(GetElementId());
                        Console.Write("Change order number: ");
                        int orderNumber = 0;
                        string tryParseOrder = Console.ReadLine();
                        while (!int.TryParse(tryParseOrder, out orderNumber))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please type a number");
                            Console.ForegroundColor = ConsoleColor.White;
                            tryParseOrder = Console.ReadLine();
                        }
                        order.OrderNumber = orderNumber;
                        Console.WriteLine();
                        Console.Write("Change country: ");
                        order.Country = Console.ReadLine();
                        context.SaveChanges();
                        Console.WriteLine("Successfully changed order");
                        break;


                }
            }
        }

        public void UserChoice()
        {
            string userChoice = "";

            while (userChoice != "6")
            {
                userChoice = GetUserOption();
                switch (userChoice)
                {
                    case "1": CreateEntity(); break;
                    case "2": GetEntityDetails(); break;
                    case "3": UpdateEntityDetails(); break;
                    case "4": DeleteEntity(); break;
                    case "5": PrintAllEntities(); break;
                }
            }

            if (userChoice == "6")
                Console.WriteLine("GoodBye :)");
        }

        public int GetElementId()
        {
            int element = 0;

            Console.WriteLine("Choose Id:");
            string tryParseToElement = Console.ReadLine();

            while (!int.TryParse(tryParseToElement, out element))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                tryParseToElement = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return element - 1;

        }
    }
}
