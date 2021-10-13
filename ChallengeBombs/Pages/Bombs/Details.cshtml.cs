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
    public class DetailsModel : PageModel
    {
        private readonly ChallengeBombs.Data.ChallengeBombsContext _context;

        public DetailsModel(ChallengeBombs.Data.ChallengeBombsContext context)
        {
            _context = context;
        }

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
    }
}
