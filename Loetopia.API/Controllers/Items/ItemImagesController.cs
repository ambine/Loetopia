using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loetopia.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loetopia.API.Controllers.Items
{
    [Route("api/items/[controller]")]
    [ApiController]
    public class ItemImagesController : ControllerBase
    {
        private IItemImages _items;
        public ItemImagesController(IItemImages items)
        {
            _items = items;
        }


        // GET: api/ItemImages
        [HttpGet]
        public IEnumerable<byte[]> Get()
        {
            return _items.GetItemsImages(null);
        }

        // GET: api/ItemImages/5
        [HttpGet("{id}")]
        public IEnumerable<byte[]> Get(int id)
        {
            return _items.GetItemsImages(id);
        }

        // POST: api/ItemImages
        [HttpPost]
        public void Post([FromBody] string value)
        {
 
        }

        // PUT: api/ItemImages/5
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
