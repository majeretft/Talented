using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;
using Talented.Entities.Talents;

namespace Talented.Calculator.Logic.Talents
{
	/// <summary>
	/// Calculates stats given by all talents with applied levels and conditions
	/// </summary>
	internal class TalentCalculator
	{
		/// <summary>
		/// Result modification handler
		/// </summary>
		private ResultValueEditor applyStatValue;

		/// <summary>
		/// Initializes a new instance of the <see cref="TalentCalculator" /> class
		/// </summary>
		/// <param name="applyStatValue">Result modification function</param>
		public TalentCalculator(ResultValueEditor applyStatValue)
		{
			this.applyStatValue = applyStatValue;
		}

		/// <summary>
		/// Apply specific stat value to calculation result
		/// </summary>
		/// <param name="type">Stat type</param>
		/// <param name="value">Stat value</param>
		/// <param name="calculationResult">Current calculation result</param>
		public delegate void ResultValueEditor(StatTypeEnum type, double value, CalculationResult calculationResult);

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
				.ForEach(x =>
				{
					result.Might += x.Might;
					x.Stats.ForEach(y => applyStatValue(y.Type, y.Value, result));
				});

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
