using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SBI_MF.Models;

namespace SBI_MF.DTO
{
    public class ChargeDto{
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

        public static ChargeDto FromEntity(ChargeModel chargeModel){
            return new ChargeDto{
                ChargeId=chargeModel.ChargeId,
                SchemeType=chargeModel.SchemeType,
                TransactionType=chargeModel.TransactionType,
                ChargeName=chargeModel.ChargeName,
                ChargeValue=chargeModel.ChargeValue,
                EffectiveDate=chargeModel.EffectiveDate,
                Remarks=chargeModel.Remarks,
            };
        }
    }
}