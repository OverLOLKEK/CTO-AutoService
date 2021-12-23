using AutoService.DBInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    public class DB
    {
        static Entities connection;
        static object objectLock = new object();
        public static Entities GetDB()
        {
            lock (objectLock)
            {
                if (connection == null)
                    connection = new Entities();
                return connection;
            }
        }
    }
}
