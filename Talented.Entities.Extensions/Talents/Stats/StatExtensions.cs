using System;
using Talented.Entities.Talents.Stats;

namespace Talented.Entities.Extensions.Talents.Stats
{
	/// <summary>
	/// Extension methods for Stat
	/// </summary>
	public static class StatExtensions
	{
		/// <summary>
		/// Change level for talent
		/// </summary>
		/// <param name="stat">Stat instance</param>
		/// <param name="newLevel">Required level</param>
		public static void ApplyLevel(this Stat stat, int newLevel)
		{
			switch (stat.GrowType)
			{
				case Stat.GrowTypeEnum.Static:
					stat.Value = stat.ValueInitial + stat.Grow * --newLevel;
					break;
				case Stat.GrowTypeEnum.Percent: throw new NotImplementedException("Calculation for Stat.GrowTypeEnum.Percent is not implemented");
				case Stat.GrowTypeEnum.Series: throw new NotImplementedException("Calculation for Stat.GrowTypeEnum.Series is not implemented");
			}
		}

		/// <summary>
		/// Applies additional value if condition is satisfied
		/// </summary>
		/// <param name="stat">Stat instance</param>
		/// <param name="context">Current battle settings</param>
		public static void ApplyCondition(this Stat stat, BattleRuntime context)
		{
			// Nothing to do
		}

		/// <summary>
		/// Applies additional value if condition is satisfied
		/// </summary>
		/// <param name="stat">Stat instance</param>
		/// <param name="context">Current battle settings</param>
		public static void ApplyCondition(this StatScore stat, BattleRuntime context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			if (context.IsMaxScore)
				stat.Value += stat.ValueAdditional;
		}

		/// <summary>
		/// Applies additional value if condition is satisfied
		/// </summary>
		/// <param name="stat">Stat instance</param>
		/// <param name="context">Current battle settings</param>
		public static void ApplyCondition(this StatTime stat, BattleRuntime context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			if (context.IsMaxTime)
				stat.Value += stat.ValueAdditional;
		}

		/// <summary>
		/// Applies additional value if condition is satisfied
		/// </summary>
		/// <param name="stat">Stat instance</param>
		/// <param name="context">Current battle settings</param>
		public static void ApplyCondition(this StatTerrain stat, BattleRuntime context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			if (stat.DependencyHandling.HasFlag(context.TerrainType))
				stat.Value += stat.ValueAdditional;
		}
	}
}
