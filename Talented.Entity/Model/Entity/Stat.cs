using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Talented.Entity.Model.Exceptions;

namespace Talented.Entity.Model.Entity
{
	/// <summary>
	/// Represents a single stat
	/// </summary>
	public partial class Stat
	{
		/// <summary>
		/// Possible stats types
		/// </summary>
		public enum StatTypeEnum
		{
			/// <summary>
			/// Default value
			/// </summary>
			None,

			/// <summary>
			/// Agility value
			/// </summary>
			Agility,

			/// <summary>
			/// Het points value
			/// </summary>
			Health,

			/// <summary>
			/// Cunning value
			/// </summary>
			Cunning,

			/// <summary>
			/// Magical protection
			/// </summary>
			Will,

			/// <summary>
			/// Physical protection
			/// </summary>
			Durability,

			/// <summary>
			/// HP regeneration value
			/// </summary>
			RegenerationHP,

			/// <summary>
			/// Energy regeneration value
			/// </summary>
			RegenerationMP,

			/// <summary>
			/// Movement speed
			/// </summary>
			Moveement
		}

		/// <summary>
		/// Possible grow types
		/// </summary>
		public enum GrowTypeEnum
		{
			/// <summary>
			/// Value will be multiplied by 1 + Grow per level
			/// </summary>
			Percent,

			/// <summary>
			/// Value will be increased by Grow per level
			/// </summary>
			Static,

			/// <summary>
			/// Value will be increased by Grow[level] per level
			/// </summary>
			Series
		}

		/// <summary>
		/// Gets or sets current stat dependency
		/// </summary>
		public StatDependencyEnum Dependency { get; set; }

		/// <summary>
		/// Gets or sets current stat type
		/// </summary>
		public StatTypeEnum Type { get; set; }

		/// <summary>
		/// Gets or sets base value of current stat
		/// </summary>
		public double Value { get; set; }

		/// <summary>
		/// Gets or sets grow percentage per level of talent
		/// Expected types: double, array[max level]
		/// </summary>
		public dynamic Grow { get; set; }

		/// <summary>
		/// Gets or sets treatment method for Grow property
		/// </summary>
		public GrowTypeEnum GrowType { get; set; }

		/// <summary>
		/// Read configuration from Xml
		/// </summary>
		/// <param name="xml">Xml description</param>
		public virtual void FromXml(XElement xml)
		{
			if (xml == null)
				throw new ArgumentNullException("xml");

			var xpath = @"string(stat/@type)";
			StatTypeEnum currentType;
			if (!TryGetStringValue(xml, xpath, out currentType))
				throw new StatConfigurationException(xpath);
			Type = currentType;

			xpath = @"string(stat/@type)";
			StatDependencyEnum currentDependency;
			if (!TryGetStringValue(xml, xpath, out currentDependency))
				throw new StatConfigurationException(xpath);
			Dependency = currentDependency;

			xpath = @"string(stat/@growType)";
			GrowTypeEnum currentGrowType;
			if (!TryGetStringValue(xml, xpath, out currentGrowType))
				throw new StatConfigurationException(xpath);
			GrowType = currentGrowType;

			xpath = @"number(stat/@value)";
			double currentValue;
			if (!TryGetNumericValue(xml, xpath, out currentValue))
				throw new StatConfigurationException(xpath);
			GrowType = currentGrowType;
		}

		protected virtual bool TryGetStringValue<T>(XNode xml, string xpath, out T result) where T : struct
		{
			if (xml == null)
				throw new ArgumentNullException("xml");

			if (string.IsNullOrEmpty(xpath))
				throw new ArgumentNullException("xpath");

			var valueString = xml.XPathEvaluate(xpath) as string;
			return Enum.TryParse(valueString, true, out result);
		}

		protected virtual bool TryGetNumericValue(XNode xml, string xpath, out double result)
		{
			if (xml == null)
				throw new ArgumentNullException("xml");

			if (string.IsNullOrEmpty(xpath))
				throw new ArgumentNullException("xpath");

			var valueString = xml.XPathEvaluate(xpath) as string;
			return double.TryParse(valueString, out result);
		}
	}
}
