using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBI_MF.Migrations
{
    public partial class workflowTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustodianInstruction",
                columns: table => new
                {
                    CustodianInstructionId = table.Column<string>(type: "varchar(15)", nullable: false),
                    TransactionId = table.Column<string>(type: "varchar(10)", nullable: true),
                    CustodianName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(15)", nullable: true),
                    ContactPerson = table.Column<string>(type: "varchar(50)", nullable: true),
                    SecurityName = table.Column<string>(type: "varchar(50)", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "date", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "date", nullable: false),
                    WeightOfGoldBar = table.Column<string>(type: "varchar(50)", nullable: true),
                    PurityOfGold = table.Column<string>(type: "varchar(20)", nullable: true),
                    Location = table.Column<string>(type: "varchar(50)", nullable: true),
                    VaultLocation = table.Column<string>(type: "varchar(50)", nullable: true),
                    CounterParty = table.Column<string>(type: "varchar(20)", nullable: true),
                    DelRefNo = table.Column<string>(type: "varchar(20)", nullable: true),
                    QtyOfGoldBar = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(20,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustodianInstruction", x => x.CustodianInstructionId);
                });

            migrationBuilder.CreateTable(
                name: "DealConfirmation",
                columns: table => new
                {
                    DealConfirmId = table.Column<string>(type: "varchar(15)", nullable: false),
                    TransactionId = table.Column<string>(type: "varchar(15)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(250)", nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(25)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "varchar(50)", nullable: false),
                    DealRefNo = table.Column<string>(type: "varchar(20)", nullable: false),
                    ClientName = table.Column<string>(type: "varchar(50)", nullable: false),
                    SchemeName = table.Column<string>(type: "varchar(50)", nullable: false),
                    TransactionType = table.Column<string>(type: "varchar(50)", nullable: false),
                    GSTNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    DealDate = table.Column<DateTime>(type: "date", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "date", nullable: false),
                    Commodity = table.Column<string>(type: "varchar(150)", nullable: false),
                    CounterpartyShipper = table.Column<string>(type: "varchar(150)", nullable: false),
                    QuantityInKilogram = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    SGST = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    CGST = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    GST = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalGST = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalConsideration = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    OtherApplicableTaxes = table.Column<string>(type: "varchar(150)", nullable: true),
                    TaxCollectedAtSource = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    NetConsideration = table.Column<string>(type: "varchar(250)", nullable: false),
                    Remarks = table.Column<string>(type: "varchar(250)", nullable: true),
                    BranchName = table.Column<string>(type: "varchar(250)", nullable: true),
                    IFSCCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    BeneficiaryAccount = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    BeneficiaryAccountName = table.Column<string>(type: "varchar(50)", nullable: true),
                    DealStatus = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealConfirmation", x => x.DealConfirmId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCapture",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "varchar(15)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    SettlementTenor = table.Column<string>(type: "varchar(10)", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "date", nullable: false),
                    Counterparty = table.Column<string>(type: "varchar(50)", nullable: false),
                    SchemeName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Security = table.Column<string>(type: "varchar(50)", nullable: false),
                    SecurityLocation = table.Column<string>(type: "varchar(50)", nullable: false),
                    DealValue = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    QuantityInKg = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    NoOfUnitsPerKg = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    TotalUnits = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "char(1)", nullable: true),
                    TransactionType = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCapture", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Valuation",
                columns: table => new
                {
                    ValuationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(nullable: false),
                    Workflow = table.Column<string>(type: "varchar(50)", nullable: true),
                    TransactionType = table.Column<string>(type: "char(1)", nullable: true),
                    LondonAMRateUSD = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    FixingChargesUSD = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    PremiumUSD = table.Column<float>(type: "real", nullable: false),
                    MetalRateUSD = table.Column<float>(type: "real", nullable: false),
                    ConversionFactor = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    RBIReferenceRateINR = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MetalRatePerkgINR = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    CustomsDutyKg = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    StampDutyINR = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    FinalPriceUSD = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuation", x => x.ValuationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustodianInstruction");

            migrationBuilder.DropTable(
                name: "DealConfirmation");

            migrationBuilder.DropTable(
                name: "TransactionCapture");

            migrationBuilder.DropTable(
                name: "Valuation");
        }
    }
}
