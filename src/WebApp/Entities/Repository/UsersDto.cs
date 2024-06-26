﻿using Core.Entities.Bases;
namespace Entities.Repository
{
    public class UsersDto : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Active { get; set; }
    }
}
