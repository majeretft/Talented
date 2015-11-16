using System;
using Talented.Entities;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Calculates properties that depends on overal stats value
	/// </summary>
	internal class DependentPropertiesCaclulator
	{
		/// <summary>
		/// Calculate and append dependent properties values to final result
		/// </summary>
		/// <param name="calculationResult">Current calculation result</param>
		public void Calculate(CalculationResult calculationResult, StatTypeEnum mainStat)
		{
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");


		}

		private void ApplyAttackPower()
		{
		}

		private void ApplyMagicalResistance()
		{
		}

		private void ApplyPhisycalResistance()
		{
		}
	}
}
