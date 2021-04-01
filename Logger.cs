using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ArenaFighter
{
    public class Logger
    {
        private LogIo _log;
        private string[] _logContents;
        private string _logContent;
        private Task _task;

        public Logger()
        {
            this._log = new LogIo();
            this._logContent = "";
            this._logContents = new string[0];
        }
        public Logger(string logData) : this()
        {
            this._logContent = logData;
        }
        public Logger(string[] logData) : this()
        {
            this._logContents = logData;
        }

        public void WriteLog(string logEntry)
        {
            _ = this._log.WriteLog(logEntry);
        }
        public void WriteLog(string logEntry, string path)
        {
            this._log.Path = path;
            _ = this._log.WriteLog(logEntry);
        }
        public void WriteLog(string[] logEntry)
        {
            _ = this._log.WriteLog(logEntry);
        }
        public void WriteLog(string[] logEntry, string path)
        {
            this._log.Path = path;
            _ = this._log.WriteLog(logEntry);
        }


        private protected class LogIo
        {
            private string _path;
            private string _logEntry;
            private string[] _logEntries = new string[0];
            private DateTime _dateTime = new DateTime();

            public LogIo()
            {
                this._path = @"~/logs/fighterLog.log";
            }
            public LogIo(string filePath)
            {
                this._path = filePath;
            }

            public string Path
            {
                get { return this._path; }
                set { this._path = value; }
            }
            public async Task WriteLog(string data)
            {
                this._logEntry = DateTime.Now.ToString() + "," + data;
                await File.AppendAllTextAsync(this._path, this._logEntry, System.Text.Encoding.UTF8);
            }
            public async Task WriteLog(string[] data)
            {
                int i = 0;
                foreach(string entry in data)
                {
                    Array.Resize(ref this._logEntries, this._logEntries.Length + 1);
                    this._logEntries[i] = DateTime.Now.ToString() + "," + entry;
                    i++;
                }
                await File.AppendAllLinesAsync(this._path, data, System.Text.Encoding.UTF8);
            }
        }
    }

    
}
