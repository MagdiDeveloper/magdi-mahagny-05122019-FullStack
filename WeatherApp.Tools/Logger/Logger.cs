using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Logger.BL;
using Tools.Logger.Interfaces;
using WeatherApp.Tools;

namespace Tools.Logger
{
    public static class Logger
    {
        static ILogger logger;
        public static void Info(string message)
        {
            logger.Info(message);
        }
        public static void Debug(string message)
        {
            if ("Logger.AllowDebugger".GetWebConfigValue<bool>())
                logger.Debug(message);
        }
        public static void Error(string message)
        {
            logger.Error(message);
        }

        static Logger()
        {
            string logType = "Logger.Type".GetWebConfigValue<string>();
            switch (logType)
            {
                case "File":
                    logger = new FilesLogger();
                    break;
                case "DB":
                    logger = new DatabaseLogger();
                    break;


            }
        }

    }
}
