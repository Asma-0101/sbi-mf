using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBI_MF.Models
{
    public class GoldLocModel
    {
        [Key]
        [Column(TypeName ="varchar(15)")]
        public string Lid {get; set;}
        public string GoldLocation {get; set;}
        [Column(TypeName = "char(1)")]
        public char Active {get; set;}


        public GoldLocModel(string lid, string goldLocation, char active)
        {
            Lid=lid;
            GoldLocation=goldLocation;
            Active=active;

        }


    }
}