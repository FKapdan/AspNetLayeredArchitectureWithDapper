﻿using Core.Entities.Bases;

namespace Entities.Business
{
    public class Assets : EntityBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public string Active { get; set; }
    }
}
