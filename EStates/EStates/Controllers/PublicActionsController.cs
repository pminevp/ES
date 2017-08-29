using Microsoft.AspNetCore.Mvc;
using EStates.ViewModels;
using ES.Data.Managers.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ES.Data.Models;

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class PublicActionsController : Controller
    {
        private IAccountManager _accountManager;

        public PublicActionsController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost("newuser/create")]
        public IActionResult NewUserRegister([FromBody] UserEditViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user == null)
                    return BadRequest($"{nameof(user)} cannot be null");


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
