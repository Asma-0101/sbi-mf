// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBI_MF.Data;

namespace SBI_MF.Migrations
{
    [DbContext(typeof(SBIMFDbContext))]
    [Migration("20211220114423_workflowTableCreation")]
    partial class workflowTableCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SBI_MF.Models.ChargeModel", b =>
                {
                    b.Property<string>("ChargeId")
                        .HasColumnType("Varchar(10)");

                    b.Property<string>("ChargeName")
                        .HasColumnType("Varchar(50)");

                    b.Property<decimal>("ChargeValue")
                        .HasColumnType("numeric(3,2)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("date");

                    b.Property<string>("Remarks")
                        .HasColumnType("Varchar(250)");

                    b.Property<string>("SchemeType")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("TransactionType")
                        .HasColumnType("Varchar(50)");

                    b.HasKey("ChargeId");

                    b.ToTable("ChargeMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.CounterPartyModel", b =>
                {
                    b.Property<string>("CounterPartyID")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("AccountNo")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Address2")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Address3")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("BankBranch")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BankName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CounterpartyName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailId1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailId2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FaxNo1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FaxNo2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GSTNo")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("IFSC")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MobNo1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MobNo2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NameBeneficiary")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PAN")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TelNo1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TelNo2")
                        .HasColumnType("varchar(50)");

                    b.HasKey("CounterPartyID");

                    b.ToTable("CounterPartyMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.CustodianInstructionModel", b =>
                {
                    b.Property<string>("CustodianInstructionId")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CounterParty")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CustodianName")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DelRefNo")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PurityOfGold")
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("QtyOfGoldBar")
                        .HasColumnType("numeric(20,2)");

                    b.Property<string>("SecurityName")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("SettlementDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(20,2)");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("date");

                    b.Property<string>("TransactionId")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("VaultLocation")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WeightOfGoldBar")
                        .HasColumnType("varchar(50)");

                    b.HasKey("CustodianInstructionId");

                    b.ToTable("CustodianInstruction");
                });

            modelBuilder.Entity("SBI_MF.Models.CustodianModel", b =>
                {
                    b.Property<string>("CustodianId")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Address1")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Address2")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Address3")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustodianName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailId1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailId2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FaxNumber1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FaxNumber2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MobileNumber1")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("MobileNumber2")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("TelephoneNumber1")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("TelephoneNumber2")
                        .HasColumnType("varchar(15)");

                    b.HasKey("CustodianId");

                    b.ToTable("CustodianMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.DealConfirmationModel", b =>
                {
                    b.Property<string>("DealConfirmId")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("BeneficiaryAccount")
                        .HasColumnType("numeric(18,0)");

                    b.Property<string>("BeneficiaryAccountName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BranchName")
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("CGST")
                        .HasColumnType("numeric(10,2)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Commodity")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CounterpartyShipper")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("DealDate")
                        .HasColumnType("date");

                    b.Property<string>("DealRefNo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DealStatus")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("GST")
                        .HasColumnType("numeric(10,2)");

                    b.Property<string>("GSTNo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IFSCCode")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NetConsideration")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("OtherApplicableTaxes")
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("QuantityInKilogram")
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric(10,2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("SGST")
                        .HasColumnType("numeric(10,2)");

                    b.Property<string>("SchemeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("TaxCollectedAtSource")
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("TotalConsideration")
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("TotalGST")
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric(10,2)");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("ValueDate")
                        .HasColumnType("date");

                    b.HasKey("DealConfirmId");

                    b.ToTable("DealConfirmation");
                });

            modelBuilder.Entity("SBI_MF.Models.GoldLocModel", b =>
                {
                    b.Property<string>("Lid")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("GoldLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Lid");

                    b.ToTable("GoldLocationMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.GoldModel", b =>
                {
                    b.Property<string>("GoldId")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Active")
                        .HasColumnType("char(1)");

                    b.Property<float>("BarWeightInGrams")
                        .HasColumnType("real");

                    b.Property<float>("BarWeightInKg")
                        .HasColumnType("real");

                    b.Property<decimal>("CGST")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("CommodityDenomination")
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("CommodityPurity")
                        .HasColumnType("numeric(20,4)");

                    b.Property<decimal>("Conversionfactor")
                        .HasColumnType("numeric(20,4)");

                    b.Property<string>("CounterpartyShipper")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Currency")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("CustomDuty")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("Facevalue")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("FixingCharge")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("GST")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("Issuer")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("NAVlot")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("Octroi")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("Premium")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("SGST")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("SecurityLocation")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SecurityName")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Stampduty")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("StockExchange")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ValuationRateType")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("VaultingAgent")
                        .HasColumnType("varchar(50)");

                    b.HasKey("GoldId");

                    b.ToTable("GoldMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.TaxesModel", b =>
                {
                    b.Property<string>("TaxId")
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("CGST")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("GST")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("SGST")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaxId");

                    b.ToTable("TaxMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.TransactionCaptureModel", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Counterparty")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("DealValue")
                        .HasColumnType("numeric(20,2)");

                    b.Property<decimal>("NoOfUnitsPerKg")
                        .HasColumnType("numeric(20,2)");

                    b.Property<decimal>("QuantityInKg")
                        .HasColumnType("numeric(20,2)");

                    b.Property<string>("SchemeName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Security")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SecurityLocation")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SettlementTenor")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("TotalUnits")
                        .HasColumnType("numeric(20,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<string>("TransactionStatus")
                        .HasColumnType("char(1)");

                    b.Property<string>("TransactionType")
                        .HasColumnType("char(1)");

                    b.Property<DateTime>("ValueDate")
                        .HasColumnType("date");

                    b.HasKey("TransactionId");

                    b.ToTable("TransactionCapture");
                });

            modelBuilder.Entity("SBI_MF.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModuleRights")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Roles")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserGroup")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("UserMaster");
                });

            modelBuilder.Entity("SBI_MF.Models.ValuationModel", b =>
                {
                    b.Property<int>("ValuationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ConversionFactor")
                        .HasColumnType("numeric(5,2)");

                    b.Property<decimal>("CustomsDutyKg")
                        .HasColumnType("numeric(5,2)");

                    b.Property<decimal>("FinalPriceUSD")
                        .HasColumnType("numeric(5,2)");

                    b.Property<decimal>("FixingChargesUSD")
                        .HasColumnType("numeric(5,2)");

                    b.Property<decimal>("LondonAMRateUSD")
                        .HasColumnType("numeric(5,2)");

                    b.Property<decimal>("MetalRatePerkgINR")
                        .HasColumnType("numeric(5,2)");

                    b.Property<float>("MetalRateUSD")
                        .HasColumnType("real");

                    b.Property<float>("PremiumUSD")
                        .HasColumnType("real");

                    b.Property<decimal>("RBIReferenceRateINR")
                        .HasColumnType("numeric(5,2)");

                    b.Property<decimal>("StampDutyINR")
                        .HasColumnType("numeric(5,2)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionStatus")
                        .HasColumnType("char(1)");

                    b.Property<string>("TransactionType")
                        .HasColumnType("char(1)");

                    b.Property<string>("Workflow")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ValuationId");

                    b.ToTable("Valuation");
                });
#pragma warning restore 612, 618
        }
    }
}
