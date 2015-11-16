using System.IO;

namespace Talented.DataProvider
{
	/// <summary>
	/// Data provider settings
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Data relative path
		/// </summary>
		public const string DataFolder = "Configuration";

		/// <summary>
		/// Talents data relative part of path
		/// </summary>
		public const string TalentFolder = "TalentConfig";

		/// <summary>
		/// Toon data relative part of path
		/// </summary>
		public const string ToonFolder = "ToonConfig";

		/// <summary>
		/// Gets talent data relative path
		/// </summary>
		public static string GetTalentPath
		{
			get
			{
				return Path.Combine(DataFolder, TalentFolder);
			}
		}

		/// <summary>
		/// Gets toon data relative path
		/// </summary>
		public static string GetToonPath
		{
			get
			{
				return Path.Combine(DataFolder, ToonFolder);
			}
		}
	}
}
