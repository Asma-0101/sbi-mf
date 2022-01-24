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
          [HttpPost("test")]
        public async Task<List<ValuationModel>> uploadExcel(IFormFile file1)
        {
            try
            { 
            var chargeData=new List<ValuationModel>();
            var fileList=HttpContext.Request.Form.Files;
            DataSet dsexcelRecords = new DataSet();
            IExcelDataReader reader = null;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if(fileList!=null)
            {
            using(var fs=new MemoryStream())
            {
               foreach(var file in fileList)
            {
                await file.CopyToAsync(fs);
            }
                
                using (reader = ExcelReaderFactory.CreateReader(fs))
                {
                    dsexcelRecords = reader.AsDataSet();
                    //if(reader.RowCount>1)
                     if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                    {            
                        DataTable dtStudentRecords = dsexcelRecords.Tables[0];
                                //while (reader.Read()) 
                                using (SqlConnection con = new SqlConnection("server=NUCDBSRV;database=SBI_MF;user id=sa;password=nuc1234$;"))

                                {
                                    for (int i = 1; i < dtStudentRecords.Rows.Count; i++)

                                    {
                                        SqlCommand cmd = new SqlCommand("ValuationInsert", con);
                                        cmd.CommandType = CommandType.StoredProcedure;                                
                                        cmd.Parameters.AddWithValue("@ValuationId",dtStudentRecords.Rows[i][0]);
                                        cmd.Parameters.AddWithValue("@TransactionId",dtStudentRecords.Rows[i][1]);
                                        cmd.Parameters.AddWithValue("@Workflow",dtStudentRecords.Rows[i][2]);
                                        cmd.Parameters.AddWithValue("@TransactionType",reader.GetValue(3).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@LondonAMRateUSD",reader.GetValue(4).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@FixingChargesUSD",reader.GetValue(5).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@PremiumUSD",reader.GetValue(6).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@MetalRateUSD",reader.GetValue(7).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@ConversionFactor",reader.GetValue(8).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@RBIReferenceRateINR",reader.GetValue(9).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@MetalRatePerkgINR",reader.GetValue(10).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@CustomsDutyKg",reader.GetValue(11).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@StampDutyINR",reader.GetValue(12).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@FinalPriceUSD",reader.GetValue(13).ToString().Trim());
                                        cmd.Parameters.AddWithValue("@TransactionStatus","N");
                                        
                                        con.Open();                                
                                        cmd.ExecuteNonQuery(); 
                                        con.Close();
                                    } 
                                        
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty File!");
                    }
                }
                // using(var xl=new ExcelPackage(fs))
                // //using(var xl=new ExcelDataReader())
                // {
                //     ExcelWorksheet sheet= xl.Workbook.Worksheets[0];
                //     var rows=sheet.Dimension.Rows;
                //     for (int r = 2; r < rows; r++)
                //     {
                //         chargeData.Add(new ChargeMaster
                //         { 
                //             SchemeType=sheet.Cells[r,1].Value.ToString().Trim(),
                //             TransactionType=sheet.Cells[r,1].Value.ToString().Trim(),
                //             ChargeName=sheet.Cells[r,1].Value.ToString().Trim(),
                //             ChargeValue=sheet.Cells[r,1].Value.ToString().Trim(),
                //             EffectiveDate=sheet.Cells[r,1].Value.ToString().Trim(),
                //             Remarks=sheet.Cells[r,1].Value.ToString().Trim()
                //         });
                //     }
                // }
            } 
            }           
            return chargeData;
            }
            catch(Exception)
            {
                throw;
            }          
            
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
