namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Contains initial data
	/// </summary>
	public partial class Stat
	{
		/// <summary>
		/// Possible grow types
		/// </summary>
		public enum GrowTypeEnum
		{
			/// <summary>
			/// Value is independent of level (default)
			/// </summary>
			None,

			/// <summary>
			/// Value will be multiplied by 1 + Grow per level
			/// </summary>
			Percent,

			/// <summary>
			/// Value will be increased by Grow per level
			/// </summary>
			Static,

			/// <summary>
			/// Value will be increased by Grow[level] per level
			/// </summary>
			Series
		}

		/// <summary>
		/// Gets or sets current stat type
		/// </summary>
		public StatTypeEnum Type { get; set; }

		/// <summary>
		/// Gets or sets base value of current stat
		/// </summary>
		public double ValueInitial { get; set; }

		/// <summary>
		/// Gets or sets grow value per level of talent
		/// Expected types: double, array[max level]
		/// </summary>
		public dynamic Grow { get; set; }

		/// <summary>
		/// Gets or sets treatment method for Grow property
		/// </summary>
		public GrowTypeEnum GrowType { get; set; }
	}
}
