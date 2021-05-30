using _3LineCardMgtLimited.Models.BaseEnity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3LineCardMgtLimited.Models
{
    public class RegisterApp : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string happening { get; set; }
        public string appDescription { get; set; }
        public DateTime timeStamp { get; set; }
        public virtual AppAuthentication AppAuthentication { get; set; }

    }
}