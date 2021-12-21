using System;
using SBI_MF.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SBI_MF.Controllers.Dtos
{
    public class CustodianDto
    {
        
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string CustodianId { get; set;}
        [Column(TypeName = "varchar(50)")]
        public string CustodianName { get; set;}
        [Column(TypeName = "varchar(250)")]
        public string Address1 { get; set;}
        [Column(TypeName = "varchar(250)")]
        public string Address2 { get; set;}
        [Column(TypeName = "varchar(250)")]
        public string Address3 { get; set;}
        [Column(TypeName = "varchar(50)")]
        public string EmailId1 { get; set;}
        [Column(TypeName = "varchar(50)")]
        public string EmailId2 { get; set;}
        [Column(TypeName = "varchar(15)")]
        public string TelephoneNumber1 { get; set;}
        [Column(TypeName = "varchar(15)")]
        public string TelephoneNumber2 { get; set;}
        [Column(TypeName = "varchar(10)")]
        public string FaxNumber1 { get; set;}
        [Column(TypeName = "varchar(10)")]
        public string FaxNumber2 { get; set;}
        [Column(TypeName = "varchar(15)")]
        public string MobileNumber1 { get; set;}
        [Column(TypeName = "varchar(15)")]
        public string MobileNumber2 { get; set;}
        [Column(TypeName = "varchar(50)")]
        public string ContactPerson { get; set;}


        public static CustodianDto FromEntity(CustodianModel custodianMaster){
            return new CustodianDto
            {
                CustodianId = custodianMaster.CustodianId,
        
                CustodianName = custodianMaster.CustodianName,
                
                Address1 = custodianMaster.Address1,
                
                Address2 = custodianMaster.Address2,
                
                Address3 = custodianMaster.Address3,
                
                EmailId1 = custodianMaster.EmailId1,
                
                EmailId2 = custodianMaster.EmailId2,
                
                TelephoneNumber1 = custodianMaster.TelephoneNumber1,
                
                TelephoneNumber2 = custodianMaster.TelephoneNumber2,
                
                FaxNumber1 = custodianMaster.FaxNumber1,
                FaxNumber2 = custodianMaster.FaxNumber2,
                MobileNumber1 = custodianMaster.MobileNumber1,
                MobileNumber2 = custodianMaster.MobileNumber2,
                ContactPerson = custodianMaster.ContactPerson,
            };
        }
    }
}