using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Vending_Machine.Machine_Unit
{
    interface IVending
    {
        public abstract void InsertMoney();
        public abstract void ShowAll();
        public abstract void Purchase(int Cost, int poolMoney);
        public abstract void EndTransaction();

    }
}
