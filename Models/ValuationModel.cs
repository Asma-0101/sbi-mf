using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SBI_MF.Models
{
    public class ValuationModel
    {
        [Key]
        public string ValuationId { get; set; }  	

        [ForeignKey("TransactionId")]
        public string TransactionId  { get; set; } 

        [Column(TypeName ="varchar(50)")]
        public string Workflow { get; set; }  

        [Column(TypeName ="char(1)")]
        public string TransactionType{ get; set; }  
        [Column(TypeName ="numeric(5,2)")]
        public float LondonAMRateUSD{ get; set; } 
        [Column(TypeName ="numeric(5,2)")] 	
        public float FixingChargesUSD 	{ get; set; } 

        [Column(TypeName ="real")] 	
        public int PremiumUSD 	{ get; set; }  
        [Column(TypeName ="real")] 		
        public int MetalRateUSD{ get; set; }
        [Column(TypeName ="numeric(5,2)")] 	
        public float  ConversionFactor { get; set; } 
        [ Column(TypeName ="numeric(5,2)")] 	
        public float RBIReferenceRateINR { get; set; }
        [Column(TypeName ="numeric(5,2)")] 	
        public int MetalRatePerkgINR { get; set; } 

        [Column(TypeName ="numeric(5,2)")] 	
        public float CustomsDutyKg { get; set; } 
        [Column(TypeName ="numeric(5,2)")] 	
        public float  StampDutyINR { get; set; } 
        [Column(TypeName ="numeric(5,2)")] 	
        public float  FinalPriceUSD { get; set; }  

        [Column(TypeName ="char(1)")] 	
        public string TransactionStatus	{ get; set; } 

        public ValuationModel(string valuationId,string transactionId,string workflow, string transactionType,float londonAMRateUSD,float fixingChargesUSD ,int premiumUSD,int metalRateUSD, float  conversionFactor, float rBIReferenceRateINR,int metalRatePerkgINR ,float customsDutyKg,float stampDutyINR,  float  finalPriceUSD,string transactionStatus )
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

    }
}