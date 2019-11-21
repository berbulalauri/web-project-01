using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace tutorial_01
{
    class Program
    {
        public static int prodId { get; set; }
        public static int prodCount { get; set; }
        public static Dictionary<int, (int, string, decimal)> dict = new Dictionary<int, (int, string, decimal)>();
        static void Main(string[] args)
        {
            dict.Add(1, (50, "Portable Blender – Blendjet One", 310));
            dict.Add(2, (50, "Spider Nail Gel", 320));
            dict.Add(3, (50, "Wireless Phone Chargers", 330));
            dict.Add(4, (50, "Face Shield", 340));
            dict.Add(5, (50, "Phone Lenses", 350));
            dict.Add(6, (50, "Inflatable Pet Collars", 360));
            dict.Add(7, (50, "Eyeshadow Stamp", 370));
            dict.Add(8, (50, "Strapless Backless Bra", 380));
            dict.Add(9, (50, "Child Wrist Leash", 390));
            dict.Add(10, (50, "Front Facing Baby Carrier", 310));
            dict.Add(11, (50, "Car Phone Holder", 311));
            dict.Add(12, (50, "Home Security IP Camera", 312));
            dict.Add(13, (50, "Wifi Repeater", 313));
            dict.Add(14, (50, "Drone Camera", 314));
            dict.Add(15, (50, "Posture Corrector", 315));
            dict.Add(16, (50, "Electric Soldering Iron Gun", 316));
            dict.Add(17, (50, "Pump Wedge Locksmith", 317));
            dict.Add(18, (50, "Bohemian Earrings", 318));
            dict.Add(19, (50, "Manicure Milling Drill Bit", 319));
            dict.Add(20, (50, "Flexible Garden Hose", 320));
            dict.Add(21, (50, "One Piece Swimsuit", 321));
            dict.Add(22, (50, "Fly Fishing Quick Knot Tool", 322));


            Console.WriteLine("Welcome to Maryna's Shop!");
            Console.WriteLine("Select the product:");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} {item.Value.Item2}");
            }
            Console.WriteLine();

            Console.Write("Your choice:");
            int.TryParse(Console.ReadLine(), out int porductIdSel);
            prodId = porductIdSel;
            while (prodId > 22 || prodId < 0)
            {
                Console.Write("Please Choose corect product:");
                int.TryParse(Console.ReadLine(), out porductIdSel);
                prodId = porductIdSel;
            }
            Console.WriteLine();

            Console.Write("How much? ");
            int.TryParse(Console.ReadLine(), out int productCount);
            prodCount = productCount;
            while (prodCount > dict[prodId].Item1)
            {
                Console.Write($"Incorect amount. please choose less than {dict[prodId].Item1}\n");
                Console.Write("How much do you want? ");
                int.TryParse(Console.ReadLine(), out productCount);
                prodCount = productCount;

            }
            Console.WriteLine();

            Customer.CustomerNameClass(222, "maryna makhukina");

            Thread thread = new Thread(ThreadReceiptCaller);
            thread.IsBackground = true;
            thread.Start();

            ThreadInvoiceCaller();

            Console.WriteLine("Buying...");
            Console.WriteLine("Invoice was created.");
            Console.WriteLine("Receipt was created.");
            Console.WriteLine("Thank you for purchase!");

        }
        static void ThreadReceiptCaller()
        {
            Thread.Sleep(800);
            Product.PrintingReceiptClass(prodId, dict[prodId].Item2, dict[prodId].Item3, prodCount);
        }
        static void ThreadInvoiceCaller()
        {
            Thread.Sleep(800);
            Product.PrintingInvoiceClass(prodId);
        }

    }
    class Customer
    {
    public static int CustomerId { get; set; }
    public static string FullName {get;set;}
        public static void CustomerNameClass(int customerId, string fullName)
        {
            CustomerId = customerId;
            FullName = fullName;
        }
    }
    class Product: Customer
    { 
    public static int ProductId { get; set; }
    public static string ProductName { get; set; }
    public static decimal Price { get; set; }

        public static void PrintingReceiptClass(int productId,string productName, decimal price, int Count)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;

        string subPath = $"../../../receipt.txt";
            string textToAdd = $"Bill to:\n{FullName} | {CustomerId}\nProduct list:\n{ProductId} | {ProductName} | {Price} | {Count}\nTotal price: {Price*Count}\n";

            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine(textToAdd);
            Console.WriteLine("-------------------------------------------------------------");

            using (StreamWriter writer = new StreamWriter(subPath, true)){writer.Write(textToAdd);}
            }
        public static void PrintingInvoiceClass(int ProductId)
        {
            string InvoiceText = $"The number of products With ID: {ProductId} has been decreased";
            string subPath = $"../../../invoice.txt";
            using (StreamWriter writer = new StreamWriter(subPath, true)){writer.Write(InvoiceText);}

            Console.WriteLine(InvoiceText);
        }
    }

}

