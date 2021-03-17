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
	public class BattleManager : PageModel
	{
		private readonly ApplicationDbContext _ctx;

		[BindProperty]
		public Creature Hero { get; set; }
		[BindProperty]
		public IEnumerable<Creature> Heroes { get; set; }
		[BindProperty]
		public Creature Enemy { get; set; }
		[BindProperty]
		public IEnumerable<Creature> EnemiesPool { get; set; }
		public IEnumerable<Creature> SelectedEnemies { get; set; }
		public string BattleReady { get; set; }

		public BattleManager(ApplicationDbContext ctx)
		{
			_ctx = ctx; 
		}

		public void OnGet()
		{
			if (BattleStatus.Hero != null)
			{
				Hero = BattleStatus.Hero;
			}

			if (BattleStatus.Enemies != null)
			{
				SelectedEnemies = BattleStatus.Enemies.ToList();
			}

			else SelectedEnemies = new List<Creature>();

			if (Hero != null && SelectedEnemies.Count() > 0)
			{
				BattleReady = "Yes";
			}

			else BattleReady = "No";

			Heroes = _ctx.Creatures.Where(x => x.Type == Enumerators.CreatureTypeEnum.Hero).ToList();
			EnemiesPool = _ctx.Creatures.ToList().Except(Heroes);
		}

		public IActionResult OnPostAssignHero(int id)
		{
			BattleStatus.AssignHero(id, _ctx);

			return RedirectToPage("Start");
		}

		public IActionResult OnPostAddEnemy(int id)
		{
			BattleStatus.AddEnemy(id, _ctx);

			return RedirectToPage("Start");
		}

		public IActionResult OnPostDeleteEnemy(int id)
		{
			BattleStatus.DeleteEnemy(id, _ctx);

			return RedirectToPage("Start");
		}

		public IActionResult OnPostStartBattle()
		{
			BattleStatus.Status = false;
			return RedirectToPage("BattleField");
		}




	}
}
