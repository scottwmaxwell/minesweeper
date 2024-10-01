namespace Minesweeper.Utility
{
    public interface Ilogger
    {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}
