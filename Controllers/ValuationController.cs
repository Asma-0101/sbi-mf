using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Data;
using SBI_MF.Models;
using SBI_MF.Controllers.Dtos;

namespace SBI_MF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuationController : ControllerBase
    {
        private readonly SBIMFDbContext _context;

        public ValuationController(SBIMFDbContext context)
        {
            _context = context;
        }

        // GET: api/Valuation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValuationModel>>> GetValuation()
        {
            return await _context.Valuation.ToListAsync();
        }

        // GET: api/Valuation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValuationModel>> GetValuationModel(string id)
        {
            var valuationModel = await _context.Valuation.FindAsync(id);

            if (valuationModel == null)
            {
                return NotFound();
            }

            return valuationModel;
        }

        // PUT: api/Valuation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValuationModel(string id, ValuationModel valuationModel)
        {
            if (id != valuationModel.ValuationId)
            {
                return BadRequest();
            }

            _context.Entry(valuationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValuationModelExists(id))
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

        // POST: api/Valuation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ValuationModel>> PostValuationModel(ValuationModel valuationModel)
        {
            _context.Valuation.Add(valuationModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValuationModelExists(valuationModel.ValuationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetValuationModel", new { id = valuationModel.ValuationId }, valuationModel);
        }

        // DELETE: api/Valuation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ValuationModel>> DeleteValuationModel(string id)
        {
            var valuationModel = await _context.Valuation.FindAsync(id);
            if (valuationModel == null)
            {
                return NotFound();
            }

            _context.Valuation.Remove(valuationModel);
            await _context.SaveChangesAsync();

            return valuationModel;
        }

        private bool ValuationModelExists(string id)
        {
            return _context.Valuation.Any(e => e.ValuationId == id);
        }
    }
}
