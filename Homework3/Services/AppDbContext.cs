using Homework3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework3.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CityData> CityDatas { get; set; }
        public DbSet<CityDailyCaseData> CityDailyCaseDatas { get; set; }
    }
}
