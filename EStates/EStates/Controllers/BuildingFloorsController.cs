using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ES.Core.Handlers;
using ES.Data.Models;
using EStates.ViewModels;
using System.Threading.Tasks;

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class BuildingFloorsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BuildingFloorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<BuildingFloor> Get() => _unitOfWork.BuildingFloor.GetAll();

        [HttpGet("{id}")]
        public async Task<BuildingFloor> Get(int id) =>  await _unitOfWork.BuildingFloor.GetFloorWithEntrenceIncluded(id);

        [Route("ApartamentsByFloorId/{id}")]
        [HttpGet()]
        public async Task<List<Apartament>> GetApartamentsByFloorId(int id)
        {
            var aparts = await _unitOfWork.Apartaments.GetApartamentsByFloorId(id);

            return aparts;
        }

        [HttpPost]
        public void Post([FromBody]BuildingFloorViewModel Floor)
        {
            //var building = _unitOfWork.Buildings.Get(Floor.buildingId);
            //var model = new BuildingFloor { id = Floor.id, Name = Floor.name, CurrentBuilding = building };

            //_unitOfWork.BuildingFloor.Add(model);
            //_unitOfWork.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BuildingFloorViewModel Floor)
        {
            //var building = _unitOfWork.Buildings.Get(Floor.buildingId);
            //var model = new BuildingFloor { id = Floor.id, Name = Floor.name, CurrentBuilding = building };

            //_unitOfWork.BuildingFloor.Update(model);
            //_unitOfWork.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var building = _unitOfWork.BuildingFloor.Get(id);
            _unitOfWork.BuildingFloor.Remove(building);
        }
    }
}