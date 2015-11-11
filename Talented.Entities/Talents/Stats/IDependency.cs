namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Dependency of external conditions
	/// </summary>
	public interface IDependency
	{
		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets additional value for satisfied condition
		/// </summary>
		double ValueAdditional { get; set; }
	}
}
