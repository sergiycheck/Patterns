using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace lab1.models
{
    public class MyAppContext:DbContext
    {
        public DbSet<MyHtmlModel> HtmlModels { get; set; }
        public MyAppContext()
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AppCoreDb;Trusted_Connection=True;");
        }
    }
}
