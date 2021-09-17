using System;
using ApiRestful.core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiRestful.Infraestructura.Data.Configurations;

#nullable disable

namespace ApiRestful.Infraestructura.Data
{
    public partial class ApiRestfulContext : DbContext
    {
        public ApiRestfulContext()
        {
        }

        public ApiRestfulContext(DbContextOptions<ApiRestfulContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new CommentConfiguracion());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
