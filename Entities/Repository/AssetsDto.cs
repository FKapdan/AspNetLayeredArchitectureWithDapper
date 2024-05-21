namespace Entities.Repository
{
    public class AssetsDto : EntityBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public string Active { get; set; }
    }
}
