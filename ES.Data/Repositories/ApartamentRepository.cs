using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ES.Data.Repositories
{
    public class ApartamentRepository : Repository<Apartament>, IApartamentRepository
    {
        public ApartamentRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }


        public async Task<List<Apartament>> GetApartamentsByFloorId(int id)
        {
            var apartaments = await appContext.Apartament.Include(x => x.ParentFloor).ToListAsync();
            return apartaments.Where(x => x.ParentFloor.id == id).ToList();
        }
    }
}
