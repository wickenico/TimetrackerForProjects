using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesRecord.Data;
using TimeRecForProjects.Models;

namespace TimetrackerForProjects.Pages.Records
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesRecord.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesRecord.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Record> Record { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList ProjectNumbers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ProjectNumber { get; set; }

        public async Task OnGetAsync()
        {

            // Use LINQ to get list of genres.
            IQueryable<string> customerQuery = from m in _context.Record
                                               orderby m.Customer
                                               select m.Customer;

            var records = from m in _context.Record
                          select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                records = records.Where(s => s.ProjectNumber.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ProjectNumber))
            {
                records = records.Where(x => x.Customer == ProjectNumber);
            }
            ProjectNumbers = new SelectList(await customerQuery.Distinct().ToListAsync());
            Record = await records.ToListAsync();
        }
    }
}
