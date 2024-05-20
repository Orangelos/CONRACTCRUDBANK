using LabaCRUD.Pages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace LabaCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly ClientContext _context;

        public EmployeeController(ClientContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public Task<ActionResult<IEnumerable<Clients>>> Getclients()
        //{
        //return _context.clients.ToList();
        //}



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return await _context.Employees.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var client = await _context.Employees.FindAsync(id);
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return client;
        }
        [HttpPut]
        public async Task<IActionResult> PutEmployee(int id, Employee client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            _context.Entry(client).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();
        }
        private bool ClientsAvailable(int id)
        {
            return (_context.Employees?.Any(x => x.Id == id)).GetValueOrDefault();
        }

       // [HttpDelete("{id}")]
       // public async Task<IActionResult> DeleteEmployee(int id)
       // {
       //     if (_context.Employees == null)
       //         return NotFound();
       //
       //     var clients = await _context.Employees.FindAsync(id);
       //     if (clients == null)
       //         return NotFound();
       //     _context.Employees.Remove(clients);
       //     await _context.SaveChangesAsync();
       //     return Ok();
       // }
       //
       // [HttpPost]
       // public async Task<ActionResult<Employee>> PostEmployee(Employee client)
       // {
       //     _context.Employees.Add(client);
       //     await _context.SaveChangesAsync();
       //     return CreatedAtAction(nameof(GetEmployee), new { id = client.Id }, client);
       // }






    }
}