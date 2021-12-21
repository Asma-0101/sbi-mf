using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class CustodianInstructionDto
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

        public static CustodianInstructionDto FromEntity(CustodianInstructionModel custodianInstruction){
            return new CustodianInstructionDto{
                CustodianInstructionId=custodianInstruction.CustodianInstructionId,
                TransactionId=custodianInstruction.TransactionId,
                CustodianName=custodianInstruction.CustodianName,
                Address=custodianInstruction.Address,
                ContactNo=custodianInstruction.ContactNo,
                ContactPerson=custodianInstruction.ContactPerson,
                SecurityName=custodianInstruction.SecurityName,
                TradeDate=custodianInstruction.TradeDate,
                SettlementDate=custodianInstruction.SettlementDate,
                WeightOfGoldBar=custodianInstruction.WeightOfGoldBar,
                PurityOfGold=custodianInstruction.PurityOfGold,
                Location=custodianInstruction.Location,
                VaultLocation=custodianInstruction.VaultLocation,
                CounterParty=custodianInstruction.CounterParty,
                DelRefNo=custodianInstruction.DelRefNo,
                QtyOfGoldBar=custodianInstruction.QtyOfGoldBar,
                Total=custodianInstruction.Total
            };
        }
    }
}