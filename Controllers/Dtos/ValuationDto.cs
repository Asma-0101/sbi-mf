using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;

using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class ValuationDto
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

        public static ValuationDto FromEntity(ValuationModel v) 
        {
        return new ValuationDto
        {
            ValuationId=v.ValuationId,
            TransactionId=v.TransactionId,
            Workflow=v.Workflow,
            TransactionType=v.TransactionType,
            LondonAMRateUSD=v.LondonAMRateUSD,
            FixingChargesUSD=v.FixingChargesUSD,
            PremiumUSD=v.PremiumUSD,
            MetalRateUSD=v.MetalRateUSD,
            ConversionFactor=v.ConversionFactor,
            RBIReferenceRateINR=v.RBIReferenceRateINR,
            MetalRatePerkgINR=v.MetalRatePerkgINR,
            CustomsDutyKg=v.CustomsDutyKg,
            StampDutyINR=v.StampDutyINR,
            FinalPriceUSD=v.FinalPriceUSD,
            TransactionStatus=v.TransactionStatus
            
        };
        }
    }
}