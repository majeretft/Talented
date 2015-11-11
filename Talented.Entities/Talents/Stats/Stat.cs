namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Represents a single stat
	/// Contains initial data
	/// </summary>
	public partial class Stat
	{
		/// <summary>
		/// Possible stats types
		/// </summary>
		public enum TypeEnum
		{
			/// <summary>
			/// Default value (valid stat should not have this type)
			/// </summary>
			None,

			/// <summary>
			/// Agility value
			/// </summary>
			Agility,

			/// <summary>
			/// Het points value
			/// </summary>
			Health,

			/// <summary>
			/// Cunning value
			/// </summary>
			Cunning,

			/// <summary>
			/// Magical protection
			/// </summary>
			Will,

			/// <summary>
			/// Physical protection
			/// </summary>
			Durability,

			/// <summary>
			/// HP regeneration value
			/// </summary>
			RegenerationHP,

			/// <summary>
			/// Energy regeneration value
			/// </summary>
			RegenerationMP,

			/// <summary>
			/// Movement speed
			/// </summary>
			Moveement
		}

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
		public TypeEnum Type { get; set; }

		/// <summary>
		/// Gets or sets base value of current stat
		/// </summary>
		public double ValueInitial { get; set; }

		/// <summary>
		/// Gets or sets grow percentage per level of talent
		/// Expected types: double, array[max level]
		/// </summary>
		public dynamic Grow { get; set; }

		/// <summary>
		/// Gets or sets treatment method for Grow property
		/// </summary>
		public GrowTypeEnum GrowType { get; set; }
	}
}
