
using System.ComponentModel.DataAnnotations;

namespace TiendaWeb.Models
{
    public class CategoryBase
    {

        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class CategoryForList
    {
        public int CategoryID { get; }
        public string Description { get; }

        public CategoryForList(int categoryID, string description)
        {

            CategoryID = categoryID;
            Description = description;
        }
    }
}
