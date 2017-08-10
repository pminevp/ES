using System.Collections.Generic;

namespace ES.Data.Models
{
   public class Building
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Entrances { get; set; }

        public int Floors { get; set; }

        public List<Apartament> Apartaments { get; set; }
    }
}