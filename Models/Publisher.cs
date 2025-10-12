namespace Ardelean_Daria_Labb2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public String PublisherName { get; set; }
        public ICollection<Book>   Books { get; set; } //navigation property
    }
}
