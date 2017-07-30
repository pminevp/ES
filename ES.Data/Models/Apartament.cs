﻿using System.Collections.Generic;

namespace ES.Data.Models
{
    public class Apartament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public List<ApplicationUser> Owners { get; set; }
    }
}