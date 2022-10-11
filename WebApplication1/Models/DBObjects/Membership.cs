using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DBObjects
{
    public partial class Membership
    {
        public Guid IdMembership { get; set; }
        public string Name { get; set; } = null!;
        public Guid IdMember { get; set; }
        public Guid IdMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Level { get; set; }

        public virtual Member IdMemberNavigation { get; set; } = null!;
        public virtual MembershipType IdMembershipTypeNavigation { get; set; } = null!;
    }
}
