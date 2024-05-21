using Core.Entities.Abstracts;

namespace Core.Entities.Results
{
    public class ResultBase : IResultBase
    {
        public ResultBase(bool Success)
        {
            this.Success = Success;
        }
        public ResultBase(bool Success, string Error, string ErrorDetail)
        {
            this.Success = Success;
            this.Error = Error;
            this.ErrorDetail = ErrorDetail;
        }

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
