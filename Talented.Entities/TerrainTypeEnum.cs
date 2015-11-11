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
		None = 0x00,

		/// <summary>
		/// Native terrain
		/// </summary>
		Native = 0x01,

		/// <summary>
		/// Neutral terrain
		/// </summary>
		Neutral = 0x10,

		/// <summary>
		/// Other team terrain
		/// </summary>
		Foreign = 0x11
	}
}
