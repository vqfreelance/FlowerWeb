using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Occcasion:IEntity
    {
        public Occcasion()
        {
            Message = new HashSet<Message>();
            OccBouquet = new HashSet<OccBouquet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int? StartMonth { get; set; }
        public int? EndMonth { get; set; }

        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<OccBouquet> OccBouquet { get; set; }
    }
}
