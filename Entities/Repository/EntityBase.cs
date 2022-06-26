using AspNetLayeredArchitectureWithDapper.Entities.Repository.Interfaces;

namespace AspNetLayeredArchitectureWithDapper.Entities.Repository
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
