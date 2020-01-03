using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Repository.Entities
{
    public class Idea
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
