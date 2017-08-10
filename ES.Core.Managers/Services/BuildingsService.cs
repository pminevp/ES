using ES.Data;
using ES.Data.Models;
using System.Collections.Generic;

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

        public void Add(Building building)
        {
            _unitOfWork.Buildings.Add(building);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// add  with adding floors and entrances
        /// </summary>
        /// <param name="building"></param>
        public void AddCascade(Building building)
        {
            _unitOfWork.Buildings.Add(building);
            _unitOfWork.SaveChanges();

            if(building.Entrances > 0)
            {
                _entranceService.AddEntranceCascade(building);
            }
        }

        public void Update(Building building)
        {
            _unitOfWork.Buildings.Update(building);
            _unitOfWork.SaveChanges();
        }

    }
}
