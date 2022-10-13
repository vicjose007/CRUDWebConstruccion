using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.CRUD_ConstSoftwareContext _context;

        public CreateModel(WebApplication1.Data.CRUD_ConstSoftwareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientTypeId"] = new SelectList(_context.ClientType, "Id", "Name");
        ViewData["ContactTypeId"] = new SelectList(_context.ContactType, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public People People { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.People.Add(People);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
