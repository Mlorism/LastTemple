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
		private readonly ApplicationDbContext _ctx;

		public CreatureModel(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		[BindProperty]
		public Creature Creature { get; set; }
		public IEnumerable<Creature> Creatures { get; set; }
		public IEnumerable<Weapon> Weapons { get; set; }
		public IEnumerable<Armor> Armors { get; set; }
		public IEnumerable<Item> Items { get; set; }
		public IEnumerable<Spell> Spells { get; set; }

		[BindProperty]
		public int LastToggle { get; set; }
		public void OnGet()
		{
			Creature = new Creature();
			
			Creatures = new GetCreatures(_ctx).Get();
			Weapons = new GetWeapons(_ctx).Get();
			Armors = new GetArmors(_ctx).Get();
			Items = new GetItems(_ctx).Get();
			Spells = new GetSpells(_ctx).Get();
		}

		public void OnGetDetails(int id, int toggle)
		{
			Creature = new GetCreature(_ctx).Get(id);

			LastToggle = toggle;
			Creatures = new GetCreatures(_ctx).Get();
			Weapons = new GetWeapons(_ctx).Get();
			Armors = new GetArmors(_ctx).Get();
			Items = new GetItems(_ctx).Get();
			Spells = new GetSpells(_ctx).Get();
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
