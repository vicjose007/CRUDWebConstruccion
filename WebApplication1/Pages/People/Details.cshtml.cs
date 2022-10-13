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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.CRUD_ConstSoftwareContext _context;

        public DetailsModel(WebApplication1.Data.CRUD_ConstSoftwareContext context)
        {
            _context = context;
        }

      public People People { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var people = await _context.People.FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            else 
            {
                People = people;
            }
            return Page();
        }
    }
}
