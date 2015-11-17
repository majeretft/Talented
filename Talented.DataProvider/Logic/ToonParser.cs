using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Talented.DataProvider.Logic;
using Talented.Entities;
using Talented.Entities.Talents.Stats;
using Talented.Entities.Toons;

namespace Talented.DataProvider.Model
{
	/// <summary>
	/// Toon initial data parser
	/// </summary>
	internal class ToonParser
	{
		/// <summary>
		/// Get new toon instance from Xml
		/// </summary>
		/// <param name="document">Xml configuration</param>
		/// <returns>Toon instance</returns>
		public Toon ParseToon(XDocument document)
		{
			if (document == null)
				throw new ArgumentNullException("document");

			var element = document.Root;
			var result = new Toon();

			var value = element.Attribute("id").Value;
			result.Id = Guid.Parse(value);

			value = element.Element("mainStat").Value;
			result.MainAttackStat = (StatTypeEnum)Enum.Parse(typeof(StatTypeEnum), value, true);

			value = element.Element("attackModifier").Value;
			result.AttackModifier = double.Parse(value, CultureInfo.InvariantCulture);

			var initialStats = new List<ToonStat>();
			var statParser = new StatParser();
			var statElements = element.Element("stats").Elements().ToList();
			statElements.ForEach(x => initialStats.Add(statParser.ParseToonStat(x)));
			result.InitialStats = initialStats;

			return result;
		}

		/// <summary>
		/// Get list of toons from Xml
		/// </summary>
		/// <param name="documents">Xml configuration list</param>
		/// <returns>Toons list</returns>
		public IEnumerable<Toon> ParseToons(IEnumerable<XDocument> documents)
		{
			if (documents == null)
				throw new ArgumentNullException("documents");

			var result = new List<Toon>();

			documents
				.ToList()
				.ForEach(x => result.Add(ParseToon(x)));

			return result;
		}
	}
}
