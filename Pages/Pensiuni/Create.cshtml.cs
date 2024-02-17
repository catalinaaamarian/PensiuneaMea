using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PensiuneaMea.Data;
using PensiuneaMea.Models;

namespace PensiuneaMea.Pages.Pensiuni
{
    public class CreateModel : PageModel
    {
        private readonly PensiuneaMea.Data.PensiuneaMeaContext _context;

        public CreateModel(PensiuneaMea.Data.PensiuneaMeaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Pensiune Pensiune { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pensiune.Add(Pensiune);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
