using LastTemple.CRUD;
using LastTemple.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class BattleStatus
	{
		private static ApplicationDbContext _ctx; 
		public static Creature Hero { get; set; }
		public static List<Creature> Enemies { get; set; }
		public static List<Creature> Combatants { get; set; }
		public static List<string> BattleLog { get; set; }
		public static bool Status { get; set; } // after the battle shoud be set to false


		public static bool AssignHero(int heroId, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Hero = new GetCreature(_ctx).Get(heroId);

			if (Hero == null) return false;			

			return true;
		}

		public static bool AddEnemy(int enemyId, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Creature enemy = new GetCreature(_ctx).Get(enemyId);

			if (enemy == null) return false;

			if (Enemies == null) Enemies = new List<Creature>();

			Enemies.Add(enemy);

			return true;
		}

		public static bool DeleteEnemy(int enemyId, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Creature enemy = Enemies.FirstOrDefault(x => x.Id == enemyId);		

			if (enemy == null) return false;			

			Enemies.Remove(enemy);

			return true;
		}


		public static void OrderOfBattle()
		{
			if (Combatants == null) Combatants = new List<Creature>();

			Combatants.Add(Hero);
			Combatants.AddRange(Enemies);
			Combatants.OrderBy(x => x.Initiative);

			for (int i = 0; i < Combatants.Count; i++)
			{
				Combatants[i].Id = i;
			}			
		}

		public static void PrepareBattle()
		{
			if (Status == false)
			{
				OrderOfBattle();
				BattleLog = new List<string>();
				Status = true;
			}
			
		}

		public static void AddToLog(int targetId)
		{
			string message = new string($"{targetId}");
			BattleLog.Add(message);
		}

		public static void Attack(int attackerId, int attackType, int targetId)
		{

			//attackType 0 - fast, 1 - normal, 2 - strong

			Creature attacker = Combatants.FirstOrDefault(x => x.Id == attackerId);
			Creature target = Combatants.FirstOrDefault(x => x.Id == targetId);

			attacker.ActionPoints -= attacker.Weapon.ActionCost;
			int attackPower = attacker.Weapon.BaseDamage;

			/// add doge and hit chance
			/// add magic damage

			int resistance = target.DamageResistance;

			if (attackPower > resistance)
			{
				int damage = attackPower - resistance;
				target.HitPoints -= damage;
				string message = new string($"{attacker.Name} trafia {target.Name} zadając mu {damage} puntków obrażeń.");
				BattleLog.Add(message);
			}

			else
			{
				string message = new string($"{attacker.Name} chybia.");
				BattleLog.Add(message);
			}


			/// add magic resistance
		} // Attack

		public static void UseItem(int userId, int itemId)
		{


		} // UseItem

		public static void CastSpell(int userId, int targetId, int spellId)
		{


		} // CastSpell


	}
}
