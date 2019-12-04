using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Logger.BE
{
    internal class LoggerEntity
    {
       
        public enum LogType
        {
            Info = 0,
            Debug = 1, 
            Error = 2
        }

        public LogType Type { get; set; }
        public DateTime LogDate { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }

        
    }
}
