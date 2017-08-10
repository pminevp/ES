using ES.Data.Models;

namespace ES.Core.Handlers.Services
{
   public class BuildingFloorService : BaseServices
    {
        public BuildingFloorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AddFloor(BuildingEntrance entrance, string floorName ="")
        {
            var floor = new BuildingFloor();
            floor.buildingEntrance = entrance;
            floor.Name = $"Етаж {floorName}";

            _unitOfWork.BuildingFloor.Add(floor);
            _unitOfWork.SaveChanges();
        }

        public void AddMultipleFloors(BuildingEntrance entrance, int floors)
        {
            for (int i = 0; i < floors; i++)
            {
                AddFloor(entrance, i.ToString());
            }
        }
    }
}
