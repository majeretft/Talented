using System;

namespace Talented.Entity.Model.Exceptions
{

	public class TalentConfigurationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TalentConfigurationException" /> class.
		/// </summary>
		public TalentConfigurationException()
		{
			// Nothing
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TalentConfigurationException" /> class.
		/// </summary>
		/// <param name="message">Exception message</param>
		public TalentConfigurationException(string message)
			: base(message)
		{
			// Nothing
		}
	}
}
