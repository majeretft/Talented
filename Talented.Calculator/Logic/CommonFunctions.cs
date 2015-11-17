using System;
using Talented.Entities;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Provides common functions
	/// </summary>
	internal class CommonFunctions
	{
		/// <summary>
		/// Apply specific stat value to calculation result
		/// </summary>
		/// <param name="type">Stat type</param>
		/// <param name="value">Stat value</param>
		/// <param name="calculationResult">Current calculation result</param>
		public void ApplyStatValue(StatTypeEnum type, double value, CalculationResult calculationResult)
		{
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");

			switch (type)
			{
				case StatTypeEnum.Agility:
					calculationResult.Agility += value;
					break;

				// This case is included here to append attack power provided by "icy bow" talent
				case StatTypeEnum.Attack:
					calculationResult.AttackPowerLow += value;
					calculationResult.AttackPowerTop += value;
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
				case StatTypeEnum.Intelligence:
					calculationResult.Intelligence += value;
					break;
				case StatTypeEnum.Mana:
					calculationResult.Mana += value;
					break;
				case StatTypeEnum.Moveement:
					calculationResult.MovementSpeed += value;
					break;
				case StatTypeEnum.RegenerationHP:
					calculationResult.RegenerationHP += value;
					break;
				case StatTypeEnum.RegenerationMP:
					calculationResult.RegenerationMP += value;
					break;
				case StatTypeEnum.Strength:
					calculationResult.Strength += value;
					break;
				case StatTypeEnum.Will:
					calculationResult.Will += value;
					break;
				default:
					throw new CalculationException(string.Format("Found unsupported stat type: {0}", type));
			}
		}
	}
}
