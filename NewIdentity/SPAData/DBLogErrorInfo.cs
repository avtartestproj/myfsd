using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
   public static  class DBLogErrorInfo
    {
        public static void LogErrorInfo_in_DB(string errorinfoMessage, string errorinfoType)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            serviceClient.LogErrorinDB(errorinfoMessage, errorinfoType);
        }
    }
}
