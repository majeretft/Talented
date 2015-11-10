using System;
using System.Xml.Linq;
using Talented.Entities.Talents.Stats;

namespace Talented.DataProvider.Model
{
	/// <summary>
	/// Talent data parser
	/// </summary>
	public class TalentParser
	{
		public Stat ParseStat(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");


		}
	}
}
