using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;
using Talented.Entities.Talents;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Upgrade talent value depending on level
	/// </summary>
	public class TalentLevelChanger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TalentLevelChanger" /> class
		/// </summary>
		public TalentLevelChanger()
		{
			MinLevel = CastleConstants.TalentLevelMin;
			MaxLevel = CastleConstants.TalentLevelMax;
		}

		/// <summary>
		/// Gets or sets minimal possible talent level
		/// </summary>
		public byte MinLevel { get; set; }

		/// <summary>
		/// Gets or sets maximal possible talent level
		/// </summary>
		public byte MaxLevel { get; set; }

		/// <summary>
		/// Change level for talent
		/// </summary>
		/// <param name="talent">Talent instance</param>
		/// <param name="newLevel">Required level</param>
		public void Change(Talent talent, byte newLevel)
		{
			if (talent == null)
				throw new ArgumentNullException("talent");
			if (newLevel < MinLevel || newLevel > MaxLevel)
				throw new ArgumentOutOfRangeException("newLevel");

			talent.ApplyLevel(newLevel);
		}

		/// <summary>
		/// Change level for talents
		/// </summary>
		/// <param name="talents">List of talents</param>
		/// <param name="newLevel">Required level</param>
		public void Change(IEnumerable<Talent> talents, byte newLevel)
		{
			if (talents == null)
				throw new ArgumentNullException("talents");

			talents
				.ToList()
				.ForEach(x => Change(x, newLevel));
		}
	}
}
