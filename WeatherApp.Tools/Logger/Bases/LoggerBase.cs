using System;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using Tools.Logger.BE;
using static Tools.Logger.BE.LoggerEntity;

namespace Tools.Logger.Bases
{
    public abstract class LoggerBase
    {
        internal LoggerEntity loggerEntity { get {return GetLoggerEntity() ; }  }
        

        LoggerEntity GetLoggerEntity()
        {
            LoggerEntity entity = new LoggerEntity();
            try
            {
               
                MethodBase method = new StackTrace().GetFrame(5).GetMethod();
                string methodName = method.Name;
                string className = method.ReflectedType.Name;
                entity.ClassName = className;
                entity.MethodName = methodName;
            }
            catch (Exception)
            {

                //throw;
            }
            dynamic contact = null;
           
            entity.LogDate = DateTime.Now;
            if (contact != null)
                entity.UserID = Guid.Parse(contact.id.ToString()).ToString();
            return entity;


        }

        internal abstract void WriteToLogger(string message, LogType logType);
    }
}