using ES.Core.Handlers;
using ES.Data.Models;
using EStates.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class BuildingApartamentController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BuildingApartamentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public Apartament Get(int id)
        {
            return _unitOfWork.Apartaments.Get(id);
        }

        [HttpPost]
        public ApartamentViewModel Post([FromBody]ApartamentViewModel apartament)
        {
            var newApart = new Apartament { Name = apartament.name, Description = apartament.description };

            var properFloor = _unitOfWork.BuildingFloor.Get(apartament.parentFloorId);

            newApart.ParentFloor = properFloor;
            
            _unitOfWork.Apartaments.Add(newApart);
            _unitOfWork.SaveChanges();

            apartament.id = newApart.Id;
            return apartament;
        }
        
        [HttpPut("{id}")]
        public ApartamentViewModel Put([FromBody]ApartamentViewModel apartament)
        {
            var updatedApart = new Apartament { Name = apartament.name, Description = apartament.description, Id= apartament.id, Status = apartament.status };

            var properFloor = _unitOfWork.BuildingFloor.Get(apartament.parentFloorId);

            updatedApart.ParentFloor = properFloor;


            _unitOfWork.Apartaments.Update(updatedApart);
            _unitOfWork.SaveChanges();

            return apartament;
        }
        
        [HttpDelete("{id}")]
        public Apartament Delete(int id)
        {
            var apart = _unitOfWork.Apartaments.Get(id);
            _unitOfWork.Apartaments.Remove(apart);
            _unitOfWork.SaveChanges();

            return new Apartament();
        }
    }
}
