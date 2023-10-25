using ConsoleTables;

namespace CodeCool.SeasonalProductDiscounter.Ui.Logger;

public class FileLogger : ILogger

{
    private readonly string _directoryPath;
    private readonly string _loggPath;



    public FileLogger()
    {
        _directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/");
        _loggPath = Path.Combine(_directoryPath, "Logger.txt");
    }
    public  void LogInfo(string message) => WriteMessageInLoggTxt(message);
    public  void LogError(string message) => WriteMessageInLoggTxt(message);
    public  void LogSuccess(string message) => WriteMessageInLoggTxt(message);

    private static string CreateLogEntry(string message) => $"{message}";

    private void PerformFileOperation(Action<StreamWriter> fileOperation)
    {
        if (!Directory.Exists(_directoryPath)) Directory.CreateDirectory(_directoryPath);

        var file = new FileInfo(_loggPath);
        using (var fileStream = file.Open(FileMode.Append, FileAccess.Write))
        using (var writer = new StreamWriter(fileStream))
        {
            fileOperation(writer);
        }
        
    }

    private void WriteMessageInLoggTxt(string message)
    {
        
        PerformFileOperation(writer => writer.WriteLine(CreateLogEntry(message)));
    }

    public  void Clear()
    {
        PerformFileOperation(writer => writer.WriteLine());
    }


    public  void LogTable(List<string[]> content, params string[] columnNames)
    {
        var table = new ConsoleTable(columnNames);
        foreach (var item in content)
        {
            table.AddRow(item);
        }

        PerformFileOperation(writer => writer.WriteLine(table.ToString()));
    }

    public void NewLine()
    {
        PerformFileOperation(writer => writer.WriteLine());
    }
}