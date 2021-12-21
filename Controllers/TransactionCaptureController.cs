using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Data;
using SBI_MF.Models;

namespace SBI_MF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionCaptureController : ControllerBase
    {
        private readonly SBIMFDbContext _context;

        public TransactionCaptureController(SBIMFDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionCapture
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<TransactionCaptureModel>>> GetTransactionCapture()
//         {
//             return await _context.TransactionCapture.ToListAsync();
//         }

        [HttpGet]
        public IQueryable<TransactionCaptureDto> GetTransactionCaptureDto(String Task)
        {

            if (Task == "Maker")
            {
                var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionStatus == "R")
                select new TransactionCaptureDto()
                    {
                        TransactionId = t.TransactionId,
                        TransactionDate = t.TransactionDate,
                        SettlementTenor = t.SettlementTenor,
                        ValueDate = t.ValueDate,
                        Counterparty = t.Counterparty,
                        SchemeName = t.SchemeName,
                        Security = t.Security,
                        SecurityLocation = t.SecurityLocation,
                        DealValue = t.DealValue,
                        QuantityInKg = t.QuantityInKg,
                        NoOfUnitsPerKg = t.NoOfUnitsPerKg,
                        TotalUnits = t.TotalUnits,
                        TransactionStatus = t.TransactionStatus,
                        TransactionType = t.TransactionType
                    };
                
                return transaction;

                // return await _context.TransactionCapture.ToListAsync();
            }

            else
            {
                var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionStatus == "M" || b.TransactionStatus == "R")
                                  select new TransactionCaptureDto()
                                  {
                                      TransactionId = t.TransactionId,
                                      TransactionDate = t.TransactionDate,
                                      SettlementTenor = t.SettlementTenor,
                                      ValueDate = t.ValueDate,
                                      Counterparty = t.Counterparty,
                                      SchemeName = t.SchemeName,
                                      Security = t.Security,
                                      SecurityLocation = t.SecurityLocation,
                                      DealValue = t.DealValue,
                                      QuantityInKg = t.QuantityInKg,
                                      NoOfUnitsPerKg = t.NoOfUnitsPerKg,
                                      TotalUnits = t.TotalUnits,
                                      TransactionStatus = t.TransactionStatus,
                                      TransactionType = t.TransactionType

                                  };
                return transaction;
             }
            // return transaction;

        }


        // GET: api/TransactionCapture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionCaptureModel>> GetTransactionCaptureModel(string id)
        {
            var transactionCaptureModel = await _context.TransactionCapture.FindAsync(id);

            if (transactionCaptureModel == null)
            {
                return NotFound();
            }

            return transactionCaptureModel;
        }

        // PUT: api/TransactionCapture/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionCaptureModel(string id, TransactionCaptureModel transactionCaptureModel)
        {
            if (id != transactionCaptureModel.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transactionCaptureModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionCaptureModelExists(id))
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

        // POST: api/TransactionCapture
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransactionCaptureModel>> PostTransactionCaptureModel(TransactionCaptureModel transactionCaptureModel)
        {
            _context.TransactionCapture.Add(transactionCaptureModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransactionCaptureModelExists(transactionCaptureModel.TransactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransactionCaptureModel", new { id = transactionCaptureModel.TransactionId }, transactionCaptureModel);
        }

        // DELETE: api/TransactionCapture/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionCaptureModel>> DeleteTransactionCaptureModel(string id)
        {
            var transactionCaptureModel = await _context.TransactionCapture.FindAsync(id);
            if (transactionCaptureModel == null)
            {
                return NotFound();
            }

            _context.TransactionCapture.Remove(transactionCaptureModel);
            await _context.SaveChangesAsync();

            return transactionCaptureModel;
        }

        private bool TransactionCaptureModelExists(string id)
        {
            return _context.TransactionCapture.Any(e => e.TransactionId == id);
        }
    }
}
