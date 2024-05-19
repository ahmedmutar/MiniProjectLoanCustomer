using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanCustomer.Data;
using LoanCustomer.Model;

namespace LoanCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : ControllerBase
    {
        private readonly LoanCustomerContext _context;

        public LoanTypesController(LoanCustomerContext context)
        {
            _context = context;
        }

        // GET: api/LoanTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanTypes>>> GetLoanTypes()
        {
            return await _context.LoanTypes.ToListAsync();
        }

        // GET: api/LoanTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanTypes>> GetLoanTypes(int id)
        {
            var loanTypes = await _context.LoanTypes.FindAsync(id);

            if (loanTypes == null)
            {
                return NotFound();
            }

            return loanTypes;
        }

        // PUT: api/LoanTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanTypes(int id, LoanTypes loanTypes)
        {
            if (id != loanTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanTypesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanTypes>> PostLoanTypes(LoanTypes loanTypes)
        {
            _context.LoanTypes.Add(loanTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanTypes", new { id = loanTypes.Id }, loanTypes);
        }

        // DELETE: api/LoanTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanTypes(int id)
        {
            var loanTypes = await _context.LoanTypes.FindAsync(id);
            if (loanTypes == null)
            {
                return NotFound();
            }

            _context.LoanTypes.Remove(loanTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanTypesExists(int id)
        {
            return _context.LoanTypes.Any(e => e.Id == id);
        }
    }
}
