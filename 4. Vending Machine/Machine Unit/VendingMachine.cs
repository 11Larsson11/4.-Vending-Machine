using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public class VendingMachine : IVending
    {

        public static int MoneyPool { get; set; }
        public string ExchangeMoney { get; set; }

        public static void PowerOn()
        {
            bool running = true;

            while (running)
            {
                running = VendingMenu();
            }
        }

        public static bool VendingMenu()
        {
            VendingMachine start = new VendingMachine();    //Instantiating an object of the type VendingMachine

            Console.Clear();
            start.ShowAll();

            switch (Console.ReadLine())
            {
                case "1":
                    start.Purchase(0, MoneyPool);
                    return true;

                case "2":
                    start.Purchase(1, MoneyPool);
                    return true;

                case "3":
                    start.Purchase(2, MoneyPool);
                    return true;

                case "4":
                    start.Purchase(3, MoneyPool);
                    return true;

                case "5":
                    start.Purchase(4, MoneyPool);
                    return true;

                case "6":
                    start.Purchase(5, MoneyPool);
                    return true;

                case "7":
                    start.Purchase(6, MoneyPool);
                    return true;

                case "8":
                    start.InsertMoney();
                    return true;

                case "9":
                    start.EndTransaction();
                    return true;

                case "0":
                    return false;

                default:
                    return true;

            }
        }

        public void InsertMoney()  //Implementing IVending InsertMoney
        {

            Console.WriteLine("\nInsert money (Only valid SEK denominations):");
            Console.Write(">");
            string userInput = Console.ReadLine();

            int moneyIn;
            int.TryParse(userInput, out moneyIn);

            if (CheckValid(moneyIn) == false)
            {
                Console.Clear();
                Console.WriteLine("Not a valid denomination in SEK.");
                Console.WriteLine("\nYou can try either: 1,2,5,10,20,50,100,200,500 or 1000.\n" +
                    "\nPress ENTER to return to main menu.");
                Console.ReadLine();
                //VendingMenu();
            }

            else

            {
                MoneyPool += moneyIn;
                //VendingMenu();
            }

            VendingMenu();
        }

        public bool CheckValid(int moneyIn)  //A method for testing if the input money is of a valid denomination
        {
            int[] validMoney = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
            ReadOnlyCollection<int> readOnlyValidMoney = Array.AsReadOnly(validMoney);

            if (readOnlyValidMoney.Contains(moneyIn))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void ShowAll()  //Implementing IVending ShowAll
        {

            Console.WriteLine("****** The Vending machine ******");
            Console.WriteLine("********** Inventory ************\n");

            Inventory show = new Inventory();   //Displaying all products in the inventory
            show.AllProducts();

            Console.WriteLine("\n*********************************");
            Console.WriteLine("       Inserted money: " + MoneyPool);
            Console.WriteLine("\n*********** Your Choice *********");
            Console.WriteLine("\n       8 - Insert money");
            Console.WriteLine("       9 - Eject money");
            Console.WriteLine("       0 - Close and walk away");
            Console.Write(">");

        }

        public void Purchase(int chosenProduct, int poolMoney)   //Implementing IVending Purchase
        {

            Inventory make = new Inventory();
            make.PurchaseOne(chosenProduct, poolMoney);    //Make a purchase from the inventory

        }


        public void EndTransaction()   //Implementing IVending EndTransaction
        {

            int allChange = MoneyPool;

            ChangeCounter(allChange);

            Console.Clear();
            Console.WriteLine("Thanks for buying from the Vending machine.\n" +
                allChange + " SEK change is returned in the tray.\n" +
                "\nThe change is divided into: \n" + ExchangeMoney);

            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();


        }


        public int ChangeCounter(int allChange) //Dividing the change in appropriate notes and coins.
        {
            while (MoneyPool >= 1000)
            {
                MoneyPool -= 1000;
                ExchangeMoney += "\nA thousand crown note.";
            }

            while (MoneyPool >= 500)
            {
                MoneyPool -= 500;
                ExchangeMoney += "\nA five hundred crown note.";
            }

            while (MoneyPool >= 200)
            {
                MoneyPool -= 200;
                ExchangeMoney += "\nA two hundred crown note.";
            }

            while (MoneyPool >= 100)
            {
                MoneyPool -= 100;
                ExchangeMoney += "\nA hundred crown note.";
            }

            while (MoneyPool >= 50)
            {
                MoneyPool -= 50;
                ExchangeMoney += "\nA fifty crown note.";
            }

            while (MoneyPool >= 20)
            {
                MoneyPool -= 20;
                ExchangeMoney += "\nA twenty crown note.";
            }

            while (MoneyPool >= 10)
            {
                MoneyPool -= 10;
                ExchangeMoney += "\nA ten crown coin.";
            }

            while (MoneyPool >= 5)
            {
                MoneyPool -= 5;
                ExchangeMoney += "\nA five crown coin.";
            }

            while (MoneyPool >= 2)
            {
                MoneyPool -= 2;
                ExchangeMoney += "\nA two crown coin.";
            }

            while (MoneyPool >= 1)
            {
                MoneyPool -= 1;
                ExchangeMoney += "\nA one crown coin.";
            }

            int noChange = MoneyPool;
            return noChange;    //Returning the end result to test if the calculation is correct

        }
    }
}

