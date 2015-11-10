﻿namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Adds functionality for time dependency
	/// </summary>
	public class StatTime : Stat, IDependency
	{
		/// <summary>
		/// Time dependency types
		/// </summary>
		public enum TimeTypeEnum
		{
			/// <summary>
			/// Independent of time (default)
			/// </summary>
			None,

			/// <summary>
			/// Linear time dependency (for each passing interval)
			/// </summary>
			Linear
		}

		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets time dependency type
		/// </summary>
		public TimeTypeEnum DependencyType { get; set; }

		/// <summary>
		/// Gets or sets additional value for satisfied condition
		/// </summary>
		public double ValueAdditional { get; set; }
	}
}
