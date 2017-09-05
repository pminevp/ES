using ES.Data;
using ES.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ES.Core.Handlers.Services
{
   public class BuildingsService : BaseServices
    {
        BuildingEntranceService _entranceService;

        public BuildingsService(ApplicationDbContext context) : base(context)
        {
            _entranceService = new BuildingEntranceService(_unitOfWork);
        }

        public BuildingsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _entranceService = new BuildingEntranceService(unitOfWork);
        }

        public IEnumerable<Building> GetAll()
        {
            return _unitOfWork.Buildings.GetAll();
        }

        public Building GetById(int id) => _unitOfWork.Buildings.Get(id);

        public async Task<Building> GetByOwnerId(string ownerId) => await _unitOfWork.Buildings.GetBuildingByOwner(ownerId);

        public void Add(Building building)
        {
            _unitOfWork.Buildings.Add(building);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// add  with adding floors and entrances
        /// </summary>
        /// <param name="building"></param>
        public Building AddCascade(Building building)
        {
            _unitOfWork.Buildings.Add(building);
            _unitOfWork.SaveChanges();

            if(building.Entrances > 0)
            {
                _entranceService.AddEntranceCascade(building);
            }

            return building;
        }

        public void CreateDefaultBuilding (Building building, Apartament apart)
        {
            building.Apartaments = new List<Apartament>();
            building.Apartaments.Add(apart);
            var bld = AddCascade(building);
            
            var buildingEntrances = _unitOfWork.BuildingEntrance.GetByBuildingId(bld.Id).ToList();
            var buildingdefaultFloor = _unitOfWork.BuildingFloor.GetFloorByEntranceId(buildingEntrances.First().id);

            var defaultFloor = buildingdefaultFloor;
            apart.ParentFloor = defaultFloor;

            _unitOfWork.Apartaments.Update(apart);
        }

        /// <summary>
        /// SAve Buildign changes
        /// </summary>
        /// <param name="building"></param>
        /// <returns></returns>
        public Building UpdateBuilding(Building building)
        {
            _unitOfWork.Buildings.Update(building);
            _unitOfWork.SaveChanges();

            return building;
        }

        public void Update(Building building)
        {
            _unitOfWork.Buildings.Update(building);
            _unitOfWork.SaveChanges();
        }

    }
}
