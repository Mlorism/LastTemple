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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CreatureItem>()
				.HasKey(x => new { x.CreatureId, x.ItemId });

			modelBuilder.Entity<CreatureItem>()	
				.HasOne(x => x.Creature)
				.WithMany(x => x.Items)			
				.HasForeignKey(x => x.CreatureId);

			modelBuilder.Entity<CreatureItem>()
				.HasOne(x => x.Item)
				.WithMany(x => x.Creatures)
				.HasForeignKey(x => x.ItemId);
		}


	}
}
