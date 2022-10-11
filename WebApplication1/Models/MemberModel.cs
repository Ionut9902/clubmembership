namespace WebApplication1.Models
{
    public class MemberModel
    {
        public Guid IdMember { get; set; }
        public string Name { get; set; } = null!;
        public string? Title { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public string? Resume { get; set; }
    }
}
