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
using Library.Core.Singleton;
using System.Configuration;
using System.IO;

namespace Library.Core.Logger
{
    public class Logger : Singleton<Logger>
    {

        String filename;

        public Logger()
        {

        }

        /// <summary>
        /// Returns path of logger
        /// </summary>
        /// <returns>String containing path of log</returns>
        private String LogGetPath()
        {
            return ConfigurationManager.AppSettings["LogPath"];
        }

        /// <summary>
        /// Read entire log from file
        /// </summary>
        /// <returns>Log in String format</returns>
        private String LogReader()
        {
            String filepath = LogGetPath();

            StreamReader sr = new StreamReader(filepath);

            return sr.ReadToEnd();
        }

        private void LogWriter(String level, String logData, String user = "")
        {
            String content = LogReader();

            DateTime date = DateTime.UtcNow;

            String log = String.Empty;

            if (String.IsNullOrEmpty(user))
                log = level + " | " + date + " | " + logData + ".";
            else
                log = level + " | " + date + " | " + logData + " | Usuário: " + user + ".";

            StreamWriter sw = new StreamWriter(filename);

            sw.WriteLine(content + log);

            sw.Flush();
            sw.Close();

        }

    }
}
