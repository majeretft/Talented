using Talented.Entities;

namespace Talented.Calculator.Logic
{
	internal class ToonCalculator
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
		/// Initializes a new instance of the <see cref="ToonCalculator" /> class
		/// </summary>
		/// <param name="applyStatValue">Result modification function</param>
		public ToonCalculator(ResultValueEditor applyStatValue)
		{
			ApplyStatValue = applyStatValue;
		}
	}
}
