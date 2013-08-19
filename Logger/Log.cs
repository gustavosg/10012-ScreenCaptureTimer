using System;
using Library.Core.Util.Asset;

namespace Library.Core.Util.Logger
{
    public static class Log
    {

        /// <summary>
        /// Generate log with level INFO
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Info(String exception)
        {
            Logger.LogWriter(BusinessStrings.LogInfo, exception);
        }

        /// <summary>
        /// Generate log with level DEBUG
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Debug(String exception)
        {
            Logger.LogWriter(BusinessStrings.LogDebug, exception);
        }

        /// <summary>
        /// Generate log with level ERROR
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Error(String exception)
        {
            Logger.LogWriter(BusinessStrings.LogError, exception);
        }

        /// <summary>
        /// Generate log with level WARN
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Warn(String exception)
        {
            Logger.LogWriter(BusinessStrings.LogWarn, exception);
        }

        /// <summary>
        /// Generate log with level FATAL
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="user"></param>
        public static void Fatal(String exception)
        {
            Logger.LogWriter(BusinessStrings.LogFatal, exception);
        }

    }
}
