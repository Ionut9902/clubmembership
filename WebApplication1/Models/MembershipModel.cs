using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MembershipModel
    {
        public Guid IdMembership { get; set; }
        public string Name { get; set; } = null!;
        public Guid IdMember { get; set; }
        public Guid IdMembershipType { get; set; }

        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int Level { get; set; }
    }
}
