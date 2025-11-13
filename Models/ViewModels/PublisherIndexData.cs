using Ardelean_Daria_Labb2.Models;
namespace Ardelean_Daria_Labb2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
