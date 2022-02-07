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
            if (id != DealConfirmationModel.DealConfirmId)
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
  
                    var dealdata=  (from c in _context.CustodianInstruction
                                    where  DealConfirmationModel.TransactionId== c.TransactionId
                                             select new
                                             {
                                                DealRefNo =c.DelRefNo
                                               
                                             }).ToList();

                        foreach (var c1 in dealdata)
                        {
                            
                            DealConfirmationModel.DealRefNo = c1.DealRefNo;

                            break;
                        }
                    
                        var data = new DealConfirmationDto()
                        {
                            DealRefNo = DealConfirmationModel.DealRefNo 
                        };

                        
                        await _context.SaveChangesAsync();
                    }
                }

            

                if (Task == "Reject")
                {
                    TransactionCaptureModel TransactionCaptureModel1 = new TransactionCaptureModel();
                    ValuationModel valuationModel1 = new ValuationModel();

                    if (DealConfirmationModel.DealStatus == "Incomplete")
                    {
                        var dto = new DealConfirmationDto()
                        {
                            DealStatus = DealConfirmationModel.DealStatus = "D",
                            
                        };

                         var dealData = (from dc in _context.DealConfirmation
                                join t in _context.TransactionCapture
                                on dc.TransactionId equals t.TransactionId
                                where DealConfirmationModel.TransactionId == t.TransactionId
                                select new
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
                                    TransactionType = t.TransactionType,

                                }
                                ).ToList();

                        foreach (var c1 in dealData)
                        {
                             TransactionCaptureModel1.TransactionId = c1.TransactionId;
                             TransactionCaptureModel1.TransactionDate = c1.TransactionDate;
                             TransactionCaptureModel1 .SettlementTenor = c1.SettlementTenor;
                             TransactionCaptureModel1.ValueDate = c1.ValueDate;
                             TransactionCaptureModel1.Counterparty = c1.Counterparty;
                             TransactionCaptureModel1.SchemeName = c1.SchemeName;
                             TransactionCaptureModel1.Security = c1.Security;
                             TransactionCaptureModel1.SecurityLocation = c1.SecurityLocation;
                             TransactionCaptureModel1.DealValue = c1.DealValue;
                             TransactionCaptureModel1.QuantityInKg = c1.QuantityInKg;
                             TransactionCaptureModel1.NoOfUnitsPerKg = c1.NoOfUnitsPerKg;
                             TransactionCaptureModel1.TotalUnits = c1.TotalUnits;
                             TransactionCaptureModel1.TransactionStatus = "D";
                             TransactionCaptureModel1.TransactionType = c1.TransactionType;

                            break;
                        }
     
                          var dto1 = new TransactionCaptureDto()       
                        {
                                TransactionId = TransactionCaptureModel1.TransactionId,
                                TransactionDate = TransactionCaptureModel1.TransactionDate,
                                SettlementTenor = TransactionCaptureModel1.SettlementTenor,
                                ValueDate = TransactionCaptureModel1.ValueDate,
                                Counterparty = TransactionCaptureModel1.Counterparty,
                                SchemeName = TransactionCaptureModel1.SchemeName,
                                Security = TransactionCaptureModel1.Security,
                                SecurityLocation = TransactionCaptureModel1.SecurityLocation,
                                DealValue = TransactionCaptureModel1.DealValue,
                                QuantityInKg = TransactionCaptureModel1.QuantityInKg,
                                NoOfUnitsPerKg = TransactionCaptureModel1.NoOfUnitsPerKg,
                                TotalUnits = TransactionCaptureModel1.TotalUnits,
                                TransactionType = TransactionCaptureModel1.TransactionType,
                                TransactionStatus = TransactionCaptureModel1.TransactionStatus 
                        };  


                       var dealData1 = (from dc in _context.DealConfirmation
                                join v in _context.TestValuation
                                on dc.TransactionId equals v.TransactionId
                                where DealConfirmationModel.TransactionId == v.TransactionId
                                select new
                                {
                                  ValuationId=v.ValuationId,
                                  TransactionId=v.TransactionId,
                                  Workflow=v.Workflow,
                                  TransactionType=v.TransactionType,
                                  LondonAMRateUSD=v.LondonAMRateUSD,
                                  FixingChargesUSD=v.FixingChargesUSD,
                                  PremiumUSD=v.PremiumUSD,
                                  MetalRateUSD=v.MetalRateUSD,
                                  ConversionFactor=v.ConversionFactor,
                                  RBIReferenceRateINR=v.RBIReferenceRateINR,
                                  MetalRatePerkgINR=v.MetalRatePerkgINR,
                                  CustomsDutyKg=v.CustomsDutyKg,
                                  StampDutyINR=v.StampDutyINR,
                                  FinalPriceUSD=v.FinalPriceUSD,
                                  TransactionStatus=v.TransactionStatus,

                                }
                                ).ToList();

                        foreach (var c2 in dealData1)
                        {
                             valuationModel1.ValuationId=c2.ValuationId;
                             valuationModel1.TransactionId=c2.TransactionId;
                             valuationModel1.Workflow=c2.Workflow;
                             valuationModel1.TransactionType=c2.TransactionType;
                             valuationModel1.LondonAMRateUSD=c2.LondonAMRateUSD;
                             valuationModel1.FixingChargesUSD=c2.FixingChargesUSD;
                             valuationModel1.PremiumUSD=c2.PremiumUSD;
                             valuationModel1.MetalRateUSD=c2.MetalRateUSD;
                             valuationModel1.ConversionFactor=c2.ConversionFactor;
                             valuationModel1.RBIReferenceRateINR=c2.RBIReferenceRateINR;
                             valuationModel1.MetalRatePerkgINR=c2.MetalRatePerkgINR;
                             valuationModel1.CustomsDutyKg=c2.CustomsDutyKg;
                             valuationModel1.StampDutyINR=c2.StampDutyINR;
                             valuationModel1.FinalPriceUSD=c2.FinalPriceUSD;
                             valuationModel1.TransactionStatus="D";

                            break;
                        }
     
                          var dto2 = new ValuationDto()       
                        {
                            ValuationId = valuationModel1.ValuationId,
                            TransactionId =valuationModel1.TransactionId,
                            Workflow =valuationModel1.Workflow,
                            TransactionType=valuationModel1.TransactionType,
                            LondonAMRateUSD =valuationModel1.LondonAMRateUSD,
                            FixingChargesUSD =valuationModel1.FixingChargesUSD,
                            PremiumUSD =valuationModel1.PremiumUSD,
                            MetalRateUSD =valuationModel1.MetalRateUSD,
                            ConversionFactor =valuationModel1.ConversionFactor,
                            RBIReferenceRateINR =valuationModel1.RBIReferenceRateINR,
                            MetalRatePerkgINR =valuationModel1.MetalRatePerkgINR,
                            CustomsDutyKg =valuationModel1.CustomsDutyKg,
                            StampDutyINR =valuationModel1.StampDutyINR,
                            FinalPriceUSD =valuationModel1.FinalPriceUSD,
                            TransactionStatus =valuationModel1.TransactionStatus,
                        };  

                        _context.Entry(TransactionCaptureModel1).State = EntityState.Modified;
                        _context.Entry(valuationModel1).State = EntityState.Modified;
                        _context.Entry(DealConfirmationModel).State = EntityState.Modified;
                       
                        await _context.SaveChangesAsync();

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
        
        
        [HttpPut("AuthMultiple")]  
        public async Task<IActionResult> ConfirmDeal1(List<DealConfirmationModel> DealConfirmationModel, string Task)
        {
            try
            {   
                foreach(var d in DealConfirmationModel)
                {
                if (Task == "Authorize")
                {
                    if (d.DealStatus == "Incomplete")
                    {
                        var dto = new DealConfirmationDto()
                        {
                            DealStatus = d.DealStatus = "Complete",
                        };

                        _context.Entry(d).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        
                        CustodianInstructionModel custodianInstructionModel1 = new CustodianInstructionModel();
  
                    var dealdata=  (from c in _context.CustodianInstruction
                                    where  d.TransactionId== c.TransactionId
                                             select new
                                             {
                                                DealRefNo =c.DelRefNo
                                               
                                             }).ToList();

                        foreach (var c1 in dealdata)
                        {
                            
                            d.DealRefNo = c1.DealRefNo;

                            break;
                        }
                    
                        var data = new DealConfirmationDto()
                        {
                            DealRefNo = d.DealRefNo 
                        };

                        _context.Entry(d).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }

            

                if (Task == "Reject")
                {
                    TransactionCaptureModel TransactionCaptureModel1 = new TransactionCaptureModel();
                    ValuationModel valuationModel1 = new ValuationModel();

                    if (d.DealStatus == "Incomplete")
                    {
                        var dto = new DealConfirmationDto()
                        {
                            DealStatus = d.DealStatus = "D",
                            
                        };

                        // var allData = (from d in _context.DealConfirmation 
                        //     join v in _context.TestValuation on d.TransactionId equals v.TransactionId
                        //     join ci in _context.CustodianInstruction on v.TransactionId equals ci.TransactionId
                        //     ).ToList();

                         var dealData = (from dc in _context.DealConfirmation
                                join t in _context.TransactionCapture
                                on dc.TransactionId equals t.TransactionId
                                where d.TransactionId == t.TransactionId
                                select new
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
                                    TransactionType = t.TransactionType,

                                }
                                ).ToList();

                        foreach (var c1 in dealData)
                        {
                             TransactionCaptureModel1.TransactionId = c1.TransactionId;
                             TransactionCaptureModel1.TransactionDate = c1.TransactionDate;
                             TransactionCaptureModel1 .SettlementTenor = c1.SettlementTenor;
                             TransactionCaptureModel1.ValueDate = c1.ValueDate;
                             TransactionCaptureModel1.Counterparty = c1.Counterparty;
                             TransactionCaptureModel1.SchemeName = c1.SchemeName;
                             TransactionCaptureModel1.Security = c1.Security;
                             TransactionCaptureModel1.SecurityLocation = c1.SecurityLocation;
                             TransactionCaptureModel1.DealValue = c1.DealValue;
                             TransactionCaptureModel1.QuantityInKg = c1.QuantityInKg;
                             TransactionCaptureModel1.NoOfUnitsPerKg = c1.NoOfUnitsPerKg;
                             TransactionCaptureModel1.TotalUnits = c1.TotalUnits;
                             TransactionCaptureModel1.TransactionStatus = "D";
                             TransactionCaptureModel1.TransactionType = c1.TransactionType;

                            break;
                        }
     
                          var dto1 = new TransactionCaptureDto()       
                        {
                                TransactionId = TransactionCaptureModel1.TransactionId,
                                TransactionDate = TransactionCaptureModel1.TransactionDate,
                                SettlementTenor = TransactionCaptureModel1.SettlementTenor,
                                ValueDate = TransactionCaptureModel1.ValueDate,
                                Counterparty = TransactionCaptureModel1.Counterparty,
                                SchemeName = TransactionCaptureModel1.SchemeName,
                                Security = TransactionCaptureModel1.Security,
                                SecurityLocation = TransactionCaptureModel1.SecurityLocation,
                                DealValue = TransactionCaptureModel1.DealValue,
                                QuantityInKg = TransactionCaptureModel1.QuantityInKg,
                                NoOfUnitsPerKg = TransactionCaptureModel1.NoOfUnitsPerKg,
                                TotalUnits = TransactionCaptureModel1.TotalUnits,
                                TransactionType = TransactionCaptureModel1.TransactionType,
                                TransactionStatus = TransactionCaptureModel1.TransactionStatus 
                        };  


                       var dealData1 = (from dc in _context.DealConfirmation
                                join v in _context.TestValuation
                                on dc.TransactionId equals v.TransactionId
                                where d.TransactionId == v.TransactionId
                                select new
                                {
                                  ValuationId=v.ValuationId,
                                  TransactionId=v.TransactionId,
                                  Workflow=v.Workflow,
                                  TransactionType=v.TransactionType,
                                  LondonAMRateUSD=v.LondonAMRateUSD,
                                  FixingChargesUSD=v.FixingChargesUSD,
                                  PremiumUSD=v.PremiumUSD,
                                  MetalRateUSD=v.MetalRateUSD,
                                  ConversionFactor=v.ConversionFactor,
                                  RBIReferenceRateINR=v.RBIReferenceRateINR,
                                  MetalRatePerkgINR=v.MetalRatePerkgINR,
                                  CustomsDutyKg=v.CustomsDutyKg,
                                  StampDutyINR=v.StampDutyINR,
                                  FinalPriceUSD=v.FinalPriceUSD,
                                  TransactionStatus=v.TransactionStatus,

                                }
                                ).ToList();

                        foreach (var c2 in dealData1)
                        {
                             valuationModel1.ValuationId=c2.ValuationId;
                             valuationModel1.TransactionId=c2.TransactionId;
                             valuationModel1.Workflow=c2.Workflow;
                             valuationModel1.TransactionType=c2.TransactionType;
                             valuationModel1.LondonAMRateUSD=c2.LondonAMRateUSD;
                             valuationModel1.FixingChargesUSD=c2.FixingChargesUSD;
                             valuationModel1.PremiumUSD=c2.PremiumUSD;
                             valuationModel1.MetalRateUSD=c2.MetalRateUSD;
                             valuationModel1.ConversionFactor=c2.ConversionFactor;
                             valuationModel1.RBIReferenceRateINR=c2.RBIReferenceRateINR;
                             valuationModel1.MetalRatePerkgINR=c2.MetalRatePerkgINR;
                             valuationModel1.CustomsDutyKg=c2.CustomsDutyKg;
                             valuationModel1.StampDutyINR=c2.StampDutyINR;
                             valuationModel1.FinalPriceUSD=c2.FinalPriceUSD;
                             valuationModel1.TransactionStatus="D";

                            break;
                        }
     
                          var dto2 = new ValuationDto()       
                        {
                            ValuationId = valuationModel1.ValuationId,
                            TransactionId =valuationModel1.TransactionId,
                            Workflow =valuationModel1.Workflow,
                            TransactionType=valuationModel1.TransactionType,
                            LondonAMRateUSD =valuationModel1.LondonAMRateUSD,
                            FixingChargesUSD =valuationModel1.FixingChargesUSD,
                            PremiumUSD =valuationModel1.PremiumUSD,
                            MetalRateUSD =valuationModel1.MetalRateUSD,
                            ConversionFactor =valuationModel1.ConversionFactor,
                            RBIReferenceRateINR =valuationModel1.RBIReferenceRateINR,
                            MetalRatePerkgINR =valuationModel1.MetalRatePerkgINR,
                            CustomsDutyKg =valuationModel1.CustomsDutyKg,
                            StampDutyINR =valuationModel1.StampDutyINR,
                            FinalPriceUSD =valuationModel1.FinalPriceUSD,
                            TransactionStatus =valuationModel1.TransactionStatus,
                        };  

                        _context.Entry(TransactionCaptureModel1).State = EntityState.Modified;
                        _context.Entry(valuationModel1).State = EntityState.Modified;
                        _context.Entry(d).State = EntityState.Modified;
                       
                        await _context.SaveChangesAsync();

                    }
                       
                }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
               
                throw;
                
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
