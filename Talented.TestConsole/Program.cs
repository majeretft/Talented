using System;
using System.Collections.Generic;
using Talented.DataProvider.AI;
using Talented.Entities;

namespace Talented.TestConsole
{
	using Calculator = Calculator.AI.Calculator;

	public class Program
	{
		public static void Main(string[] args)
		{
			var idr = new InitialDataReader();
			var talents = idr.GetTalents();
			var toons = idr.GetToons();

			var c = new Calculator(toons, talents);

			var cas = new CastleRuntime
			{
				Toon = new Guid("dfa1673e-4c53-4f63-97df-876948b8b3a7"),
				CastleStatDistribution = new Dictionary<StatTypeEnum, byte>(),
				TalentLevelDistribution = new Dictionary<Guid, byte>()
			};

			cas.CastleStatDistribution.Add(StatTypeEnum.Agility, 42);

			cas.TalentLevelDistribution.Add(new Guid("6f779e8f-11d6-4e10-965d-6eeabf465d49"), 5);

			var bat = new BattleRuntime
			{
				IsMaxScore = true,
				IsMaxTime = true,
				TerrainType = TerrainTypeEnum.Foreign | TerrainTypeEnum.Neutral
			};

			var result = c.Calculate(cas, bat);
		}
	}
}
