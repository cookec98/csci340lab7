using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChallengeBombs.Data;
using ChallengeBombs.Models;

namespace ChallengeBombs.Pages.Bombs
{
    public class CreateModel : PageModel
    {
        private readonly ChallengeBombs.Data.ChallengeBombsContext _context;

        public CreateModel(ChallengeBombs.Data.ChallengeBombsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bomb Bomb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bomb.Add(Bomb);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
