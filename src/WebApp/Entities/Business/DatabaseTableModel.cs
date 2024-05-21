using Core.Entities.Bases;

namespace Entities
{
    public class DatabaseTableModel : EntityBase
    {
        public int Id { get; set; }
        public string TelNo { get; set; }
        public string Pid { get; set; }
    }
}
