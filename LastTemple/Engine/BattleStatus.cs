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
		public static Random random;
		public static bool Status { get; set; } // after the battle should be set to false

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
			Combatants = new List<Creature>();

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
				random = new Random();
				OrderOfBattle();
				BattleLog = new List<string>();
				Status = true;
			}
			
		}

		public static void AddToLog(string text)
		{
			string message = new string(text);
			BattleLog.Add(message);
		}

		public static void Attack(int attackerId, int attackType, int targetId)
		{
			//attackType 0 - fast, 1 - normal, 2 - strong

			int chanceLevel = 0;
			bool HitSucces = false;
			string message = "message text";

			Creature attacker = Combatants.FirstOrDefault(x => x.Id == attackerId);

			if (random.Next(0, 100) == 1)
			{
				targetId = attackerId;

				message = new string($"{attacker.Name} chybia krytycznie cel raniąc siebie.");
				BattleLog.Add(message);							

			} // fail - the attacker hitting itself

			Creature target = Combatants.FirstOrDefault(x => x.Id == targetId);			

			if (attackType == 0)
			{
				attacker.ActionPoints -= (attacker.Weapon.ActionCost - 1);
			}

			else if (attackType == 1)
			{
				attacker.ActionPoints -= attacker.Weapon.ActionCost;
			}

			else
			{
				attacker.ActionPoints -= (attacker.Weapon.ActionCost + 1);
			}

			#region hit chance
			if (targetId != attackerId)
			{
				if (attackType == 0)
				{
					chanceLevel = attacker.Weapon.HitChance + 10 + attacker.Agility - target.Agility; // +10 as fast attack is more likely to hit						
				}

				else if (attackType == 1)
				{
					chanceLevel = attacker.Weapon.HitChance + attacker.Agility - target.Agility;
				}

				else
				{
					chanceLevel = attacker.Weapon.HitChance - 10 + attacker.Agility - target.Agility; // -10 as strong attack is less likely to hit						
				}

				int calculateHit = random.Next(0, 100);

				if (calculateHit <= chanceLevel)
				{
					HitSucces = true;
				}

				else
				{
					HitSucces = false;
					message = new string($"{attacker.Name} chybia.");
					BattleLog.Add(message);
				}
			}

			else
			{
				HitSucces = true;
			}
			
			#endregion

			if(HitSucces == true)
			{				
				double attackPower = (double)attacker.Weapon.BaseDamage;
				double attackMagicPower = (double)attacker.Weapon.MagicDamage;
				
				if (attackType == 0)
				{
					attackPower *= (double)(attacker.Strength / 4) * (random.NextDouble() * (0.8 - 0.65) + 0.65); 
					attackMagicPower *= (double)(attacker.Strength / 4) * (random.NextDouble() * (0.8 - 0.65) + 0.65);
				}

				else if (attackType == 1)
				{
					attackPower *= (double)(attacker.Strength / 4) * (random.NextDouble() * (1.1 - 0.9) + 0.9);
					attackMagicPower *= (double)(attacker.Strength / 4) * (random.NextDouble() * (1.1 - 0.9) + 0.9);
				}

				else
				{
					attackPower *= (double)(attacker.Strength / 4) * (random.NextDouble() * (1.35 - 1.2) + 1.2);
					attackMagicPower *= (double)(attacker.Strength / 4) * (random.NextDouble() * (1.35 - 1.2) + 1.2);
				}

				double damage = attackPower * (100 / (100 + (double)target.DamageResistance)) - attackPower/2;
				double MDamage = attackMagicPower * (100 / (100 + (double)target.MagicResistance)) - attackPower/2;
				
				int realDMG = (int)Math.Round(damage);
				int realMDMG = (int)Math.Round(MDamage);				

				if (realDMG > 0 && realMDMG > 0)
				{
					target.HitPoints -= realDMG;
					target.HitPoints -= realMDMG;
					message = new string($"{attacker.Name} trafia {target.Name} zadając {realDMG} fizycznych i {realMDMG} magicznych puntków obrażeń.");
				}
				
				else if (realDMG > 0)
				{
					target.HitPoints -= realDMG;
					message = new string($"{attacker.Name} trafia {target.Name} zadając {realDMG} puntków obrażeń.");
				}

				else if (realMDMG > 0)
				{
					target.HitPoints -= realMDMG;
					message = new string($"{attacker.Name} trafia {target.Name} zadając {realMDMG} magicznych puntków obrażeń.");
				}			
								
				BattleLog.Add(message);	
								
				VerifyStatus(targetId);
			}
		} // Attack()

		public static void UseItem(int userId, int itemId)
		{
			Creature user = Combatants.SingleOrDefault(x => x.Id == userId);
			CreatureItem item = user.Items.SingleOrDefault(x => x.ItemId == itemId);					

			if (item.Item.ItemType == Enumerators.ItemTypeEnum.Healing)
			{
				user.HitPoints += item.Item.Strength;

				if (user.HitPoints > user.MaxHP)
				{
					user.HitPoints = user.MaxHP;
				}

				string message = new string($"{user.Name} używa {item.Item.Name}, które przywraca {item.Item.Strength} punktów zdrowia.");
				BattleLog.Add(message);
			}

			else if (item.Item.ItemType == Enumerators.ItemTypeEnum.Mana)
			{
				user.Mana += item.Item.Strength;

				if(user.Mana > user.MaxMana)
				{
					user.Mana = user.MaxMana;
				}

				string message = new string($"{user.Name} używa {item.Item.Name}, które przywraca {item.Item.Strength} punktów many.");
				BattleLog.Add(message);
			}

			user.ActionPoints -= item.Item.ActionCost;

			if (item.Qty == 1)
			{
				user.Items.Remove(item);
			}

			else
			{
				item.Qty -= 1;
			}

		} // UseItem()

		public static void CastSpell(int userId, int targetId, int spellId, ApplicationDbContext ctx)
		{
			_ctx = ctx;

			Creature user = Combatants.SingleOrDefault(x => x.Id == userId);
			Creature target;

			if (userId != targetId)
			{
				target = Combatants.SingleOrDefault(x => x.Id == targetId);
			}
			
			else
			{
				target = user;
			}

			Spell spell = new GetSpell(_ctx).Get(spellId);

			if (spell.Type == Enumerators.SpellTypeEnum.Healing)
			{
				user.HitPoints += spell.Strength;

				if (user.HitPoints > user.MaxHP)
				{
					user.HitPoints = user.MaxHP;
				}

				string message = new string($"{user.Name} rzuca {spell.Name}, które przywraca {spell.Strength} punktów zdrowia.");
				BattleLog.Add(message);
			}

			else
			{
				int damage = spell.Strength - target.MagicResistance;

				if (damage > 0)
				{
					target.HitPoints -= damage;
				}

				string message = new string($"{user.Name} rzuca {spell.Name}, które trafia {target.Name} zadając mu {damage} punktów obrażeń.");
				BattleLog.Add(message);

				VerifyStatus(targetId);
			}

			user.Mana -= spell.ManaCost;
			user.ActionPoints -= spell.ActionCost;

			// dodge chance and spell succes rate?


		} // CastSpell()


		public static void EndTurn()
		{
			foreach (var item in Combatants)
			{
				item.ActionPoints = item.MaxAP;
			}
		} // EndTurn()

		public static void VerifyStatus(int targetId)
		{
			Creature target = Combatants.FirstOrDefault(x => x.Id == targetId);

			if (target.HitPoints < 1)
			{	
				target.Alive = false;

				if (target.HitPoints < 0)
				{
					target.HitPoints = 0;
				}

				string message = new string($"W skutek odniesionych ran {target.Name} pada martwy.");

				BattleLog.Add(message);
			}

			if (Hero.Alive == false)
			{
				string message = new string($"To koniec podróży. Oczy {Hero.Name} już na zawsze pozostaną zamknięte. Inni zostaną wysłani, ale czy ktokolwiek odniesie sukces?");

				BattleLog.Add(message);
			}

			else
			{
				int deadCount = 0;

				foreach (var creature in Enemies)
				{
					if (creature.Alive == false)
					{
						deadCount++;
					}
				}

				if(Enemies.Count == deadCount)
				{
					string message = new string($"{Hero.Name} rozgromił wszystkich przeciwników, których resztki leżą rozrzucone na ziemii. Walka skończona.");

					BattleLog.Add(message);
				}
				
			}
		} // VerifyStatus()


	}
}
