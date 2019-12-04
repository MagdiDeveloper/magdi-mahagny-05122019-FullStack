using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Logger.Bases;
using Tools.Logger.BE;
using Tools.Logger.Interfaces;
using WeatherApp.Tools;

namespace Tools.Logger.BL
{
    internal class FilesLogger : LoggerBase, ILogger
    {
        public void Debug(string message)
        {
            WriteToLogger(message, LoggerEntity.LogType.Debug);
        }

        public void Error(string message)
        {
            WriteToLogger(message, LoggerEntity.LogType.Error);
        }

        public void Info(string message)
        {
            WriteToLogger(message, LoggerEntity.LogType.Info);
        }

        internal override void WriteToLogger(string message, LoggerEntity.LogType logType)
        {
            string logRootPath = "Logger.Path".GetWebConfigValue<string>();
            if (Directory.Exists(logRootPath))
            {
                string logFilePath = logRootPath + "\\Log_" + loggerEntity.LogDate.Date.Year + "_" + loggerEntity.LogDate.Month + "_" + loggerEntity.LogDate.Day + ".log";
                StringBuilder logMessage = new StringBuilder();
                logMessage.AppendFormat("[{0}] [{1}] [{2}] [{3}] [{4}] [{5}]", loggerEntity.LogDate, logType, loggerEntity.UserID, loggerEntity.ClassName, loggerEntity.MethodName, message);
                Task.Run(async () =>
                {
                    using (StreamWriter file = new StreamWriter(logFilePath, true))
                    {
                        // Can write either a string or char array
                        await file.WriteLineAsync(logMessage.ToString());
                        await file.FlushAsync();
                    }
                });
            }
        }
    }
}
