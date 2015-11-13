using System.Collections.Generic;
using Talented.DataProvider.Logic.Files;
using Talented.DataProvider.Model;
using Talented.Entities.Talents;

namespace Talented.DataProvider.AI
{
	/// <summary>
	/// Provides initial data for calculation
	/// </summary>
	public class InitialDataReader
	{
		/// <summary>
		/// Returns list of all talents
		/// </summary>
		/// <returns>List of all talents</returns>
		public IEnumerable<Talent> GetTalents()
		{
			var xdp = new XDocumentProvider();
			var documents = xdp.GetDocuments(Constants.GetTalentPath);

			var tp = new TalentParser();
			return tp.ParseTalents(documents);
		}
	}
}
