using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Data;
using SBI_MF.Models;
using ExcelDataReader;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;


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
        [HttpPost]
        public async Task<ActionResult<ValuationModel>> PostValuationModel(IFormFile file)
        {
            ValuationModel valuationModel=new ValuationModel();
            try
            {
               
                string message="";
                IExcelDataReader reader = null;  
                var valuationData=new List<ValuationModel>();
                var fileList=HttpContext.Request.Form.Files;
                // Stream FileStreams = null; 
                string fileExt = System.IO.Path.GetExtension(file.FileName).ToLower(); 
                DataSet dsExcelData = new DataSet();
        
             
                if(file != null)
                {
                    //FileStream.Position=1;
                    //FileStreams=file.OpenReadStream();
                    using(var fs=new MemoryStream())
                    {
               
                        foreach(var files in fileList)
                        {
                            await files.CopyToAsync(fs);
                        }
            
                    
                    string path=Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
                    
                    
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.GetFileName(file.FileName);
                    
                    string filePath = Path.Combine(path, fileName);
                        
                    
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    // var estEncoding = Encoding.GetEncoding(1252);
                    //     var est= File.ReadAllText(filePath, estEncoding);       
                    //     var utf = Encoding.UTF8;
                    //     est = utf.GetString(Encoding.Convert(estEncoding, utf, estEncoding.GetBytes(est)));

                       
                    if(fileExt == ".xls")
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    }
                    else if(fileExt == ".xlsx")
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(fs);  
                    }
                    else  
                    {
                        message = "The file format is not supported.";  
                    }

                    dsExcelData = reader.AsDataSet();  
                    reader.Close(); 

                    if(dsExcelData != null && dsExcelData.Tables.Count > 0)
                    {
                        DataTable dtEmp = new DataTable();
                        dtEmp=dsExcelData.Tables[0];
                        if(dtEmp!=null)
                        {
                        for(int i = 1; i < dtEmp.Rows.Count; i++)
                        {
                           
                            ValuationModel objEmp = new ValuationModel(); 
                            objEmp.ValuationId = Convert.ToString(dtEmp.Rows[i][0]);
                            objEmp.TransactionId = Convert.ToString(dtEmp.Rows[i][1]);
                            objEmp.Workflow = Convert.ToString(dtEmp.Rows[i][2]);
                            objEmp.TransactionType = Convert.ToString(dtEmp.Rows[i][3]);
                            objEmp.LondonAMRateUSD = float.Parse(dtEmp.Rows[i][4].ToString());
                            Console.WriteLine(float.Parse(dtEmp.Rows[i][4].ToString().Trim()));
                            objEmp.FixingChargesUSD = (float)Convert.ToDecimal(dtEmp.Rows[i][5]);
                            objEmp.PremiumUSD = Convert.ToInt16(dtEmp.Rows[i][6].ToString());
                            objEmp.MetalRateUSD =Convert.ToInt16(dtEmp.Rows[i][7].ToString());
                            objEmp.ConversionFactor = (float)Convert.ToDecimal(dtEmp.Rows[i][8]);
                            objEmp.RBIReferenceRateINR = (float)Convert.ToDecimal(dtEmp.Rows[i][9]);
                            objEmp.MetalRatePerkgINR = Convert.ToInt16(dtEmp.Rows[i][10].ToString());
                            objEmp.CustomsDutyKg = (float)Convert.ToDecimal(dtEmp.Rows[i][11]);
                            objEmp.StampDutyINR = (float)Convert.ToDecimal(dtEmp.Rows[i][12]);
                            objEmp.FinalPriceUSD = (float)Convert.ToDecimal(dtEmp.Rows[i][13]);
                            objEmp.TransactionStatus = valuationModel.TransactionStatus = "N";


                            //string conString = this.Configurations.GetConnectionString("DevConnection");
                            using (SqlConnection con = new SqlConnection("Data Source=NUCDBSRV;Initial Catalog=SBI_MF;User ID=sa;Password=nuc1234$"))
                            {
                                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                                {
                                    sqlBulkCopy.DestinationTableName = "dbo.Valuation";
 
                                    //[OPTIONAL]: Map the Excel columns with that of the database table.
                                    //sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                                    //sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                                    //sqlBulkCopy.ColumnMappings.Add("Country", "Country");
 
                                    con.Open();
                                    sqlBulkCopy.WriteToServer(dtEmp);
                                    if(dtEmp.Rows.Count > 0)
                                    {
                                        message = "File uploaded successfully";
                                    }
                                    con.Close();
                                }
                            }
                        }
                        }
               
                    }
                    }
            }
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
              await _context.SaveChangesAsync();
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
