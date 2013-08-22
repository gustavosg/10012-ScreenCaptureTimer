using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Library.Core.Util.Singleton
{
    public class Singleton<GenericClass> where GenericClass : class, new()
    {
        private static GenericClass instance;

        private static Object singletonLock = new Object();

        /// <summary>
        /// Return Singleton instance of Class
        /// </summary>
        /// <returns>Instance of class</returns>
        public static GenericClass GetSingleton()
        {
            if (instance == null)
                lock (singletonLock)
                {
                    if (instance == null)
                    {
                        Type t = typeof(GenericClass);

                        // Confere se não tem construtores publicos...
                        ConstructorInfo[] ctors = t.GetConstructors();
                        if (ctors.Length > 0)
                            instance = (GenericClass)Activator.CreateInstance(t, true);
                    }
                }
            return instance;
        }
    }
}
