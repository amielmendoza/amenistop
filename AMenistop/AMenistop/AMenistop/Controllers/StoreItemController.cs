using BAL.AMenistop.Common;
using BAL.AMenistop.Interfaces;
using BAL.AMenistop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AMenistop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreItemController : ControllerBase
    {
        IStoreItemService _storeItemService;
        public StoreItemController(IStoreItemService storeItemService)
        {
            _storeItemService = storeItemService;
        }

        [HttpGet]
        public ResultObjectList<StoreItem> GetAll()
        {
            return _storeItemService.GetAll();
        }

        // GET api/<StoreItemController>/5
        [HttpGet("{id}")]
        public ResultObject<StoreItem> Get(int id)
        {
            return _storeItemService.GetById(id);
        }

        // POST api/<StoreItemController>
        [HttpPost]
        public ResultObject<StoreItem> Post([FromBody]StoreItem storeItem)
        {
            return _storeItemService.Add(storeItem);
        }

        // PUT api/<StoreItemController>/5
        [HttpPut("{id}")]
        public ResultObject<StoreItem> Put([FromBody]StoreItem storeItem)
        {
            return _storeItemService.Update(storeItem);
        }

        // DELETE api/<StoreItemController>/5
        [HttpDelete("{id}")]
        public ResultObject<StoreItem> Delete(int id)
        {
            return _storeItemService.Delete(id);
        }
    }
}
