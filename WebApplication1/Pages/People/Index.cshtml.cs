using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.CRUD_ConstSoftwareContext _context;

        public IndexModel(WebApplication1.Data.CRUD_ConstSoftwareContext context)
        {
            _context = context;
        }

        public IList<People> People { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.People != null)
            {
                People = await _context.People
                .Include(p => p.ClientType)
                .Include(p => p.ContactType).ToListAsync();
            }
        }
    }
}
