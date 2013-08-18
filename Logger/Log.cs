using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Core.Logger
{
    public class Log<Singleton>
    {

        
        public Log()
        {
            Logger log = Logger.GetSingleton();
        }

        public void Info(String exception)
        {

        }

    }
}
