using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    static class Round
    {
        private static int _numberOfRounds = 0;
        private static Random _generator = new Random();
        private static RoundResult _result = new RoundResult();
        private static Logger _logWriter = new Logger();

        public static int NumberOfRounds
        {
            get { return _numberOfRounds; }
        }
             
        public static RoundResult RollTheDice(string logFileName)
        {
            string logData = "";
            do
            {
                _result.UserScore = _generator.Next(1, 6);
                _result.ComputerScore = _generator.Next(1, 6);
            } 
            while (_result.UserScore == _result.ComputerScore);

            _numberOfRounds++;

            // Write log entry!
            logData = "Round," + _numberOfRounds.ToString() + "," + _result.UserScore.ToString() + "," + _result.ComputerScore.ToString()+"\n";

            _logWriter.WriteLog(logData, logFileName);
            
            return _result;
        }

        public static void ResetNumberOfRounds()
        {
            _numberOfRounds = 0;
        }

        public struct RoundResult
        {

            public int UserScore { get; set; }
            public int ComputerScore { get; set; }

            public FightWinnerResult Winner
            {
                get
                {
                    if (ComputerScore > UserScore)
                    {
                        return FightWinnerResult.Computer;
                    }
                    else
                    {
                        return FightWinnerResult.User;
                    }
                }
            }

            public int DamageToInflict
            {
                get
                {
                    return Math.Abs(UserScore - ComputerScore);
                }
            }
        }
    }

    public enum FightWinnerResult
    {
        User,
        Computer
    }
}
