using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.CRUD;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LastTemple.Controllers;

namespace LastTemple.Pages.Create
{
	public class ArmourModel : PageModel
	{
		private readonly ApplicationDbContext _ctx;

		public ArmourModel(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		[BindProperty]
		public Armor Armor { get; set; }
		[BindProperty]
		public IEnumerable<Armor> Armors { get; set; }
		
		public void OnGet()
		{
			Armors = new GetArmors(_ctx).Get();					
		}
		
		public async Task<IActionResult> OnPostCreateAsync()
		{
			await new CreateArmor(_ctx).Create(Armor);			
			
			return RedirectToPage("Armor");
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			await new DeleteArmor(_ctx).Delete(id);

			return RedirectToPage("Armor");
		}

		public async Task<IActionResult> OnPostUpdateAsync()
		{
			var target = _ctx.Armors.Find(Armor.Id);
			if (target == null)
			{
				return RedirectToPage("Armor");
			}

			target.Name = Armor.Name;
			target.DamageResistance = Armor.DamageResistance;
			target.MagicResistance = Armor.MagicResistance;

			await _ctx.SaveChangesAsync();
			return RedirectToPage("Armor");
		}


	}
}
