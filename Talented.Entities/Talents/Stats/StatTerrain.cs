using System;

namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Adds functionality for terrain dependency
	/// </summary>
	public class StatTerrain : Stat, IDependency
	{
		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets terrain dependency type
		/// </summary>
		public TerrainTypeEnum DependencyHandling { get; set; }

		/// <summary>
		/// Gets or sets additional value for condition
		/// </summary>
		public double ValueAdditional { get; set; }
	}
}
