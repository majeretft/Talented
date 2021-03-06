﻿using System;
using System.Collections.Generic;
using System.Linq;
using Talented.Entities;
using Talented.Entities.Talents;
using Talented.Entities.Talents.Stats;

namespace Talented.Calculator.Logic.Talents
{
	/// <summary>
	/// Upgrade talent value depending on environment (terrain type, time, ect.)
	/// </summary>
	internal class TalentConditionRelay
	{
		/// <summary>
		/// Current battle settings
		/// </summary>
		private BattleRuntime context;

		/// <summary>
		/// Initializes a new instance of the <see cref="TalentConditionRelay" /> class
		/// </summary>
		/// <param name="context">Current battle settings</param>
		public TalentConditionRelay(BattleRuntime context)
		{
			this.context = context;
		}

		/// <summary>
		/// Changes talent level
		/// </summary>
		/// <param name="talent">Talent instance</param>
		public void Change(Talent talent)
		{
			if (talent == null)
				throw new ArgumentNullException("talent");

			talent.ApplyCondition(context);
		}

		/// <summary>
		/// Changes level for talents
		/// </summary>
		/// <param name="talents">Talent instance</param>
		public void Change(IEnumerable<Talent> talents)
		{
			if (talents == null)
				throw new ArgumentNullException("talents");

			talents
				.ToList()
				.ForEach(x => Change(x));
		}
	}
}
