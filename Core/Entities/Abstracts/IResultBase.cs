namespace AspNetLayeredArchitectureWithDapper.Core.Abstracts
{
    public interface IResultBase
    {
        public bool Success { get; set; }
        /// <summary>
        /// Ekran hata dönüşlerinde kulanılabilir.
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Loglamalarda kullanılabilir.
        /// </summary>
        public string ErrorDetail { get; set; }
    }
}
