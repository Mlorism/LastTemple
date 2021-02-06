using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.CRUD;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Create
{
    public class CreatureModel : PageModel
    {
		private ApplicationDbContext _ctx;

		public CreatureModel(ApplicationDbContext ctx)
		{
            _ctx = ctx;
		}

        [BindProperty]
        public Creature Creature { get; set; }
		public IEnumerable<Creature> Creatures { get; set; }

		public void OnGet()
        {
            Creatures = new GetCreatures(_ctx).Get();
        }

        public async Task<IActionResult> OnPostCreateAsync()
		{
            await new CreateCreature(_ctx).Create(Creature);

            return RedirectToPage("Creature");
		}

        public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
            var item = _ctx.Creatures.Find(id);

            if (item == null)
			{
                return RedirectToPage("Creature");
            }

            await new DeleteCreature(_ctx).Delete(id);

            return RedirectToPage("Creature");
        }

        public async Task<IActionResult> OnPostUpdateAsync()
		{
            var item = _ctx.Creatures.Find(Creature.Id);

            if (item == null)
            {
                return RedirectToPage("Creature");
            }

            await new EditCreature(_ctx).Update(Creature);

            return RedirectToPage("Creature");
        }










    }
}
