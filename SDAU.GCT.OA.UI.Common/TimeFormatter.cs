using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.Common
{
    public static class TimeFormatter
    {
       
        public static string TimeFormat(string dt)
        {
            DateTime datetime = DateTime.Parse(dt);
            return datetime.ToString("yyyy/MM/dd HH:mm:ss");
        }



    }
}
