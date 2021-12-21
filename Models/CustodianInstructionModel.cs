using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBI_MF.Models
{
    public class CustodianInstructionModel
    {
        [Key]
        [Column(TypeName="varchar(15)")]
        public string CustodianInstructionId {get;set;}       
        [Column(TypeName ="varchar(10)")]
        [ForeignKey("TransactionId")]
        public string TransactionId {get;set;}
        [Column(TypeName ="varchar(20)")]
        public string CustodianName {get;set;}
        [Column(TypeName ="varchar(250)")]
        public string Address {get;set;}
        [Column(TypeName ="varchar(15)")]
        public string ContactNo {get;set;}
        [Column(TypeName ="varchar(50)")]
        public string ContactPerson {get;set;}
        [Column(TypeName ="varchar(50)")]
        public string SecurityName {get;set;}
        [Column(TypeName ="date")]
        public DateTime TradeDate {get;set;}
        [Column(TypeName ="date")]
        public DateTime SettlementDate {get;set;}
        [Column(TypeName ="varchar(50)")]
        public string WeightOfGoldBar {get;set;}
        [Column(TypeName ="varchar(20)")]
        public string PurityOfGold {get;set;}
        [Column(TypeName ="varchar(50)")]
        public string Location {get;set;}
        [Column(TypeName ="varchar(50)")]
        public string VaultLocation {get;set;}
        [Column(TypeName ="varchar(20)")]
        public string CounterParty {get;set;}
        [Column(TypeName ="varchar(20)")]
        public string DelRefNo {get;set;}
        [Column(TypeName ="numeric(20,2)")]
        public float QtyOfGoldBar {get;set;}
        [Column(TypeName ="numeric(20,2)")]
        public float Total {get;set;}

        public CustodianInstructionModel(string custodianInstructionId,string transactionId, string custodianName, string address,string contactNo, string contactPerson,string securityName,DateTime tradeDate,DateTime settlementDate, string weightOfGoldBar, string purityOfGold, string location,string vaultLocation, string counterParty, string delRefNo, float qtyOfGoldBar, float total){
            CustodianInstructionId = custodianInstructionId;
            TransactionId=transactionId;
            CustodianName=custodianName;
            ContactNo=contactNo;
            Address=address;
            ContactPerson=contactPerson;
            SecurityName=securityName;
            TradeDate=tradeDate;
            SettlementDate=settlementDate;
            WeightOfGoldBar=weightOfGoldBar;
            PurityOfGold=purityOfGold;
            Location=location;
            VaultLocation=vaultLocation;
            CounterParty=counterParty;
            DelRefNo=delRefNo;
            QtyOfGoldBar=qtyOfGoldBar;
            Total=total;
        }

    }
}