using ES.Data;
using ES.Data.Models;

namespace ES.Core.Handlers.Services
{
    public class BuildingEntranceService : BaseServices
    {
        BuildingFloorService _buildingFloorServices;

        public BuildingEntranceService(ApplicationDbContext context) : base(context)
        {
            _buildingFloorServices = new BuildingFloorService(_unitOfWork);
        }

        public BuildingEntranceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _buildingFloorServices = new BuildingFloorService(unitOfWork);
        }

        public void AddEntrance(Building building)
        {
            for (int i = 0; i < building.Entrances; i++)
            {
                var newEntrance = new BuildingEntrance();
                newEntrance.name = $"Вход {i}";
                _unitOfWork.BuildingEntrance.Add(newEntrance);
            }

            _unitOfWork.SaveChanges();
        }

        public void AddEntranceCascade(Building building)
        {
            for (int i = 0; i < building.Entrances; i++)
            {
                var newEntrance = new BuildingEntrance();
                newEntrance.name = $"Вход {i}";
                newEntrance.CurrentBuilding = building;

                _unitOfWork.BuildingEntrance.Add(newEntrance);
                _buildingFloorServices.AddMultipleFloors(newEntrance, building.Floors);
            }
        }

    }
}
