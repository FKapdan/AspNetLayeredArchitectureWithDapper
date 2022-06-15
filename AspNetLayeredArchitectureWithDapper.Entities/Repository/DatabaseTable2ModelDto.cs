using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;
using System;

namespace AspNetLayeredArchitectureWithDapper.Entities.Repository
{
    public class DatabaseTable2ModelDto: IDto
    {
        public int Id { get; set; }
        public string TelNo { get; set; }
        public string Pid { get; set; }
    }
}
