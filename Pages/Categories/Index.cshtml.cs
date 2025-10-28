using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ardelean_Daria_Labb2.Data;
using Ardelean_Daria_Labb2.Models;
using Ardelean_Daria_Labb2.Models.ViewModels;

namespace Ardelean_Daria_Labb2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context _context;

        public IndexModel(Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }


        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;

                // găsim categoria selectată
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();

                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
