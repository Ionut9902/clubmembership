using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DBObjects
{
    public partial class Annoucement
    {
        public Guid IdAnnouncement { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime? EventDateTime { get; set; }
        public string? Tags { get; set; }
    }
}
