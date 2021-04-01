using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class TheGame
    {
        private Battle _battle;
        public Character userFighter;

        public void NewGame()
        {
            Console.Write("\n\n\t\tNew Game!\n\nEnter your Fighter's name: ");
            string userFighterName = Console.ReadLine();

            if (userFighterName != "")
            {
                this.userFighter = new Character(userFighterName);
            }
            else
            {
                this.userFighter = new Character("User");
            }
            PlayGame(ref userFighter);

            if (this.userFighter.Health > 0)
            {

            }
        }

        public void PlayGame(ref Character refUserFighter)
        {
            ConsoleKeyInfo key;
            bool continueGame = true;

            while (continueGame)
            {
                this._battle = new Battle();
                this._battle.StartBattle(ref refUserFighter);
                Console.Write("\n\n\tStart a New Battle?  Y/N ");
                key = Console.ReadKey();
                if (key.KeyChar.ToString().ToLower() == "n")
                {
                    continueGame = false;
                }
            }
        }
    }
}
