using System.Collections.Generic;

namespace ES.Data.Models
{
    public class BuildingFloor
    {
        public int id { get; set; }

        public string Name { get; set; }

        public BuildingEntrance buildingEntrance { get; set; }
    }
}