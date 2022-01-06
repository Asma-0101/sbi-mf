using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;

using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class LogDto
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

        public static LogDto FromEntity(LogModel  v) 
        {
        return new LogDto
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
