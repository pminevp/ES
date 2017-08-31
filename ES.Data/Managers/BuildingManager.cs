using ES.Data.Managers.Interfaces;
using ES.Data.Models;
using ES.Data.Repositories;
using ES.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Data.Managers
{
    public class BuildingManager : IBuildingManager
    {
        private ApplicationDbContext _context;
        private IBuildingRepository _buildingRepository;
       
        public BuildingManager(ApplicationDbContext context)
        {
            _context = context;
            _buildingRepository = new BuildingRepository(_context);
        }
    }
}
