using System;

namespace Talented.Entities.Talents.Stats
{
	/// <summary>
	/// Added functionality for dependency
	/// </summary>
	public partial class Stat
	{
		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets additional value if condition is satisfied
		/// </summary>
		public double ValueAdditional { get; set; }

		/// <summary>
		/// Applies additional value if condition is satisfied
		/// </summary>
		/// <param name="context">Current battle settings</param>
		internal virtual void ApplyCondition(BattleRuntime context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			if (context.IsMaxScore)
				Value += ValueAdditional;
		}
	}
}
