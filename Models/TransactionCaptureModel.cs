using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBI_MF.Models
{
    public class TransactionCaptureModel
    {
        [Key]
        
        [Column(TypeName ="varchar(15)")]
        public string TransactionId {get; set;}

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="date")]
        public DateTime TransactionDate {get; set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(10)")]
        public string SettlementTenor {get; set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "date")]
        public DateTime ValueDate {get; set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(50)")]
        public string Counterparty {get; set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(20)")]
        public string SchemeName {get; set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(50)")]
        public string Security {get; set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(50)")]
        public string SecurityLocation {get; set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "numeric(20,2)")]
        public float DealValue {get; set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "numeric(20,2)")]
        public float QuantityInKg {get; set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "numeric(20,2)")]
        public float NoOfUnitsPerKg {get; set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "numeric(20,2)")]
        public float TotalUnits {get; set;}


        
        [Column(TypeName = "char(1)")]
        public string TransactionStatus {get; set;}
        [Column(TypeName = "char(1)")]
        public string TransactionType {get; set;}



        public TransactionCaptureModel(string transactionId, DateTime transactionDate, string settlementTenor, 
        DateTime valueDate, string counterparty, string schemeName, string security, string securityLocation, 
        float dealValue, float quantityInKg, float noOfUnitsPerKg, float totalUnits, string transactionStatus, 
        string transactionType)
        {
            TransactionId=transactionId;
            TransactionDate=transactionDate;
            SettlementTenor=settlementTenor;
            ValueDate=valueDate;
            Counterparty=counterparty;
            SchemeName=schemeName;
            Security=security;
            SecurityLocation=securityLocation;
            DealValue=dealValue;
            QuantityInKg=quantityInKg;
            NoOfUnitsPerKg=noOfUnitsPerKg;
            TotalUnits=totalUnits;
            TransactionStatus=transactionStatus;
            TransactionType=transactionType;


        }


    }
}