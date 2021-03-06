﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string FriendlyName
        {
            get
            {
                string friendlyName = string.IsNullOrWhiteSpace(FullName) ? UserName : FullName;

                if (!string.IsNullOrWhiteSpace(JobTitle))
                    friendlyName = JobTitle + " " + friendlyName;

                return friendlyName;
            }
        }


        public string JobTitle { get; set; }
        public string FullName { get; set; }
        public string Configuration { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLockedOut => this.LockoutEnabled && this.LockoutEnd >= DateTimeOffset.UtcNow;

        public int BuildingId { get; set; }

        [Obsolete]
        public ICollection<BuildingFloor> ManagedFloors { get; set; }

        public ICollection<BuildingEntrance> ManagedEntrances { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
