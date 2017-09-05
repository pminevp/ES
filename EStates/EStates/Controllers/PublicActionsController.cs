using Microsoft.AspNetCore.Mvc;
using EStates.ViewModels;
using ES.Data.Managers.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ES.Data.Models;
using ES.Core.Handlers;
using ES.Core.Handlers.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

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
        [Produces(typeof(Tuple<bool,string[]>))]
        public async Task<IActionResult> NewUserRegister([FromBody] UserRegistrationViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user == null)
                    return BadRequest($"{nameof(user)} cannot be null");            

                var newUser = new ApplicationUser {
                    UserName = user.UserName,
                    BuildingId =1, //building.Id,
                    IsEnabled= true,
                    Email = user.Email,
                    EmailConfirmed = true
                };

                List<string> roleList = new List<string>
                {
                    user.RoleName
                };
                var usr = _accountManager.CreateUserAsync(newUser, roleList, user.NewPassword);
                var data =  usr.Result;

                if(data.Item1)
                {
                    var building = new Building
                    {
                        Entrances = 1,
                        Floors = 2,
                        Name = user.buildingName
                    };

                    var defaultApart = new Apartament { Name = "Системен Апартамент" };
                    _buildingServices.CreateDefaultBuilding(building, defaultApart);

                    var updateUsr = await _accountManager.GetUserByUserNameAsync(user.UserName);

                    if(updateUsr == null)
                    {
                        data = new Tuple<bool, string[]>(false, new string[1] { "Проблем при регистрацията." });                 
                    }

                    if (!data.Item1)
                        return Ok(data);

                    updateUsr.BuildingId = building.Id;
                    data = await _accountManager.UpdateUserAsync(updateUsr);
                }

                return Ok(data);
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
