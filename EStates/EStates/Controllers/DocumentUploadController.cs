using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EStates.ViewModels;
using ES.Core.Handlers;
using ES.Data.Repositories.Interfaces;
using ES.Data.Models;
using EStates.ViewModels.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class DocumentUploadController : Controller
    {
        IUnitOfWork _unitOfWork;


        public DocumentUploadController(IUnitOfWork unitoOfWork)
        {
            _unitOfWork = unitoOfWork;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var resultSet = new DocumentUploadResponse();

            var foundDocument = _unitOfWork.Documentfiles.Get(id);
            if (foundDocument != null)
                resultSet.ParseToViewModel(foundDocument);
            else
                resultSet.AddError(0, "Няма намерен Документ в системата");

            return new JsonResult(resultSet);
        }

        [HttpPost]
        public JsonResult Post([FromBody]DocumentFileViewModel data)
        {
            var response = new DocumentUploadResponse();


            if (data.TypeId != 0)
            {
                var docType = _unitOfWork.DocumentDataType.Get(data.TypeId);
                var newitem = new DocumentFile
                {
                    BuildingFloorId = data.BuildingFloorId,
                    BuildingId = data.BuildingId,
                    Type = docType,
                    Description = data.Description,
                    DocumentId = data.DocumentId,
                    Id = data.Id,
                    Name = data.Name
                };

                _unitOfWork.Documentfiles.Add(newitem);
                _unitOfWork.SaveChanges();
            }
            else
            {
                response.AddError(0, "Моля Изберете Тип на документа");
            }

            return new JsonResult(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
