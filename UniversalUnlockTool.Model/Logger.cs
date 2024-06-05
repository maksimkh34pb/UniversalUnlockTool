using System.Collections.ObjectModel;

namespace UniversalUnlockTool.Model
{
    public static class Logger
    {
        static string logTypeStr = "";

        readonly static ObservableCollection<string> directOutput = new();
        public static ObservableCollection<string>? DirectOutput
        {
            get
            {
                if (useDirectOutput) return directOutput;
                else return null;
            }
        }

        public delegate void _LogDelegate(string msg);
        static _LogDelegate? LogDelegate;

        static bool useDirectOutput = false;
        static string? logFilePath = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logType">
        /// logType is string with log mode. Compose chars to define log mode
        /// 
        /// 'C' - Console
        /// 'F' - File
        /// 'D' - Direct
        /// 
        /// Console - directly prints logs to console
        /// File - saves logs to file. Call Logger.SetFile(...) to specify file output
        /// Direct - DirectOutput (List<string>?) will contain all log strings.
        /// </param>

        public static void SetLogger(string logType)
        {
            logTypeStr = logType;
            foreach (char s in logType)
            {
                switch (s)
                {
                    case 'C':
                        LogDelegate += Console.WriteLine;
                        break;
                    case 'F':
                        LogDelegate += LogToFile;
                        break;
                    case 'D':
                        useDirectOutput = true;
                        break;
                    default:
                        throw new Exception("Invalid Log Type provided. ");

                }
            }
        }

        public static void Log(string text, string invoker)
        {
            text = GetPrefix(invoker) + text;
            directOutput.Add(text);
            LogDelegate?.Invoke(text);
        }

        /// <summary>
        /// Throws IOException. 
        /// </summary>
        public static void SetFile(string dir, string fileName)
        {
            if (logTypeStr.Contains('F'))
            {
                logFilePath = dir + GenerateLogFile(fileName);
                File.Create(logFilePath).Close();
            }
            else
            {
                throw new Exception("File log is off.");
            }
        }

        public static void LogToFile(string text)
        {
            if (logTypeStr.Contains('F'))
            {
                File.AppendAllText(logFilePath ?? "local.log", text);
            }
            else
            {
                throw new Exception("File log is off.");
            }
        }

        static string GenerateLogFile(string name)
        {
            return DateTime.Now.ToString("yyyy.MM.dd.HH.mm.") + name + ".log";
        }

        static string GetPrefix(string invoker)
        {
            return
                DateTime.Now.ToString("[yyyy.MM.dd HH:mm]") +
                $" ({invoker}) ";
        }
    }
}
