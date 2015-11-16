using System;
using System.Collections.Generic;
using Talented.Entities.Talents.Stats;

namespace Talented.Entities.Talents
{
	/// <summary>
	/// Represents a single talent
	/// </summary>
	public partial class Talent : IEquatable<Talent>
	{
		/// <summary>
		/// Gets or sets unique identifier
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets initial might value
		/// </summary>
		public double MightInitial { get; set; }

		/// <summary>
		/// Gets or sets row number in the grid
		/// </summary>
		public int Tier { get; set; }

		/// <summary>
		/// Gets or sets stats of current talent
		/// </summary>
		public List<Stat> Stats { get; set; }

		/// <summary>
		/// Check for equality between objects
		/// </summary>
		/// <param name="other">Another object</param>
		/// <returns>True if other equals current</returns>
		public override bool Equals(object other)
		{
			return other is Talent ? Equals(other) : false;
		}

		/// <summary>
		/// Returns hash code
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		/// <summary>
		/// Check for equality between talents
		/// </summary>
		/// <param name="other">Another talent</param>
		/// <returns>True if other equals current</returns>
		public bool Equals(Talent other)
		{
			if (other == null)
				return false;

			return Id == other.Id;
		}
	}
}
