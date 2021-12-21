using System;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class TaxDto
    {
        public string TaxId {get; set;}
        public string State {get; set;}
        [Column(TypeName = "numeric(3,2)")]
        public float SGST {get; set;}
        [Column(TypeName = "numeric(3,2)")]
        public float CGST {get; set;}
        [Column(TypeName = "numeric(3,2)")]
        public float GST {get; set;}

         public static TaxDto FromEntity(TaxesModel tax)
        {
            return new TaxDto
            {
            TaxId=tax.TaxId,
            State=tax.State,
            SGST=tax.SGST,
            CGST=tax.CGST,
            GST=tax.GST

            };
        }


    


    }
}