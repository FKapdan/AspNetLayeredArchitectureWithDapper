namespace AspNetLayeredArchitectureWithDapper.Web.ViewModels.Interfaces
{
    public interface IBaseViewModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
