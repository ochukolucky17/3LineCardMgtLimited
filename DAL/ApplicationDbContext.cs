using _3LineCardMgtLimited.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _3LineCardMgtLimited.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext") // constructor 
        {
        }

        public DbSet<AppAuthentication> AppAuthentications { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CardMaster> cardMasters  { get; set; }
        public DbSet<RegisterApp> RegisterApps { get; set; }


    }
}