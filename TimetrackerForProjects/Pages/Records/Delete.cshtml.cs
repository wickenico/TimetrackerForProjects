using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesRecord.Data;
using TimeRecForProjects.Models;

namespace TimetrackerForProjects.Pages.Records
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesRecord.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesRecord.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Record Record { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = await _context.Record.FirstOrDefaultAsync(m => m.ID == id);

            if (Record == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = await _context.Record.FindAsync(id);

            if (Record != null)
            {
                _context.Record.Remove(Record);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
