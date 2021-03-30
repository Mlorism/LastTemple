using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.Engine;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Gameplay
{
	public class CharacterCreation : PageModel
	{
		private readonly ApplicationDbContext _ctx;
		public CharacterCreation(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		[BindProperty]		
		public string Name { get; set; }
		[BindProperty]
		public int selectedStrength { get; set; }
		[BindProperty]
		public int selectedWeakness { get; set; }
		[BindProperty]
		public int selectedWeapon { get; set; }
		public void OnGet()
		{

		}

		public IActionResult OnPostCreateHero()
		{
			HeroCreation.Create(Name, selectedStrength, selectedWeakness, selectedWeapon, _ctx);

			GameplayManager.UpdateStatus(_ctx);

			return RedirectToPage(GameplayManager.GetPhase());
		}
	}
}
