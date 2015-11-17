using System;

namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Contains dynamic (calculation) data
	/// </summary>
	public partial class Stat
	{
		/// <summary>
		/// Gets or sets current (calculated) value
		/// </summary>
		public double Value { get; set; }

		/// <summary>
		/// Change level for talent
		/// </summary>
		/// <param name="newLevel">Required level</param>
		internal void ApplyLevel(byte newLevel)
		{
			switch (GrowType)
			{
				case GrowTypeEnum.Static:
					Value = ValueInitial + Grow * --newLevel;
					break;
				case GrowTypeEnum.Percent: throw new NotImplementedException("Calculation for Stat.GrowTypeEnum.Percent is not implemented");
				case GrowTypeEnum.Series: throw new NotImplementedException("Calculation for Stat.GrowTypeEnum.Series is not implemented");
			}
		}
	}
}
