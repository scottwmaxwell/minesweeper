
using NLog;

namespace Minesweeper.Utility
{
    public class MyLogger : Ilogger
    {
        // Singleton design pattern 
        private static MyLogger instance;
        private static Logger logger;

        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();

            }
            return instance;
        }

        private Logger GetLogger()
        {
            if (MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger("MinesweeperLoggerrule");
            }
            return MyLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }
    }
}
