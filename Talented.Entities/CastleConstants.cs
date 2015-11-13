namespace Talented.Entities
{
	/// <summary>
	/// Constants for castle
	/// </summary>
	public static class CastleConstants
	{
		/// <summary>
		/// Talent level min
		/// </summary>
		public const byte TalentLevelMin = 1;

		/// <summary>
		/// Talent level max
		/// </summary>
		public const byte TalentLevelMax = 5;

		/// <summary>
		/// Talents in each column (count)
		/// </summary>
		public const byte TalentRows = 6;

		/// <summary>
		/// Talents in each row (count)
		/// </summary>
		public const byte TalentColumns = 6;

		/// <summary>
		/// Gets maximal talents count that possible to use in castle
		/// </summary>
		public static byte GetTalentGridCount
		{
			get
			{
				return TalentRows * TalentColumns;
			}
		}
	}
}
