namespace Ardelean_Daria_Labb2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public String CategoryName { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}
