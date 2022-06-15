using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDB
{
    public class Context
    {
        /*        public static ApplicationContext Db { get; private set; }
        */
        public static ApplicationContext db = new ApplicationContext();

        internal static void AddDb(ApplicationContext application)
        {
            db = application;
        }
        public Context(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }
        public static void InitDb()
        {
            db = new ApplicationContext();
        }
    }
}
