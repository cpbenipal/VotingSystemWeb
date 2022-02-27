using NLog;
using System;
using VSM.LoggerService.Contracts;

namespace VSM.LoggerService.Service
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(Exception ex)
        {
            logger.Error(ex, ExeptionHelper.GetaAllErrors(ex));
        }
        public void LogError_Wrapper(string api,  string errorMessage)
        {
            logger.Error("ERROR from .net core wrapper :: " + api + " | Message:" + errorMessage);
        }
        public void LogError(string api, string errorCode, string errorMessage)
        {
            logger.Error("ERROR from API :: " + api + " | ErrorCode:" + errorCode + " | Message:" + errorMessage);
        }
        public void LogError(string api, string errorCode, string errorMessage, string errorCommendation, string errorRecordId)
        {
            logger.Error("ERROR from Legacy API :: " + api + " | ErrorCode:" + errorCode + " | Message:" + errorMessage 
                + (errorCommendation!=null ? " | ERRORRECOMMENDATION:"+errorCommendation : "")
                +(errorRecordId!=null ? " | ERRORRECORDID:"+ errorRecordId : ""));
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

       
    }
}
