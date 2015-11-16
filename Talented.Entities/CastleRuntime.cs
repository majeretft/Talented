using System;
using System.Collections.Generic;

namespace Talented.Entities
{
	/// <summary>
	/// Castle conditions defined in runtime
	/// </summary>
	public class CastleRuntime
	{
		/// <summary>
		/// Gets or sets castle stats distribution
		/// </summary>
		public IDictionary<StatTypeEnum, byte> CastleStatDistribution { get; set; }

		/// <summary>
		/// Gets or sets current character
		/// </summary>
		public Guid Toon { get; set; }

		/// <summary>
		/// Gets or sets talent levels
		/// </summary>
		public IDictionary<Guid, byte> TalentLevelDistribution { get; set; }
	}
}
