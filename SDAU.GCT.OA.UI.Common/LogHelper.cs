using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.Common
{
    public class LogHelper
    {
        public static Queue<string> ErrorStringQueue = new Queue<string>();
        public static Queue<string> InfoStringQueue = new Queue<string>();
        public static Queue<string> WarnStringQueue = new Queue<string>();
        public static Queue<string> DebugStringQueue = new Queue<string>();
        public static string LogLevel { get; set; }
        public static List<ILogWriter> ILogWriterList = new List<ILogWriter>();
        static LogHelper()
        {
            ILogWriterList.Add(new Log4NetWriter());
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    switch(LogLevel)
                    {
                        case "Error":
                            lock (ErrorStringQueue)
                            {
                                if (ErrorStringQueue.Count > 0)
                                {
                                    string str = ErrorStringQueue.Dequeue();
                                    //从队列获取错误信息写到日志文件里
                                    foreach (var ILogWriter in ILogWriterList)
                                    {
                                        ILogWriter.LogWriter_Error(str);
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(30);
                                }
                            }
                            break;
                        case "Info":
                            lock (InfoStringQueue)
                            {
                                if (InfoStringQueue.Count > 0)
                                {
                                    string str = InfoStringQueue.Dequeue();
                                    foreach (var ILogWriter in ILogWriterList)
                                    {
                                        ILogWriter.LogWriter_Info(str);
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(30);
                                }
                            }
                            break;
                        case "Debug":
                            lock (DebugStringQueue)
                            {
                                if (DebugStringQueue.Count > 0)
                                {
                                    string str = DebugStringQueue.Dequeue();
                                    foreach (var ILogWriter in ILogWriterList)
                                    {
                                        ILogWriter.LogWriter_Debug(str);
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(30);
                                }
                            }
                            break;
                        case "Warn":
                            lock (WarnStringQueue)
                            {
                                if (WarnStringQueue.Count > 0)
                                {
                                    string str = WarnStringQueue.Dequeue();
                                    foreach (var ILogWriter in ILogWriterList)
                                    {
                                        ILogWriter.LogWriter_Warn(str);
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(30);
                                }
                            }
                            break;
                    }                    
                }
            });
        }
        public static void WriteLog_Error(string ExceptionText)
        {
            LogLevel ="Error";
            lock (ErrorStringQueue)
            {
                //把错误信息写入队列
                ErrorStringQueue.Enqueue(ExceptionText);
            }
        }

        public static void WriteLog_Info(string InfoText)
        {
            LogLevel = "Info";
            lock (InfoStringQueue)
            {
                InfoStringQueue.Enqueue(InfoText);
            }
        }
        public static void WriteLog_Debug(string InfoText)
        {
            LogLevel = "Debug";
            lock (DebugStringQueue)
            {
                DebugStringQueue.Enqueue(InfoText);
            }
        }
        public static void WriteLog_Warn(string InfoText)
        {
            LogLevel = "Warn";
            lock (WarnStringQueue)
            {
                WarnStringQueue.Enqueue(InfoText);
            }
        }
    }
}
