using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ardelean_Daria_Labb2.Data;
using Ardelean_Daria_Labb2.Models;

namespace Ardelean_Daria_Labb2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context _context;

        public DetailsModel(Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
            .Include(b => b.Author) 
            .Include(b => b.Publisher) 
            .Include(b => b.BookCategories)  
            .ThenInclude(bc => bc.Category) 
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if(Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
