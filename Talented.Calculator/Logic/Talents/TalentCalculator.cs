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
		/// <param name="talentsUsed">Used talents</param>
		/// <param name="talentLevelDistribution">Levels for used talents</param>
		/// <param name="battleContext">Battle conditions description</param>
		/// <param name="calculationResult">Processing calculation result</param>
		public void Calculate(IEnumerable<Talent> talentsUsed, IDictionary<Guid, byte> talentLevelDistribution, BattleRuntime battleContext, CalculationResult calculationResult)
		{
			if (talentLevelDistribution == null)
				throw new ArgumentNullException("talentLevelDistribution");
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");
			if (talentsUsed == null)
				throw new ArgumentNullException("talentsUsed");

			// Append stats given by talent levels
			ApplyCastleContext(talentsUsed, talentLevelDistribution);

			// Append stats given by special conditions (like native land)
			ApplyBattleContext(talentsUsed, battleContext);

			// Append all values to final result
			talentsUsed
				.ToList()
				.ForEach(x =>
				{
					calculationResult.Might += x.Might;
					x.Stats.ForEach(y => applyStatValue(y.Type, y.Value, calculationResult));
				});
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
	}
}
