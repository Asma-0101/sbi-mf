
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
namespace SBI_MF.Models
{
    public class DealConfirmationModel
    {
        [Key]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(15)")]
        public string  DealConfirmId{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [ForeignKey("TransactionId")]
        [Column(TypeName ="varchar(15)")]
        
        public string TransactionId {get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(50)")]
        public string Name{get;set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(250)")]
        public string Address{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(25)")]
        public string ContactNo{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(50)")]
        public string ContactPersonName{get;set;} 


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(20)")]
        public string DealRefNo{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(50)")]

        public string ClientName{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(50)")]

        public string SchemeName{get;set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(50)")]

        public string TransactionType{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^([0][1-9]|[1-2][0-9]|[3][0-7])([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$", ErrorMessage = "Invalid GST Number.")]
        [Column(TypeName ="varchar(50)")]

        public string GSTNo{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="date")]

        public DateTime DealDate {get;set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="date")]

        public DateTime ValueDate{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(150)")]

        public string Commodity{get;set;}


        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(150)")]

        public string CounterpartyShipper{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")] 	
        public float QuantityInKilogram{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")]
        public float Rate{get;set;}




        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")] 	
        public float TotalPrice{get;set;}




        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")] 	            
        public float SGST{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")] 	
        public float CGST{get;set;}




        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")] 	
        public float GST{get;set;}




        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="numeric(10,2)")] 	
        public float TotalGST{get;set;}



        [Required(ErrorMessage = "This field is required.")]

        [Column(TypeName ="numeric(10,2)")] 	
        public float TotalConsideration{get;set;}



        [Column(TypeName ="varchar(150)")]
        public string OtherApplicableTaxes{get;set;}



        [Required(ErrorMessage = "This field is required.")]

        [Column(TypeName ="numeric(10,2)")] 	
        public float TaxCollectedAtSource{get;set;}




        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(250)")]
        public string NetConsideration{get;set;}



        [Column(TypeName ="varchar(250)")]
        public string Remarks{get;set;}



        
        [Column(TypeName ="varchar(250)")]                    
        public string BranchName{get;set;}



        [RegularExpression(@"^[A-Z]{4}0[A-Z0-9]{6}$", ErrorMessage = "Invalid IFSC code Number.")]
        
        [Column(TypeName ="varchar(50)")]
        public string IFSCCode{get;set;}



        

        [Column(TypeName ="numeric(18,0)")] 	
        public int BeneficiaryAccount{get;set;}



        
        [Column(TypeName ="varchar(50)")]
        public string BeneficiaryAccountName{get;set;}



        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName ="varchar(50)")]
        public string DealStatus{get;set;}           



        public DealConfirmationModel(string dealConfirmId,string transactionId,string name,string address,string contactNo,string contactPersonName,string dealRefNo,string clientName,string schemeName,string transactionType,string gSTNo,DateTime dealDate,DateTime valueDate,string commodity,string counterpartyShipper,float quantityInKilogram,float rate,float totalPrice,float sGST,float cGST,float gST,float totalGST,float totalConsideration,string otherApplicableTaxes,float taxCollectedAtSource,string netConsideration,string remarks,string branchName,string iFSCCode,int beneficiaryAccount,string beneficiaryAccountName,string dealStatus)
        {
        DealConfirmId=dealConfirmId;
        TransactionId=transactionId;
        Name=name;
        Address=address;
        ContactNo=contactNo;
        ContactPersonName=contactPersonName;
        DealRefNo=dealRefNo;
        ClientName=clientName;
        SchemeName=schemeName;
        TransactionType=transactionType;
        GSTNo=gSTNo;
        DealDate=dealDate;
        ValueDate=valueDate;
        Commodity=commodity;
        CounterpartyShipper=counterpartyShipper;
        QuantityInKilogram=quantityInKilogram;
        Rate=rate;
        TotalPrice=totalPrice;
        SGST=sGST;
        CGST=cGST;
        GST=gST;
        TotalGST=totalGST;
        TotalConsideration=totalConsideration;
        OtherApplicableTaxes=otherApplicableTaxes;
        TaxCollectedAtSource=taxCollectedAtSource;
        NetConsideration=netConsideration;
        Remarks=remarks;
        BranchName=branchName;
        IFSCCode=iFSCCode;
        BeneficiaryAccount=beneficiaryAccount;
        BeneficiaryAccountName=beneficiaryAccountName;
        DealStatus=dealStatus;



        }
    }
}