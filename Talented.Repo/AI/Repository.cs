using System.Collections.Generic;
using Talented.Repo.Model;

namespace Talented.Repo.AI
{
	/// <summary>
	/// Repository loader
	/// </summary>
	public class Repository
	{
		/// <summary>
		/// Profile reader
		/// </summary>
		private ProfileReader reader;

		/// <summary>
		/// Initializes a new instance of the <see cref="Repository" /> class
		/// </summary>
		public Repository()
		{
			reader = new ProfileReader();
		}
	}
}
