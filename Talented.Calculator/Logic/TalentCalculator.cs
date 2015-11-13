using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;
using Talented.Entities.Talents;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Calculates stats given by all talents with applied levels and conditions
	/// </summary>
	public class TalentCalculator
	{
		/// <summary>
		/// Calculate stats given by talents
		/// </summary>
		/// <param name="talents">All talents</param>
		/// <param name="castleContext">Castle settings</param>
		/// <param name="battleContext">Battle conditions description</param>
		/// <returns>Talents calculation result</returns>
		public CalculationResult Calculate(IEnumerable<Talent> talents, CastleRuntime castleContext, BattleRuntime battleContext)
		{
			if (castleContext == null)
				throw new ArgumentNullException("castleContext");

			var talentsUsed = GetUsedTalents(talents, castleContext.TalentLevelDictionary);

			ApplyCastleContext(talentsUsed, castleContext.TalentLevelDictionary);
			ApplyBattleContext(talentsUsed, battleContext);

			var result = new CalculationResult();

			talentsUsed
				.ToList()
				.ForEach(x => x.Stats.ForEach(y => ApplyStatValue(y.Type, y.Value, result)));

			return result;
		}

		/// <summary>
		/// Apply conditions
		/// </summary>
		/// <param name="talentsUsed">Selected talents</param>
		/// <param name="battleContext">Conditions description</param>
		private void ApplyBattleContext(IEnumerable<Talent> talentsUsed, BattleRuntime battleContext)
		{
			if (talentsUsed == null)
				throw new ArgumentNullException("talentsUsed");
			if (battleContext == null)
				throw new ArgumentNullException("battleContext");

			var condition = new TalentConditionRelay(battleContext);
			condition.Change(talentsUsed);
		}

		/// <summary>
		/// Apply levels
		/// </summary>
		/// <param name="talentsUsed">Selected talents</param>
		/// <param name="talentLevelDictionary">Talents levels</param>
		private void ApplyCastleContext(IEnumerable<Talent> talentsUsed, IDictionary<Guid, byte> talentLevelDictionary)
		{
			if (talentsUsed == null)
				throw new ArgumentNullException("talentsUsed");
			if (talentLevelDictionary == null)
				throw new ArgumentNullException("talentLevelDictionary");

			var level = new TalentLevelChanger();

			var levels = talentLevelDictionary.Values.Distinct();
			var allSameLevel = levels.Count() < 2;

			if (allSameLevel)
			{
				level.Change(talentsUsed, levels.First());
				return;
			}

			talentsUsed
				.ToList()
				.ForEach(x => level.Change(x, talentLevelDictionary.First(y => y.Key == x.Id).Value));
		}

		/*
		/// <summary>
		/// Apply stats distributed in castle
		/// </summary>
		/// <param name="castleStatsDictionary">Stats distributed in castle</param>
		/// <param name="calculationResult">Current calculation result</param>
		private void ApplyCastleStatsDistribution(IDictionary<StatTypeEnum, byte> castleStatsDictionary, CalculationResult calculationResult)
		{
			if (castleStatsDictionary == null)
				throw new ArgumentNullException("castleStatsDictionary");
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");

			castleStatsDictionary
				.ToList()
				.ForEach(y => ApplyStatValue(y.Key, y.Value, calculationResult));
		}
		*/

		/// <summary>
		/// Apply specific stat value to calculation result
		/// </summary>
		/// <param name="type">Stat type</param>
		/// <param name="value">Stat value</param>
		/// <param name="calculationResult">Current calculation result</param>
		private void ApplyStatValue(StatTypeEnum type, double value, CalculationResult calculationResult)
		{
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");

			switch (type)
			{
				case StatTypeEnum.Agility:
					calculationResult.Agility += value;
					break;
				case StatTypeEnum.Attack:
					calculationResult.Attack += value;
					break;
				case StatTypeEnum.Cunning:
					calculationResult.Cunning += value;
					break;
				case StatTypeEnum.Durability:
					calculationResult.Durability += value;
					break;
				case StatTypeEnum.Health:
					calculationResult.Health += value;
					break;
				case StatTypeEnum.HealthSteal:
					calculationResult.HealthSteal += value;
					break;
				case StatTypeEnum.Moveement:
					calculationResult.Moveement += value;
					break;
				case StatTypeEnum.RegenerationHP:
					calculationResult.RegenerationHP += value;
					break;
				case StatTypeEnum.RegenerationMP:
					calculationResult.RegenerationMP += value;
					break;
				case StatTypeEnum.Will:
					calculationResult.Will += value;
					break;
				default:
					throw new CalculationException("Found talent with unsupported type");
			}
		}

		/// <summary>
		/// Get uses talents from all talents
		/// </summary>
		/// <param name="talents">All talents</param>
		/// <param name="talentLevelDictionary">Used talents levels</param>
		/// <returns>Used talents</returns>
		private IEnumerable<Talent> GetUsedTalents(IEnumerable<Talent> talents, IDictionary<Guid, byte> talentLevelDictionary)
		{
			if (talents == null)
				throw new ArgumentNullException("talents");
			if (talentLevelDictionary == null)
				throw new ArgumentNullException("talentLevelDictionary");

			var ids = talentLevelDictionary.Select(x => x.Key);
			return new List<Talent>(talents.Where(x => ids.Contains(x.Id)));
		}
	}
}
