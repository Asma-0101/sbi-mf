
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using SBI_MF.Models;

namespace SBI_MF.Controllers.Dtos
{
    public class UserDto
{
        [Key]
        public int   UserId{get;set;}

                [Column(TypeName ="varchar(50)")]
                public string UserName{get;set;}

              [Column(TypeName ="varchar(50)")]
                public string Password	{get;set;}

                [Column(TypeName ="varchar(50)")]
                public string Roles	{get;set;}
                [Column(TypeName ="varchar(50)")]
                public string UserGroup	{get;set;}
                [Column(TypeName ="varchar(50)")]
                public string ModuleRights{get;set;}

  public static UserDto FromEntity(UserModel um) 

                {
                            return new UserDto
                                    {
                                        UserId=um.UserId,
                                        UserName=um.UserName,
                                        Password=um.Password,
                                        Roles=um.Roles,
                                        UserGroup=um.UserGroup,
                                        ModuleRights=um.ModuleRights
    
                                    };
                  }

 }
            
}