using Core.Entities.General;
using Core.Extensions;
using Core.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public sealed class FileLogService : ILogService
    {
        private readonly object _lock = new object();
        private readonly string LogDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}Logs";
        private readonly string LogFile = $"\\{Assembly.GetEntryAssembly()?.GetName().Name}";
        public void Log(LogModel logModel)
        {
            try
            {
                lock (_lock)
                {
                    if (!Directory.Exists(LogDirectory))
                    {
                        Directory.CreateDirectory(LogDirectory);
                    }
                    if (!File.Exists(LogDirectory + LogFile))
                    {
                        File.Create(LogDirectory + LogFile).Close();
                    }
                    File.AppendAllText((LogDirectory + LogFile), JsonSerializerExtensions.SerializeCore(logModel) + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
