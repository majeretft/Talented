namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Adds functionality for score dependency
	/// </summary>
	public class StatScore : Stat, IDependency
	{
		/// <summary>
		/// Score dependency types
		/// </summary>
		public enum ScoreTypeEnum
		{
			/// <summary>
			/// Independent of scores (default)
			/// </summary>
			None,

			/// <summary>
			/// Linear score dependency (for each passing interval)
			/// </summary>
			Linear
		}

		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets score dependency type
		/// </summary>
		public ScoreTypeEnum DependencyType { get; set; }

		/// <summary>
		/// Gets or sets additional value if condition is satisfied
		/// </summary>
		public double ValueAdditional { get; set; }
	}
}
