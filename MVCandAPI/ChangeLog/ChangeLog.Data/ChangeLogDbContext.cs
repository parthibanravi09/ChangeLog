using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLog.Data
{
    public class ChangeLogDbContext: DbContext
    {
        public DbSet<ChangeLogs> ChangeLogs { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ChangeLogDb.db");
        }
    }

}
