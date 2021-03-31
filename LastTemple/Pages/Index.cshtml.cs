using LastTemple.Engine;
using LastTemple.Enumerators;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Pages
{
	public class IndexModel : PageModel
	{
		public GamePhase Phase { get; set; }

		private readonly ApplicationDbContext _ctx;
		public IndexModel(ApplicationDbContext ctx)
		{
			_ctx = ctx;
		}
		public void OnGet()
		{
			Phase = GameplayManager.Phase;			
		}
	}
}
