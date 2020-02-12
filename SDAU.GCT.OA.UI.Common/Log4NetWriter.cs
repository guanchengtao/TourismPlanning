using log4net;
using SDAU.GCT.OA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.Common
{
    public class Log4NetWriter : ILogWriter
    {
        public void LogWriter_Debug(string str)
        {
            ILog logWriter = LogManager.GetLogger("Mr.G");
            //用{ n} 占位符，而不是字符 串拼接
            //这样如果配置中不输出这个级别的时候，就不会进行字符串拼接，提升性能。
            logWriter.DebugFormat("{0}",str);//这里写入的是调试级别的消息

        }

        public void LogWriter_Error(string str)
        {
            ILog logWriter = LogManager.GetLogger("Mr.G");
            logWriter.ErrorFormat("{0}",str);//这里写入的是错误级别的消息

        }

        public void LogWriter_Info(string str)
        {
            ILog logWriter = LogManager.GetLogger("Mr.G");
            logWriter.InfoFormat("{0}",str);//这里写入的是消息级别的消息
        }

        public void LogWriter_Warn(string str)
        {
            ILog logWriter = LogManager.GetLogger("Mr.G");
            logWriter.WarnFormat("{0}",str);//这里写入的是警告级别的消息

        }
    }
}
