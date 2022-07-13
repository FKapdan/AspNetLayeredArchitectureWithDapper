using AspNetLayeredArchitectureWithDapper.Web.Attributes;
using System.ComponentModel;

namespace AspNetLayeredArchitectureWithDapper.Web.ViewModels
{
    public class AssetsViewModel
    {
        [PropVisible(false)]
        [DisplayName("Id")]
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
