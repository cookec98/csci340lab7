using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChallengeBombs.Data;
using ChallengeBombs.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChallengeBombs.Pages.Bombs
{
    public class IndexModel : PageModel
    {
        private readonly ChallengeBombs.Data.ChallengeBombsContext _context;

        public IndexModel(ChallengeBombs.Data.ChallengeBombsContext context)
        {
            _context = context;
        }

        public IList<Bomb> Bomb { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Difficulty { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BombDifficulty { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> difficultyQuery = from m in _context.Bomb
                                            orderby m.Difficulty
                                            select m.Difficulty;

            var bombs = from m in _context.Bomb
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                bombs = bombs.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BombDifficulty))
            {
                bombs = bombs.Where(x => x.Difficulty == BombDifficulty);
            }
            Difficulty = new SelectList(await difficultyQuery.Distinct().ToListAsync());

            Bomb = await bombs.ToListAsync(); ;
        }
    }
}
