using JavaFlorist.Models.EFCore;
using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Message:IEntity
    {
        public int Id { get; set; }
        public string MeContent { get; set; }
        public int? OccasionId { get; set; }

        public virtual Occasion Occasion { get; set; }
    }
}
