using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities.Talents;
using Talented.Entities.Talents.Stats;

namespace Talented.Calculator.Logic.Talents
{
	/// <summary>
	/// Upgrade talent value depending on level
	/// </summary>
	public class LevelChanger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LevelChanger" /> class
		/// </summary>
		/// <param name="minLevel">Minimal possible talent level</param>
		/// <param name="maxLevel">Maximal possible talent level</param>
		public LevelChanger(int minLevel, int maxLevel)
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
		public void ChangeLevel(Talent talent, int newLevel)
		{
			if (talent == null)
				throw new ArgumentNullException("talent");
			if (newLevel < MinLevel || newLevel > MaxLevel)
				throw new ArgumentOutOfRangeException("newLevel");

			talent.Stats
				.Where(x => x.GrowType != Stat.GrowTypeEnum.None && x.Grow != 0)
				.ToList()
				.ForEach(x =>
				{
					switch (x.GrowType)
					{
						case Stat.GrowTypeEnum.Static:
							x.Value = x.ValueInitial + x.Grow * --newLevel;
							break;
						case Stat.GrowTypeEnum.Percent: throw new NotImplementedException("Calculation for Stat.GrowTypeEnum.Percent is not implemented");
						case Stat.GrowTypeEnum.Series: throw new NotImplementedException("Calculation for Stat.GrowTypeEnum.Series is not implemented");
					}
				});
		}

		/// <summary>
		/// Change level for talents
		/// </summary>
		/// <param name="talents">List of talents</param>
		/// <param name="newLevel">Required level</param>
		public void ChangeLevel(IEnumerable<Talent> talents, int newLevel)
		{
			if (talents == null)
				throw new ArgumentNullException("talents");

			talents
				.ToList()
				.ForEach(x => ChangeLevel(x, newLevel));
		}
	}
}
