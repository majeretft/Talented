namespace Talented.Entities
{
	/// <summary>
	/// Possible stats types
	/// </summary>
	public enum StatTypeEnum
	{
		/// <summary>
		/// Default value (valid stat should not have this type)
		/// </summary>
		None,

		/// <summary>
		/// Agility value
		/// </summary>
		Agility,

		/// <summary>
		/// Hit points value
		/// </summary>
		Health,

		/// <summary>
		/// Health steal value
		/// </summary>
		HealthSteal,

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
		Moveement,

		/// <summary>
		/// Attack power
		/// </summary>
		Attack
	}
}
