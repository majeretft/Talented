using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities.Extensions.Talents;
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
		/// <param name="minLevel">Minimal possible talent level</param>
		/// <param name="maxLevel">Maximal possible talent level</param>
		public TalentLevelChanger(int minLevel, int maxLevel)
		{
			MinLevel = minLevel;
			MaxLevel = maxLevel;
		}

		/// <summary>
		/// Gets or sets minimal possible talent level
		/// </summary>
		public int MinLevel { get; set; }

		/// <summary>
		/// Gets or sets maximal possible talent level
		/// </summary>
		public int MaxLevel { get; set; }

		/// <summary>
		/// Change level for talent
		/// </summary>
		/// <param name="talent">Talent instance</param>
		/// <param name="newLevel">Required level</param>
		public void Change(Talent talent, int newLevel)
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
		public void Change(IEnumerable<Talent> talents, int newLevel)
		{
			if (talents == null)
				throw new ArgumentNullException("talents");

			talents
				.ToList()
				.ForEach(x => Change(x, newLevel));
		}
	}
}
