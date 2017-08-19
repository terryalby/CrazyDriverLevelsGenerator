using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDriverLevelsGenerator
{

    public class Entry
    {
        public string Distance { get; set; }
        public string Object { get; set; }
        public string OriginX { get; set; }
    }

    public class Level
    {
        public string LevelName { get; set; }
        public string LevelId { get; set; }
        public List<Entry> Data { get; set; }
    }
}
