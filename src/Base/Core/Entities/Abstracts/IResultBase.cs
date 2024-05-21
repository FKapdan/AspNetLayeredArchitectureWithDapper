namespace Core.Entities.Abstracts
{
    public interface IResultBase
    {
        public bool Success { get; set; }
        /// <summary>
        /// Ekran hata dönüşlerinde kulanılabilir.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Loglamalarda kullanılabilir.
        /// </summary>
        public string Detail { get; set; }
    }
}
