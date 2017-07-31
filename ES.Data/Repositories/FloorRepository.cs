using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ES.Data.Repositories
{
    public class FloorRepository : Repository<BuildingFloor>, IFloorRepository
    {
        public FloorRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }
    }
}
