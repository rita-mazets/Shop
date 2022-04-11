using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using igi.Data;
using igi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace igi.Areas.Admin.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly igi.Data.ApplicationDbContext _context;

        public IndexModel(igi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
        }
    }
}
