namespace CodeCool.SeasonalProductDiscounter.Service.Logger;

public class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        LogMessage(message, "ERROR");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void LogSuccess(string message)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        LogMessage(message, "SUCCESS");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogInfo(string message)
    {
        Console.WriteLine(message);
    }

    private void LogMessage(string message, string type)
    {
        var entry = $"[{DateTime.Now}] {type}: {message}";
        Console.WriteLine(entry);
    }

    public void NewLine()
    {
        Console.WriteLine("\n");
    }
}
