using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using SBI_MF.Models;


namespace SBI_MF.Controllers.Dtos
{
    public class DealConfirmationDto
    {
        [Key]
        public string  DealConfirmId{get;set;}

        [ForeignKey("TransactionId")]

        public string TransactionId {get;set;}
        [Column(TypeName ="varchar(50)")]
        public string Name{get;set;}
        [Column(TypeName ="varchar(250)")]
        public string Address{get;set;}

        [Column(TypeName ="varchar(25)")]
        public string ContactNo{get;set;}
        [Column(TypeName ="varchar(50)")]
        public string ContactPersonName{get;set;} 
        [Column(TypeName ="varchar(20)")]
        public string DealRefNo{get;set;}
        [Column(TypeName ="varchar(50)")]

        public string ClientName{get;set;}
        [Column(TypeName ="varchar(50)")]

        public string SchemeName	{get;set;}
        [Column(TypeName ="varchar(50)")]

        public string TransactionType{get;set;}
        [Column(TypeName ="varchar(50)")]
        public string GSTNo{get;set;}
        [Column(TypeName ="date")]

        public DateTime DealDate {get;set;}
        [Column(TypeName ="date")]

        public DateTime ValueDate{get;set;}
        [Column(TypeName ="varchar(150)")]

        public string Commodity{get;set;}
        [Column(TypeName ="varchar(150)")]

        public string CounterpartyShipper{get;set;}
        [Column(TypeName ="numeric(10,2)")] 	
        public float QuantityInKilogram{get;set;}
        public float Rate{get;set;}
        [Column(TypeName ="numeric(10,2)")] 	
        public float TotalPrice{get;set;}
        [Column(TypeName ="numeric(10,2)")] 	            
        public float SGST{get;set;}
        [Column(TypeName ="numeric(10,2)")] 	
        public float CGST{get;set;}
        [Column(TypeName ="numeric(5,2)")] 	
        public float GST{get;set;}
        [Column(TypeName ="numeric(10,2)")] 	
        public float TotalGST{get;set;}

        [Column(TypeName ="numeric(10,2)")] 	
        public float TotalConsideration{get;set;}

        [Column(TypeName ="varchar(150)")]
        public string OtherApplicableTaxes{get;set;}

        [Column(TypeName ="numeric(10,2)")] 	
        public float TaxCollectedAtSource{get;set;}
        [Column(TypeName ="varchar(250)")]
        public string NetConsideration{get;set;}

        [Column(TypeName ="varchar(250)")]
        public string Remarks{get;set;}
        [Column(TypeName ="varchar(250)")]                    
        public string BranchName{get;set;}
        [Column(TypeName ="varchar(50)")]
        public string IFSCCode{get;set;}

        [Column(TypeName ="int")] 	
        public int BeneficiaryAccount{get;set;}
        [Column(TypeName ="varchar(50)")]
        public string BeneficiaryAccountName{get;set;}
        [Column(TypeName ="varchar(50)")]
        public string DealStatus{get;set;}
        public static DealConfirmationDto FromEntity(DealConfirmationModel dc)
        {
        return new DealConfirmationDto
        {
        DealConfirmId=dc.DealConfirmId,
        TransactionId=dc.TransactionId,
        Name=dc.Name,
        Address=dc.Address,
        ContactNo=dc.ContactNo,
        ContactPersonName=dc.ContactNo,
        DealRefNo=dc.DealRefNo,
        ClientName=dc.ClientName,
        SchemeName=dc.SchemeName,
        TransactionType=dc.TransactionType,
        GSTNo=dc.GSTNo,
        DealDate=dc.DealDate,
        ValueDate=dc.ValueDate,
        Commodity=dc.Commodity,
        CounterpartyShipper=dc.CounterpartyShipper,
        QuantityInKilogram=dc.QuantityInKilogram,
        Rate=dc.Rate,
        TotalPrice=dc.TotalPrice,
        CGST=dc.CGST,
        SGST=dc.SGST,
        GST=dc.GST,
        TotalGST=dc.TotalGST,
        TotalConsideration=dc.TotalConsideration,
        OtherApplicableTaxes=dc.OtherApplicableTaxes,
        TaxCollectedAtSource=dc.TaxCollectedAtSource,
        NetConsideration=dc.NetConsideration,
        Remarks=dc.Remarks,
        BranchName=dc.BranchName,
        IFSCCode=dc.IFSCCode,
        BeneficiaryAccount=dc.BeneficiaryAccount,
        BeneficiaryAccountName=dc.BeneficiaryAccountName,
        DealStatus=dc.DealStatus


        };
        }  
    }
}