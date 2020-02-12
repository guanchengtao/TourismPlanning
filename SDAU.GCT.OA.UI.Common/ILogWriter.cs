using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.Common
{
   
        public interface ILogWriter
        {
        void LogWriter_Error(string str);
        void LogWriter_Info(string str);
        void LogWriter_Debug(string str);
        void LogWriter_Warn(string str);
    }
    
}
