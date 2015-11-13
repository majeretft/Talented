using System.Collections.Generic;
using Talented.Calculator.Logic;
using Talented.Calculator.Logic.Talents;
using Talented.Entities;
using Talented.Entities.Talents;

namespace Talented.Calculator.AI
{
	/// <summary>
	/// Calculates overall data
	/// </summary>
	public class Calculator
	{
		/// <summary>
		/// Common functions class instance
		/// </summary>
		private CommonFunctions commonFunctions;

		/// <summary>
		/// Initializes a new instance of the <see cref="Calculator" /> class
		/// </summary>
		public Calculator()
		{
			commonFunctions = new CommonFunctions();
		}

		/// <summary>
		/// Calculate all data
		/// </summary>
		/// <param name="battle">Current batttle context</param>
		/// <param name="castle">Current castle context</param>
		/// <param name="talents">All talents</param>
		/// <returns>Calculated data</returns>
		public CalculationResult Calculate(IEnumerable<Talent> talents, CastleRuntime castle, BattleRuntime battle)
		{
			var cr = new CalculationResult();

			var tc = new TalentCalculator(commonFunctions.ApplyStatValue);
			tc.Calculate(talents, castle, battle, cr);

			return cr;
		}
	}
}
