using System;
using System.IO;
using System.Collections.Generic;
using YamlDotNet;

namespace ReversiBot
{
	public class Config
	{
		private static string filePath = "./config.yaml";
		public string BoardCellImportance;
		private int[,] _BoardCells = new int[8, 8];
		public float EnemyPossibleMoveScore;
		public float FlipAmountMultiplier;
		public int Depth;

		public Config()
		{

		}

		public static Config Load()
		{
			Console.WriteLine("Loading Config from " + filePath);

			var deserializer = new YamlDotNet.Serialization.Deserializer();
			Config config = deserializer.Deserialize<Config>(File.ReadAllText(filePath));

			config.LoadBoardCells(config.BoardCellImportance);
			
			return config;
		}

		private void LoadBoardCells(string values)
		{
			int y = 0;
			foreach(string line in values.Split("\n"))
			{
				int x = 0;
				foreach(string snum in line.Split(" "))
				{
					int num = int.Parse(snum);
					_BoardCells[x, y] = num;
					x++;
				}
				y++;
			}
		}

		public int GetCellImportance(Vector2 pos)
		{
			return _BoardCells[pos.X, pos.Y];
		}
	}
}