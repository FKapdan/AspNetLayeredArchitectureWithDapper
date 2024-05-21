using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CoreDIConfs
    {
        /// <summary>
        /// Core.Utilities.JwtHelpler altındaki yardımcı metotları true verilerek DI ortamına ekleyerek kullanıma sunar
        /// </summary>
        public bool IsAddJwtHelper { get; set; }
    }
}
