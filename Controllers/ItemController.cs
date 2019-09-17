using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tasklist_api_aspnet_core.Data;
using tasklist_api_aspnet_core.models;

namespace tasklist_api_aspnet_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public IRepository repository {get;}

        public ItemController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/itenm
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await repository.GetAllItensAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }
        }

        // GET api/item/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await repository.GetItemAsyncById(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }
        }

        // POST api/item
        [HttpPost]
        public async Task<IActionResult> Post(Item item)
        {
            try
            {
                item.Created = DateTime.Now;
                item.Edited = DateTime.Now;
                if(item.Status)
                item.Finished = DateTime.Now;

                repository.Add(item);

                if(await repository.SaveChangesAsync())
                    return Created($"/api/aluno/{item.Id}", item);
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }

            return BadRequest();
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Item item)
        {
            try
            {
                var result = await repository.GetItemAsyncById(id);

                if(result == null)
                    return NotFound();
                else
                {
                    
                    item.Id = result.Id;
                    item.Edited = DateTime.Now;
                    item.Created = result.Created;
                    item.Finished = result.Finished;

                    if(item.Status && DateTime.Compare( item.Finished, DateTime.MinValue) == 0)
                      item.Finished = DateTime.Now;
                    repository.Update(item);
    
                    if(await repository.SaveChangesAsync())
                        return Created($"/api/item/{id}", id);
                }
                
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await repository.GetItemAsyncById(id);

                if(item == null)
                    return NotFound();
                else
                {
                    repository.Delete(item);

                    if(await repository.SaveChangesAsync())
                        return Created($"/api/item/{id}", id);
                }
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }
            return BadRequest();
        }
    }
}
