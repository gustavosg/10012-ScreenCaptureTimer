// --------------------------------------------------------------------------------
//
//
//
// --------------------------------------------------------------------------------
//
//
//
//
// --------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.IO;
using Library.Core.Util.Singleton;

namespace Library.Core.Util.Logger
{
    public static class Logger
    {

        static String filename;

        /// <summary>
        /// Returns path of current log
        /// </summary>
        /// <returns>String containing path of log</returns>
        private static String LogGetCurrentFile()
        {
            filename = ConfigurationManager.AppSettings["LogPath"] + AppDomain.CurrentDomain.FriendlyName + ".log";
            return filename;
        }

        /// <summary>
        /// Returns path of old log file
        /// </summary>
        /// <returns>String containing path of log</returns>
        private static String LogGetOldFile()
        {
            return ConfigurationManager.AppSettings["LogPath"] + AppDomain.CurrentDomain.FriendlyName + ".1.log";
        }

        /// <summary>
        /// Read entire log from file
        /// </summary>
        /// <returns>Log in String format</returns>
        private static String LogReader()
        {
            FileInfo file = new FileInfo(LogGetCurrentFile());

            // In case file doesn't exists, creates file AND directory
            if (!File.Exists(file.FullName))
            {
                file.Directory.Create();
                File.Create(file.FullName);
            }

            if (file.Length > 1024000000)
                File.Move(LogGetCurrentFile(), LogGetOldFile());

            // Opening file to read
            StreamReader sr = new StreamReader(file.FullName);

            // Reading content of file
            String content = sr.ReadToEnd().ToString();

            // Closing file to avoid exception
            sr.Close();

            return content;
        }

        /// <summary>
        /// Write content to log
        /// </summary>
        /// <param name="level">Log Level (INFO, DEBUG, ERROR, WARN, FATAL)</param>
        /// <param name="logData">Content to write on Log</param>
        public static void LogWriter(String level, String logData)
        {
            try
            {
                // TODO Gustavo: Colocar algumas explicações de código
                String content = LogReader();

                DateTime date = DateTime.Now;

                String log = String.Empty;

                log = level + " | " + date + " | " + logData + ".";

                StreamWriter sw = new StreamWriter(filename);

                sw.WriteLine(content + log);

                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
