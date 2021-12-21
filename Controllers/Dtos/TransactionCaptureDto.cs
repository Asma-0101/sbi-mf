using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class TransactionCaptureDto
    {
        [Key]
        
        [Column(TypeName ="varchar(15)")]
        public string TransactionId {get; set;}
        [Column(TypeName ="date")]
        public DateTime TransactionDate {get; set;}
        [Column(TypeName = "varchar(10)")]
        public string SettlementTenor {get; set;}
        [Column(TypeName = "date")]
        public DateTime ValueDate {get; set;}
        [Column(TypeName = "varchar(50)")]
        public string Counterparty {get; set;}

        [Column(TypeName = "varchar(20)")]
        public string SchemeName {get; set;}
        [Column(TypeName = "varchar(50)")]
        public string Security {get; set;}
        [Column(TypeName = "varchar(50)")]
        public string SecurityLocation {get; set;}
        [Column(TypeName = "numeric(20,2)")]
        public float DealValue {get; set;}
        [Column(TypeName = "numeric(20,2)")]
        public float QuantityInKg {get; set;}
        [Column(TypeName = "numeric(20,2)")]
        public float NoOfUnitsPerKg {get; set;}
        [Column(TypeName = "numeric(20,2)")]
        public float TotalUnits {get; set;}
        [Column(TypeName = "char(1)")]
        public string TransactionStatus {get; set;}
        [Column(TypeName = "char(1)")]
        public string TransactionType {get; set;}
         public static TransactionCaptureDto FromEntity(TransactionCaptureModel transcap)
        {
            return new TransactionCaptureDto
            {
            TransactionId=transcap.TransactionId,
            TransactionDate=transcap.TransactionDate,
            SettlementTenor=transcap.SettlementTenor,
            ValueDate=transcap.ValueDate,
            Counterparty=transcap.Counterparty,
            SchemeName=transcap.SchemeName,
            Security=transcap.Security,
            SecurityLocation=transcap.SecurityLocation,
            DealValue=transcap.DealValue,
            QuantityInKg=transcap.QuantityInKg,
            NoOfUnitsPerKg=transcap.NoOfUnitsPerKg,
            TotalUnits=transcap.TotalUnits,
            TransactionStatus=transcap.TransactionStatus,
            TransactionType=transcap.TransactionType
            };
        }


    


    }
}