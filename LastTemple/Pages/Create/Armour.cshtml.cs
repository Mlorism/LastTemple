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
		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();				
			}

			await new CreateArmor(_ctx).Create(Armor);
			return Page();
		}
	}
}
