using ES.Core.Handlers;
using ES.Data.Managers.Interfaces;
using ES.Data.Models;
using EStates.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class BuildingApartamentController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IAccountManager _accountManager;

        public BuildingApartamentController(IUnitOfWork unitOfWork, IAccountManager accountManager)
        {
            _unitOfWork = unitOfWork;
            _accountManager = accountManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<Apartament> Get(int id)
        {
          return await _unitOfWork.Apartaments.GetApartamentOwnerIncluded(id);
        }

        [HttpGet("apartaments/building/{buildingName}")]
        public async Task<IList<Apartament>> GetApartamentsByBuilding(string buildingName)
        {
            return await _unitOfWork.Apartaments.GetApartamentsByBuildingName(buildingName);
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

        [Route("AddUser/")]
        [HttpPost()]
        public async Task<ApplicationUser> AddUser([FromBody]UserToApartamentViewModel user)
        {          
            var apartUser = await  _accountManager.GetUserByUserNameAsync(user.UserName);

            if (apartUser != null && !string.IsNullOrEmpty(apartUser.Id))
            {
                user.Id = apartUser.Id;

                var apart = await _unitOfWork.Apartaments.GetApartamentOwnerIncluded(user.ApartamentId);

                apart.Owners.Add(apartUser);
                _unitOfWork.Apartaments.Update(apart);
                _unitOfWork.SaveChanges();
            }

            if(apartUser == null)
            {
                apartUser = new ApplicationUser { UserName = "", Id = "" };
            }
               

            return apartUser;
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
