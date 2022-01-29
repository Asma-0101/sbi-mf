using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Controllers.Dtos;
using SBI_MF.Data;
using SBI_MF.Models;

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
            return await _context.TestValuation.ToListAsync();
        }
        
        [HttpGet("PendingRecord")]
      
        public IQueryable<ValuationDto> GetValuation()
        {
            try
            {
                var transaction = from t in _context.TestValuation.Where(b => b.TransactionStatus == "N" || b.TransactionStatus == "M" )
                                  select new ValuationDto()
                                  {
                                      ValuationId = t.ValuationId,
                                      TransactionId = t.TransactionId,
                                      Workflow = t.Workflow,
                                      TransactionType = t.TransactionType,
                                      LondonAMRateUSD = t.LondonAMRateUSD,
                                      FixingChargesUSD = t.FixingChargesUSD,
                                      PremiumUSD = t.PremiumUSD,
                                      MetalRateUSD = t.MetalRateUSD,
                                      ConversionFactor = t.ConversionFactor,
                                      RBIReferenceRateINR = t.RBIReferenceRateINR,
                                      MetalRatePerkgINR = t.MetalRatePerkgINR,
                                      CustomsDutyKg = t.CustomsDutyKg,
                                      StampDutyINR = t.StampDutyINR,
                                      FinalPriceUSD = t.FinalPriceUSD,
                                      TransactionStatus = t.TransactionStatus
                                  };

                return transaction;

            }
            catch
            {
                throw;
            }


        }

        // GET: api/Valuation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValuationModel>> GetValuationModel(string id)
        {
            var valuationModel = await _context.TestValuation.FindAsync(id);

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
        public async Task<IActionResult> PutValuationModel(ValuationModel valuationModel, string Task)
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
                                         where c.TransactionId == valuationModel.TransactionId
                                         select new
                                         {
                                             SchemeName = c.SchemeName,
                                             TransactionType = c.TransactionType,
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
                                        where t.TransactionId == valuationModel.TransactionId
                                        select new
                                        {
                                            Name = c.CounterpartyName,
                                            Address = c.Address1,
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
                                         where t.TransactionId == valuationModel.TransactionId && t.TransactionType == "S"
                                         select new
                                         {
                                             BranchName = c.BankBranch,
                                             IFSCCode = c.IFSC,
                                             BeneficiaryAccount = c.AccountNo,
                                             BeneficiaryAccountName = c.NameBeneficiary,

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
                                        where c.SecurityLocation == t.SecurityLocation
                                        select new
                                        {
                                            Commodity = c.CommodityPurity,
                                            Commodity1 = c.CommodityDenomination,
                                            CounterpartyShipper = c.CounterpartyShipper,

                                        }).ToList();

                        foreach (var c1 in GoldData)
                        {
                            DealConfirmationModel1.Commodity = c1.Commodity + " " + c1.Commodity1;
                            DealConfirmationModel1.CounterpartyShipper = c1.CounterpartyShipper;


                            break;
                        }

                        var tax = (from c in _context.TaxMaster
                                   where c.TaxId == "TAX0000001"
                                   select new
                                   {
                                       TaxId = c.TaxId,
                                       State = c.State,
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
                            DealConfirmationModel1.GST = c1.GST * DealConfirmationModel1.TotalPrice;
                            DealConfirmationModel1.TotalGST = DealConfirmationModel1.SGST + DealConfirmationModel1.CGST + DealConfirmationModel1.GST;


                            break;
                        }

                        var data = new DealConfirmationDto()
                        {
                            DealConfirmId = DealConfirmationModel1.DealConfirmId = SBIMFDbContext.fn_DealConfirmID(),
                            TransactionId = DealConfirmationModel1.TransactionId = valuationModel.TransactionId,
                            DealRefNo = DealConfirmationModel1.DealRefNo = "",
                            SchemeName = DealConfirmationModel1.SchemeName,
                            TransactionType = DealConfirmationModel1.TransactionType,
                            DealDate = DealConfirmationModel1.DealDate,
                            ValueDate = DealConfirmationModel1.ValueDate,
                            QuantityInKilogram = DealConfirmationModel1.QuantityInKilogram,
                            Name = DealConfirmationModel1.Name,
                            Address = DealConfirmationModel1.Address,
                            ContactNo = DealConfirmationModel1.ContactNo,
                            ContactPersonName = DealConfirmationModel1.ContactPersonName,
                            GSTNo = DealConfirmationModel1.GSTNo,
                            BranchName = DealConfirmationModel1.BranchName,
                            IFSCCode = DealConfirmationModel1.IFSCCode,
                            BeneficiaryAccount = DealConfirmationModel1.BeneficiaryAccount,
                            BeneficiaryAccountName = DealConfirmationModel1.BeneficiaryAccountName,
                            Commodity = DealConfirmationModel1.Commodity,
                            CounterpartyShipper = DealConfirmationModel1.CounterpartyShipper,
                            ClientName = DealConfirmationModel1.ClientName = "SBI-MUTUAL-FUND",
                            Rate = DealConfirmationModel1.Rate,
                            Remarks = DealConfirmationModel1.Remarks = "",
                            DealStatus = DealConfirmationModel1.DealStatus = "Incomplete",
                            TotalPrice = DealConfirmationModel1.TotalPrice,
                            SGST = DealConfirmationModel1.SGST,
                            CGST = DealConfirmationModel1.CGST,
                            GST = DealConfirmationModel1.GST,
                            TotalGST = DealConfirmationModel1.TotalGST,
                            TotalConsideration = DealConfirmationModel1.TotalConsideration = (DealConfirmationModel1.TotalPrice + DealConfirmationModel1.TotalGST),
                            OtherApplicableTaxes = DealConfirmationModel1.OtherApplicableTaxes = "",
                            TaxCollectedAtSource = DealConfirmationModel1.TaxCollectedAtSource = DealConfirmationModel1.TotalConsideration,
                            NetConsideration = DealConfirmationModel1.NetConsideration = (DealConfirmationModel1.TotalConsideration + DealConfirmationModel1.TaxCollectedAtSource),
                        };

                        _context.DealConfirmation.Add(DealConfirmationModel1);

                        await _context.SaveChangesAsync();


                    }


                }

                else if (Task == "Reject")

                {
                    LogModel LogModel1 = new LogModel();

                    if (valuationModel.TransactionStatus == "N")
                    {
                        LogModel1.ValuationId = valuationModel.ValuationId;
                        LogModel1.TransactionId = valuationModel.TransactionId;
                        LogModel1.Workflow = valuationModel.Workflow;
                        LogModel1.TransactionType = valuationModel.TransactionType;
                        LogModel1.LondonAMRateUSD = valuationModel.LondonAMRateUSD;
                        LogModel1.FixingChargesUSD = valuationModel.FixingChargesUSD;
                        LogModel1.PremiumUSD = valuationModel.PremiumUSD;
                        LogModel1.MetalRateUSD = valuationModel.MetalRateUSD;
                        LogModel1.ConversionFactor = valuationModel.ConversionFactor;
                        LogModel1.RBIReferenceRateINR = valuationModel.RBIReferenceRateINR;
                        LogModel1.MetalRatePerkgINR = valuationModel.MetalRatePerkgINR;
                        LogModel1.CustomsDutyKg = valuationModel.CustomsDutyKg;
                        LogModel1.StampDutyINR = valuationModel.StampDutyINR;
                        LogModel1.FinalPriceUSD = valuationModel.FinalPriceUSD;
                        LogModel1.TransactionStatus = "R";
                                                

                        _context.TestValuation.Remove(valuationModel);                
                        _context.Log.Add(LogModel1);

                       await _context.SaveChangesAsync();

                    }


                }


            }
            catch (Exception)
            {

                throw;

            }

            return NoContent();
        }
        
        
        
         [HttpPut("AuthMultiple")]
        public async Task<IActionResult> PutValuationModel1(List<ValuationModel> valuationModel, string Task)
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
                    foreach(var v in valuationModel)
                    {
                    if (v.TransactionStatus == "N" || v.TransactionStatus == "M")
                    {
                        var dto = new ValuationDto()
                        {
                            TransactionStatus = v.TransactionStatus = "A"
                        };

                         _context.Entry(v).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        DealConfirmationModel DealConfirmationModel1 = new DealConfirmationModel();
                        TransactionCaptureModel TransactionCaptureModel1 = new TransactionCaptureModel();
                        CounterPartyModel counterPartyModel1 = new CounterPartyModel();
                        CustodianInstructionModel custodianInstructionModel1 = new CustodianInstructionModel();
                        GoldModel goldModel1 = new GoldModel();
                        TaxesModel taxesModel1 = new TaxesModel();



                        var Transdata = (from c in _context.TransactionCapture
                                         where c.TransactionId == v.TransactionId
                                         select new
                                         {
                                             SchemeName = c.SchemeName,
                                             TransactionType = c.TransactionType,
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
                                        where t.TransactionId == v.TransactionId
                                        select new
                                        {
                                            Name = c.CounterpartyName,
                                            Address = c.Address1,
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
                                         where t.TransactionId == v.TransactionId && t.TransactionType == "S"
                                         select new
                                         {
                                             BranchName = c.BankBranch,
                                             IFSCCode = c.IFSC,
                                             BeneficiaryAccount = c.AccountNo,
                                             BeneficiaryAccountName = c.NameBeneficiary,

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
                                        where c.SecurityLocation == t.SecurityLocation
                                        select new
                                        {
                                            Commodity = c.CommodityPurity,
                                            Commodity1 = c.CommodityDenomination,
                                            CounterpartyShipper = c.CounterpartyShipper,

                                        }).ToList();

                        foreach (var c1 in GoldData)
                        {
                            DealConfirmationModel1.Commodity = c1.Commodity + " " + c1.Commodity1;
                            DealConfirmationModel1.CounterpartyShipper = c1.CounterpartyShipper;


                            break;
                        }

                        var tax = (from c in _context.TaxMaster
                                   where c.TaxId == "TAX0000001"
                                   select new
                                   {
                                       TaxId = c.TaxId,
                                       State = c.State,
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
                            DealConfirmationModel1.GST = c1.GST * DealConfirmationModel1.TotalPrice;
                            DealConfirmationModel1.TotalGST = DealConfirmationModel1.SGST + DealConfirmationModel1.CGST + DealConfirmationModel1.GST;


                            break;
                        }

                        var data = new DealConfirmationDto()
                        {
                            DealConfirmId = DealConfirmationModel1.DealConfirmId = SBIMFDbContext.fn_DealConfirmID(),
                            TransactionId = DealConfirmationModel1.TransactionId = v.TransactionId,
                            DealRefNo = DealConfirmationModel1.DealRefNo = "",
                            SchemeName = DealConfirmationModel1.SchemeName,
                            TransactionType = DealConfirmationModel1.TransactionType,
                            DealDate = DealConfirmationModel1.DealDate,
                            ValueDate = DealConfirmationModel1.ValueDate,
                            QuantityInKilogram = DealConfirmationModel1.QuantityInKilogram,
                            Name = DealConfirmationModel1.Name,
                            Address = DealConfirmationModel1.Address,
                            ContactNo = DealConfirmationModel1.ContactNo,
                            ContactPersonName = DealConfirmationModel1.ContactPersonName,
                            GSTNo = DealConfirmationModel1.GSTNo,
                            BranchName = DealConfirmationModel1.BranchName,
                            IFSCCode = DealConfirmationModel1.IFSCCode,
                            BeneficiaryAccount = DealConfirmationModel1.BeneficiaryAccount,
                            BeneficiaryAccountName = DealConfirmationModel1.BeneficiaryAccountName,
                            Commodity = DealConfirmationModel1.Commodity,
                            CounterpartyShipper = DealConfirmationModel1.CounterpartyShipper,
                            ClientName = DealConfirmationModel1.ClientName = "SBI-MUTUAL-FUND",
                            Rate = DealConfirmationModel1.Rate,
                            Remarks = DealConfirmationModel1.Remarks = "",
                            DealStatus = DealConfirmationModel1.DealStatus = "Incomplete",
                            TotalPrice = DealConfirmationModel1.TotalPrice,
                            SGST = DealConfirmationModel1.SGST,
                            CGST = DealConfirmationModel1.CGST,
                            GST = DealConfirmationModel1.GST,
                            TotalGST = DealConfirmationModel1.TotalGST,
                            TotalConsideration = DealConfirmationModel1.TotalConsideration = (DealConfirmationModel1.TotalPrice + DealConfirmationModel1.TotalGST),
                            OtherApplicableTaxes = DealConfirmationModel1.OtherApplicableTaxes = "",
                            TaxCollectedAtSource = DealConfirmationModel1.TaxCollectedAtSource = DealConfirmationModel1.TotalConsideration,
                            NetConsideration = DealConfirmationModel1.NetConsideration = (DealConfirmationModel1.TotalConsideration + DealConfirmationModel1.TaxCollectedAtSource),
                        };

                        _context.DealConfirmation.Add(DealConfirmationModel1);

                        await _context.SaveChangesAsync();


                    }
                    }

                }

                else if (Task == "Reject")
                {
                    LogModel LogModel1 = new LogModel();

                    foreach(var v1 in valuationModel)
                    {
                    if (v1.TransactionStatus == "N")
                    {
                        LogModel1.ValuationId = v1.ValuationId;
                        LogModel1.TransactionId = v1.TransactionId;
                        LogModel1.Workflow = v1.Workflow;
                        LogModel1.TransactionType = v1.TransactionType;
                        LogModel1.LondonAMRateUSD = v1.LondonAMRateUSD;
                        LogModel1.FixingChargesUSD = v1.FixingChargesUSD;
                        LogModel1.PremiumUSD = v1.PremiumUSD;
                        LogModel1.MetalRateUSD = v1.MetalRateUSD;
                        LogModel1.ConversionFactor = v1.ConversionFactor;
                        LogModel1.RBIReferenceRateINR = v1.RBIReferenceRateINR;
                        LogModel1.MetalRatePerkgINR = v1.MetalRatePerkgINR;
                        LogModel1.CustomsDutyKg = v1.CustomsDutyKg;
                        LogModel1.StampDutyINR = v1.StampDutyINR;
                        LogModel1.FinalPriceUSD = v1.FinalPriceUSD;
                        LogModel1.TransactionStatus = "R";
                                                

                        _context.TestValuation.Remove(v1);                
                        _context.Log.Add(LogModel1);

                       await _context.SaveChangesAsync();

                    }
                    }

                }


            }
            catch (Exception)
            {

                throw;

            }

            return NoContent();
        }


        // POST: api/Valuation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost]
        public async Task<ActionResult<ValuationModel>> PostValuationModel(IFormFile file)
        {
            ValuationModel valuationModel = new ValuationModel();
            CustodianInstructionModel custodianInstructionModel1 = new CustodianInstructionModel();

            try
            {
                IExcelDataReader reader = null;
                var fileList = HttpContext.Request.Form.Files;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                // Stream FileStreams = null; 
                string fileExt = System.IO.Path.GetExtension(file.FileName).ToLower();
                DataSet dsExcelData = new DataSet();


                if (file != null)
                {
                   
                    using (var fs = new MemoryStream())
                    {

                        foreach (var files in fileList)
                        {
                            await files.CopyToAsync(fs);
                        }


                        string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                         string dt = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss") + "_";


                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                       string fileName = Path.GetFileName(file.FileName);
                       string f1 = fileName+dt+fileExt;
 
                        string filePath = Path.Combine(path, f1);


                        using (FileStream stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        // var estEncoding = Encoding.GetEncoding(1252);
                        //     var est= File.ReadAllText(filePath, estEncoding);       
                        //     var utf = Encoding.UTF8;
                        //     est = utf.GetString(Encoding.Convert(estEncoding, utf, estEncoding.GetBytes(est)));


                        if (fileExt == ".xls")
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(fs);
                        }
                        else if (fileExt == ".xlsx")
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                        }
                        else
                        {
                          return NotFound("The file format is not supported.");
                        }

                        dsExcelData = reader.AsDataSet();
                        reader.Close();

                        if (dsExcelData != null && dsExcelData.Tables.Count > 0)
                        {
                            DataTable dtEmp = new DataTable();
                            // dtEmp=dsExcelData.Tables[0].Clone();
                            dtEmp = dsExcelData.Tables[0];

                            if (dtEmp != null)
                            {
                                ValuationModel objEmp = new ValuationModel();
                                for (int i = 1; i < dtEmp.Rows.Count; i++)
                                {

                                    objEmp.ValuationId = SBIMFDbContext.fn_getValuationIDs();
                                    objEmp.TransactionId = (dtEmp.Rows[i][1].ToString().Trim());
                                    objEmp.Workflow = (dtEmp.Rows[i][2].ToString().Trim());
                                    objEmp.TransactionType = (dtEmp.Rows[i][3].ToString().Trim());
                                    objEmp.LondonAMRateUSD = (dtEmp.Rows[i][4].ToString().Trim());
                                    objEmp.FixingChargesUSD = (dtEmp.Rows[i][5].ToString().Trim());
                                    objEmp.PremiumUSD = (dtEmp.Rows[i][6].ToString().Trim());
                                    objEmp.MetalRateUSD = (dtEmp.Rows[i][7].ToString().Trim());
                                    objEmp.ConversionFactor = (dtEmp.Rows[i][8].ToString().Trim());
                                    objEmp.RBIReferenceRateINR = (dtEmp.Rows[i][9].ToString().Trim());
                                    objEmp.MetalRatePerkgINR = (dtEmp.Rows[i][10].ToString().Trim());
                                    objEmp.CustomsDutyKg = (dtEmp.Rows[i][11].ToString().Trim());
                                    objEmp.StampDutyINR = (dtEmp.Rows[i][12].ToString().Trim());
                                    objEmp.FinalPriceUSD = (dtEmp.Rows[i][13].ToString().Trim());
                                    objEmp.TransactionStatus = "N";

                                   var path1 = (from t in _context.CustodianInstruction where t.TransactionId == objEmp.TransactionId
                                              select new CustodianInstructionDto()
                                                {
                                                    TransactionId = t.TransactionId,
                                                }).ToList();

                                    foreach(var p in path1)
                                    {
                                        valuationModel.TransactionId=p.TransactionId;

                                      break;
                                    }

                                    if( objEmp.TransactionId==valuationModel.TransactionId)
                                    {
                                         _context.TestValuation.Add(objEmp);
                                          await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                      return NotFound("Please enter Valid TransactionId mapping.");
                                    }
                                 
                                }



                            }

                        }
                    }

                }


                return Ok();
            }
            catch (Exception)
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

        }


        // DELETE: api/Valuation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ValuationModel>> DeleteValuationModel(string id)
        {
            var valuationModel = await _context.TestValuation.FindAsync(id);
            if (valuationModel == null)
            {
                return NotFound();
            }

            _context.TestValuation.Remove(valuationModel);
            await _context.SaveChangesAsync();

            return valuationModel;
        }

        private bool ValuationModelExists(string id)
        {
            return _context.TestValuation.Any(e => e.ValuationId == id);
        }
    }
}
