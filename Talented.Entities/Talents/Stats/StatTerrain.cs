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
		/// Terrain dependency types
		/// </summary>
		[Flags]
		public enum TerrainTypeEnum
		{
			/// <summary>
			/// Independent of terrain (default)
			/// </summary>
			None,

			/// <summary>
			/// Native terrain
			/// </summary>
			Native,

			/// <summary>
			/// Neutral terrain
			/// </summary>
			Neutral,

			/// <summary>
			/// Other team terrain
			/// </summary>
			Foreign
		}

		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets terrain dependency type
		/// </summary>
		public TerrainTypeEnum DependencyType { get; set; }

		/// <summary>
		/// Gets or sets additional value for condition
		/// </summary>
		public double ValueAdditional { get; set; }
	}
}
