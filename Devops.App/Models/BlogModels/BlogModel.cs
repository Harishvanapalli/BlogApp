using System.ComponentModel.DataAnnotations;

namespace Devops.App.Models.BlogModels
{
    public class BlogModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        [Required]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
