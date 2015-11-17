using System;

namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Adds functionality for terrain dependency
	/// </summary>
	public class StatTerrain : Stat
	{
		/// <summary>
		/// Gets or sets terrain dependency type
		/// </summary>
		public TerrainTypeEnum DependencyHandling { get; set; }

		/// <summary>
		/// Append additional value if condition is satisfied
		/// </summary>
		/// <param name="context">Current battle settings</param>
		internal override void ApplyCondition(BattleRuntime context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			if (DependencyHandling.HasFlag(context.TerrainType))
				Value += ValueAdditional;
		}
	}
}
