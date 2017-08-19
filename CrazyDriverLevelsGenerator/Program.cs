using System;
using Newtonsoft;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CrazyDriverLevelsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var level = GenerateLevel(40, 30000, "1", "level1.json");
            PrintLevelInJsonFormat(level);
            Console.Read();
        }

        // difficulty from 1 to 100
        static Level GenerateLevel(int diffculty, int ticks, string levelId, string levelName)
        {
            var random = new Random();
            var level = new Level();
            var currentTick = 1;

            level.LevelId = levelId;
            level.LevelName = levelName;
            level.Data = new List<Entry>();

            while (currentTick < ticks)
            {
                var entry = new Entry();

                currentTick = (int) random.NextDouble() * (currentTick+200-diffculty - currentTick) + currentTick+200-diffculty;

                entry.Distance = currentTick.ToString();
                entry.OriginX = ((int)(random.NextDouble() * (270 - 0))).ToString();
                entry.Object = random.NextDouble() > ((double) diffculty / 100) ?  "Ammunition" : "RedCar";

                level.Data.Add(entry);
            }

            var endEntry = new Entry();

            endEntry.Distance = (currentTick + 1).ToString();
            endEntry.OriginX = "0";
            endEntry.Object = "End";

            level.Data.Add(endEntry);

            return level;
        }

        static void PrintLevelInJsonFormat(Level level)
        {
            Console.Write(JsonConvert.SerializeObject(level));
        }
    }
}