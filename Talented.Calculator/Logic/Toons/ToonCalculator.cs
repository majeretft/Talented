using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;
using Talented.Entities.Talents.Stats;
using Talented.Entities.Toons;

namespace Talented.Calculator.Logic.Toons
{
	/// <summary>
	/// Calculates stats given by toon
	/// </summary>
	internal class ToonCalculator
	{
		/// <summary>
		/// Result modification handler
		/// </summary>
		private ResultValueEditor applyStatValue;

		/// <summary>
		/// Initializes a new instance of the <see cref="ToonCalculator" /> class
		/// </summary>
		/// <param name="applyStatValue">Result modification function</param>
		public ToonCalculator(ResultValueEditor applyStatValue)
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
		/// Calculates stats provided by toon at maximal level with known might
		/// </summary>
		/// <param name="currentToon">Current character</param>
		/// <param name="calculationResult">Calculation results, containing calculated talents data</param>
		public void Calculate(Toon currentToon, CalculationResult calculationResult)
		{
			if (currentToon == null)
				throw new ArgumentNullException("currentToon");

			// Append initial stats (independent from might and talents)
			ApplyInitial(currentToon.InitialStats);

			// Append stats given by might (depends on current might value)
			ApplyMight(currentToon.InitialStats, calculationResult.Might);

			// Append all values to final result
			currentToon.InitialStats
				.ToList()
				.ForEach(x => applyStatValue(x.Type, x.Value, calculationResult));
		}

		/// <summary>
		/// Append initial stats (independent from might and talents)
		/// </summary>
		/// <param name="initialStats">Initial stats</param>
		private void ApplyInitial(IEnumerable<ToonStat> initialStats)
		{
			initialStats
				.ToList()
				.ForEach(x => x.Value += x.ValueInitial);
		}

		/// <summary>
		/// Append toon specific characteristics given by might for maximal level (coefficient "M" in might specific formula for maximal level)
		/// </summary>
		/// <param name="initialStats">Might modifier list for corresponding stats</param>
		/// <param name="currentMight">Might provided by used talents</param>
		private void ApplyMight(IEnumerable<ToonStat> initialStats, double currentMight)
		{
			if (initialStats == null)
				throw new ArgumentNullException("initialStats");

			initialStats
				.ToList()
				.ForEach(x =>
				{
					if (x.GrowType == Stat.GrowTypeEnum.None)
						return;
					var q = GetMightModifier(x);
					x.Value += GetMightContribution(x, q, currentMight);
				});
		}

		/// <summary>
		/// Get toon specific coefficient value (coefficient "q" for might specific formula)
		/// </summary>
		/// <param name="initialStat">Current character initial stat</param>
		/// <returns>Might modifier for corresponding stat</returns>
		private double GetMightModifier(ToonStat initialStat)
		{
			if (initialStat == null)
				throw new ArgumentNullException("initialStat");

			double result;

			var growCoeff = initialStat.GrowMight / initialStat.Grow / 100;

			switch (initialStat.Type)
			{
				case StatTypeEnum.Agility:
				case StatTypeEnum.Cunning:
				case StatTypeEnum.Durability:
				case StatTypeEnum.Intelligence:
				case StatTypeEnum.Strength:
				case StatTypeEnum.Will:
					{
						result = 5 * growCoeff;
						break;
					}

				case StatTypeEnum.Health:
				case StatTypeEnum.Mana:
					{
						result = 25 * growCoeff;
						break;
					}

				default: throw new CalculationException(string.Format("Unsupported stat type found: {0}", initialStat.Type.ToString()));
			}

			return result;
		}

		/// <summary>
		/// Gets toon specific characteristics given by might for maximal level (coefficient "M" in might specific formula for maximal level)
		/// </summary>
		/// <param name="initialStat">Current character initial stats</param>
		/// <param name="statModifier">Might modifier for stat</param>
		/// <param name="currentMight">Might provided by used talents</param>
		/// <returns>Might modifier list for corresponding stats</returns>
		private double GetMightContribution(ToonStat initialStat, double statModifier, double currentMight)
		{
			if (initialStat == null)
				throw new ArgumentNullException("initialStat");

			var m = initialStat.Grow * (0.6 * statModifier * (currentMight / 10 - 16) + 36);

			return m;
		}
	}
}
