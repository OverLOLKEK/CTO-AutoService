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
        static Entities  entities;
        static object objectLock = new object();
        public static Entities GetDB()
        {
            lock (objectLock)
            {
                if (entities == null)
                    entities = new Entities();
                return entities;
            }
        }
    }
}
