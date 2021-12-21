
using SBI_MF.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SBI_MF.Controllers.Dtos
{
    public class CounterPartyDto
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
        public int AccountNo { get; set; }

        public static CounterPartyDto FromCounterParty(CounterPartyModel counterParty)
        {
            return new CounterPartyDto
            {
                CounterPartyID = counterParty.CounterPartyID,
                CounterpartyName = counterParty.CounterpartyName,
                PAN = counterParty.PAN,
                GSTNo = counterParty.GSTNo,
                Address1 = counterParty.Address1,
                Address2 = counterParty.Address2,
                Address3 = counterParty.Address3,
                EmailId1 = counterParty.EmailId1,
                EmailId2 = counterParty.EmailId2,
                TelNo1 = counterParty.TelNo1,
                TelNo2 = counterParty.TelNo2,
                FaxNo1 = counterParty.FaxNo1,
                FaxNo2 = counterParty.FaxNo2,
                MobNo1 = counterParty.MobNo1,
                MobNo2 = counterParty.MobNo2,
                ContactPerson = counterParty.ContactPerson,
                BankName = counterParty.BankName,
                BankBranch = counterParty.BankBranch,
                IFSC = counterParty.IFSC,
                NameBeneficiary = counterParty.NameBeneficiary,
                AccountNo = counterParty.AccountNo
            };
        }
    }
}