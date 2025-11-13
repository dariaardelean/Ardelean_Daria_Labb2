using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ardelean_Daria_Labb2.Data;
using Ardelean_Daria_Labb2.Models;

namespace Ardelean_Daria_Labb2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context _context;

        public IndexModel(Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b=> b.Author)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
