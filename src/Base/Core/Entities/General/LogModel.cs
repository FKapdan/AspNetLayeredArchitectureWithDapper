using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.General
{
    internal class LogModel
    {
        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public int StatusCode { get; set; }
        public string? Url { get; set; }
        public string Method { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string? Token { get; set; }
        public string Ip { get; set; }
        public string User { get; set; }
        public string LogType { get; set; }
        public int Duration { get; set; }
        public string TraceIdentifier { get; set; }
    }
}
