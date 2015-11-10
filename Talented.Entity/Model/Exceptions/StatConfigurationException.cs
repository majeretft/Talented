using System;

namespace Talented.Entity.Model.Exceptions
{

	public class StatConfigurationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StatConfigurationException" /> class.
		/// </summary>
		public StatConfigurationException()
		{
			// Nothing
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StatConfigurationException" /> class.
		/// </summary>
		/// <param name="message">Exception message</param>
		public StatConfigurationException(string message)
			:base (message)
		{
			// Nothing
		}
	}
}
