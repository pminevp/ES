﻿// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
using ES.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EStates.Policies
{
    public class AssignRolesRequirement : IAuthorizationRequirement
    {

    }


    public class AssignRolesHandler : AuthorizationHandler<AssignRolesRequirement, Tuple<string[], string[]>>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AssignRolesRequirement requirement, Tuple<string[], string[]> newAndCurrentRoles)
        {
            if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.AssignRoles) || !GetIsRolesChanged(newAndCurrentRoles.Item1, newAndCurrentRoles.Item2))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }


        private bool GetIsRolesChanged(string[] newRoles, string[] currentRoles)
        {
            if (newRoles == null)
                newRoles = new string[] { };

            if (currentRoles == null)
                currentRoles = new string[] { };


            bool roleAdded = newRoles.Except(currentRoles).Any();
            bool roleRemoved = currentRoles.Except(newRoles).Any();

            return roleAdded || roleRemoved;
        }
    }
}