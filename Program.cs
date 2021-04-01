using System;

namespace ArenaFighter
{
    class Program
    {
        
        static void Main(string[] args)
        {

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            Console.WriteLine("Welcome to the Arena Fighter Game!\n\nPress Enter to start game...\n\n");
            
            key = Console.ReadKey(false);

            if (key.KeyChar == '\r')
            {
                StartGame();
            }
        }

        public static void StartGame()
        {
            TheGame game = new TheGame();
            bool ok = true;
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (ok)
            {
                game.NewGame();

                Console.WriteLine("Press any key for a new game or '0' to end!\n\n");
                key = Console.ReadKey(false);

                
                if (key.KeyChar == '0') { ok = false; }
            }
            
        }
    }

    
}
