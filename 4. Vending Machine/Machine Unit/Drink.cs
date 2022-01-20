using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public class Drink : Product
    {
        public Drink(int Slot, string Info, int Cost, int Calories) : base(Slot, Info, Cost, Calories) { }

        public override void Examine() //A building block of the menu, that displays product slot, name and cost
        {
            Console.WriteLine(Slot + ") " + Info + " ................. " + Cost + " SEK");
        }

        public override void Use()
        {
            Console.WriteLine("Enjoy your drink! Please return the empty can."); //A comment how to use the drink
        }

        public override double MinutesToBurnCalories()
        {
            return MinutesToExercise = Calories / 2.2;
        }

    }
}
