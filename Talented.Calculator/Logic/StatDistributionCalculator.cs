using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;

namespace Talented.Calculator.Logic
{
	internal class StatDistributionCalculator
	{
		/// <summary>
		/// Apply specific stat value to calculation result
		/// </summary>
		/// <param name="type">Stat type</param>
		/// <param name="value">Stat value</param>
		/// <param name="calculationResult">Current calculation result</param>
		public delegate void ResultValueEditor(StatTypeEnum type, double value, CalculationResult calculationResult);

		/// <summary>
		/// Result modification handler
		/// </summary>
		private ResultValueEditor ApplyStatValue;

		/// <summary>
		/// Initializes a new instance of the <see cref="StatDistributionCalculator" /> class
		/// </summary>
		/// <param name="applyStatValue">Result modification function</param>
		public StatDistributionCalculator(ResultValueEditor applyStatValue)
		{
			ApplyStatValue = applyStatValue;
		}

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
	}
}
