using Ibks.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibks.Data.Configurations
{
    //public class TicketReplyConfiguration : IEntityTypeConfiguration<TicketReplyEntity>
    //{
    //    public void Configure(EntityTypeBuilder<TicketReplyEntity> entity)
    //    {
    //        entity.ToTable("Companies").HasKey(e => e.Id);
    //        //entity.HasIndex(e => e.Name);
    //        //entity.HasIndex(e => e.Country);
    //        //entity.HasIndex(e => e.Phone);

    //        //entity.Property(e => e.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();

    //        //entity.Property(e => e.Name).HasColumnName("Name").HasColumnType("nvarchar(255)");
    //        //entity.Property(e => e.Email).HasColumnName("Email").HasColumnType("nvarchar(255)");
    //        //entity.Property(e => e.Country).HasColumnName("Country").HasColumnType("nvarchar(255)");
    //        //entity.Property(e => e.Phone).HasColumnName("Phone").HasColumnType("nvarchar(255)");
    //        //entity.Property(e => e.LogoUrl).HasColumnName("LogoUrl").HasColumnType("nvarchar(max)").IsRequired(false);

    //        //entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetimeoffset");
    //        //entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasColumnType("nvarchar(255)");
    //        //entity.Property(e => e.LastUpdatedAt).HasColumnName("LastUpdatedAt").HasColumnType("datetimeoffset");
    //        //entity.Property(e => e.LastUpdatedBy).HasColumnName("LastUpdatedBy").HasColumnType("nvarchar(255)");
    //        //entity.Property(e => e.LastUpdateById).HasColumnName("LastUpdateById").HasColumnType("nvarchar(36)");
    //        //entity.Property(e => e.CreatedById).HasColumnName("CreatedById").HasColumnType("nvarchar(36)");


    //        //entity.HasMany(a => a.Locations).WithOne(b => b.Company).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Cascade);
    //        //entity.HasMany(a => a.AssignedUsers).WithOne(b => b.Company).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Restrict);

    //    }
    //}
}
