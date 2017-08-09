using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class UploadImageController : Controller
    {
        IHostingEnvironment _hostingEnvironment;


        public UploadImageController(IHostingEnvironment hosting)
        {
            _hostingEnvironment = hosting;
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
        public void Post()
        {
            var a = Request.Form;
             
            Stream st;

            var fl =  a.Files[0];
            var fileName = ContentDispositionHeaderValue.Parse(fl.ContentDisposition)
                .FileName
                .Trim('"');

            var uploadsPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            var filePath = Path.Combine(uploadsPath, fl.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fl.CopyTo(fileStream);
            }
          
  


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
