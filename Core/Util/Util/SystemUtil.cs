using System;
using System.Diagnostics;
using Library.Core.Util.Logger;

namespace Library.Core.Util
{
    public static class SystemUtil 
    {

        

        /// <summary>
        /// Check if there's another application currently running
        /// </summary>
        /// <returns>If there's another application alive</returns>
        public static Boolean IsAnotherProcessRunning()
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
