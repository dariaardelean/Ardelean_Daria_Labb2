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
    public class IndexModel : PageModel
    {
        private readonly Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context _context;

        public IndexModel(Ardelean_Daria_Labb2.Data.Ardelean_Daria_Labb2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }
    }
}
