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
    public class SpellModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public SpellModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
		public Spell Spell { get; set; }
		public IEnumerable<Spell> Spells { get; set; }

		public void OnGet()
        {
            Spells = new GetSpells(_ctx).Get();
        }

        public async Task<IActionResult> OnPostCreateAsync()
		{
            await new CreateSpell(_ctx).Create(Spell);

            return RedirectToPage("Spell");
		}

        public async Task<IActionResult> OnPostDeleteAsync()
		{
            var item = _ctx.Spells.Find(Spell.Id);

            if (item == null)
			{
                return RedirectToPage("Spell");
            }

            await new DeleteSpell(_ctx).Delete(Spell.Id);

            return RedirectToPage("Spell");

        }

        public async Task<IActionResult> OnPostUpdateAsync()
		{
            var item = _ctx.Spells.Find(Spell.Id);

            if (item == null)
            {
                return RedirectToPage("Spell");
            }

            await new EditSpell(_ctx).Update(Spell);

            return RedirectToPage("Spell");
        }
           
    }
}
