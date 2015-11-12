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
		/// Apply new level for talent
		/// </summary>
		/// <param name="newLevel">Required level</param>
		public void ApplyLevel(int newLevel)
		{
			Stats
				.Where(x => x.GrowType != Stat.GrowTypeEnum.None && x.Grow != 0)
				.ToList()
				.ForEach(x => x.ApplyLevel(newLevel));
		}

		/// <summary>
		/// Apply new condition for talent
		/// </summary>
		/// <param name="context">Condition parameters</param>
		public void ApplyCondition(BattleRuntime context)
		{
			Stats
				.Where(x => x.GrowType != Stat.GrowTypeEnum.None && x.Grow != 0)
				.ToList()
				.ForEach(x => x.ApplyCondition(context));
		}
	}
}
