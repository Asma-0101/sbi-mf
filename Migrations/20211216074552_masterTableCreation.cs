using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBI_MF.Migrations
{
    public partial class masterTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargeMaster",
                columns: table => new
                {
                    ChargeId = table.Column<string>(type: "Varchar(10)", nullable: false),
                    SchemeType = table.Column<string>(type: "Varchar(50)", nullable: true),
                    TransactionType = table.Column<string>(type: "Varchar(50)", nullable: true),
                    ChargeName = table.Column<string>(type: "Varchar(50)", nullable: true),
                    ChargeValue = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    Remarks = table.Column<string>(type: "Varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeMaster", x => x.ChargeId);
                });

            migrationBuilder.CreateTable(
                name: "CounterPartyMaster",
                columns: table => new
                {
                    CounterPartyID = table.Column<string>(type: "varchar(15)", nullable: false),
                    CounterpartyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PAN = table.Column<string>(type: "varchar(10)", nullable: true),
                    GSTNo = table.Column<string>(type: "varchar(15)", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(250)", nullable: true),
                    Address2 = table.Column<string>(type: "varchar(250)", nullable: true),
                    Address3 = table.Column<string>(type: "varchar(250)", nullable: true),
                    EmailId1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    EmailId2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    TelNo1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    TelNo2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    FaxNo1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    FaxNo2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    MobNo1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    MobNo2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactPerson = table.Column<string>(type: "varchar(50)", nullable: true),
                    BankName = table.Column<string>(type: "varchar(50)", nullable: true),
                    BankBranch = table.Column<string>(type: "varchar(50)", nullable: true),
                    IFSC = table.Column<string>(type: "varchar(50)", nullable: true),
                    NameBeneficiary = table.Column<string>(type: "varchar(50)", nullable: true),
                    AccountNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterPartyMaster", x => x.CounterPartyID);
                });

            migrationBuilder.CreateTable(
                name: "CustodianMaster",
                columns: table => new
                {
                    CustodianId = table.Column<string>(type: "varchar(15)", nullable: false),
                    CustodianName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(250)", nullable: true),
                    Address2 = table.Column<string>(type: "varchar(250)", nullable: true),
                    Address3 = table.Column<string>(type: "varchar(250)", nullable: true),
                    EmailId1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    EmailId2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    TelephoneNumber1 = table.Column<string>(type: "varchar(15)", nullable: true),
                    TelephoneNumber2 = table.Column<string>(type: "varchar(15)", nullable: true),
                    FaxNumber1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    FaxNumber2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    MobileNumber1 = table.Column<string>(type: "varchar(15)", nullable: true),
                    MobileNumber2 = table.Column<string>(type: "varchar(15)", nullable: true),
                    ContactPerson = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustodianMaster", x => x.CustodianId);
                });

            migrationBuilder.CreateTable(
                name: "GoldLocationMaster",
                columns: table => new
                {
                    Lid = table.Column<string>(type: "varchar(15)", nullable: false),
                    GoldLocation = table.Column<string>(nullable: true),
                    Active = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldLocationMaster", x => x.Lid);
                });

            migrationBuilder.CreateTable(
                name: "GoldMaster",
                columns: table => new
                {
                    GoldId = table.Column<string>(type: "varchar(15)", nullable: false),
                    SecurityName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Active = table.Column<string>(type: "char(1)", nullable: true),
                    SecurityLocation = table.Column<string>(type: "varchar(50)", nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", nullable: true),
                    BarWeightInKg = table.Column<float>(nullable: false),
                    BarWeightInGrams = table.Column<float>(nullable: false),
                    CommodityPurity = table.Column<decimal>(type: "numeric(20,4)", nullable: false),
                    CommodityDenomination = table.Column<string>(type: "varchar(10)", nullable: true),
                    ValuationRateType = table.Column<string>(type: "varchar(10)", nullable: true),
                    Conversionfactor = table.Column<decimal>(type: "numeric(20,4)", nullable: false),
                    VaultingAgent = table.Column<string>(type: "varchar(50)", nullable: true),
                    CounterpartyShipper = table.Column<string>(type: "varchar(150)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(50)", nullable: true),
                    Issuer = table.Column<string>(type: "varchar(50)", nullable: true),
                    StockExchange = table.Column<string>(type: "varchar(50)", nullable: true),
                    Stampduty = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    Octroi = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    CustomDuty = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    FixingCharge = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    SGST = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    CGST = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    GST = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    NAVlot = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    Facevalue = table.Column<decimal>(type: "numeric(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldMaster", x => x.GoldId);
                });

            migrationBuilder.CreateTable(
                name: "TaxMaster",
                columns: table => new
                {
                    TaxId = table.Column<string>(type: "varchar(15)", nullable: false),
                    State = table.Column<string>(nullable: true),
                    SGST = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    CGST = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    GST = table.Column<decimal>(type: "numeric(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxMaster", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    Roles = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserGroup = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModuleRights = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargeMaster");

            migrationBuilder.DropTable(
                name: "CounterPartyMaster");

            migrationBuilder.DropTable(
                name: "CustodianMaster");

            migrationBuilder.DropTable(
                name: "GoldLocationMaster");

            migrationBuilder.DropTable(
                name: "GoldMaster");

            migrationBuilder.DropTable(
                name: "TaxMaster");

            migrationBuilder.DropTable(
                name: "UserMaster");
        }
    }
}
