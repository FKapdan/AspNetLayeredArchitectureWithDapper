using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;

namespace AspNetLayeredArchitectureWithDapper.Entities.Repository
{
    public class DatabaseTableModelDto : EntityBase
    {
        public string TelNo { get; set; }
        public string Pid { get; set; }
    }
}
