using Ardelean_Daria_Labb2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace Ardelean_Daria_Labb2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Ardelean_Daria_Labb2Context context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                book.BookCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(Ardelean_Daria_Labb2Context context,
            string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }
            var SelectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
                    (bookToUpdate.BookCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (SelectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(
                            new BookCategory
                            {
                                BookID = bookToUpdate.ID,
                                CategoryID = cat.ID
                            });

                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory bookToRemove
                            = bookToUpdate
                            .BookCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(bookToRemove);
                    }
                }
            }

        }
    }
}
