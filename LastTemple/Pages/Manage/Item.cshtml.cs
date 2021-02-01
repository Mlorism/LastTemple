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
    public class ItemModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public ItemModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
		public Item Item { get; set; }
		public IEnumerable<Item> Items { get; set; }


		public void OnGet()
        {
            Items = new GetItems(_ctx).Get();
        }

        public async Task<IActionResult> OnPostCreateAsync()
		{
            await new CreateItem(_ctx).Create(Item);

            return RedirectToPage("Item");
		}

        public async Task<IActionResult> OnPostDeleteAsync()
		{
            var item = _ctx.Items.Find(Item.Id);

            if(item == null)
			{
                return RedirectToPage("Item");
            }

            await new DeleteItem(_ctx).Delete(Item.Id);
            return RedirectToPage("Item");
        }

        public async Task<IActionResult> OnPostUpdateAsync()
		{
            var item = _ctx.Items.Find(Item.Id);

            if (item == null)
            {
                return RedirectToPage("Item");
            }

            await new EditItem(_ctx).Update(Item);

            return RedirectToPage("Item");
        }


    }
}
