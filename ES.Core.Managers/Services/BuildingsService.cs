using ES.Data;
using ES.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Handlers.Services
{
   public class BuildingsService
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public BuildingsService(ApplicationDbContext context)
        {
            _context = context;

            _unitOfWork = new UnitOfWork(context);
        }

        public BuildingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }

        public IEnumerable<Building> GetAll()
        {
            return _unitOfWork.Buildings.GetAll();
        }

        public Building GetById(int id) => _unitOfWork.Buildings.Get(id);

        public void Add(Building building) => _unitOfWork.Buildings.Add(building);

        public void Update(Building building) => _unitOfWork.Buildings.Update(building);

    }
}
