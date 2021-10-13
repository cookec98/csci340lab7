using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChallengeBombs.Data;
using ChallengeBombs.Models;

namespace ChallengeBombs.Pages.Bombs
{
    public class EditModel : PageModel
    {
        private readonly ChallengeBombs.Data.ChallengeBombsContext _context;

        public EditModel(ChallengeBombs.Data.ChallengeBombsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bomb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BombExists(Bomb.ID))
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

        private bool BombExists(int id)
        {
            return _context.Bomb.Any(e => e.ID == id);
        }
    }
}
