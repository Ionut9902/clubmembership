using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CodeSnippetModel
    {
        public Guid IdCodeSnippet { get; set; }
        public string Title { get; set; } = null!;
        public string ContentCode { get; set; } = null!;
        public Guid IdMember { get; set; }
        public int Revision { get; set; }
        public Guid? IdSnippetPreviousVersion { get; set; }

        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DateTimeAdded { get; set; }
        public bool IsPublished { get; set; }
    }
}
