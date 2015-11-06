namespace Talented.Entity.Model.Entity
{
	/// <summary>
	/// Represents a single stat
	/// </summary>
	public class Stat
	{
		/// <summary>
		/// Gets or sets current stat type
		/// </summary>
		public StatTypeEnum Type { get; set; }

		/// <summary>
		/// Gets or sets base value of current stat
		/// </summary>
		public double Value { get; set; }

		/// <summary>
		/// Gets or sets grow percentage per level of talent
		/// </summary>
		public double Grow { get; set; }
	}
}
