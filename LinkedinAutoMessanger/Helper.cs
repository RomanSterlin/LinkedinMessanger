using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinAutoMessanger
{
    public static class Helper
    {
        public static string Connection(string name)
        {
         return ConfigurationManager.ConnectionStrings[name].ConnectionString;  
        }
    }
}
