using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ardelean_Daria_Labb2.Data;
using Ardelean_Daria_Labb2.Models;

namespace Ardelean_Daria_Labb2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context _context;

        public DetailsModel(Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context context)
        {
            _context = context;
        }

      public Publisher Publisher { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            else 
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}
