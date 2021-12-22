using System;
//using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SBI_MF.Models
{
    public class CounterPartyModel
    {
        [Key]
        [Column(TypeName ="varchar(15)")]
        public string CounterPartyID { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string CounterpartyName { get; set; }
        [Column(TypeName ="varchar(10)")]
        public string PAN { get; set; }
        [Column(TypeName ="varchar(15)")]
        public string GSTNo { get; set; }
        [Column(TypeName ="varchar(250)")]
        public string Address1 { get; set; }
        [Column(TypeName ="varchar(250)")]
        public string Address2 { get; set; }
        [Column(TypeName ="varchar(250)")]
        public string Address3 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string EmailId1 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string EmailId2 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string TelNo1 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string TelNo2 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FaxNo1 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FaxNo2 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string MobNo1 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string MobNo2 { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string ContactPerson { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string BankName { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string BankBranch { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string IFSC { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string NameBeneficiary { get; set; }
        [Column(TypeName ="numeric(18,0)")]
        public float AccountNo { get; set; }

        public CounterPartyModel(string counterPartyID, string counterpartyName, string pAN, string gSTNo, string address1, string address2, 
        string address3, string emailId1, string emailId2,string telNo1, string telNo2, string faxNo1, string faxNo2, string mobNo1, 
        string mobNo2, string contactPerson, string bankName, string bankBranch, string iFSC, string nameBeneficiary, float accountNo)
        {
            CounterPartyID = counterPartyID;
            CounterpartyName = counterpartyName;
            PAN = pAN;
            GSTNo = gSTNo;
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            EmailId1 = emailId1;
            EmailId2 = emailId2;
            TelNo1 = telNo1;
            TelNo2 = telNo2;
            FaxNo1 = faxNo1;
            FaxNo2 = faxNo2;
            MobNo1 = mobNo1;
            MobNo2 = mobNo2;
            ContactPerson = contactPerson;
            BankName = bankName;
            BankBranch = bankBranch;
            IFSC = iFSC;
            NameBeneficiary = nameBeneficiary;
            AccountNo = accountNo;
        }
    }
}
