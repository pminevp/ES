using System.Collections.Generic;

namespace ES.Data.Models
{
    public class BuildingEntrance
    {
        public int id { get; set; }

        public string name { get; set; }

        public IEnumerable<Apartament> Apartaments { get; set; }

        public Building CurrentBuilding { get; set; }

        public ApplicationUser manager { get; set; }
    }
}