using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.Engine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Gameplay
{
	public class BattlefieldModel : PageModel
	{

		public Creature Hero { get; set; }	
		public List<Creature> Enemies { get; set; }
		[BindProperty]
		public int SelectedEnemy { get; set; }
		public List<string> BattleLog { get; set; }

		public void OnGet()
		{
			BattleStatus.PrepareBattle(); 
			Hero = BattleStatus.Hero;
			Enemies = BattleStatus.Enemies;
			BattleLog = BattleStatus.BattleLog;
		}
		public IActionResult OnPostAttack(int attackerId)
		{
			BattleStatus.Attack(attackerId, SelectedEnemy);		

			return RedirectToPage("BattleField");
		}


	}
}