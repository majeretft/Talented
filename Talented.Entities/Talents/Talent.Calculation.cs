using System;
using System.Linq;
using Talented.Entities.Talents.Stats;

namespace Talented.Entities.Talents
{
	/// <summary>
	/// Added functionality for calculation
	/// </summary>
	public partial class Talent
	{
		/// <summary>
		/// Gets or sets calculated might value
		/// </summary>
		public double Might { get; set; }

		/// <summary>
		/// Change level of a talent
		/// </summary>
		/// <param name="newLevel">Required level</param>
		public void ApplyLevel(byte newLevel)
		{
			Might = MightInitial + CastleConstants.MightGrow * MightInitial * (newLevel - 1);

			Stats
				.Where(x => x.GrowType != Stat.GrowTypeEnum.None && x.Grow != 0)
				.ToList()
				.ForEach(x => x.ApplyLevel(newLevel));
		}

		/// <summary>
		/// Append additional value if condition is satisfied
		/// </summary>
		/// <param name="context">Condition parameters</param>
		public void ApplyCondition(BattleRuntime context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			Stats
				.Where(x => x.ValueAdditional != 0)
				.ToList()
				.ForEach(x => x.ApplyCondition(context));
		}
	}
}
