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
        [HttpPut]
        public async Task<IActionResult> PutValuationModel( ValuationModel valuationModel, string Task)
        {
            // if (id != valuationModel.ValuationId)
            // {
            //     return BadRequest();
            // }

            _context.Entry(valuationModel).State = EntityState.Modified;

            try
            {
                if (Task == "Authorize")
                {
                    if (valuationModel.TransactionStatus == "N" || valuationModel.TransactionStatus == "M")
                    {
                        var dto = new ValuationDto()
                        {
                            TransactionStatus = valuationModel.TransactionStatus = "A"
                        };

                          await _context.SaveChangesAsync();

                           DealConfirmationModel DealConfirmationModel1 = new DealConfirmationModel();
                           TransactionCaptureModel TransactionCaptureModel1 = new TransactionCaptureModel();
                           CounterPartyModel counterPartyModel1 = new CounterPartyModel();
                           CustodianInstructionModel custodianInstructionModel1 = new CustodianInstructionModel();
                           GoldModel goldModel1 = new GoldModel();
                           TaxesModel taxesModel1 = new TaxesModel();

                    var Transdata = (from c in _context.TransactionCapture
                                    where  c.TransactionId== valuationModel.TransactionId
                                             select new
                                             {
                                                SchemeName =c.SchemeName,
                                                TransactionType =c.TransactionType,
                                                DealDate = c.TransactionDate,
                                                ValueDate = c.ValueDate,
                                                QuantityInKilogram = c.QuantityInKg,
                                                
                                             }).ToList();

                        foreach (var c1 in Transdata)
                        {
                            
                            DealConfirmationModel1.SchemeName = c1.SchemeName;
                            DealConfirmationModel1.TransactionType = c1.TransactionType;
                            DealConfirmationModel1.DealDate = c1.DealDate;
                            DealConfirmationModel1.ValueDate = c1.ValueDate;
                            DealConfirmationModel1.QuantityInKilogram = c1.QuantityInKilogram;
                          

                            break;
                        }
                    
                    var DealData = (from c in _context.CounterPartyMaster
                                    join t in _context.TransactionCapture on c.CounterpartyName equals t.Counterparty
                                    where  t.TransactionId== valuationModel.TransactionId
                                             select new
                                             {
                                                 Name = c.CounterpartyName,
                                                 Address =  c.Address1,
                                                 ContactNo = c.MobNo1,
                                                 ContactPersonName = c.ContactPerson,
                                                 GSTNo = c.GSTNo,
                                                 
                                             }).ToList();

                        foreach (var c1 in DealData)
                        {
                            DealConfirmationModel1.Name = c1.Name;
                            DealConfirmationModel1.Address = c1.Address;
                            DealConfirmationModel1.ContactNo = c1.ContactNo;
                            DealConfirmationModel1.ContactPersonName = c1.ContactPersonName;
                            DealConfirmationModel1.GSTNo = c1.GSTNo;

                            break;
                        }

                        var DealData1 = (from c in _context.CounterPartyMaster
                                        join t in _context.TransactionCapture on c.CounterpartyName equals t.Counterparty
                                        where  t.TransactionId== valuationModel.TransactionId && t.TransactionType == "S"
                                        select new
                                             {
                                                BranchName =c.BankBranch,
                                                IFSCCode = c.IFSC,
                                                BeneficiaryAccount = c.AccountNo,
                                                BeneficiaryAccountName =c.NameBeneficiary,
                                                 
                                             }).ToList();

                        foreach (var c1 in DealData1)
                        {
                            DealConfirmationModel1.BranchName = c1.BranchName;
                            DealConfirmationModel1.IFSCCode = c1.IFSCCode;
                            DealConfirmationModel1.BeneficiaryAccount = c1.BeneficiaryAccount;
                            DealConfirmationModel1.BeneficiaryAccountName = c1.BeneficiaryAccountName;
                       

                            break;
                        }

                        var GoldData = (from c in _context.GoldMaster
                                       join t in _context.TransactionCapture on c.SecurityLocation equals t.SecurityLocation
                                       where  c.SecurityLocation== t.SecurityLocation
                                             select new
                                             {
                                                Commodity =c.CommodityPurity,
                                                Commodity1 =c.CommodityDenomination,
                                                CounterpartyShipper = c.CounterpartyShipper,
                                                
                                             }).ToList();

                        foreach (var c1 in GoldData)
                        {
                            DealConfirmationModel1.Commodity = c1.Commodity + " " +c1.Commodity1;
                            DealConfirmationModel1.CounterpartyShipper = c1.CounterpartyShipper;
                          

                            break;
                        }

                        var tax = (from c in _context.TaxMaster
                                        where c.TaxId == "TAX0000001"
                                             select new
                                             {
                                                TaxId =c.TaxId,
                                                State =c.State,
                                                SGST = c.SGST,
                                                GST = c.GST,
                                                CGST = c.CGST,
                                                
                                             }).ToList();
                        foreach (var c1 in tax)
                        {
                            DealConfirmationModel1.Rate = 3;
                            DealConfirmationModel1.TotalPrice = (DealConfirmationModel1.QuantityInKilogram * DealConfirmationModel1.Rate);
                            DealConfirmationModel1.SGST = c1.SGST * DealConfirmationModel1.TotalPrice;
                            DealConfirmationModel1.CGST = c1.CGST * DealConfirmationModel1.TotalPrice;
                            DealConfirmationModel1.GST = c1.GST* DealConfirmationModel1.TotalPrice;
                            DealConfirmationModel1.TotalGST = DealConfirmationModel1.SGST+DealConfirmationModel1.CGST+DealConfirmationModel1.GST;
                          

                            break;
                        }

                        var data = new DealConfirmationDto()
                        {
                        DealConfirmId = DealConfirmationModel1.DealConfirmId = SBIMFDbContext.fn_DealConfirmID(),
                        TransactionId = DealConfirmationModel1.TransactionId = valuationModel.TransactionId,
                        DealRefNo = DealConfirmationModel1.DealRefNo = "",
                        SchemeName=DealConfirmationModel1.SchemeName,
                        TransactionType=DealConfirmationModel1.TransactionType,
                        DealDate=DealConfirmationModel1.DealDate,
                        ValueDate=DealConfirmationModel1.ValueDate,
                        QuantityInKilogram=DealConfirmationModel1.QuantityInKilogram,
                        Name=DealConfirmationModel1.Name,
                        Address=DealConfirmationModel1.Address,
                        ContactNo=DealConfirmationModel1.ContactNo,
                        ContactPersonName=DealConfirmationModel1.ContactPersonName,
                        GSTNo=DealConfirmationModel1.GSTNo,
                        BranchName=DealConfirmationModel1.BranchName,
                        IFSCCode=DealConfirmationModel1.IFSCCode,
                        BeneficiaryAccount=DealConfirmationModel1.BeneficiaryAccount,
                        BeneficiaryAccountName=DealConfirmationModel1.BeneficiaryAccountName,
                        Commodity=DealConfirmationModel1.Commodity,
                        CounterpartyShipper=DealConfirmationModel1.CounterpartyShipper,
                        ClientName = DealConfirmationModel1.ClientName = "SBI-MUTUAL-FUND",
                        Rate = DealConfirmationModel1.Rate,
                        Remarks = DealConfirmationModel1.Remarks = "",
                        DealStatus = DealConfirmationModel1.DealStatus = "Incomplete",
                        TotalPrice = DealConfirmationModel1.TotalPrice,
                        SGST = DealConfirmationModel1.SGST,
                        CGST = DealConfirmationModel1.CGST,
                        GST = DealConfirmationModel1.GST,
                        TotalGST = DealConfirmationModel1.TotalGST,
                        TotalConsideration =  DealConfirmationModel1.TotalConsideration = (DealConfirmationModel1.TotalPrice + DealConfirmationModel1.TotalGST),
                        OtherApplicableTaxes = DealConfirmationModel1.OtherApplicableTaxes = "",
                        TaxCollectedAtSource = DealConfirmationModel1.TaxCollectedAtSource = DealConfirmationModel1.TotalConsideration,
                        NetConsideration =  DealConfirmationModel1.NetConsideration = (DealConfirmationModel1.TotalConsideration + DealConfirmationModel1.TaxCollectedAtSource),
                        };

                        _context.DealConfirmation.Add(DealConfirmationModel1);

                        await _context.SaveChangesAsync();
                        
                        
                    }
                    
                    
                }

              
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!ValuationModelExists(id))
                // {
                //     return NotFound();
                // }
                // else
                // {
                //     throw;
                // }
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
