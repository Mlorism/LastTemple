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
	public class ArmourModel : PageModel
	{
		private readonly ApplicationDbContext _ctx;

		public ArmourModel(ApplicationDbContext ctx)
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
		
		public async Task<IActionResult> OnPostAsync()
		{
			await new CreateArmor(_ctx).Create(Armor);			
			
			return RedirectToPage("Armour");
		}

		public async Task<IActionResult> OnPostDelete(int id)
		{
			await new DeleteArmor(_ctx).Delete(id);

			return RedirectToPage("Armour");
		}



	}
}
