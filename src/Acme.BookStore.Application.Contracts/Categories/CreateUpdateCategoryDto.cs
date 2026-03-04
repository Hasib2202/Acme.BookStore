using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Categories
{
    public class CreateUpdateCategoryDto 
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
