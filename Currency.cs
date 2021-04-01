using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    
    public class Currency
    {
        private int _amount;

        public Currency() {
            this._amount = 2;
        }

        public int Amount
        {
            get { return this._amount; }
        }
        public void AddCurrency(int data)
        {
            this._amount += data;
        }
        public bool WithdrawCurrency(int data)
        {
            if (this._amount - data >= 0)
            {
                this._amount -= data;
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
