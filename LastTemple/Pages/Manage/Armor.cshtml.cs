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
	public class ArmorModel : PageModel
	{
		private readonly ApplicationDbContext _ctx;

		public ArmorModel(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}


		[BindProperty]
		public Armor Armor { get; set; }
		
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
			var item = _ctx.Armors.Find(id);

			if (item == null)
			{
				return RedirectToPage("Armor");
			}

			await new DeleteArmor(_ctx).Delete(id);

			return RedirectToPage("Armor");
		}

		public async Task<IActionResult> OnPostUpdateAsync()
		{
			var item = _ctx.Armors.Find(Armor.Id);

			if (item == null)
			{
				return RedirectToPage("Armor");
			}

			await new EditArmor(_ctx).Update(Armor);

			return RedirectToPage("Armor");
		}

	}
}
