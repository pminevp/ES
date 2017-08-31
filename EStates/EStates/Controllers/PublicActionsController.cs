using Microsoft.AspNetCore.Mvc;
using EStates.ViewModels;
using ES.Data.Managers.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ES.Data.Models;
using ES.Core.Handlers;
using ES.Core.Handlers.Services;

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class PublicActionsController : Controller
    {
        private IAccountManager _accountManager;
        private BuildingsService _buildingServices;

        public PublicActionsController(IAccountManager accountManager, IUnitOfWork unitOfWork)
        {
            _accountManager = accountManager;
            _buildingServices = new BuildingsService(unitOfWork);
        }

        [HttpPost("newuser/create")]
        public IActionResult NewUserRegister([FromBody] UserRegistrationViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user == null)
                    return BadRequest($"{nameof(user)} cannot be null");


                var building = new Building
                {
                    Entrances=1,
                    Floors= 2,
                    Name= user.buildingName
                };
 
                var defaultApart = new Apartament { Name = "Системен Апартамент" };
                _buildingServices.CreateDefaultBuilding(building, defaultApart);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("publicroles/all")]
        public async Task<IList<ApplicationRole>> GetPublicRoles()
        {
            return await _accountManager.GetPublicRoles();
        }
    }
}
