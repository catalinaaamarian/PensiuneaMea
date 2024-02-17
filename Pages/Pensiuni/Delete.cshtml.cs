using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PensiuneaMea.Data;
using PensiuneaMea.Models;

namespace PensiuneaMea.Pages.Pensiuni
{
    public class DeleteModel : PageModel
    {
        private readonly PensiuneaMea.Data.PensiuneaMeaContext _context;

        public DeleteModel(PensiuneaMea.Data.PensiuneaMeaContext context)
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

            var pensiune = await _context.Pensiune.FirstOrDefaultAsync(m => m.ID == id);

            if (pensiune == null)
            {
                return NotFound();
            }
            else
            {
                Pensiune = pensiune;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensiune = await _context.Pensiune.FindAsync(id);
            if (pensiune != null)
            {
                Pensiune = pensiune;
                _context.Pensiune.Remove(Pensiune);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
