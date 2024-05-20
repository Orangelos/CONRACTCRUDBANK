using LabaCRUD.Pages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace LabaCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        public readonly ClientContext _context;

        public ContractController(ClientContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public Task<ActionResult<IEnumerable<Clients>>> Getclients()
        //{
        //return _context.clients.ToList();
        //}



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContract()
        {
            if (_context.Contracts == null)
            {
                return NotFound();
            }
            return await _context.Contracts.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            var client = await _context.Contracts.FindAsync(id);
            if (_context.Contracts == null)
            {
                return NotFound();
            }
            return client;
        }
        [HttpPut]
        public async Task<IActionResult> PutContract(int id, Client client)
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
            return (_context.Contracts?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            if (_context.Contracts == null)
                return NotFound();

            var clients = await _context.Contracts.FindAsync(id);
            if (clients == null)
                return NotFound();
            _context.Contracts.Remove(clients);
            await _context.SaveChangesAsync();
            return Ok() ;
        }
        [HttpPost]
        public async Task<ActionResult<Contract>> CreateContract(Contract contract)
        {
           
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

           
            Order order = new Order
            {
                ContractId = contract.Id
            };

            if (((contract.Amount*0.12+ contract.Amount)/contract.mouth)<contract.Salary/1.5)
            {
                order.Answer = "ПОЛНОСТЬЮ ОДОБРЕНО";
                order.Reason = "В соответсвтвии с пунктом 1 настоящего Приказа";
            }
            else if (contract.Salary >= 500000 && contract.Amount >= 100000000)
            {
                order.Answer = "ОДОБРЕНО С ОГРАНИЧЕНИЯМИ";
                order.Reason = "В соответсвтвии с пунктом 2 настоящего Приказа";
            }
            else if (contract.Amount / contract.Salary * 12 / 120 < 1)
            {
                order.Answer = "ОДОБРЕНО ИПОТЕКОЙ ПОД 12%";
                order.Reason = "В соответсвтвии с пунктом 3 настоящего Приказа";
            }
            else if((contract.creditstory<3 )&&(contract.Amount<=1000000))
            {
                order.Answer = "ОДОБРЕНО C ОГРАНИЧЕНИЯМИ ";
                order.Reason = "В соответсвтвии с пунктом 4 настоящего Приказа";
            }
            else if ((contract.poruchitel >= 1) && (contract.Amount < 1000000))
            {
                order.Answer = "ОДОБРЕНО ЧАСТИЧНО";
                order.Reason = "В соответсвтвии с пунктом 5 настоящего Приказа";
            }
            else if ((contract.poruchitel > 2) && (contract.Amount < 1000000))
            {
                order.Answer = "ЧАСТИЧНЫЙ ОТКАЗ";
                order.Reason = "В соответсвтвии с пунктом 6 настоящего Приказа";
            }
            else if ((contract.poruchitel >= 1) && (contract.Amount >= 1000000)&&(contract.Salary >= 1000000)&&(contract.creditstory>3))
            {
                order.Answer = "ВРЕМЕННЫЙ ОТКАЗ";
                order.Reason = "В соответсвтвии с пунктом 7 настоящего Приказа";
            }
            else
            {
                order.Answer = "ПОЛНЫЙ ОТКАЗ";
                order.Reason = "В соответсвтвии с пунктом 8 настоящего Приказа";
            }
            

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContract), new { id = contract.Id }, contract);
        }
        //  [HttpPost]
        //  public async Task<ActionResult<Contract>> PostcContract(Contract client)
        //  {
        //      _context.Contracts.Add(client);
        //      await _context.SaveChangesAsync();
        //      return CreatedAtAction(nameof(GetContract), new { id = client.Id }, client);
        //  }






    }
}