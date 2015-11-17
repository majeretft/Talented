namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Enumeration of possible stat dependencies
	/// </summary>
	public enum StatDependencyEnum
	{
		/// <summary>
		/// Independent (default)
		/// </summary>
		None,

		/// <summary>
		/// Native land
		/// </summary>
		Terrain,

		/// <summary>
		/// Time period
		/// </summary>
		Time,

		/// <summary>
		/// Last hit statistics and score
		/// </summary>
		Score
	}
}
