using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Calculates properties that depends on overall stats value
	/// </summary>
	internal class DependentPropertiesCaclulator
	{
		/// <summary>
		/// Calculate and append dependent properties values to final result
		/// </summary>
		/// <param name="calculationResult">Current calculation result</param>
		/// <param name="mainStat">Main stat</param>
		/// <param name="attackModifier">Attack modifier value (percent)</param>
		public void Calculate(CalculationResult calculationResult, StatTypeEnum mainStat, double attackModifier)
		{
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");

			var armorPenetration = CalculateArmorPenetration(calculationResult.Agility, calculationResult.Cunning);
			calculationResult.ArmorPenetration = armorPenetration;

			var mainStatValue = GetMainStatValue(calculationResult, mainStat);
			var attackPower = CalculateAttackPower(mainStatValue, attackModifier);
			calculationResult.AttackPowerLow += attackPower.LowBorderValue;
			calculationResult.AttackPowerTop += attackPower.TopBorderValue;

			var attackSpeed = CalculateAttackSpeed(calculationResult.Agility);
			calculationResult.AttackSpeed = attackSpeed;

			var critChance = CalculateCritChance(calculationResult.Cunning);
			calculationResult.CritChance = critChance;

			var armor = CalculateResistance(calculationResult.Will, calculationResult.Durability);
			calculationResult.MagicalResistance = armor.First(x => x.Key == StatTypeEnum.Will).Value;
			calculationResult.PhisycalResistance = armor.First(x => x.Key == StatTypeEnum.Durability).Value;
		}

		/// <summary>
		/// Calculate armor penetration based on agility and cunning
		/// </summary>
		/// <param name="agility">Agility value</param>
		/// <param name="cunning">Cunning value</param>
		/// <returns>Armor penetration value</returns>
		private double CalculateArmorPenetration(double agility, double cunning)
		{
			var ap = agility > 400
				? 55.177 + 1.4415 * agility - 7.58925 * agility / Math.Log(agility)
				: 31.867 + 1.922 * agility - 10.119 * agility / Math.Log(agility);

			var cp = cunning > 400
				? 0.40425 * cunning + 2965.05 / (54.47 + cunning) - 2.695
				: 0.539 * cunning + 3953.4 / (54.47 + cunning) - 58.77;

			return ap + cp;
		}

		/// <summary>
		/// Calculate attack damage for final result
		/// </summary>
		/// <param name="mainStatValue">Main stat value (usually strength or intelligence)</param>
		/// <param name="attackModifier">Attack modifier value (percent)</param>
		/// <returns>Low and top attack border values</returns>
		private RangeResult CalculateAttackPower(double mainStatValue, double attackModifier)
		{
			var modifiedSat = mainStatValue * attackModifier / 100;

			return new RangeResult
			{
				LowBorderValue = 0.9 * modifiedSat,
				TopBorderValue = 1.1 * modifiedSat
			};
		}

		/// <summary>
		/// Calculate attack speed for final result
		/// </summary>
		/// <param name="agility">Agility value</param>
		/// <returns>Attack speed</returns>
		private double CalculateAttackSpeed(double agility)
		{
			return agility >= 360 ? 2 : 0.0042 * agility + 0.49;
		}

		/// <summary>
		/// Calculate critical chance for final result 
		/// </summary>
		/// <param name="cunning">Cunning value</param>
		/// <returns>Critical chance</returns>
		private double CalculateCritChance(double cunning)
		{
			return cunning > 400
				? 58.3563 - (5874.6 / (86.17 + 0.862 * cunning))
				: 62.9 - (7832.8 / (86.17 + 0.862 * cunning));
		}

		/// <summary>
		/// Calculate primary and secondary defense values
		/// </summary>
		/// <param name="will">Will value</param>
		/// <param name="durability">Durability value</param>
		/// <returns>Primary and secondary defense values</returns>
		private Dictionary<StatTypeEnum, double> CalculateResistance(double will, double durability)
		{
			var result = new Dictionary<StatTypeEnum, double>(2);

			// TODO: Here should be =< operator? Need to clarify what stat is primary if both are equal!
			var willIsLower = will < durability;

			var primary = !willIsLower ? will : durability;
			var secondary = willIsLower ? will : durability;

			var primaryValue = 0.5355 * primary - 20;
			var secondaryValue = 0.5355 * (primary + secondary) / 2 - 20;

			result.Add(willIsLower ? StatTypeEnum.Will : StatTypeEnum.Durability, secondaryValue);
			result.Add(!willIsLower ? StatTypeEnum.Will : StatTypeEnum.Durability, primaryValue);

			return result;
		}

		/// <summary>
		/// Get value of main stat from calculation result
		/// </summary>
		/// <param name="calculationResult">Current calculation result</param>
		/// <param name="mainStat">Main stat type</param>
		/// <returns>Main stat value</returns>
		private double GetMainStatValue(CalculationResult calculationResult, StatTypeEnum mainStat)
		{
			if (calculationResult == null)
				throw new ArgumentNullException("calculationResult");

			switch (mainStat)
			{
				case StatTypeEnum.Strength: return calculationResult.Strength;
				case StatTypeEnum.Intelligence: return calculationResult.Intelligence;
				default: throw new CalculationException(string.Format("Unsupported mainstat type found: {0}", mainStat.ToString()));
			}
		}

		/// <summary>
		/// Represents a calculation result, containing a border low and top values
		/// </summary>
		private class RangeResult
		{
			/// <summary>
			/// Gets or sets low border value
			/// </summary>
			public double LowBorderValue { get; set; }

			/// <summary>
			/// Gets or sets top border value
			/// </summary>
			public double TopBorderValue { get; set; }
		}
	}
}
