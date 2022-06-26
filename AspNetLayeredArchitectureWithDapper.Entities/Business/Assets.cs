using AspNetLayeredArchitectureWithDapper.Entities.Repository;

namespace AspNetLayeredArchitectureWithDapper.Entities.Business
{
    public class Assets : EntityBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public string Active { get; set; }
    }
}
