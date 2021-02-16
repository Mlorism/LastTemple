using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LastTemple.Models
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Creature> Creatures { get; set; }
		public DbSet<Weapon> Weapons { get; set; }
		public DbSet<Armor> Armors { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Spell> Spells { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}		

	}
}
