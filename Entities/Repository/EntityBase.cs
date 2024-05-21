using Entities.Repository.Interfaces;

namespace Entities.Repository
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
