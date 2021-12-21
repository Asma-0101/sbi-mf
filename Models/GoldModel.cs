using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SBI_MF.Models
{
    public class GoldModel
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
       

        public GoldModel( string goldId,string securityName,string active , string securityLocation ,string type ,
          float barWeightInKg, float barWeightInGrams,float commodityPurity ,string commodityDenomination , string valuationRateType,
          float conversionfactor,  string vaultingAgent ,string counterpartyShipper ,string currency ,string issuer,  
          string stockExchange ,float stampduty ,float octroi, float premium , float customDuty,float fixingCharge,
          float sGST, float cGST ,float gST, float nAVlot,float facevalue )
        {
            GoldId = goldId;
            SecurityName = securityName;
            Active = active;
            SecurityLocation = securityLocation;
            Type = type;
            BarWeightInKg = barWeightInKg;
            BarWeightInGrams = barWeightInGrams;
            CommodityPurity = commodityPurity;
            CommodityDenomination = commodityDenomination;
            ValuationRateType = valuationRateType;
            Conversionfactor = conversionfactor;
            VaultingAgent = vaultingAgent;
            CounterpartyShipper = counterpartyShipper;
            Currency = currency;
            Issuer = issuer;
            StockExchange = stockExchange;
            Stampduty = stampduty;
            Octroi = octroi;
            Premium = premium;
            CustomDuty = customDuty;
            FixingCharge = fixingCharge;
            SGST = sGST;
            CGST = cGST;
            GST = gST;
            NAVlot = nAVlot;
            Facevalue = facevalue;
        }
    }
}