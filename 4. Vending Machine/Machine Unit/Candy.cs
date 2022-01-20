using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public class Candy : Product
    {
        public Candy(int Slot, string Info, int Cost, double Calories) : base(Slot, Info, Cost, Calories) { }

        public override void Examine()
        {
            Console.WriteLine(Slot + ") " + Info + " .............. " + Cost + " SEK");
        }

        public override void Use()
        {
            Console.WriteLine("Enjoy your candy! Please throw the wrapping in the garbage.");
        }

        public override double MinutesToBurnCalories()
        {
            return MinutesToExercise = Calories / 2;
        }

    }

}

