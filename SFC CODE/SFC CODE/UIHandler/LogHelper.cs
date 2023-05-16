using System;
using System.IO;
namespace UIHandler
{
	public class LogHelper : IDisposable
	{
		private string LogFile;
		private string logIsWrite ;
        private static StreamWriter sw;

		public LogHelper()
		{
			this.CreateLoggerFile(null);
		}
        public LogHelper(string isWrite, string logFilePath)
        {
            this.logIsWrite = isWrite;
            this.LogFile = logFilePath;
            this.CreateLoggerFile(null);
        }
		private void CreateLoggerFile(string fileName)
		{
			if (this.logIsWrite.ToLower() == "true")
			{
				if (string.IsNullOrEmpty(fileName))
				{
					fileName = DateTimeHelper.GetToday();
				}
				object obj = null;
				if (obj == null)
				{
                    //this.LogFile = ConfigHelper.GetAppSettings("LogFilePath");
					if (!File.Exists(this.LogFile))
					{
						Directory.CreateDirectory(this.LogFile);
					}
				}
				else
				{
					this.LogFile = obj.ToString();
				}
				if (1 > this.LogFile.Length)
				{
					Console.WriteLine("配置文件中没有指定日志文件目录！");
					return;
				}
				if (!Directory.Exists(this.LogFile))
				{
					Console.WriteLine("配置文件中指定日志文件目录不存在！");
					return;
				}
				if (this.LogFile.Substring(this.LogFile.Length - 1, 1).Equals("/") || this.LogFile.Substring(this.LogFile.Length - 1, 1).Equals("\\"))
				{
					this.LogFile = this.LogFile + fileName + ".log";
				}
				else
				{
					this.LogFile = this.LogFile + "\\" + fileName + ".log";
				}
				try
				{
					FileStream fileStream = new FileStream(this.LogFile, FileMode.OpenOrCreate);
					fileStream.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}
		private void writeInfos(string messagestr)
		{
			try
			{
				this.FileOpen();
				string str = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
				string value = str + "\n" + messagestr;
				LogHelper.sw.WriteLine(value);
				LogHelper.sw.Flush();
				LogHelper.sw.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		private void FileOpen()
		{
            LogHelper.sw = new StreamWriter(this.LogFile, true, System.Text.Encoding.GetEncoding("UTF-8"));
		}
		private void FileClose()
		{
			if (LogHelper.sw != null)
			{
				LogHelper.sw.Flush();
				LogHelper.sw.Close();
				LogHelper.sw.Dispose();
				LogHelper.sw = null;
			}
		}
		public void WriteLog(string msg)
		{
			if (msg != null)
			{
				this.writeInfos(msg.ToString());
			}
		}
		public void Dispose()
		{
		}
	}
}
