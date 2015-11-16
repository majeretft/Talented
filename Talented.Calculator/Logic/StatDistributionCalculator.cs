using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Appends stats distribution for toon levels and guild progress
	/// </summary>
	internal class StatDistributionCalculator
	{
		/// <summary>
		/// Result modification handler
		/// </summary>
		private ResultValueEditor applyStatValue;

		/// <summary>
		/// Initializes a new instance of the <see cref="StatDistributionCalculator" /> class
		/// </summary>
		/// <param name="applyStatValue">Result modification function</param>
		public StatDistributionCalculator(ResultValueEditor applyStatValue)
		{
			this.applyStatValue = applyStatValue;
		}

		/// <summary>
		/// Append specific stat value to calculation result
		/// </summary>
		/// <param name="type">Stat type</param>
		/// <param name="value">Stat value</param>
		/// <param name="calculationResult">Current calculation result</param>
		public delegate void ResultValueEditor(StatTypeEnum type, double value, CalculationResult calculationResult);

		/// <summary>
		/// Append stats distributed in castle
		/// </summary>
		/// <param name="castleStatsDictionary">Stats distributed in castle</param>
		/// <param name="calculationResult">Current calculation result</param>
		public void ApplyCastleStatsDistribution(IDictionary<StatTypeEnum, byte> castleStatsDictionary, CalculationResult calculationResult)
		{
			if (castleStatsDictionary == null)
				throw new ArgumentNullException("castleStatsDictionary");
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");

			castleStatsDictionary
				.ToList()
				.ForEach(y => applyStatValue(y.Key, y.Value, calculationResult));
		}
	}
}
