using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loetopia.DataAccess.Models;
using Loetopia.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loetopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAttributeController : ControllerBase
    {
        private IItemAttributes _item;
        public ItemAttributeController(IItemAttributes item)
        {
            _item = item;
        }


        [HttpGet]
        public IEnumerable<ItemsAttributes> Get()
        {
            return _item.GetItemsAttributes(null);
        }

        // GET: api/ItemAttribute
        [HttpGet("{id}")]
        public IEnumerable<ItemsAttributes> Get(int id)
        {
            return _item.GetItemsAttributes(id);
        }

        // POST: api/ItemAttribute
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ItemAttribute/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
