using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PensiuneaMea.Data;
using PensiuneaMea.Models;

namespace PensiuneaMea.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly PensiuneaMea.Data.PensiuneaMeaContext _context;

        public IndexModel(PensiuneaMea.Data.PensiuneaMeaContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
