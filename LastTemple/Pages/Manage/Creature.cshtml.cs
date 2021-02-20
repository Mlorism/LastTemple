using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.CRUD;
using LastTemple.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
		[BindProperty]
		public string UrlString { get; set; }
		[BindProperty]
		public int LastToggle { get; set; }
		[BindProperty]
		public int SpellId { get; set; }
		[BindProperty]
		public int ItemId { get; set; }
		public IEnumerable<Creature> Creatures { get; set; }
		public IEnumerable<Weapon> Weapons { get; set; }
		public IEnumerable<Armor> Armors { get; set; }
		public IEnumerable<Item> Items { get; set; }
		public IEnumerable<Spell> Spells { get; set; }

		
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
			await new DeleteCreature(_ctx).Delete(id);

			return RedirectToPage("Creature");
		}

		public async Task<IActionResult> OnPostUpdateCreatureAsync()
		{	
			await new EditCreature(_ctx).UpdateCreature(Creature);

			return RedirectToPage("Creature");
		}

		public async Task<IActionResult> OnPostUpdateWeaponAsync()
		{			
			var weapon = _ctx.Weapons.Find(Creature.Weapon.Id);

			if (weapon == null)	return RedirectToPage("Creature");			

			Creature.Weapon = weapon;

			await new EditCreature(_ctx).UpdateWeapon(Creature);

			return Redirect(UrlString);
		}

		public async Task<IActionResult> OnPostUpdateArmorAsync()
		{
			var armor = _ctx.Armors.Find(Creature.Armor.Id);

			if (armor == null) return RedirectToPage("Creature");

			Creature.Armor = armor;

			await new EditCreature(_ctx).UpdateArmor(Creature);

			return Redirect(UrlString);
		}

		public async Task<IActionResult> OnPostAddItemAsync()
		{	
			await new EditCreature(_ctx).AddItem(Creature, ItemId);

			return Redirect(UrlString);
		}

		public async Task<IActionResult> OnPostDeleteItemAsync(int id)
		{
			Creature = _ctx.Creatures.Include(x => x.Items).SingleOrDefault(x => x.Id == Creature.Id);

			CreatureItem item = Creature.Items.SingleOrDefault(x => x.ItemId == id);

			if (item == null) return RedirectToPage("Creature");

			await new EditCreature(_ctx).DeleteItem(Creature, id);

			return Redirect(UrlString);
		}





	}
}
