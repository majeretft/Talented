using System;

namespace Talented.Entities
{
	/// <summary>
	/// Terrain dependency types
	/// </summary>
	[Flags]
	public enum TerrainTypeEnum
	{
		/// <summary>
		/// Independent of terrain (default)
		/// </summary>
		None = 0x0,

		/// <summary>
		/// Native terrain
		/// </summary>
		Native = 0x1,

		/// <summary>
		/// Neutral terrain
		/// </summary>
		Neutral = 0x2,

		/// <summary>
		/// Other team terrain
		/// </summary>
		Foreign = 0x4
	}
}
