using System.Collections.Generic;
using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace ES.Data.Repositories
{
    public class BuildingEntranceRepository : Repository<BuildingEntrance>, IBuildingEntranceRepository
    {
        public BuildingEntranceRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }

        public List<BuildingEntrance> GetByBuildingId(int id)
        {
            var t = base.Find(x => x.CurrentBuilding.Id == id).ToList();

            return t;
        }

      
    }
}