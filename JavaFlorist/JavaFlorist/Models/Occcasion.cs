﻿using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Occcasion
    {
        public Occcasion()
        {
            Message = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int? StartMonth { get; set; }
        public int? EndMonth { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
