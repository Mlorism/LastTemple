using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTemple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastTemple.Pages.Create
{
    public class WeaponModel : PageModel
    {
		private ApplicationDbContext _ctx;

		public Weapon Weapon { get; set; }
		public IEnumerable<Weapon> Weapons { get; set; }

		public WeaponModel(ApplicationDbContext ctx)
		{
            _ctx = ctx;
		}
        public void OnGet()
        {

        }
    }
}
