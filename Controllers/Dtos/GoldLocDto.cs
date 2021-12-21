using System;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class GoldLocDto
    {
        public string Lid {get; set;}
        public string GoldLocation {get; set;}
        [Column(TypeName = "char(1)")]
        public char Active {get; set;}

        
         public static GoldLocDto FromEntity(GoldLocModel gld)
        {
            return new GoldLocDto
            {
            Lid=gld.Lid,
            GoldLocation=gld.GoldLocation,
            Active=gld.Active

            };
        }
    }
}

