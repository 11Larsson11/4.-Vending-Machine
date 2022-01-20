using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public class Inventory
    {

        public static Candy product1 = new Candy(1, "Snickers", 15, 487);
        public static Candy product2 = new Candy(2, "Mars bar", 12, 449);
        public static Candy product3 = new Candy(3, "Nonstop ", 24, 480);
        public static Drink product4 = new Drink(4, "Smakis", 8, 22);
        public static Drink product5 = new Drink(5, "Pepsi", 12, 44);
        public static Food product6 = new Food(6, "Sandwich", 22, 252);
        public static Food product7 = new Food(7, "Caviar ", 235, 270);

        private List<Product> existingProducts = new List<Product>()   //A list of all existing products in the vending machine

            { product1,
            product2,
            product3,
            product4,
            product5,
            product6,
            product7
            };

        public void AllProducts()   //Display all products
        {
            foreach (Product p in existingProducts)
            {
                p.Examine();
            }
        }

        public void PurchaseOne(int choice, int tempPool)
        {
            Console.WriteLine("The product costs: " + existingProducts[choice].Cost);

            string productName = existingProducts[choice].Info;
            int productCost = existingProducts[choice].Cost;
            double exerciseTime = existingProducts[choice].MinutesToBurnCalories();

            if (CanBuy(tempPool, productCost) == true)
            {
                VendingMachine.MoneyPool -= productCost;
                Console.Clear();
                Console.WriteLine("\nYou just bought one " + productName + "!\n");

                Console.WriteLine("\nIf you sit still, it will take exactly " + exerciseTime + " minutes to burn the calories it contain.\n");


                existingProducts[choice].Use();

            }


            else //An error message if the user doesn't have enough money to buy the product
            {
                Console.Clear();
                Console.WriteLine("\nNot enough money to buy a " + productName + "!\n" +
                    "\nAdd some more money or choose another product!\n");
                //"\nPress ENTER to continue.");
                //Console.ReadLine();
                //VendingMachine.VendingMenu();
            }


            Console.WriteLine("\nPress ENTER to continue");
            Console.ReadLine();

        }

        public bool CanBuy(int checkMoney, int productCost) //Checking if the user has the money to buy a product
        {
            if (checkMoney >= productCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
