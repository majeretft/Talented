using System.Linq;
using Talented.Entities.Extensions.Talents.Stats;
using Talented.Entities.Talents;
using Talented.Entities.Talents.Stats;

namespace Talented.Entities.Extensions.Talents
{
	/// <summary>
	/// Extension methods for Talent
	/// </summary>
	public static class TalentExtensions
	{
		/// <summary>
		/// Apply new level for talent
		/// </summary>
		/// <param name="talent">Talent instance</param>
		/// <param name="newLevel">Required level</param>
		public static void ApplyLevel(this Talent talent, int newLevel)
		{
			talent.Stats
				.Where(x => x.GrowType != Stat.GrowTypeEnum.None && x.Grow != 0)
				.ToList()
				.ForEach(x => x.ApplyLevel(newLevel));
		}

		/// <summary>
		/// Apply new condition for talent
		/// </summary>
		/// <param name="talent">Talent instance</param>
		/// <param name="context">Condition parameters</param>
		public static void ApplyCondition(this Talent talent, BattleRuntime context)
		{
			talent.Stats
				.Where(x => x.GrowType != Stat.GrowTypeEnum.None && x.Grow != 0)
				.ToList()
				.ForEach(x => x.ApplyCondition(context));
		}
	}
}
