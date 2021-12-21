using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class GoldDto
    {
        [Key]
        [Column(TypeName ="varchar(15)")]
        public string GoldId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string SecurityName { get; set; }
        [Column(TypeName ="char(1)")]
        public string Active { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string SecurityLocation { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Type { get; set; }
    
         public float BarWeightInKg{ get; set; }
        
        public float BarWeightInGrams { get; set; }
        [Column(TypeName ="numeric(20,4)")]
        public float CommodityPurity { get; set; }
        [Column(TypeName ="varchar(10)")]
        public string CommodityDenomination { get; set; }
        [Column(TypeName ="varchar(10)")]
        public string ValuationRateType { get; set; }
        [Column(TypeName ="numeric(20,4)")]
        public float Conversionfactor  { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string VaultingAgent { get; set; }
        [Column(TypeName ="varchar(150)")]
        public string CounterpartyShipper { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Currency { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Issuer  { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string StockExchange { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float Stampduty { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float Octroi { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float Premium  { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float CustomDuty { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float FixingCharge { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float SGST { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float CGST  { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float GST { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float NAVlot { get; set; }
        [Column(TypeName ="numeric(3,2)")]
        public float Facevalue { get; set; }

        public static GoldDto FromEntity(GoldModel goldMaster)
        {
              return new GoldDto
              {
                    GoldId = goldMaster.GoldId,
                    SecurityName =goldMaster.SecurityName,
                    Active = goldMaster.Active,
                    SecurityLocation = goldMaster.SecurityLocation,
                    Type = goldMaster.Type,
                    BarWeightInKg = goldMaster.BarWeightInKg,
                    BarWeightInGrams = goldMaster.BarWeightInGrams,
                    CommodityPurity = goldMaster.CommodityPurity,
                    CommodityDenomination = goldMaster.CommodityDenomination,
                    ValuationRateType = goldMaster.ValuationRateType,
                    Conversionfactor = goldMaster.Conversionfactor,
                    VaultingAgent = goldMaster.VaultingAgent,
                    CounterpartyShipper = goldMaster.CounterpartyShipper,
                    Currency = goldMaster.Currency,
                    Issuer = goldMaster.Issuer,
                    StockExchange = goldMaster.StockExchange,
                    Stampduty = goldMaster.Stampduty,
                    Octroi = goldMaster.Octroi,
                    Premium = goldMaster.Premium,
                    CustomDuty = goldMaster.CustomDuty,
                    FixingCharge = goldMaster.FixingCharge,
                    SGST = goldMaster.SGST,
                    CGST = goldMaster.CGST,
                    GST = goldMaster.GST,
                    NAVlot = goldMaster.NAVlot,
                    Facevalue = goldMaster.Facevalue
               };

        }

    }
}