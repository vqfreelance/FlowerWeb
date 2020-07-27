using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string MeContent { get; set; }
        public int? OccasionId { get; set; }

        public virtual Occasion Occasion { get; set; }
    }
}
