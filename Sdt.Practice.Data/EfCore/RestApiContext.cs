﻿using Microsoft.EntityFrameworkCore;
using Sdt.Practice.Domain.Models;

namespace Sdt.Practice.Data
{
    public class RestApiContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public RestApiContext(DbContextOptions<RestApiContext> options) : base(options)
        {

        }
    }
}