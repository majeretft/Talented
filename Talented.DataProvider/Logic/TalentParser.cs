using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Talented.DataProvider.Logic;
using Talented.Entities.Talents;
using Talented.Entities.Talents.Stats;

namespace Talented.DataProvider.Model
{
	/// <summary>
	/// Talent data parser
	/// </summary>
	internal class TalentParser
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

			value = element.Element("mightInitial").Value;
			result.MightInitial = int.Parse(value);

			value = element.Element("tier").Value;
			result.Tier = int.Parse(value);

			result.Stats = new List<Stat>();
			var statParser = new StatParser();
			var statElements = element.Element("stats").Elements().ToList();
			statElements.ForEach(x => result.Stats.Add(statParser.ParseTalentStat(x)));

			return result;
		}

		/// <summary>
		/// Get list of talents from Xml
		/// </summary>
		/// <param name="documents">Xml configuration list</param>
		/// <returns>Talents list</returns>
		public IEnumerable<Talent> ParseTalents(IEnumerable<XDocument> documents)
		{
			if (documents == null)
				throw new ArgumentNullException("documents");

			var result = new List<Talent>();

			documents
				.ToList()
				.ForEach(x => result.Add(ParseTalent(x)));

			return result;
		}
	}
}
