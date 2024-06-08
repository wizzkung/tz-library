using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tz_lib24.Models;

    public class libContext : DbContext
    {
        public libContext(DbContextOptions<libContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Issues> Book_issues { get; set; }
        public DbSet<ReturnedBooks> ReturnedBooks { get; set; }
        public DbSet<UnreturnedBooks> UnreturnedBooks { get; set; }
    }

