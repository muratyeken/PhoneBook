using Microsoft.EntityFrameworkCore;
using OrionPhoneDirectory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OrionPhoneDirectory.Repository.Context
{
    public class OrionPhoneDirectoryContext : DbContext
    {
        public OrionPhoneDirectoryContext(DbContextOptions<OrionPhoneDirectoryContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=BALIM\\MSSQLSERVER2019;Database=PhoneDirectoryDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}



