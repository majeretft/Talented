using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Talented.Repo.Model
{
	/// <summary>
	/// XML profile reader
	/// </summary>
	public class ProfileReader
	{
		/// <summary>
		/// Path to talents profiles
		/// </summary>
		private string pathTalents = @"Profiles/Talents";

		/// <summary>
		/// Path to toons profiles
		/// </summary>
		private string pathToons = @"Profiles/Toons";

		/// <summary>
		/// Load all profiles from folder
		/// </summary>
		/// <returns>Profiles documents</returns>
		public List<XDocument> ReadTalentList()
		{
			return ReadList(pathTalents);
		}

		/// <summary>
		/// Load all profiles from folder
		/// </summary>
		/// <returns>Profiles documents</returns>
		public List<XDocument> ReadToonsList()
		{
			return ReadList(pathToons);
		}

		/// <summary>
		/// Load all profiles from folder
		/// </summary>
		/// <param name="path">Folder path</param>
		/// <returns>Profiles documents</returns>
		protected List<XDocument> ReadList(string path)
		{
			var files = GetFiles(path);

			var result = new List<XDocument>(50);

			files.ForEach(x => result.Add(XDocument.Load(x.FullName)));

			return result;
		}

		/// <summary>
		/// Gets file info for all XML documents in folder
		/// </summary>
		/// <param name="path">Folder path</param>
		/// <returns>List of file info</returns>
		protected List<FileInfo> GetFiles(string path)
		{
			if (!Directory.Exists(path))
				throw new DirectoryNotFoundException("path");

			var di = new DirectoryInfo(path);
			return di.GetFiles("*.xml").ToList();
		}
	}
}
