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
		/// Gets or sets talent levels
		/// </summary>
		public IDictionary<Guid, byte> TalentLevelDictionary { get; set; }

		/// <summary>
		/// Gets or sets castle stats distribution
		/// </summary>
		public IDictionary<StatTypeEnum, byte> CastleStatsDictionary { get; set; }
	}
}
