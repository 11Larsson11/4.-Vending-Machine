using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    interface IVending
    {
        void ShowAll();

        void InsertMoney();

        void Purchase(int choice);

        void EndTransaction();
    }
}
