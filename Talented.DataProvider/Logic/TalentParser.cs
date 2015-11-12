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
		/// <summary>
		/// Get new talent instance from Xml
		/// </summary>
		/// <param name="document">Xml configuration</param>
		/// <returns>Talent instance</returns>
		public Talent ParseTalent(XDocument document)
		{
			if (document == null)
				throw new ArgumentNullException("document");

			var element = document.Root;
			var result = new Talent();

			var value = element.Attribute("id").Value;
			result.Id = Guid.Parse(value);

			value = element.Element("might").Value;
			result.Might = int.Parse(value);

			value = element.Element("tier").Value;
			result.Might = int.Parse(value);

			result.Stats = new List<Stat>();
			var statElements = element.Element("stats").Elements().ToList();
			statElements.ForEach(x => result.Stats.Add(ParseStat(x)));

			return result;
		}

		/// <summary>
		/// Parse Xml configuration
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <returns>Stat instance</returns>
		protected Stat ParseStat(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			var dependencyType = StatDependencyEnum.None;
			var dependencyElement = element.Element("dependency");
			if (dependencyElement != null && !string.IsNullOrEmpty(dependencyElement.Value))
				dependencyType = (StatDependencyEnum)Enum.Parse(typeof(StatDependencyEnum), dependencyElement.Value, true);

			switch (dependencyType)
			{
				case StatDependencyEnum.None:
				case StatDependencyEnum.Time:
				case StatDependencyEnum.Score:
					{
						var stat = new Stat();
						FillStat(element, stat);

						if (dependencyType != StatDependencyEnum.None)
							FillDependency(element, stat);

						return stat;
					}

				case StatDependencyEnum.Terrain:
					{
						var stat = new StatTerrain();
						FillStat(element, stat);
						FillDependency(element, stat);
						FillStatTerrain(element, stat);
						return stat;
					}

				default: throw new NotSupportedException(string.Format("{0} is not supported!", dependencyType.ToString()));
			}
		}

		/// <summary>
		/// Fill stat data
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <param name="stat">Stat instance</param>
		protected void FillStat(XElement element, Stat stat)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			if (stat == null)
				throw new ArgumentNullException("stat");

			var value = element.Attribute("growType").Value;
			stat.GrowType = (Stat.GrowTypeEnum)Enum.Parse(typeof(Stat.GrowTypeEnum), value, true);

			value = element.Element("type").Value;
			stat.Type = (Stat.TypeEnum)Enum.Parse(typeof(Stat.TypeEnum), value, true);

			value = element.Element("initialValue").Value;
			stat.ValueInitial = double.Parse(value);

			value = element.Element("grow").Value;
			stat.Grow = double.Parse(value);
		}

		/// <summary>
		/// Fill stat dependency data
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <param name="stat">Stat instance</param>
		protected void FillDependency(XElement element, Stat stat)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			string value;

			value = element.Attribute("dependency").Value;
			stat.Dependency = (StatDependencyEnum)Enum.Parse(typeof(StatDependencyEnum), value, true);

			value = element.Element("valueAdditional").Value;
			stat.ValueAdditional = double.Parse(value);
		}

		/// <summary>
		/// Fill stat terrain data
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <param name="stat">Stat instance</param>
		protected void FillStatTerrain(XElement element, StatTerrain stat)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			var value = element.Attribute("dependency").Value;
			stat.Dependency = (StatDependencyEnum)Enum.Parse(typeof(StatDependencyEnum), value, true);
		}
	}
}
