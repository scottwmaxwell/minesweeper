
using NLog;

namespace Minesweeper.Utility
{
    public class MyLogger : Ilogger
    {
        private static Logger logger;

        public MyLogger()
        {
            logger = LogManager.GetLogger("MinesweeperLoggerrule");
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
