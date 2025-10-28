using System.Collections.Generic;
using Ardelean_Daria_Labb2.Models;
namespace Ardelean_Daria_Labb2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
