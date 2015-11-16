using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Calculator.Logic;
using Talented.Calculator.Logic.Talents;
using Talented.Calculator.Logic.Toons;
using Talented.Entities;
using Talented.Entities.Talents;
using Talented.Entities.Toons;

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
		/// All talents
		/// </summary>
		private IEnumerable<Talent> talentsAll;

		/// <summary>
		/// All toons
		/// </summary>
		private IEnumerable<Toon> toonsAll;

		/// <summary>
		/// Initializes a new instance of the <see cref="Calculator" /> class
		/// </summary>
		/// <param name="toonsAll">All toons</param>
		/// <param name="talentsAll">All talents</param>
		public Calculator(IEnumerable<Toon> toonsAll, IEnumerable<Talent> talentsAll)
		{
			commonFunctions = new CommonFunctions();

			this.talentsAll = talentsAll;
			this.toonsAll = toonsAll;
		}

		/// <summary>
		/// Calculate all data
		/// </summary>
		/// <param name="castle">Current castle context</param>
		/// <param name="battle">Current battle context</param>
		/// <returns>Calculated data</returns>
		public CalculationResult Calculate(CastleRuntime castle, BattleRuntime battle)
		{
			if (castle == null)
				throw new ArgumentNullException("castle");

			var cr = new CalculationResult();

			// Calculate and append stats provided by talents and its bonuses
			var talc = new TalentCalculator(commonFunctions.ApplyStatValue);
			talc.Calculate(GetUsedTalents(castle.TalentLevelDistribution), castle.TalentLevelDistribution, battle, cr);

			// Calculate and append stats provided by toon and talents might
			var toonc = new ToonCalculator(commonFunctions.ApplyStatValue);
			toonc.Calculate(GetUsedToon(castle.Toon), cr);

			// Calculate and append stats distributed in castle (such as guild bonuses, stats for character level, ect.)
			var sdc = new StatDistributionCalculator(commonFunctions.ApplyStatValue);
			sdc.Calculate(castle.CastleStatDistribution, cr);

			// Calculate and append values of dependent properties
			var dpc = new DependentPropertiesCaclulator();
			dpc.Calculate(cr);

			return cr;
		}

		/// <summary>
		/// Get uses talents from all talents
		/// </summary>
		/// <param name="talentLevelDictionary">Used talents levels</param>
		/// <returns>Used talents</returns>
		private IEnumerable<Talent> GetUsedTalents(IDictionary<Guid, byte> talentLevelDictionary)
		{
			if (talentLevelDictionary == null)
				throw new ArgumentNullException("talentLevelDictionary");

			var ids = talentLevelDictionary.Select(x => x.Key);
			return new List<Talent>(talentsAll.Where(x => ids.Contains(x.Id)));
		}

		/// <summary>
		/// Get current character
		/// </summary>
		/// <param name="currentToon">Current character identifier</param>
		/// <returns>Current character</returns>
		private Toon GetUsedToon(Guid currentToon)
		{
			return toonsAll.First(x => x.Id == currentToon);
		}
	}
}
