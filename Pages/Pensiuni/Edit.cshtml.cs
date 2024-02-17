using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PensiuneaMea.Data;
using PensiuneaMea.Models;

namespace PensiuneaMea.Pages.Pensiuni
{
    public class EditModel : PensiuneCategoriesPageModel
    {
        private readonly PensiuneaMea.Data.PensiuneaMeaContext _context;

        public EditModel(PensiuneaMea.Data.PensiuneaMeaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pensiune Pensiune { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensiune =  await _context.Pensiune.FirstOrDefaultAsync(m => m.ID == id);
            if (pensiune == null)
            {
                return NotFound();
            }
            Pensiune = pensiune;
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pensiune).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PensiuneExists(Pensiune.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PensiuneExists(int id)
        {
            return _context.Pensiune.Any(e => e.ID == id);
        }
    }
}
