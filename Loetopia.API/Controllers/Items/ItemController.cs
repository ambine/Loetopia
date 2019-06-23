using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loetopia.DataAccess;
using Loetopia.DataAccess.Models;
using Loetopia.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Loetopia.API.Controllers.Items
{
    [Route("api/items/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItems _item;
        public ItemController(IItems item)
        {
            _item = item;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<ItemDescription>> Get()
        { 
            return _item.GetItemInformation(null);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<ItemDescription>> Get(int id)
        {
            return _item.GetItemInformation(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<int> Post([FromBody] Item item)
        {
            return await _item.AddItem(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Item item)
        {
            return await _item.UpdateItem(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _item.RemoveItem(id);
        }
    }
}
