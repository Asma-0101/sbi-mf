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
    public class TransactionCaptureController : ControllerBase
    {
        private readonly SBIMFDbContext _context;

        public TransactionCaptureController(SBIMFDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionCapture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionCaptureModel>>> GetTransactionCapture()
        {
            return await _context.TransactionCapture.ToListAsync();
        }

        // GET: api/TransactionCapture/5
        [HttpGet("GoldMaster")]
        public IQueryable<GoldDto> GetTransactionCaptureModel(string securityName)
        {
            var securityLocation = from c in _context.GoldMaster.Where(b => b.SecurityName == securityName )
                            select new GoldDto()
                            {
                                SecurityLocation = c.SecurityLocation,
                                NAVlot = c.NAVlot
                            };
            
                return securityLocation;
        
            //var GoldModel = await _context.TransactionCapture.FindAsync(securityName);

            // if (securityLocation == null)
            // {
            //     return NotFound();
            // }
            // else{
            // }

            //return transactionCaptureModel;
        }

        // PUT: api/TransactionCapture/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionCaptureModel(string id, TransactionCaptureModel transactionCaptureModel, string Task)
        {
            if (id != transactionCaptureModel.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transactionCaptureModel).State = EntityState.Modified;

            try
            {
                if (Task == "Authorize")
                {
                    if (transactionCaptureModel.TransactionStatus == "N")
                    {
                        var dto = new TransactionCaptureDto()
                        {
                            TransactionStatus = transactionCaptureModel.TransactionStatus = "A"
                        };
                    }
                }
                else if (Task == "Reject")
                {
                    if (transactionCaptureModel.TransactionStatus == "N")
                    {
                        var dto = new TransactionCaptureDto()
                        {
                            TransactionStatus = transactionCaptureModel.TransactionStatus = "R"
                        };
                    }
                }
                else if (Task == "Update")
                {
                    if (transactionCaptureModel.TransactionStatus == "R")
                    {
                        var dto = new TransactionCaptureDto()
                        {
                            TransactionDate = transactionCaptureModel.TransactionDate,
                            SettlementTenor = transactionCaptureModel.SettlementTenor,
                            ValueDate = transactionCaptureModel.ValueDate,
                            Counterparty = transactionCaptureModel.Counterparty,
                            SchemeName = transactionCaptureModel.SchemeName,
                            Security = transactionCaptureModel.Security,
                            SecurityLocation = transactionCaptureModel.SecurityLocation,
                            DealValue = transactionCaptureModel.DealValue,
                            QuantityInKg = transactionCaptureModel.QuantityInKg,
                            NoOfUnitsPerKg = transactionCaptureModel.NoOfUnitsPerKg,
                            TotalUnits = transactionCaptureModel.TotalUnits,
                            TransactionStatus = transactionCaptureModel.TransactionStatus = "N",
                            TransactionType = transactionCaptureModel.TransactionType
                        };
                    }
                }

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
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TransactionCapture
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransactionCaptureModel>> PostTransactionCaptureModel(TransactionCaptureModel transactionCaptureModel)
        {
            try
            {
                var data = new TransactionCaptureDto()
                {
                    TransactionId = transactionCaptureModel.TransactionId = SBIMFDbContext.fn_getTransactionID(),
                    TransactionDate = transactionCaptureModel.TransactionDate,
                    SettlementTenor = transactionCaptureModel.SettlementTenor,
                    ValueDate = transactionCaptureModel.ValueDate,
                    Counterparty = transactionCaptureModel.Counterparty,
                    SchemeName = transactionCaptureModel.SchemeName,
                    Security = transactionCaptureModel.Security,
                    SecurityLocation = transactionCaptureModel.SecurityLocation,
                    DealValue = transactionCaptureModel.DealValue,
                    QuantityInKg = transactionCaptureModel.QuantityInKg,
                    NoOfUnitsPerKg = transactionCaptureModel.NoOfUnitsPerKg,
                    TotalUnits = transactionCaptureModel.TotalUnits,
                    TransactionStatus = transactionCaptureModel.TransactionStatus = "N",
                    TransactionType = transactionCaptureModel.TransactionType
                };
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
            _context.TransactionCapture.Add(transactionCaptureModel);
            await _context.SaveChangesAsync();

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

