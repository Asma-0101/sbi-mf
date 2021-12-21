using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBI_MF.Models
{
    public class TaxesModel
    {
        [Key]
        [Column(TypeName ="varchar(15)")]
        public string TaxId {get; set;}
        public string State {get; set;}
        [Column(TypeName = "numeric(3,2)")]
        public float SGST {get; set;}
        [Column(TypeName = "numeric(3,2)")]
        public float CGST {get; set;}
        [Column(TypeName = "numeric(3,2)")]
        public float GST {get; set;}


        public TaxesModel(string taxId, string state, float sGST, float cGST, float gST)
        {
            TaxId=taxId;
            State=state;
            SGST=sGST;
            CGST=cGST;
            GST=gST;


        }


    }
}