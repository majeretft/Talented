using System;

namespace Talented.Calculator.Logic
{
	/// <summary>
	/// Represents an exception in calculation
	/// </summary>
	public class CalculationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CalculationException"/> class
		/// </summary>
		/// <param name="message">Exception description message</param>
		public CalculationException(string message) : base(message)
		{
			// Nothing to do
		}
	}
}
