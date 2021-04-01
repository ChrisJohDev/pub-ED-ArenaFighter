using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    class TheGame
    {
        private Battle _battle;
        public Character userFighter;
        private Logger _logHandler = new Logger();

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
            string logName = "Battle_";
            string logEntry;

            while (continueGame)
            {
                
                Console.Write("\n\n\tStart a New Battle?  Y/N ");
                key = Console.ReadKey();
                this._battle = new Battle();
                if (key.KeyChar.ToString().ToLower() == "n")
                {
                    continueGame = false;
                    logEntry = "Battle " + this._battle.NumberOfBattles.ToString() + " End\n";
                }
                else
                {
                    logEntry = "Battle " + this._battle.NumberOfBattles.ToString() + " Start\n";
                }
                logName += this._battle.NumberOfBattles.ToString() + ".log";
                this._logHandler.WriteLog(logEntry, logName);
                this._battle.StartBattle(ref refUserFighter, logName);
            }
        }
    }
}
