﻿namespace CodeCool.SeasonalProductDiscounter.Ui.Logger;

public interface ILogger
{
    public void LogInfo(string message);
    public void LogError(string message);
    public void LogSuccess(string message);
    public void NewLine();
}