using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Talented.DataProvider.Logic.Files
{
	/// <summary>
	/// Provides Xml configuration files for parsing
	/// </summary>
	public class XDocumentProvider
	{
		/// <summary>
		/// Load single document
		/// </summary>
		/// <param name="path">File path</param>
		/// <returns>Loaded document</returns>
		public XDocument GetDocument(string path)
		{
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException("path");
			if (!File.Exists(path))
				throw new FileNotFoundException("path");

			using (var sr = new StreamReader(path))
			{
				return XDocument.Load(sr);
			}
		}

		/// <summary>
		/// Load documents
		/// </summary>
		/// <param name="path">Folder path</param>
		/// <param name="approximateFilesCount">Approximate files count</param>
		/// <returns>Loaded documents</returns>
		public IEnumerable<XDocument> GetDocuments(string path, int approximateFilesCount = 4)
		{
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException("path");
			if (!Directory.Exists(path))
				throw new DirectoryNotFoundException("path");
			if (approximateFilesCount < 1)
				throw new ArgumentOutOfRangeException("approximateFilesCount");

			var di = new DirectoryInfo(path);
			var files = di.GetFiles("*.xml").ToList();

			var result = new List<XDocument>(approximateFilesCount);

			files.ForEach(x => result.Add(GetDocument(x.FullName)));

			return result;
		}
	}
}
