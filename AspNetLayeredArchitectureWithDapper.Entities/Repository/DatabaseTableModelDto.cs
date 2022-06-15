using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;

namespace AspNetLayeredArchitectureWithDapper.Entities.Repository
{
    public class DatabaseTableModelDto : IDto
    {
        public int Id { get; set; }
        public string TelNo { get; set; }
        public string Pid { get; set; }
    }
}
