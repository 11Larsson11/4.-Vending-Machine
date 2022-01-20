using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    public abstract class Product
    {
            public int Slot { get; set; }
            public string Info { get; set; }
            public int Cost { get; set; }
            public int Calories { get; set; }
            public double MinutesToExercise { get; set; }

            public Product(int slot = 0, string info = "Noname", int cost = 0, int calories = 0)
            {
                Slot = slot;
                Info = info;
                Cost = cost;
                Calories = calories;
            }

            public virtual void Examine()
            {
                Console.WriteLine("Oops! This product is not implemented.");
            }

            public virtual void Use()
            {
                Console.WriteLine("Oops! No use defined for this product.");
            }

            public abstract double MinutesToBurnCalories();

        }
    }


