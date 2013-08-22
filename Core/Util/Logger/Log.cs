using System;
using Library.Core.Util.Asset;

namespace Library.Core.Util.Logger
{
    public static class Log
    {

        /// <summary>
        /// Generate log with level INFO
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public static void Info(String message)
        {
            Logger.LogWriter(BusinessStrings.LogInfo, message);
        }

        /// <summary>
        /// Generate log with level DEBUG
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public static void Debug(String message)
        {
            Logger.LogWriter(BusinessStrings.LogBuild, message);
        }

        /// <summary>
        /// Generate log with level ERROR
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public static void Error(String message)
        {
            Logger.LogWriter(BusinessStrings.LogError, message);
        }

        /// <summary>
        /// Generate log with level WARN
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public static void Warn(String message)
        {
            Logger.LogWriter(BusinessStrings.LogWarn, message);
        }

        /// <summary>
        /// Generate log with level FATAL
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public static void Fatal(String message)
        {
            Logger.LogWriter(BusinessStrings.LogFatal, message);
        }

    }
}
