using ConsoleTables;

namespace CodeCool.SeasonalProductDiscounter.Ui.Logger;

public class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        LogMessage(message, "ERROR");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void LogSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        LogMessage(message, "SUCCESS");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogInfo(string message)
    {
        Console.WriteLine(message);
    }

    public void LogTable(List<string[]> content, params string[] columnNames)
    {
        var table = new ConsoleTable(columnNames);
        foreach (var item in content)
        {
            table.AddRow(item);
        }
        table.Write(Format.Minimal);
        Console.WriteLine();
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

    public void Clear()
    {
        Console.Clear();
    }
}
