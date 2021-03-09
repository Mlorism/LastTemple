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

		static int combatantsCount;
		static int combatantTurn;

		static Random random;		
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
				Combatants[i].Items.OrderByDescending(x => x.Item.Strength);
			}
		} // OrderOfBattle()

		public static void PrepareBattle()
		{
			if (Status == false)
			{
				random = new Random();
				OrderOfBattle();
				BattleLog = new List<string>();
				Status = true;
				combatantsCount = Combatants.Count();
				combatantTurn = 0;
				var first = Combatants.First();
				AddToLog(new string($"Walka rozpoczęta, jako pierwszy uderza {first.Name}"));
			}

			BattleTurn();	 
		} // PrepareBattle()

		public static void AddToLog(string text)
		{			
			BattleLog.Add(text);
		} // AddToLog()

		public static void Attack(int attackerId, int attackType, int targetId)
		{
			//attackType 0 - fast, 1 - normal, 2 - strong

			int chanceLevel = 0;
			bool HitSucces = false;			

			Creature attacker = Combatants.FirstOrDefault(x => x.Id == attackerId);

			if (random.Next(1, 100) == 50)
			{
				targetId = attackerId;

				AddToLog(new string($"{attacker.Name} chybia cel raniąc siebie."));		
			} // fail - 1% chance, the attacker hitting itself

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
					AddToLog($"{attacker.Name} chybia.");					
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
				double criticalSuccess = 1;

				if(random.Next(1, 100) == 50)
				{
					criticalSuccess = 2;
				} // 1% chance to deal double damage

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

				double damage = (attackPower * (100 / (100 + (double)target.DamageResistance)) - attackPower/2) * criticalSuccess;
				double MDamage = (attackMagicPower * (100 / (100 + (double)target.MagicResistance)) - attackPower/2)  * criticalSuccess;
				
				int realDMG = (int)Math.Round(damage);
				int realMDMG = (int)Math.Round(MDamage);

				if (criticalSuccess == 2)
				{
					AddToLog(new string($"Cios jaki wyprowadza {attacker.Name} uderza ze zdwojoną siłą."));
				}

				if (realDMG > 0 && realMDMG > 0)
				{
					target.HitPoints -= realDMG;
					target.HitPoints -= realMDMG;
					AddToLog(new string($"{attacker.Name} trafia {target.Name} zadając {realDMG} fizycznych i {realMDMG} magicznych puntków obrażeń."));
				}
				
				else if (realDMG > 0)
				{
					target.HitPoints -= realDMG;
					AddToLog(new string($"{attacker.Name} trafia {target.Name} zadając {realDMG} puntków obrażeń."));
				}

				else if (realMDMG > 0)
				{
					target.HitPoints -= realMDMG;
					AddToLog(new string($"{attacker.Name} trafia {target.Name} zadając {realMDMG} magicznych puntków obrażeń."));
				}	
								
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

				AddToLog(new string($"{user.Name} używa {item.Item.Name}, które przywraca {item.Item.Strength} punktów zdrowia."));				
			}

			else if (item.Item.ItemType == Enumerators.ItemTypeEnum.Mana)
			{
				user.Mana += item.Item.Strength;

				if(user.Mana > user.MaxMana)
				{
					user.Mana = user.MaxMana;
				}

				AddToLog(new string($"{user.Name} używa {item.Item.Name}, które przywraca {item.Item.Strength} punktów many."));				
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
			Spell spell = new GetSpell(_ctx).Get(spellId);

			user.Mana -= spell.ManaCost;
			user.ActionPoints -= spell.ActionCost;

			if ((spell.Level * 10) >= random.Next(1, 100))
			{
				int selfharm;
				selfharm = (int)Math.Round((double)(spell.Strength / 4));
				user.HitPoints -= selfharm;

				if (spell.Type== Enumerators.SpellTypeEnum.Healing)
				{					
					AddToLog(new string($"Zaklęcie {spell.Name} wymyka się spod kontoli i {user.Name} zamiast uleczyć rani się tracąc {selfharm} punktów życia."));
				}

				else
				{					
					AddToLog(new string($"Zaklęcie {spell.Name} wymyka się spod kontoli i {user.Name} zamiast trafić w przeciwnika rani siebie tracąc {selfharm} punktów życia."));
				}
								
			} /// higher spell level means higher chance for failure and % of dmg done to the caster 0 - 0% , 10 - 10%

			else
			{
				if (userId != targetId)
				{
					target = Combatants.SingleOrDefault(x => x.Id == targetId);
				}

				else
				{
					target = user;
				}

				if (spell.Type == Enumerators.SpellTypeEnum.Healing)
				{
					user.HitPoints += spell.Strength;

					if (user.HitPoints > user.MaxHP)
					{
						user.HitPoints = user.MaxHP;
					}

					AddToLog(new string($"{user.Name} rzuca {spell.Name}, które przywraca {spell.Strength} punktów zdrowia."));
				}

				else
				{
					if (random.Next(0, 100) < target.Willpower)
					{
						AddToLog(new string($"{target.Name} dzięki sile woli odrzuca zaklęcie wychodząc z ataku bez szwanku."));
					}

					else
					{
						int damage = (int)Math.Round((double)(spell.Strength * (100 / (100 + (double)target.MagicResistance))));						

						if (damage > 0)
						{
							target.HitPoints -= damage;
						}

						AddToLog(new string($"{user.Name} rzuca {spell.Name}, które trafia {target.Name} zadając mu {damage} punktów obrażeń."));
					}
				}				

				VerifyStatus(targetId);
			}			


		} // CastSpell()

		public static void EndTurn()
		{
			foreach (var item in Combatants)
			{
				item.ActionPoints = item.MaxAP;
			}

			combatantTurn = (combatantTurn + 1) % combatantsCount;
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

				AddToLog(new string($"W skutek odniesionych ran {target.Name} pada martwy."));				
			}

			if (Hero.Alive == false)
			{
				AddToLog(new string($"To koniec podróży. Oczy {Hero.Name} już na zawsze pozostaną zamknięte. Inni zostaną wysłani, ale czy ktokolwiek odniesie sukces?"));				
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
					AddToLog(new string($"{Hero.Name} rozgromił wszystkich przeciwników, których resztki leżą rozrzucone na ziemii. Walka skończona."));
				}
				
			}
		} // VerifyStatus()

		public static void BattleTurn()
		{
			while(combatantTurn != Hero.Id)
			{
				if (combatantTurn != Hero.Id)
				{
					var fighter = Combatants[combatantTurn];
					if (fighter.Alive != false)
					{
						EnemyLogic(fighter);
					}
				}

				combatantTurn = (combatantTurn + 1) % combatantsCount;
			}

		} // BattleTurn()

		public static void EnemyLogic(Creature fighter)
		{
			double healthRemaining = (fighter.HitPoints / fighter.MaxHP);

			if (fighter.Type == Enumerators.CreatureTypeEnum.Standard)
			{
				while (fighter.ActionPoints > 0)
				{
					#region heal
					if (healthRemaining < 0.5)
					{
						Item chosenItem = new Item();

						if (fighter.Items.Count > 0)
						{
							foreach (var item in fighter.Items)
							{
								if (item.Item.ItemType == Enumerators.ItemTypeEnum.Healing && item.Qty > 0)
								{
									if (item.Item.Strength > chosenItem.Strength)
									{
										chosenItem = item.Item;
									} // chose the strongest healing item
								}
							}

							if (chosenItem.ItemType == Enumerators.ItemTypeEnum.Healing)
							{
								if (fighter.ActionPoints >= chosenItem.ActionCost)
								{
									UseItem(fighter.Id, chosenItem.Id);
								}
							} // if healing item was assign to chosenItem (exist)
						} // if creature have any items						
					} // healing item
					#endregion

					#region chose attack type
					int attackType = -1;

					if (fighter.ActionPoints >= (fighter.Weapon.ActionCost + 1))
					{
						attackType = 2; // strong attack
					}

					else if (fighter.ActionPoints >= fighter.Weapon.ActionCost)
					{
						attackType = 1; // normal attack
					}

					else if (fighter.ActionPoints >= (fighter.Weapon.ActionCost - 1))
					{
						attackType = 0; // fast attack
					}

					if (attackType > -1)
					{
						attackType = random.Next(0, attackType);
						Attack(fighter.Id, attackType, Hero.Id);
					}
					#endregion

					#region AP remain
					if ((fighter.Weapon.ActionCost-1) > fighter.ActionPoints)
					{
						fighter.ActionPoints = 0;
					}
					#endregion

				} // (while) AP remain
			} // CreatureTypeEnum.Standard

			else if (fighter.Type == Enumerators.CreatureTypeEnum.Magical)
			{
				//while (fighter.ActionPoints > 0)
				//{

				//}
			} // CreatureTypeEnum.Magical

			else if (fighter.Type == Enumerators.CreatureTypeEnum.Hybrid)
			{
				//while (fighter.ActionPoints > 0)
				//{

				//}
			} // CreatureTypeEnum.Hybrid

			else
			{
				return; // hero type controlled by the player
			}

		} // EnemyLogic()





	}
}
