using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Talented.Entity.Model.Entity;

namespace Talented.Repo.Model
{
	/// <summary>
	/// XML document parser
	/// </summary>
	public class TalentParser
	{
		/// <summary>
		/// Parse a talent information
		/// </summary>
		/// <param name="talentDocument">Talent definition XML document</param>
		/// <returns>New talent instance</returns>
		public Talent ParseTalent(XDocument talentDocument)
		{
			if (talentDocument == null)
				throw new ArgumentNullException();

			var result = new Talent
			{
				//Id = new Guid(talentDocument.XPathEvaluate(@"string(talent/@id)") as string),
				//Caption = talentDocument.XPathEvaluate(@"string(talent/caption)") as string,
				//Description = talentDocument.XPathEvaluate(@"string(talent/description)") as string,
				Might = (double)talentDocument.XPathEvaluate(@"number(talent/might)"),
				Tier = (int)talentDocument.XPathEvaluate(@"number(talent/tier)"),
				Stats = talentDocument.XPathSelectElements(@"talent/stats/stat")
					.Select(x => new Stat
					{
						Grow = (double)x.XPathEvaluate("number(stat/@grow)"),
						//Type = (StatTypeEnum)Enum.Parse(typeof(StatTypeEnum), x.XPathEvaluate("string(stat/type)") as string, true),
						Value = (double)x.XPathEvaluate("number(stat/@value)")
					})
					.ToList()
			};

			return result;
		}
	}
}
