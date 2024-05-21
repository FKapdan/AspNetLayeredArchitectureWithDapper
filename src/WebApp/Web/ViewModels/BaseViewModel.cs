using Web.ViewModels.Interfaces;

namespace Web.ViewModels
{
    public class BaseViewModel : IBaseViewModel
    {
        public BaseViewModel(bool Success)
        {
            this.Success = Success;
        }
        public BaseViewModel(bool Success, string Error)
        {
            this.Success = Success;
            this.Error = Error;
        }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
