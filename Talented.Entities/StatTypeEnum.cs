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
		/// Attack power
		/// </summary>
		Attack,

		/// <summary>
		/// Cunning value
		/// </summary>
		Cunning,

		/// <summary>
		/// Physical protection
		/// </summary>
		Durability,

		/// <summary>
		/// Hit points value
		/// </summary>
		Health,

		/// <summary>
		/// Health steal value
		/// </summary>
		HealthSteal,

		/// <summary>
		/// Intelligence value
		/// </summary>
		Intelligence,

		/// <summary>
		/// Energy value
		/// </summary>
		Mana,

		/// <summary>
		/// Movement speed
		/// </summary>
		Moveement,

		/// <summary>
		/// HP regeneration value
		/// </summary>
		RegenerationHP,

		/// <summary>
		/// Energy regeneration value
		/// </summary>
		RegenerationMP,

		/// <summary>
		/// Magical protection
		/// </summary>
		Will
	}
}
