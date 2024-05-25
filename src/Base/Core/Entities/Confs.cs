namespace Core.Entities
{
    public class CoreDIConfs
    {
        /// <summary>
        /// Core.Utilities.JwtHelpler altındaki yardımcı metotları true verilerek DI ortamına ekleyerek kullanıma sunar
        /// </summary>
        public bool IsAddJwtServices { get; set; }
        /// <summary>
        /// Loglama işleminde file kullanılması isteniyor ise true verilebilir.
        /// </summary>
        public bool IsAddFileLog { get; set; }
    }
}
