using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public abstract class Product
    {
        public Product(int slot = 0, string info = "Noname", int cost = 0)
        {
            Slot = slot;
            Info = info;
            Cost = cost;
        }

        public virtual void Examine()
        {
            Console.WriteLine("Oops! This product is not implemented.");
        }

        public virtual void Use()
        {
            Console.WriteLine("Oops! No use defined for this product.");
        }


        public int Slot { get; set; }
        public string Info { get; set; }
        public int Cost { get; set; }
        public static int moneyPool { get; set; }
        public string exchangeMoney { get; set; }


        public void Inventory(int choice)
        {

            Product snickers = new Candy(1, "Snickers", 15);
            Product smakis = new Drink(2, "Smakis", 8);
            Product sandwich = new Food(3, "Sandwich", 22);
            Product pepsi = new Drink(4, "Pepsi", 12);
            Product mars = new Candy(5, "Mars bar", 12);
            Product nonstop = new Candy(6, "Nonstop ", 24);
            Product caviar = new Food(7, "Caviar ", 235);

            Product[] ourProducts = new Product[7];  //The products are stored in this collection
            ourProducts[0] = snickers;
            ourProducts[1] = smakis;
            ourProducts[2] = sandwich;
            ourProducts[3] = pepsi;
            ourProducts[4] = mars;
            ourProducts[5] = nonstop;
            ourProducts[6] = caviar;


            
            if (choice == 0)  //Showing the inventory
            {

                Console.WriteLine("****** The Vending machine ******" +
                    "\n********** Inventory ************\n");

                foreach (Product p in ourProducts)
                {
                    p.Examine();
                }

                Console.WriteLine("\n*********************************" + 
                    "\n***** You have added " + moneyPool + " SEK ******\n");

            }

            else  //Buying from the inventory
            {
                string productName = ourProducts[choice -1].Info;
                int productCost = ourProducts[choice -1].Cost;
                int checkMoney = moneyPool;

                if (CanBuy(checkMoney, productCost) == 1) 
                {
                    moneyPool -= productCost;
                    Console.Clear();
                    Console.WriteLine("\nYou just bought one " + productName + "!\n");

                    ourProducts[choice - 1].Use();

                    Console.WriteLine("\nPress ENTER to continue");
                    Console.ReadLine();
                }
                
                else //An error message if the user doesn't have enough money to buy the product
                {
                    Console.Clear();
                    Console.WriteLine("\nNot enough money to buy a " + productName + "!\n" +
                        "\nAdd some more money or choose another product!\n" +
                        "\nPress ENTER to continue.");
                    Console.ReadLine();
                }
            }
        }

        public int CanBuy(int checkMoney, int productCost) //Checking if the user has the money to buy a product
        {
            if (checkMoney >= productCost)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}

