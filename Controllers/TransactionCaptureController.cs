using System.Linq.Expressions;
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
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<TransactionCaptureModel>>> GetTransactionCapture()
        // {
        //     return await _context.TransactionCapture.ToListAsync();
        // }
        [HttpGet("SecurityDetails")]
        public IQueryable<GoldDto> GetGoldLocation(string securityName)
        {
            var securityLocation = from c in _context.GoldMaster.Where(b => b.SecurityName == securityName )
                            select new GoldDto()
                            {
                                SecurityLocation = c.SecurityLocation,
                                NAVlot = c.NAVlot
                            };
            
                return securityLocation;
        }

        [HttpGet("GoldMaster")]
        public IQueryable<GoldDto> GetGoldMaster()
        {
            var transaction = from c in _context.GoldMaster
                            select new GoldDto()
                            {
                                GoldId=c.GoldId,
                                SecurityName=c.SecurityName,
                                Active=c.Active,
                                SecurityLocation = c.SecurityLocation,
                                Type=c.Type,
                                BarWeightInKg=c.BarWeightInKg,
                                BarWeightInGrams=c.BarWeightInGrams,
                                CommodityPurity=c.CommodityPurity,
                                CommodityDenomination=c.CommodityDenomination,
                                ValuationRateType=c.ValuationRateType,
                                CounterpartyShipper=c.CounterpartyShipper,
                                Currency=c.Currency,
                                Issuer=c.Issuer,
                                StockExchange=c.StockExchange,
                                Stampduty=c.Stampduty,
                                Octroi=c.Octroi,
                                Premium=c.Premium,
                                CustomDuty=c.CustomDuty,
                                FixingCharge=c.FixingCharge,
                                SGST=c.SGST,
                                CGST=c.CGST,
                                GST=c.GST,
                                NAVlot = c.NAVlot,
                                Facevalue=c.Facevalue
                            };
            
                return transaction;
        }

        [HttpGet("CounterParty")]
        public IQueryable<CounterPartyDto> GetCounterPartyDto()
        {
            {
                var transaction = from t in _context.CounterPartyMaster
                                  select new CounterPartyDto()
                                  {
                                      CounterPartyID = t.CounterPartyID,
                                      CounterpartyName = t.CounterpartyName,
                                      PAN = t.PAN,
                                      GSTNo = t.GSTNo,
                                      Address1 = t.Address1,
                                      Address2 = t.Address2,
                                      Address3 = t.Address3,
                                      EmailId1 = t.EmailId1,
                                      EmailId2 = t.EmailId2,
                                      TelNo1 = t.TelNo1,
                                      TelNo2 = t.TelNo2,
                                      FaxNo1 = t.FaxNo1,
                                      FaxNo2 = t.FaxNo2,
                                      MobNo1 = t.MobNo1,
                                      MobNo2 = t.MobNo2,
                                      ContactPerson = t.ContactPerson,
                                      BankName = t.BankName,
                                      BankBranch = t.BankBranch,
                                      IFSC = t.IFSC,
                                      NameBeneficiary = t.NameBeneficiary,
                                      AccountNo = t.AccountNo
                                  };

                return transaction;

                // return await _context.TransactionCapture.ToListAsync();
            }
        }
        [HttpGet("SalesMaker")]
        public IQueryable<TransactionCaptureDto> GetTransactionCaptureSM()
        {
            try
            {
                var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionStatus == "R" && b.TransactionType == "S")
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
            catch
            {
                throw;
            }


        }

        [HttpGet("PurchaseMaker")]
        public IQueryable<TransactionCaptureDto> GetTransactionCapturePM()
        {
            try
            {
                var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionStatus == "R" && b.TransactionType == "P")
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

            catch
            {
                throw;
            }
        }


        [HttpGet("SalesChecker")]
        public IQueryable<TransactionCaptureDto> GetTransactionCaptureSC()
        {
            try
            {
                var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionStatus == "M" || b.TransactionStatus == "N" && b.TransactionType == "S")
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
            catch
            {
                throw;
            }

        }

        [HttpGet("PurchaseChecker")]
        public IQueryable<TransactionCaptureDto> GetTransactionCapturePC()
        {
            try
            {
                var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionStatus == "M" || b.TransactionStatus == "N" && b.TransactionType == "P")
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
            catch
            {
                throw;
            }


        }






        // GET: api/TransactionCapture/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<TransactionCaptureModel>> GetTransactionCaptureModel(string id)
        // {
        //     var transactionCaptureModel = await _context.TransactionCapture.FindAsync(id);

        //     if (transactionCaptureModel == null)
        //     {
        //         return NotFound();
        //     }

        //     return transactionCaptureModel;
        // }

        [HttpGet("id")]

        public IQueryable<TransactionCaptureDto> GetbyID(string tid)
        {
            var transaction = from t in _context.TransactionCapture.Where(b => b.TransactionId == tid)
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


        // PUT: api/TransactionCapture/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTransactionCaptureModel(string id, TransactionCaptureModel transactionCaptureModel)
        // {
        //     if (id != transactionCaptureModel.TransactionId)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(transactionCaptureModel).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!TransactionCaptureModelExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }





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
                    if (transactionCaptureModel.TransactionStatus == "N" || transactionCaptureModel.TransactionStatus == "M")
                    {
                        var dto = new TransactionCaptureDto()
                        {
                            TransactionStatus = transactionCaptureModel.TransactionStatus = "A"
                        };
                    }
                }
                else if (Task == "Reject")
                {
                    if (transactionCaptureModel.TransactionStatus == "N" || transactionCaptureModel.TransactionStatus == "M")
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
                            TransactionStatus = transactionCaptureModel.TransactionStatus = "M",
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
