using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Context
    {
        public static ApplicationContext Db { get; private set; }
        public static ApplicationContext Db2 = new ApplicationContext();

        internal static void AddDb(ApplicationContext application)
        {
            Db = application;
        }
        public Context(ApplicationContext applicationContext)
        {
            Db = applicationContext;
        }
        public static void InitDb()
        {
            Db = new ApplicationContext();
        }
    }
}
