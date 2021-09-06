using demo_api_zeer.Models;
using demo_api_zeer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_api_zeer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        TodosRepo _todosRepo = new TodosRepo();
        
        // GET: api/<TodosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _todosRepo.GetAllTodos();

            if (res != null)
            {
                return Ok(res);
            } 
            else
            {
                return NotFound(new { error = "No Todos Found in DB!" });
            }
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id)
        {
            var res = await _todosRepo.GetTodoByID(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(new { error = "Invalid ID! Todo not found!" });
            }
        }

        // POST api/<TodosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodosModel newTodo)
        {
            var res = await _todosRepo.AddNewTodo(newTodo);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(new { error = "Failed to save the new Todo in DB!" });
            }
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(String id, [FromBody] TodosModel updatedTodo)
        {
            var res = await _todosRepo.UpdateTdodo(id, updatedTodo);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(new { error = "Invalid Todo Item!" });
            }
        }

        // PATCH api/<TodoController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(String id)
        {
            var res = await _todosRepo.UpdateCompletedStatusOfTodo(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(new { error = "Failed to update the Completed Status!" });
            }
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            var res = await _todosRepo.DeleteTodo(id);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(new { error = "Invalid Todo!" });
            }
        }
    }
}
