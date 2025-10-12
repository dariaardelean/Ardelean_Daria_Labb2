using System.ComponentModel.DataAnnotations;

namespace Ardelean_Daria_Labb2.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public ICollection<Book>? Books { get; set; }


    }
}
