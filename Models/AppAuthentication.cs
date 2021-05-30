using _3LineCardMgtLimited.Models.BaseEnity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3LineCardMgtLimited.Models
{
    public class AppAuthentication : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string appKey { get; set; }
        public string hashKey { get; set; }
        public string authorisationKey { get; set; }
        public DateTime timeStamp { get; set; }
        public virtual ICollection<RegisterApp> RegisterApps { get; set; }


    }
}