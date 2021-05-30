using _3LineCardMgtLimited.Models.BaseEnity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3LineCardMgtLimited.Models
{
    public class Bank : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public virtual ICollection<CardMaster> CardMasters { get; set; }
    }
}