using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Validator
    {
       private static string title = "=============" + " \n\n Entry Error " + "\n\n==============";

        
                                
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        public static bool IsYORN (string input)
        {
            if (input == "y" || input =="n")
            {

                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(Title + "\n\nYou must choose y or n.");
                return false;
            }
        }

        public static bool IsPresent(string input)
        {
            if (input == "")
            {
                Console.Clear();
                Console.WriteLine(Title + "\n\nThe required field is mandatory");
                return false;
            }
            return true;
        }

        public static bool IsDecimal(string input)
        {
            decimal number = 0m;

            if (Decimal.TryParse(input, out number))
            {
                Console.Clear();
                
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(Title + "\n\nThe required field must be a decimal");
                return false;
            }



        }

        public static bool IsCode(string input)
        {
            if (input.Length >= 5)
            {
                Console.Clear();

                Console.WriteLine(Title  + "\n\nThe required Code field must only be 4 digits long");
                return false;
            }
            return true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            string code = "0000";
            string description = null;
            decimal price = 0m;
            string priceString = "";
            string author = "";
            bool validator = false;
            string addAnother = "";
            bool addAnotherBool = true;
            ProductList products = new ProductList();

            do
            {

           
            Console.WriteLine("Please enter the 4 digit Code for your book: ");
            code = Console.ReadLine();

            while (!validator)
            {


                if (!Validator.IsCode(code) || !Validator.IsPresent(code))
                {
                    Console.WriteLine("Please enter the 4 digit Code for your book: ");
                    code = Console.ReadLine();
                    //validator = false;
                    
                }
                else
                {
                        break;
                }


            }


            Console.WriteLine("Please enter a description for the book: ");
            description = Console.ReadLine();

            while (!validator)
            {


                if (!Validator.IsPresent(description))
                {
                    Console.WriteLine("Please enter a description for your book: ");
                    code = Console.ReadLine();
                    //validator = false;

                }
                else
                {
                    break;
                }


            }



            Console.WriteLine("Please enter the price for the book: ");
            priceString = Console.ReadLine();

            


            while (!validator)
            {


                if (!Validator.IsPresent(priceString) || !Validator.IsDecimal(priceString))
                {
                    Console.WriteLine("Please enter the price for your book: ");
                    priceString = Console.ReadLine();
                    //validator = false;

                }
                else
                {
                    price = Convert.ToDecimal(priceString);
                    break;
                }


            }

            Console.WriteLine("Please enter the Author's name: ");
            author = Console.ReadLine();

            while (!validator)
            {


                if (!Validator.IsPresent(author) )
                {
                    Console.WriteLine("Please enter the Author's name: ");
                    author = Console.ReadLine();
                    //validator = false;

                }
                else
                {
                    break;
                }


            }


            Book book1 = new Book(code,description,price,author);
            products.Add(book1);


            Console.Clear();

            Console.WriteLine("Congrats you've entered the follwoing book into our system: \n   Code: " + book1.Code + 
                " \n    Description: " + book1.Description +
                " \n    Author: " + book1.Author + 
                " \n    Price: "  + book1.Price.ToString("c" ));

            Console.ReadLine();

            Console.WriteLine("Would you like to enter another book to your list?");
            addAnother = Console.ReadLine();

            while (!validator)
            {
                if (Validator.IsYORN(addAnother))
                {

                        break;
                }
                else
                {
                    Console.WriteLine("Would you like to enter another book to the Product List?   y or no ");
                    addAnother = Console.ReadLine();
                    
                }

            }

            if (addAnother == "y")
            {
                addAnotherBool = true;
            }
            else
            {
                addAnotherBool = false;
            }

            } while (addAnotherBool);

            Console.Clear();
            Console.WriteLine("\n\nHere is your Product List you have created:\n\n");

            foreach(Book product in ProductList.products)
            {
                product.DisplayProductBookText();
            }

            Console.ReadLine();
        }

        
    }

    public class Product
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product() { }

        public Product(string code, string description, decimal price)
        {
            Code = code;
            Description = description;
            Price = price;

        }


    }

    public class Book : Product
    {
        public string Author { get; set; }

        public Book(string code, string description, decimal price, string author) : base (code,description,price)
        {
            Author = author;
        }

        public void DisplayProductBookText()
        {
            Console.WriteLine( "Code: " + Code + "" +
                "\nDescription: " + Description + 
                "\n Author: " +
                Author +
                "\nPrice: " + Price.ToString("c")+ "\n\n");

        }
    }

    public class Display : Product
    {

    }
    public class ProductList
    {
        public static List<Product> products;

        public ProductList()
        {
            products = new List<Product>();
        }

        public int Count => products.Count;

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Add(string code, string description, decimal price)
        {
            Product p = new Product(code, description, price);
            products.Add(p);
        }

        public Product GetProductByIndex(int i) => products[i];

        public void Remove(Product product)
        {
            products.Remove(product);
        }

        public void SortProducts()
        {
            products.Sort();
        }

    }
}
