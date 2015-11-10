using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Talented.Entities.Talents;
using Talented.Entities.Talents.Stats;

namespace Talented.DataProvider.Model
{
	/// <summary>
	/// Talent data parser
	/// </summary>
	public class TalentParser
	{
		public Talent ParseTalent(XDocument document)
		{
			if (document == null)
				throw new ArgumentNullException("document");

			var element = document.Root;
			var result = new Talent();

			var idString = element.Attribute("id").Value;
			result.Id = Guid.Parse(idString);

			var mightString = element.Element("might").Value;
			result.Might = int.Parse(mightString);

			var tierString = element.Element("tier").Value;
			result.Might = int.Parse(tierString);

			result.Stats = new List<Stat>();
			var statElements = element.Element("stats").Elements().ToList();
			statElements.ForEach(x => result.Stats.Add(ParseStat(x)));

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private Stat ParseStat(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			var dependencyType = StatDependencyEnum.None;
			var dependencyElement = element.Element("dependency");
			if (dependencyElement != null && !string.IsNullOrEmpty(dependencyElement.Value))
				dependencyType = (StatDependencyEnum) Enum.Parse(typeof(StatDependencyEnum), dependencyElement.Value, true);

			switch (dependencyType)
			{
				case StatDependencyEnum.None: break;
				case StatDependencyEnum.Score: break;
				case StatDependencyEnum.Terrain: break;
				case StatDependencyEnum.Time: break;
				default: throw new NotSupportedException(string.Format("{0} is not supported!", dependencyType.ToString()));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private Stat ParseStatNone(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			var dependencyType = StatDependencyEnum.None;
			var dependencyElement = element.Element("dependency");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private Stat ParseStatScore(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private Stat ParseStatTime(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private Stat ParseStatTerrain(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

		}
	}
}
