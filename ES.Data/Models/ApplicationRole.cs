﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ES.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationRole"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public ApplicationRole()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public ApplicationRole(string roleName) : base(roleName)
        {

        }


        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <param name="description">Description of the role.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public ApplicationRole(string roleName, string description) : base(roleName)
        {
            Description = description;
        }





        /// <summary>
        /// Gets or sets the description for this role.
        /// </summary>
        public string Description { get; set; }
    }
}
