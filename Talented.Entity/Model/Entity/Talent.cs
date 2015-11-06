using System;
using System.Collections.Generic;

namespace Talented.Entity.Model.Entity
{
	/// <summary>
	/// Contains all source information about a talent
	/// </summary>
	public class Talent
	{
		/// <summary>
		/// Gets or sets unique identifier
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets Might value
		/// </summary>
		public double Might { get; set; }

		/// <summary>
		/// Gets or sets row number in the grid
		/// </summary>
		public int Tier { get; set; }

		/// <summary>
		/// Gets or sets stats of current talent
		/// </summary>
		public List<Stat> Stats { get; set; }

		/// <summary>
		/// Gets or sets caption
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Gets or sets description template
		/// </summary>
		public string Description { get; set; }
	}
}
