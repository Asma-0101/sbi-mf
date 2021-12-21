using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SBI_MF.Models
{
    public class ChargeModel
    {
        [Key]
        [Column(TypeName = "Varchar(10)")]
        public string ChargeId {get; set;}
        [Column(TypeName = "Varchar(50)")]
        public string SchemeType {get;set;}
        [Column(TypeName = "Varchar(50)")]
        public string TransactionType {get;set;}
        [Column(TypeName = "Varchar(50)")]
        public string ChargeName {get;set;}
        [Column(TypeName = "numeric(3,2)")]
        public float ChargeValue {get;set;}
        [Column(TypeName = "date")]
        public DateTime EffectiveDate {get;set;}
        [Column(TypeName = "Varchar(250)")]
        public string Remarks {get;set;}



        public ChargeModel(string chargeId,string schemeType,string transactionType,string chargeName,float chargeValue,DateTime effectiveDate,string remarks){
            ChargeId = chargeId;
            SchemeType=schemeType;
            TransactionType=transactionType;
            ChargeName=chargeName;
            ChargeValue=chargeValue;
            EffectiveDate=effectiveDate;
            Remarks=remarks;
           
        }
    }
}