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
    public class DealConfirmationController : ControllerBase
    {
        private readonly SBIMFDbContext _context;

        public DealConfirmationController(SBIMFDbContext context)
        {
            _context = context;
        }

        // GET: api/DealConfirmation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealConfirmationModel>>> GetDealConfirmation()
        {
            return await _context.DealConfirmation.ToListAsync();
        }
        
         [HttpGet("PendingRecord")]
      
        public IQueryable<DealConfirmationDto> GetDealConfirmation()
        {
            try
            {
                var transaction = from t in _context.DealConfirmation.Where(b => b.DealStatus == "Incomplete")
                                  select new DealConfirmationDto()
                                  {
                                      DealConfirmId = t.DealConfirmId,
                                      TransactionId = t.TransactionId,
                                      Name = t.Name,
                                      Address = t.Address,
                                      ContactNo = t.ContactNo,
                                      ContactPersonName = t.ContactPersonName,
                                      DealRefNo = t.DealRefNo,
                                      ClientName = t.ClientName,
                                      SchemeName = t.SchemeName,
                                      TransactionType = t.TransactionType,
                                      GSTNo = t.GSTNo,
                                      DealDate = t.DealDate,
                                      ValueDate = t.ValueDate,
                                      Commodity = t.Commodity,
                                      CounterpartyShipper = t.CounterpartyShipper,
                                      QuantityInKilogram = t.QuantityInKilogram,
                                      Rate = t.Rate,
                                      TotalPrice = t.TotalPrice,
                                      SGST = t.SGST,
                                      CGST = t.CGST,
                                      GST = t.GST,
                                      TotalGST = t.TotalGST,
                                      TotalConsideration = t.TotalConsideration,
                                      OtherApplicableTaxes = t.OtherApplicableTaxes,
                                      TaxCollectedAtSource = t.TaxCollectedAtSource,
                                      NetConsideration = t.NetConsideration,
                                      Remarks = t.Remarks,
                                      BranchName = t.BranchName,
                                      IFSCCode = t.IFSCCode,
                                      BeneficiaryAccount = t.BeneficiaryAccount,
                                      BeneficiaryAccountName = t.BeneficiaryAccountName,
                                      DealStatus =t.DealStatus
                                  };

                return transaction;

            }
            catch
            {
                throw;
            }


        }


        // GET: api/DealConfirmation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealConfirmationModel>> GetDealConfirmationModel(string id)
        {
            var dealConfirmationModel = await _context.DealConfirmation.FindAsync(id);

            if (dealConfirmationModel == null)
            {
                return NotFound();
            }

            return dealConfirmationModel;
        }

        // PUT: api/DealConfirmation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealConfirmationModel(string id, DealConfirmationModel dealConfirmationModel)
        {
            if (id != dealConfirmationModel.DealConfirmId)
            {
                return BadRequest();
            }

            _context.Entry(dealConfirmationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealConfirmationModelExists(id))
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

        // POST: api/DealConfirmation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DealConfirmationModel>> PostDealConfirmationModel(DealConfirmationModel dealConfirmationModel)
        {
            _context.DealConfirmation.Add(dealConfirmationModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DealConfirmationModelExists(dealConfirmationModel.DealConfirmId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDealConfirmationModel", new { id = dealConfirmationModel.DealConfirmId }, dealConfirmationModel);
        }

        // DELETE: api/DealConfirmation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DealConfirmationModel>> DeleteDealConfirmationModel(string id)
        {
            var dealConfirmationModel = await _context.DealConfirmation.FindAsync(id);
            if (dealConfirmationModel == null)
            {
                return NotFound();
            }

            _context.DealConfirmation.Remove(dealConfirmationModel);
            await _context.SaveChangesAsync();

            return dealConfirmationModel;
        }

        private bool DealConfirmationModelExists(string id)
        {
            return _context.DealConfirmation.Any(e => e.DealConfirmId == id);
        }
    }
}
