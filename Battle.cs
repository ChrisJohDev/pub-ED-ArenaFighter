using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class Battle
    {
        private static int _numberOfBattles;
        private Character _computerFighter;
        private Round.RoundResult _result;

        public Battle()
        {
            Round.ResetNumberOfRounds();
            this._computerFighter = new Character();
            //this._result = new RoundResult();
        }

        public static void BattleCounterAddBattle()
        {
            _numberOfBattles += 1;
        }

        public int NumberOfBattles
        {
            get { return _numberOfBattles; }
        }

        public static void ResetNumberOfBattles()
        {
            _numberOfBattles = 0;
        }

        public void StartBattle(ref Character userFighter)
        {
            ConsoleKeyInfo key;
            Round.ResetNumberOfRounds();
            
            while (userFighter.Health > 0 && this._computerFighter.Health > 0)
            {
                this._result = Round.RollTheDice();
                
                if(this._result.Winner == FightWinnerResult.User)
                {
                    // Possible selections of how to inflict damage with what weapon and what to do with the amount won.
                    userFighter.Wealth.AddCurrency(25);
                    this._computerFighter.Health = this._computerFighter.Health - this._result.DamageToInflict;
                }
                else if(this._result.Winner == FightWinnerResult.Computer)
                {
                    // Possible selections of how to inflict damage with what weapon and what to do with the amount won.
                    this._computerFighter.Wealth.AddCurrency(25);
                    userFighter.Health = userFighter.Health - this._result.DamageToInflict;
                }
                Console.WriteLine("\n\n--------------------\nThe Winner of round " + Round.NumberOfRounds + " is: " + this._result.Winner);
                Console.WriteLine("\n\nUser:\t\t" + userFighter.Name + "\nHealth:\t\t" + userFighter.Health + "\nStrength:\t" + userFighter.Strength);
                Console.WriteLine("\n\nComputer:\t" + this._computerFighter.Name + "\nHealth:\t\t" + this._computerFighter.Health + "\nStrength:\t" + this._computerFighter.Strength);
                Console.Write("Press Enter to continue: ");
                key = Console.ReadKey();
                while (key.KeyChar != '\r')
                {
                    Console.Write("\nPress Enter to continue: ");
                    key = Console.ReadKey();
                }
            }
            // Write log entry!
        }

    }
}
