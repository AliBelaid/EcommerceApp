using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContext: IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppIdentityDbContext()
        {
        }

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options){

        }
   
     
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
  public DbSet<Core.Entities.identity.Address> Address { get; set; }

        public override DbSet<AppUser> Users { get => base.Users; set => base.Users = value; }
        public override DbSet<IdentityUserClaim<int>> UserClaims { get => base.UserClaims; set => base.UserClaims = value; }
        public override DbSet<IdentityUserLogin<int>> UserLogins { get => base.UserLogins; set => base.UserLogins = value; }
        public override DbSet<IdentityUserToken<int>> UserTokens { get => base.UserTokens; set => base.UserTokens = value; }
        public override DbSet<AppUserRole> UserRoles { get => base.UserRoles; set => base.UserRoles = value; }
        public override DbSet<AppRole> Roles { get => base.Roles; set => base.Roles = value; }
        public override DbSet<IdentityRoleClaim<int>> RoleClaims { get => base.RoleClaims; set => base.RoleClaims = value; }

    

        protected override void OnModelCreating(ModelBuilder builder)
        {

  base.OnModelCreating(builder);


 builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite") {
                foreach(var entityType in builder.Model.GetEntityTypes()){
                 var properties= entityType.ClrType.GetProperties().Where(p=>p.PropertyType==typeof(decimal));
var dataTimeProperty = entityType.ClrType.GetProperties().Where(p=>p.PropertyType == typeof(DateTimeOffset));


              foreach(var property in properties){
                  builder.Entity(entityType.Name).Property(property.
                  Name).HasConversion<double>();
                  
              }
              foreach(var property in dataTimeProperty) {
                builder.Entity(entityType.Name).Property(property.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
              }
                }

          
           }














            base.OnModelCreating(builder);
                    builder.Entity<Group>()
                .HasMany(x => x.Connections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
     builder.Entity<AppUser>()
                .HasOne(ur => ur.Address)
                .WithOne(u => u.AppUser)
                .HasForeignKey<Address>(ur => ur.AppUserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
    

            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

             
        }
        
    }
    
}