using ES.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ES.Core.Handlers.Managers
{
    public class BuildingManager
    {
        UnitOfWork _unitOfWork;

        public BuildingManager(Data.ApplicationDbContext dbContext)
        {
            _unitOfWork = new UnitOfWork(dbContext);
        }

         
        public void Add(Building building)
        {
            _unitOfWork.Buildings.Add(building);
        }


        /// <summary>
        /// Get buildign by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Building GetBuildingById(int id) => _unitOfWork.Buildings.Get(id);

        public List<Building> GetAllBuildings() => _unitOfWork.Buildings.GetAll().ToList();

    }
}
