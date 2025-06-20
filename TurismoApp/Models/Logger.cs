namespace TurismoApp.Models
{
    public delegate void LogDelegate(string message);

    public class Logger
    {
        private readonly LogDelegate _logs;

        public Logger()
        {
            _logs = LogHelper.LogToConsole;
            _logs += LogHelper.LogToFile;
            _logs += LogHelper.LogToMemory;
        }

        public void Log(string message)
        {
            _logs?.Invoke(message);
        }
    }
}
