namespace Talented.Entities
{
	/// <summary>
	/// Battle conditions defined in runtime
	/// </summary>
	public class BattleRuntime
	{
		/// <summary>
		/// Gets or sets a value indicating whether that time-depending talent stats value should maximized
		/// </summary>
		public bool IsMaxTime { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether that score-depending talent stats value should maximized
		/// </summary>
		public bool IsMaxScore { get; set; }

		/// <summary>
		/// Gets or sets value for terrain-depending talent stats condition
		/// </summary>
		public TerrainTypeEnum TerrainType { get; set; }
	}
}
