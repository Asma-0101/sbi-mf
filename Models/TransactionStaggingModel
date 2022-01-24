using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbi_mf_sbi_mfv1.Models
{
    public class TransactionStaggingModel
    {
        [Key]
        [Column(TypeName ="int")]
        public int Id {get; set;}
        [Column(TypeName ="varchar(15)")]
        public string BusinessKey {get; set;}
        [Column(TypeName ="varchar(50)")]
        public string ProcessInstanceId {get; set;}
        [Column(TypeName ="varchar(50)")]
        public string TaskInstanceId {get; set;}
        [Column(TypeName ="varchar(50)")]
        public string TaskName {get; set;}
        [Column(TypeName ="date")]
        public DateTime CreationDate {get; set;}
        [Column(TypeName ="char(1)")]
        public string TaskStatus {get; set;}
         [Column(TypeName ="date")]
        public DateTime TaskCompletionDate {get; set;}
         [Column(TypeName ="char(1)")]
        public string RoleName {get; set;}
          [Column(TypeName ="varchar(20)")]
        public string UserId {get; set;}

        public TransactionStaggingModel( int id,string businessKey, string processInstanceId, string taskInstanceId,string taskName,DateTime creationDate,string taskStatus,
        DateTime taskCompletionDate,string roleName,string userId )
        {
              Id=id;
              BusinessKey=businessKey;
              ProcessInstanceId=processInstanceId;
              TaskInstanceId=taskInstanceId;
              TaskName=taskName;
              CreationDate=creationDate;
              TaskStatus=taskStatus;
              TaskCompletionDate=taskCompletionDate;
              RoleName=roleName;
              UserId=userId;

        }

    }
}
