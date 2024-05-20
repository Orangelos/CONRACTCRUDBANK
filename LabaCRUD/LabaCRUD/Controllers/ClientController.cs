using LabaCRUD.Pages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabaCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public readonly ClientContext _context;

        public ClientsController(ClientContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public Task<ActionResult<IEnumerable<Clients>>> Getclients()
        //{
        //return _context.clients.ToList();
        //}



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Getclients()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            return await _context.Clients.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Getclient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (_context.Clients == null)
            {
                return NotFound();
            }
            return client;
        }
        [HttpPut]
        public async Task<IActionResult> PutClient(int id, Client client)
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
            return (_context.Clients?.Any(x => x.Id == id)).GetValueOrDefault();
        }

     //   [HttpDelete("{id}")]
     //   public async Task<IActionResult> DeleteClient(int id)
     //   {
     //       if (_context.Clients == null)
     //           return NotFound();
     //
     //       var clients = await _context.Clients.FindAsync(id);
     //       if (clients == null)
     //           return NotFound();
     //       _context.Clients.Remove(clients);
     //       await _context.SaveChangesAsync();
     //       return Ok()
     //       ;
     //   }
     //
     //   [HttpPost]
     //   public async Task<ActionResult<Client>> Postclient(Client client)
     //   {
     //       _context.Clients.Add(client);
     //       await _context.SaveChangesAsync();
     //       return CreatedAtAction(nameof(Getclient), new { id = client.Id }, client);
     //   }


      










        





    }
}
