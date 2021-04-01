
using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    public class Gear
    {
        private Random randomGenerator = new Random();
        private int _noArrows;
        private bool _hasShield, _hasKnife, _hasSword, _hasBow;

        public Gear(bool isGeneratedCharacter = false)
        {
            if (isGeneratedCharacter)
            {
                this._hasBow = randomGenerator.Next(0, 99) % 2 == 0 ? true : false;
                this._hasKnife = randomGenerator.Next(0, 99) % 2 == 0 ? true : false;
                this._hasShield = randomGenerator.Next(0, 99) % 2 == 0 ? true : false;
                this._hasSword = randomGenerator.Next(0, 99) % 2 == 0 ? true : false;
                if (this._hasBow)
                {
                    this._noArrows = randomGenerator.Next(1, 30);
                }
            }
            else
            {
                this._hasBow =  false;
                this._hasKnife =  false;
                this._hasShield =  false;
                this._hasSword =  false;
                this._noArrows = 0;
            }
        }
        public bool HasBow { 
            get { return this._hasBow; }
            set { this._hasBow = value; }
        }
        public bool HasKnife { 
            get { return this._hasKnife; }
            set { this._hasKnife = value; }
        }
        public bool HasShield
        {
            get { return this._hasShield; }
            set { this._hasShield = value; }
        }
        public bool HasSword
        {
            get { return this._hasSword; }
            set { this._hasSword = value; }
        }

        public bool AddArrows()
        {
            if (HasBow)
            {
                this._noArrows++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Arrows
        {
            get { return this._noArrows; }
        }
        public bool AddArrows(int arrows)
        {
            if (HasBow)
            {
                this._noArrows += arrows;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UsedArrow()
        {
            if (HasBow && this._noArrows > 0)
            {
                this._noArrows--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GearShop(ref Character customer)
        {
            string strSelection = "", strNumber = "";
            int selection = 0, number = 0;
            Console.WriteLine("\n\nWelcome to the Fighter's Gear Shop!");
            Console.WriteLine("\n\t\tPricelist:\n");
            Console.WriteLine("1 Shield:\t\t$35\n2 Knife:\t\t$5\n3 Sword:\t\t$30\n4 Bow:\t\t$20\n5 Arrow:\t\t$2/each");
            Console.WriteLine("-------\nYou have $" + customer.Wealth.Amount.ToString() + " to spend today.");
            Console.WriteLine("\nEnter the number for the item you want to buy.");
            Console.Write("$");
            strSelection = Console.ReadLine();
            if(strSelection != "")
            {
                try
                {
                    selection = Convert.ToInt32(strSelection);
                    if (selection == 1 && customer.Wealth.Amount > 34 && !customer.GetGearArsenal.HasShield)
                    {
                        customer.Wealth.WithdrawCurrency(35);
                        customer.GetGearArsenal.HasShield = true;
                        return true;
                    }
                    else if(selection == 2 && customer.Wealth.Amount > 4 && !customer.GetGearArsenal.HasKnife)
                    {
                        customer.Wealth.WithdrawCurrency(5);
                        customer.GetGearArsenal.HasKnife = true;
                        return true;
                    }
                    else if (selection == 3 && customer.Wealth.Amount > 29 && !customer.GetGearArsenal.HasSword)
                    {
                        customer.Wealth.WithdrawCurrency(30);
                        customer.GetGearArsenal.HasSword = true;
                        return true;
                    }
                    else if (selection == 4 && customer.Wealth.Amount > 19 && !customer.GetGearArsenal.HasBow)
                    {
                        customer.Wealth.WithdrawCurrency(20);
                        customer.GetGearArsenal.HasBow = true;
                        return true;
                    }
                    else if (selection == 5 && customer.GetGearArsenal.HasBow)
                    {
                        Console.WriteLine("\nHow many arrows do you want to purchase?");
                        strNumber = Console.ReadLine();
                        number = Convert.ToInt32(strNumber);

                        if (customer.Wealth.WithdrawCurrency(number * 2))
                        {
                            customer.GetGearArsenal.AddArrows(number);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
