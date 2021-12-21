using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Models;

namespace SBI_MF.Data
{
    public class SBIMFDbContext : DbContext
    {
        public DbSet<UserModel> UserMaster { get; set; }
        public DbSet<GoldLocModel> GoldLocationMaster { get; set; }
        public DbSet<GoldModel> GoldMaster { get; set; }
        public DbSet<CustodianModel> CustodianMaster { get; set; }
        public DbSet<CounterPartyModel> CounterPartyMaster { get; set; }
        public DbSet<ChargeModel> ChargeMaster { get; set; }
        public DbSet<TaxesModel> TaxMaster { get; set; }
        public DbSet<TransactionCaptureModel> TransactionCapture { get; set; }
        public DbSet<CustodianInstructionModel> CustodianInstruction { get; set; }
        public DbSet<ValuationModel> Valuation { get; set; }
        public DbSet<DealConfirmationModel> DealConfirmation { get; set; }

        public SBIMFDbContext(DbContextOptions options) : base (options){
            
        }

        public SBIMFDbContext()
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=nucdbsrv; database=SBI_MF; user id=sa; password=nuc1234$");
        }


        [DbFunction("fn_TransactionID", "dbo")]
        public static string fn_getTransactionID()
        {
            string autoVal;
            SBIMFDbContext dataContext = new SBIMFDbContext();
            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.VarChar, 50)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            dataContext.Database.ExecuteSqlRaw("SELECT @result = (select dbo.fn_TransactionID())",result);
            autoVal = result.Value.ToString();

            return autoVal;
            //throw new NotImplementedException();
            //throw new NotSupportedException("Direct calls are not supported.");
        }
    
    }
}
