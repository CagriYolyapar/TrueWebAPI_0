using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueWebAPI_0.Models;

namespace TrueWebAPI_0.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool() { }

        static NorthwindEntities _dbInstance;

        public static NorthwindEntities DbInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new NorthwindEntities();
                return _dbInstance;
            }
        }
    }
}