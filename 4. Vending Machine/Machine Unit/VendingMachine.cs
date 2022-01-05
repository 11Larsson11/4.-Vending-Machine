using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{

    public class VendingMachine : Product, IVending
    {
        public static void MachineMenu()
        {

            bool running = true;

            while (running)
            {
                running = VendingMenu();
            }
        }

        public static bool VendingMenu()
        {
            Console.Clear();

            VendingMachine newObject = new VendingMachine();
            newObject.ShowAll();    //Showing the inventory

            Console.WriteLine("8) Add money to the vending machine.");
            Console.WriteLine("9) Eject remaining money.");
            Console.Write("0) Close the app and walk away." +
                "\n>");

            switch (Console.ReadLine())
            {
                case "1":
                    VendingMachine buy1 = new VendingMachine();
                    buy1.Purchase(1);
                    return true;

                case "2":
                    VendingMachine buy2 = new VendingMachine();
                    buy2.Purchase(2);
                    return true;

                case "3":
                    VendingMachine buy3 = new VendingMachine();
                    buy3.Purchase(3);
                    return true;

                case "4":
                    VendingMachine buy4 = new VendingMachine();
                    buy4.Purchase(4);
                    return true;

                case "5":
                    VendingMachine buy5 = new VendingMachine();
                    buy5.Purchase(5);
                    return true;

                case "6":
                    VendingMachine buy6 = new VendingMachine();
                    buy6.Purchase(6);
                    return true;

                case "7":
                    VendingMachine buy7 = new VendingMachine();
                    buy7.Purchase(7);
                    return true;

                case "8":
                    VendingMachine insert = new VendingMachine();
                    insert.InsertMoney();
                    return true;

                case "9":
                    VendingMachine purchase = new VendingMachine();
                    purchase.EndTransaction();
                    return true;

                case "0":
                    return false;
                default:
                    return true;

            }
        }

        public void ShowAll()
        {
            VendingMachine newObjectx = new VendingMachine();
            newObjectx.Inventory(0);  //Taking the information from the Inventory to show all products
        }

        public void InsertMoney()
        {

                Console.WriteLine("\nInsert money (Only valid SEK denominations):");
                Console.Write(">");
                string userInput = Console.ReadLine();

                int moneyIn = CheckValid(userInput); //Using CheckValid to check if the user input is valid


                if (CheckValid(userInput) == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid denomination in SEK.");
                    Console.WriteLine("\nYou can try either: 1,2,5,10,20,50,100,200,500 or 1000.\n" +
                        "\nPress ENTER to return to main menu.");
                    Console.ReadLine();
                }

                else
                {
                    moneyPool += moneyIn;
                }
        }

        public void Purchase(int choice)
        {
            Inventory(choice); //Purchase a thing from the inventory
        }

        public void EndTransaction()
        {

            int allChange = moneyPool;
            
            ChangeCounter(allChange); //Dividing the change in appropriate bills and coins

            Console.Clear();
            Console.WriteLine("Thanks for buying from the Vending machine.\n" +
                allChange + " SEK change is returned in the tray.\n" +
                "\nThe change is divided into: \n" + exchangeMoney);

            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();


        }

        public int ChangeCounter(int allchange)
        {
            while (moneyPool >= 1000)  //Dividing the change in appropriate notes and coins.
            {
                moneyPool -= 1000;
                exchangeMoney += "\nA thousand crown note.";
            }

            while (moneyPool >= 500)
            {
                moneyPool -= 500;
                exchangeMoney += "\nA five hundred crown note.";
            }

            while (moneyPool >= 100)
            {
                moneyPool -= 100;
                exchangeMoney += "\nA hundred crown note.";
            }

            while (moneyPool >= 50)
            {
                moneyPool -= 50;
                exchangeMoney += "\nA fifty crown note.";
            }

            while (moneyPool >= 20)
            {
                moneyPool -= 20;
                exchangeMoney += "\nA twenty crown note.";
            }

            while (moneyPool >= 10)
            {
                moneyPool -= 10;
                exchangeMoney += "\nA ten crown coin.";
            }

            while (moneyPool >= 5)
            {
                moneyPool -= 5;
                exchangeMoney += "\nA five crown coin.";
            }

            while (moneyPool >= 2)
            {
                moneyPool -= 2;
                exchangeMoney += "\nA two crown coin.";
            }

            while (moneyPool >= 1)
            {
                moneyPool -= 1;
                exchangeMoney += "\nA one crown coin.";
            }

            int noChange = moneyPool;
            return noChange;    //Returning the end result to test if the calculation is correct

        }

        public int CheckValid(string userInput)  //A method for testing if the input money is of a valid denomination
        {
            int[] validMoney = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
            ReadOnlyCollection<int> readOnlyValidMoney = Array.AsReadOnly(validMoney);

            int moneyIn;
            int.TryParse(userInput, out moneyIn);

            if (readOnlyValidMoney.Contains(moneyIn))
            {
                return moneyIn;
            }

            else
            {
                return -1;
            }
        }
    }
}
