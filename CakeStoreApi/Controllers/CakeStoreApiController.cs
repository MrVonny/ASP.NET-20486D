using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CakeStoreApi.Models;

namespace CakeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeStoreApiController : ControllerBase
    {
        private IData data;

        public CakeStoreApiController(IData data)
        {
            this.data = data;
        }

        [HttpGet("/api/CakeStore")]
        public ActionResult<List<CakeStore>> GetAll()
        {
            return data.CakesInitializeData();
        }

        [HttpGet("/api/CakeStore/{id}")]
        public ActionResult<CakeStore> GetById(int? id)
        {
            var item = data.GetCakeById(id);
            if (item == null) return NotFound();
            return new ObjectResult(item);
        }
    }
}