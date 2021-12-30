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

        
        // GET: api/DealConfirmation
        [HttpGet("GetSales")]
        public IQueryable<DealConfirmationDto> GetSales()
        {
            // return await _context.DealConfirmation.ToListAsync();
            try
            {
                var transaction = from t in _context.DealConfirmation.Where(b => b.DealStatus == "Incomplete" && b.TransactionType == "S")
                                  select new DealConfirmationDto()
                                  {
                                      TransactionId = t.TransactionId,
                                      DealConfirmId = t.DealConfirmId,
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
                                      DealStatus = t.DealStatus
                                  };

                return transaction;

            }
            catch
            {
                throw;
            }
        }

        [HttpGet("GetPurchase")]
        public IQueryable<DealConfirmationDto> GetPurchase()
        {
            // return await _context.DealConfirmation.ToListAsync();
            try
            {
                var transaction = from t in _context.DealConfirmation.Where(b => b.DealStatus == "Incomplete" && b.TransactionType == "P")
                                  select new DealConfirmationDto()
                                  {
                                      TransactionId = t.TransactionId,
                                      DealConfirmId = t.DealConfirmId,
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
                                      DealStatus = t.DealStatus
                                  };

                return transaction;

            }
            catch
            {
                throw;
            }
        }


        [HttpGet("id")]

        public IQueryable<DealConfirmationDto> GetbyDRN(string drn)
        {
            var transaction = from t in _context.DealConfirmation.Where(b => b.DealRefNo == drn && b.TransactionType == "S" && b.DealStatus == "Complete")
                              select new DealConfirmationDto()
                              {
                                  TransactionId = t.TransactionId,
                                  DealConfirmId = t.DealConfirmId,
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
                                  DealStatus = t.DealStatus

                              };

            return transaction;
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
        
        [HttpPut("{id}")]
        
        public async Task<IActionResult> ConfirmDeal(string id, DealConfirmationModel DealConfirmationModel, string Task)
        {
            if (id != DealConfirmationModel.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(DealConfirmationModel).State = EntityState.Modified;

            try
            {
                if (Task == "Authorize")
                {
                    if (DealConfirmationModel.DealStatus == "Incomplete")
                    {
                        var dto = new DealConfirmationDto()
                        {
                            DealStatus = DealConfirmationModel.DealStatus = "Complete",

                        };

                        await _context.SaveChangesAsync();
                    
                        CustodianInstructionModel custodianInstructionModel1 = new CustodianInstructionModel();
  
                        var data = new DealConfirmationDto()
                        {
                            DealRefNo = DealConfirmationModel.DealRefNo = custodianInstructionModel1.DelRefNo 
      
                        };
                    }
                }

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
            await _context.SaveChangesAsync();

            return NoContent();
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
