using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ES.Core.Handlers.Services;
using ES.Core.Handlers;
using ES.Data.Models;

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {
        private BuildingsService _buildingServices;


        public BuildingController(IUnitOfWork unitOfWork)
        {
            _buildingServices = new BuildingsService(unitOfWork);
        }

        [HttpGet]
        public IEnumerable<Building> Get()
        {
            return _buildingServices.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Building Get(int id) => _buildingServices.GetById(id);

        // POST api/values
        [HttpPost]
        public Building Post([FromBody] Building building)
        {
            if (building.Entrances > 1)
                _buildingServices.AddCascade(building);
            else
                _buildingServices.Add(building);

            return building;
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Building value) => _buildingServices.Update(value);


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [Route("Documents")]
        [HttpPost]
        public JsonResult BuildingDocuments()
        {

            return Json(new { success = true, message = "Next step" });
        }

    }
}
