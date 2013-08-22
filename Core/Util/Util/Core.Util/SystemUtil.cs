using System;
using System.Windows;
using System.Diagnostics;
using Library.Core.Util.Logger;
using Library.Core.Util.Singleton;

namespace Library.Core.Util
{
    public class SystemUtil : Singleton<SystemUtil>
    {

        /// <summary>
        /// Check if there's another application currently running
        /// </summary>
        /// <returns>If there's another application alive</returns>
        public Boolean IsAnotherProcessRunning()
        {
            try
            {
                foreach (Process item in Process.GetProcesses())
                    if (item.ProcessName.Equals(AppDomain.CurrentDomain.FriendlyName))
                        return true;
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
                throw;
            }

            return false;
        }

    }
}
