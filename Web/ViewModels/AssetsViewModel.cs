using AspNetLayeredArchitectureWithDapper.Web.Attributes;
using System.ComponentModel;

namespace AspNetLayeredArchitectureWithDapper.Web.ViewModels
{
    public class AssetsViewModel
    {
        [DisplayName("Id")]
        [PropVisible(false)]
        public int Id { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Marka")]
        public string Brand { get; set; }
        [DisplayName("Adet")]
        public int Count { get; set; }
        [DisplayName("Aktif")]
        public string Active { get; set; }
    }
}
