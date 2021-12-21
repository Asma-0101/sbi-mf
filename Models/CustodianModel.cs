using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBI_MF.Models
{
    public class CustodianModel
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
       
        public CustodianModel(string custodianId, string custodianName, string address1,string address2, string address3, string emailId1,
                string emailId2, string telephoneNumber1, string telephoneNumber2,string faxNumber1, string faxNumber2, string mobileNumber1,string mobileNumber2,
                string contactPerson)
            {
                CustodianId = custodianId;
                CustodianName = custodianName;
                Address1 = address1;
                Address2 = address2;
                Address3 = address3 ;
                EmailId1 = emailId1;
                EmailId2 = emailId2;
                TelephoneNumber1 = telephoneNumber1;
                TelephoneNumber2 = telephoneNumber2;
                FaxNumber1 = faxNumber1;
                FaxNumber2 = faxNumber2;
                MobileNumber1 = mobileNumber1;
                MobileNumber2 = mobileNumber2;
                ContactPerson =contactPerson;
            }
    }
}