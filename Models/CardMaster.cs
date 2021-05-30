using _3LineCardMgtLimited.Models.BaseEnity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3LineCardMgtLimited.Models
{
    public enum cardType { debit, credit }
    public enum cardScheme { VISA, MASTERCARD, AMEX } 

    public class CardMaster : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string cardNumber { get; set; }
        public int hitCount { get; set; }
        public cardType? cardType { get; set; }
        public cardScheme? cardScheme { get; set; }
        public virtual Bank Bank { get; set; }
          
    }
}