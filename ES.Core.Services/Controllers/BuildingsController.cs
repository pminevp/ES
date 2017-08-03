using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ES.Core.Handlers;
using ES.Data.Models;
using Microsoft.AspNetCore.Cors;

namespace ES.Core.Services.Controllers
{
    [EnableCors("test")]
    [Route("api/[controller]")]
    public class BuildingsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BuildingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        
 
        [HttpGet]
        public IEnumerable<Building> Get()
        {
            return _unitOfWork.Buildings.GetAll();
        }
                
        [HttpGet("{id}")]
        public Building Get(int id)
        {
            return _unitOfWork.Buildings.Get(id);
        }

         
        [HttpPost]
        public void Post([FromBody]Building newBuilding)
        {
            _unitOfWork.Buildings.Add(newBuilding);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Building updatedBuilding)
        {
            _unitOfWork.Buildings.Update(updatedBuilding);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bld = _unitOfWork.Buildings.Get(id);
            _unitOfWork.Buildings.Remove(bld);
        }
    }
}