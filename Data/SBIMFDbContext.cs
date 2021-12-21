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

        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
           
        //     optionsBuilder.UseSqlServer("server=nucdbsrv;database=SBI_MF;user id=sa;password=nuc1234$");
        // }
    
    }
}