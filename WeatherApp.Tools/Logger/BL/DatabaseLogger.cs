using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Logger.Bases;
using Tools.Logger.BE;
using Tools.Logger.Interfaces;

namespace Tools.Logger.BL
{
    public class DatabaseLogger : LoggerBase, ILogger
    {
        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        internal override void WriteToLogger(string message, LoggerEntity.LogType logType)
        {
            throw new NotImplementedException();
        }
    }
}
