using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChallengeBombs.Data;
using ChallengeBombs.Models;

namespace ChallengeBombs.Pages.Bombs
{
    public class DeleteModel : PageModel
    {
        private readonly ChallengeBombs.Data.ChallengeBombsContext _context;

        public DeleteModel(ChallengeBombs.Data.ChallengeBombsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bomb Bomb { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bomb = await _context.Bomb.FirstOrDefaultAsync(m => m.ID == id);

            if (Bomb == null)
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

            Bomb = await _context.Bomb.FindAsync(id);

            if (Bomb != null)
            {
                _context.Bomb.Remove(Bomb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
