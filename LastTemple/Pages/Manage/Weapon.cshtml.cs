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
    public class WeaponModel : PageModel
    {
		private ApplicationDbContext _ctx;

        [BindProperty]
		public Weapon Weapon { get; set; }
		public IEnumerable<Weapon> Weapons { get; set; }

		public WeaponModel(ApplicationDbContext ctx)
		{
            _ctx = ctx;
		}
        public void OnGet()
        {
            Weapons = new GetWeapons(_ctx).Get();
        }

        public async Task<IActionResult> OnPostCreateAsync()
		{
            await new CreateWeapon(_ctx).Create(Weapon);

            return RedirectToPage("Weapon");
		}

        public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
            var item = _ctx.Weapons.Find(id);

            if (item == null)
			{
                return RedirectToPage("Weapon");
            }

            await new DeleteWeapon(_ctx).Delete(id);

            return RedirectToPage("Weapon");
        }

        public async Task<IActionResult> OnPostUpdateAsync()
		{
            var item = _ctx.Weapons.Find(Weapon.Id);

            if (item == null)
            {
                return RedirectToPage("Weapon");
            }

            await new EditWeapon(_ctx).Update(Weapon);

            return RedirectToPage("Weapon");
        }

    }
}
