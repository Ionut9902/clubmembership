using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AnnouncementModel
    {
        public Guid IdAnnouncement { get; set; }

        [DisplayFormat(DataFormatString= "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EventDateTime { get; set; }
        public string? Tags { get; set; }
    }
}

