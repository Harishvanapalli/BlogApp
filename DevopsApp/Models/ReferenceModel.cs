using System.ComponentModel.DataAnnotations;

namespace DevopsApp.Models
{
    public class ReferenceModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
