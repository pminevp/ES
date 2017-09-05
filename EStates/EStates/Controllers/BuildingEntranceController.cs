using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ES.Core.Handlers;
using ES.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using EStates.ViewModels;
using ES.Data.Managers.Interfaces;

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class BuildingEntranceController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public IAccountManager _accountManager { get; }

        public BuildingEntranceController(IUnitOfWork unitOfWork, IAccountManager accountManager)
        {
            _unitOfWork = unitOfWork;
            _accountManager = accountManager;
        }

        [HttpGet]
        public IEnumerable<BuildingEntrance> Get() => _unitOfWork.BuildingEntrance.GetAll();

        [HttpGet("{id}")]
        public IEnumerable<BuildingEntrance> Get(int id) => _unitOfWork.BuildingEntrance.GetByBuildingId(id);

        [Route("Floors/{id}")]
        [HttpGet()]
        public List<BuildingFloor> GetFloors(int id)
        {
            //var floors = _unitOfWork.GetBuildingFloorByEntranceId(id);

            var floors = _unitOfWork.BuildingFloor.GetFloorByEntranceIncluded(id).Result;
            return floors;
        }

        [Route("ById/{id}")]
        [HttpGet]
        public BuildingEntrance GetBuildingEntranceById(int id)
        {
            var dat = _unitOfWork.BuildingEntrance.Get(id);

            return dat;
        }

        [HttpGet("SelectEntrances/{buildingId:int}/{userId}")]
        public List<BuildingEntrance> GetBuildingEntrancesByUser(int buildingId,string userId)
        {
            var result = _unitOfWork.BuildingEntrance.GetByUserId(buildingId, userId);
            return result;
        }


        [HttpPost]
        public async Task<BuildingEntranceAddViewModel> Post([FromBody]BuildingEntranceAddViewModel buildingEntrance)
        {
            var building = _unitOfWork.Buildings.Get(buildingEntrance.BuildingId);
            var owner = await _accountManager.GetUserByIdAsync(buildingEntrance.CreatorId);

            if (building == null || owner == null)
                return buildingEntrance;

            var newEntrance = new BuildingEntrance
            {
                name = buildingEntrance.Name,
                CurrentBuilding = building,
                Apartaments = new List<Apartament>(),
                manager = owner
            };
            _unitOfWork.BuildingEntrance.Add(newEntrance);
            _unitOfWork.SaveChanges();

            buildingEntrance.Id = newEntrance.id;

            return buildingEntrance;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BuildingEntrance buildingEntrance)
        {
            _unitOfWork.BuildingEntrance.Update(buildingEntrance);
            _unitOfWork.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var buildingEntrance = _unitOfWork.BuildingEntrance.Get(id);

            _unitOfWork.BuildingEntrance.Remove(buildingEntrance);
            _unitOfWork.SaveChanges();
        }
    }
}
