using Core.Entities.Abstracts;

namespace Core.Entities.Results
{
    public class ResultBase : IResultBase
    {
        public ResultBase(bool Success)
        {
            this.Success = Success;
        }
        public ResultBase(bool Success, string Message, string Detail)
        {
            this.Success = Success;
            this.Message = Message;
            this.Detail = Detail;
        }
        public ResultBase(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
        }
        public ResultBase(string Message)
        {
            this.Message = Message;
        }
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
