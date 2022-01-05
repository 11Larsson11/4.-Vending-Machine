using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public class Food : Product
    {
        public Food(int Slot, string Info, int Cost) : base(Slot, Info, Cost) { }

        public override void Examine()
        {
            Console.WriteLine(Slot + ") " + Info + " .............. " + Cost + " SEK");
        }

        public override void Use()
        {
            Console.WriteLine("Please eat your food in the cafeteria.");
        }
    }
}
