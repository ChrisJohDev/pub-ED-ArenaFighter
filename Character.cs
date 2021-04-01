using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
	public class Character
	{
		private string _name= "Seymour Hooters";
		private int _health, _strength, _gamesWon, _roundsWon;
        private Random _randomGenerator = new Random();
		private Currency _wealth = new Currency();
		private Gear _gearArsenal = new Gear();
		public Character()
		{
			this._health = this._randomGenerator.Next(10, 100);
			this._strength = this._randomGenerator.Next(5, 100);
			this._gamesWon = 0;
			this._roundsWon = 0;
		}
		public Character(string userName) : this()
		{
			this._name = userName;
		}
		public string Name
        {
            get { return this._name; }
        }
		public int Health
        {
            get { return this._health; }
            set { this._health = value; }
        }
		public int Strength
		{
			get { return this._strength; }
			set { this._strength = value; }
		}
		public int RoundsWon
        {
            get { return this._roundsWon; }
        }
		public int GamesWon
        {
            get { return this._gamesWon; }
        }
		public int Score
        {
            get
            {
				if (this._health > 0)
				{
					int score = 0;
					if (this._gearArsenal.HasBow && this._gearArsenal.Arrows > 0)
					{
						score += this._gearArsenal.Arrows * 2;
					}
					if (this._gearArsenal.HasKnife)
					{
						score += 5;
					}
					if (this._gearArsenal.HasShield)
					{
						score += 35;
					}
					if (this._gearArsenal.HasSword)
					{
						score += 30;
					}
					score += this._wealth.Amount;
					score += this._health;
					score += this._strength;
					return score;
				}
                else
                {
					return 0;
                }
            }
        }

		public Gear GetGearArsenal
        {
            get { return this._gearArsenal; }
        }
		public Currency Wealth
        {
            get { return this._wealth; }
        }
		
		public bool BuyHealth()
        {
			const int healthUnitCost = 2;
			string strAmount = "";
			int amount = 0;
			Console.WriteLine("\n\n---------------\nWelcome to the Health Store!\nYou have $"+this.Wealth.Amount.ToString()+" available.");
			Console.WriteLine("\nEach unit of health costs $2\nHow Much health do you want to buy?");
			strAmount = Console.ReadLine();

            try
            {
                if (strAmount != "")
                {
					amount = Convert.ToInt32(strAmount);
                    if (this._wealth.Amount > (healthUnitCost * amount - 1))
                    {
						this._health += amount;
						this._wealth.WithdrawCurrency(amount * healthUnitCost);
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
    }
}
