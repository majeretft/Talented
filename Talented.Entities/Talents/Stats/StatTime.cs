namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Adds functionality for time dependency
	/// </summary>
	public class StatTime : Stat, IDependency
	{
		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets additional value for satisfied condition
		/// </summary>
		public double ValueAdditional { get; set; }
	}
}
