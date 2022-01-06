using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SBI_MF.Models
{
    public class LogModel
    {
        [Key]
        public string ValuationId { get; set; }  	

        [ForeignKey("TransactionId")]
        public string TransactionId  { get; set; } 

        [Column(TypeName ="varchar(50)")]
        public string Workflow { get; set; }  

        [Column(TypeName ="char(1)")]
        public string TransactionType{ get; set; }  
        [Column(TypeName ="varchar(15)")]
        public string LondonAMRateUSD{ get; set; } 
        [Column(TypeName ="varchar(15)")] 	
        public string FixingChargesUSD 	{ get; set; } 

        [Column(TypeName ="varchar(15)")] 	
        public string PremiumUSD 	{ get; set; }  
        [Column(TypeName ="varchar(15)")] 		
        public string MetalRateUSD{ get; set; }
        [Column(TypeName ="varchar(15)")] 	
        public string  ConversionFactor { get; set; } 
        [ Column(TypeName ="varchar(15)")] 	
        public string RBIReferenceRateINR { get; set; }
        [Column(TypeName ="varchar(15)")] 	
        public string MetalRatePerkgINR { get; set; } 

        [Column(TypeName ="varchar(15)")] 	
        public string CustomsDutyKg { get; set; } 
        [Column(TypeName ="varchar(15)")] 	
        public string  StampDutyINR { get; set; } 
        [Column(TypeName ="varchar(15)")] 	
        public string  FinalPriceUSD { get; set; }  

        [Column(TypeName ="char(1)")] 	
        public string TransactionStatus	{ get; set; } 

        public LogModel(string valuationId,string transactionId,string workflow, string transactionType,string londonAMRateUSD,string fixingChargesUSD ,string premiumUSD,string metalRateUSD, string  conversionFactor, string rBIReferenceRateINR,string metalRatePerkgINR ,string customsDutyKg,string stampDutyINR,  string  finalPriceUSD,string transactionStatus )
        {
        ValuationId=valuationId;
        TransactionId=transactionId;
        Workflow=workflow;
        TransactionType=transactionType;
        LondonAMRateUSD=londonAMRateUSD;
        FixingChargesUSD=fixingChargesUSD;
        MetalRateUSD=metalRateUSD;
        ConversionFactor=conversionFactor;
        RBIReferenceRateINR=rBIReferenceRateINR;
        MetalRatePerkgINR=metalRatePerkgINR;
        CustomsDutyKg=customsDutyKg;
        StampDutyINR=stampDutyINR;
        FinalPriceUSD=finalPriceUSD;
        TransactionStatus=transactionStatus;

        }

        public LogModel()
        {
        }
    }
}
