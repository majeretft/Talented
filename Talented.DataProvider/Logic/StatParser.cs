using System;
using System.Globalization;
using System.Xml.Linq;
using Talented.Entities;
using Talented.Entities.Talents.Stats;

namespace Talented.DataProvider.Logic
{
	/// <summary>
	/// Stat data parser
	/// </summary>
	internal class StatParser
	{
		/// <summary>
		/// Parse Xml configuration
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <returns>Stat instance</returns>
		public Stat ParseTalentStat(XElement element)
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
		/// Parse Xml configuration
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <returns>Stat instance</returns>
		public ToonStat ParseToonStat(XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			var stat = new ToonStat();
			FillStat(element, stat);
			FillStatToon(element, stat);

			return stat;
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
			stat.Type = (StatTypeEnum)Enum.Parse(typeof(StatTypeEnum), value, true);

			value = element.Element("valueInitial").Value;
			stat.ValueInitial = double.Parse(value, CultureInfo.InvariantCulture);

			value = element.Element("grow").Value;
			stat.Grow = double.Parse(value, CultureInfo.InvariantCulture);
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
			if (stat == null)
				throw new ArgumentNullException("stat");

			string value;

			value = element.Element("dependency").Value;
			stat.Dependency = (StatDependencyEnum)Enum.Parse(typeof(StatDependencyEnum), value, true);

			value = element.Element("valueAdditional").Value;
			stat.ValueAdditional = double.Parse(value, CultureInfo.InvariantCulture);
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
			if (stat == null)
				throw new ArgumentNullException("stat");

			var value = element.Element("dependency").Value;
			stat.Dependency = (StatDependencyEnum)Enum.Parse(typeof(StatDependencyEnum), value, true);
		}

		/// <summary>
		/// Fill toon stat data
		/// </summary>
		/// <param name="element">Stat node from Xml configuration</param>
		/// <param name="stat">Stat instance</param>
		protected void FillStatToon(XElement element, ToonStat stat)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			if (stat == null)
				throw new ArgumentNullException("stat");

			var value = element.Element("growMight").Value;
			stat.GrowMight = double.Parse(value, CultureInfo.InvariantCulture);
		}
	}
}
