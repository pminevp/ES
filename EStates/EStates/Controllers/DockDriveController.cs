using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EStates.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class DockDriveController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DockDriveController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
             

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post()
        {
            var fls = Request.Form.Files;
            var filePath = _hostingEnvironment.WebRootPath+ @"\uploads\";

            var docResponse = new DocumentResponse();

            foreach (var formFile in fls)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath+ formFile.FileName, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                    docResponse.DocumentWebPath = $"/uploads/{formFile.FileName}";
                    docResponse.DocumentFileName = formFile.FileName;
                }
            }

            return new JsonResult(docResponse);
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
