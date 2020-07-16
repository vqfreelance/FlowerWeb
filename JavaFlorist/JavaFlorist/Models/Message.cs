using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string MeContent { get; set; }
        public int? OccasionId { get; set; }

        public virtual Occcasion Occasion { get; set; }
    }
}
