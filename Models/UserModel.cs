using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
namespace SBI_MF.Models
{
    public class UserModel
    {
      [Key]
      public int UserId{get;set;}

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

      public UserModel(int userId, string userName,string password,string roles,string userGroup, string moduleRights)

      {
        UserId=userId;
        UserName=userName;
        Password=password;
        Roles=roles;
        UserGroup=userGroup;
        ModuleRights=moduleRights;
      }

    }

}