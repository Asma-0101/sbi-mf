using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Controllers.Dtos;
using SBI_MF.Data;
using SBI_MF.Models;

namespace SBI_MF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustodianInstructionController : ControllerBase
    {
        private readonly SBIMFDbContext _context;

        public CustodianInstructionController(SBIMFDbContext context)
        {
            _context = context;
        }

        // GET: api/CustodianInstruction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustodianInstructionModel>>> GetCustodianInstruction()
        {
            return await _context.CustodianInstruction.ToListAsync();
        }

        // GET: api/CustodianInstruction/5
        [HttpGet("SecurityLocation")]
        public async Task<ActionResult<CustodianInstructionModel>> GetCustodianInstructionModel(string securitylocation)
        {
           CustodianInstructionModel custodianInstructionModel = new CustodianInstructionModel();
            try
            {
                if (custodianInstructionModel == null)
                {
                    return NotFound();
                }
                else
                {
                    var custodianInstruction = from t in _context.CustodianInstruction.Where(b => b.Location == securitylocation)
                                               select new CustodianInstructionDto()
                                               {
                                                   CustodianName = t.CustodianName,
                                                   Address = t.Address,
                                                   ContactNo = t.ContactNo,
                                                   ContactPerson = t.ContactPerson,
                                                   SecurityName = t.SecurityName,
                                                   TradeDate = t.TradeDate,
                                                   SettlementDate = t.SettlementDate,
                                                   WeightOfGoldBar = t.WeightOfGoldBar,
                                                   PurityOfGold = t.PurityOfGold,
                                                   Location = t.Location,
                                                   VaultLocation = t.VaultLocation,
                                                   CounterParty = t.CounterParty,
                                                   DelRefNo = t.DelRefNo,
                                                   QtyOfGoldBar = t.QtyOfGoldBar,
                                                   Total = t.Total

                                               };
                    await _context.SaveChangesAsync();

                    return Ok(custodianInstruction);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustodianInstructionModelExists(securitylocation))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return custodianInstructionModel;
        }

        // PUT: api/CustodianInstruction/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustodianInstructionModel(string securityLocation, DateTime transactiondate, CustodianInstructionModel custodianInstructionModel)
        {
            if (securityLocation != custodianInstructionModel.Location)
            {
                return BadRequest();
            }

            TransactionCaptureModel transactionCaptureModel = new TransactionCaptureModel();

            _context.Entry(custodianInstructionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustodianInstructionModelExists(securityLocation))
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

        // POST: api/CustodianInstruction
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustodianInstructionModel>> PostCustodianInstructionModel(CustodianInstructionModel custodianInstructionModel)
        {
            _context.CustodianInstruction.Add(custodianInstructionModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustodianInstructionModelExists(custodianInstructionModel.CustodianInstructionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustodianInstructionModel", new { id = custodianInstructionModel.CustodianInstructionId }, custodianInstructionModel);
        }

        // DELETE: api/CustodianInstruction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustodianInstructionModel>> DeleteCustodianInstructionModel(string id)
        {
            var custodianInstructionModel = await _context.CustodianInstruction.FindAsync(id);
            if (custodianInstructionModel == null)
            {
                return NotFound();
            }

            _context.CustodianInstruction.Remove(custodianInstructionModel);
            await _context.SaveChangesAsync();

            return custodianInstructionModel;
        }

        private bool CustodianInstructionModelExists(string id)
        {
            return _context.CustodianInstruction.Any(e => e.CustodianInstructionId == id);
        }
    }
}
