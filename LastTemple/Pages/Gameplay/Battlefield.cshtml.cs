using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.CRUD;
using LastTemple.Engine;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Gameplay
{
	public class BattlefieldModel : PageModel
	{
		private readonly ApplicationDbContext _ctx;

		public Creature Hero { get; set; }	
		public List<Creature> Enemies { get; set; }		
		[BindProperty]
		public int SelectedEnemy { get; set; }
		[BindProperty]
		public int SelectedItem { get; set; }
		[BindProperty]
		public int SelectedSpell { get; set; }
		public List<string> BattleLog { get; set; }

		public BattlefieldModel(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}

		public void OnGet()
		{
			BattleStatus.PrepareBattle(); 
			Hero = BattleStatus.Hero;
			Enemies = BattleStatus.Enemies;
			BattleLog = BattleStatus.BattleLog;
		}
		public IActionResult OnPostAttack(int attackerId, int attackType)
		{
			BattleStatus.Attack(attackerId, attackType, SelectedEnemy);			

			return RedirectToPage("BattleField");
		}

		public IActionResult OnPostUseItem(int userId)
		{
			if (SelectedItem != -1)
			{
				BattleStatus.UseItem(userId, SelectedItem);
			}

			return RedirectToPage("BattleField");
		}

		public IActionResult OnPostCastSpell(int userId)
		{
			if (SelectedSpell != -1)
			{
				Spell spell = new GetSpell(_ctx).Get(SelectedSpell);

				if (spell.Type == Enumerators.SpellTypeEnum.Healing)
				{
					BattleStatus.CastSpell(userId, userId, SelectedSpell, _ctx);
				}

				else
				{
					BattleStatus.CastSpell(userId, SelectedEnemy, SelectedSpell, _ctx);
				}
			}

			return RedirectToPage("BattleField");
		}

		public IActionResult OnPostEndTurn()
		{
			BattleStatus.EndTurn();
			return RedirectToPage("BattleField");
		}

	}
}
