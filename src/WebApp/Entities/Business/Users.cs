﻿using Core.Entities.Bases;

namespace Entities
{
    public class Users : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Active { get; set; }
    }
}
