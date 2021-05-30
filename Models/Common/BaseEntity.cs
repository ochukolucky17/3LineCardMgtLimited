using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3LineCardMgtLimited.Models.BaseEnity
{
    public class BaseEntity
    {
       
        public int CreadtedById { get; set; }
        public bool Is_modifiedId { get; set; }
        public bool Is_Deleted { get; set; }

    }
}