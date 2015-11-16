using System;
using System.Collections.Generic;
using Talented.Entities.Talents.Stats;

namespace Talented.Entities.Toons
{
	/// <summary>
	/// Represents a single toon
	/// </summary>
	public class Toon
	{
		/// <summary>
		/// Gets or sets unique identifier
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets list of initial characteristics
		/// </summary>
		public IEnumerable<ToonStat> InitialStats { get; set; }

		/// <summary>
		/// Gets or sets list of initial talents
		/// </summary>
		public IEnumerable<Guid> InitialTalents { get; set; }

		/// <summary>
		/// Gets or sets character main stat for attack power
		/// </summary>
		public StatTypeEnum MainAttackStat { get; set; }
	}
}
