using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Library.Core.Singleton
{
    public class Singleton<T> where T : class
    {
        private static T instance;

        private static Object singletonLock = new Object();

        /// <summary>
        /// Return Singleton instance of Class
        /// </summary>
        /// <returns>Instance of class</returns>
        public static T GetSingleton()
        {
            if (instance == null)
                lock (singletonLock)
                {
                    if (instance == null)
                    {
                        Type t = typeof(T);

                        // Confere se não tem construtores publicos...
                        ConstructorInfo[] ctors = t.GetConstructors();
                        if (ctors.Length > 0)
                            instance = (T)Activator.CreateInstance(t, true);

                    }
                }

            return instance;
        }

    }
}
