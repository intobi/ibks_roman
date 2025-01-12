using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ibks.Data.Entities;

namespace Ibks.Data.Configurations
{
    //public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
    //{
    //    public void Configure(EntityTypeBuilder<TicketEntity> entity)
    //    {
    //        entity.ToTable("Ticket").HasKey(e => e.Id);
    //        entity.Property(e => e.Id).HasColumnName("Id").HasColumnType("bigint").IsRequired();
    //        entity.Property(e => e.Title).HasColumnName("Title").HasColumnType("nvarchar(250)").IsRequired();
    //        entity.Property(e => e.ApplicationId).HasColumnName("ApplicationId").HasColumnType("int").IsRequired();
    //        entity.Property(e => e.ApplicationName).HasColumnName("ApplicationName").HasColumnType("nvarchar(250)");
    //        entity.Property(e => e.Description).HasColumnName("Description").HasColumnType("nvarchar(max)");
    //        entity.Property(e => e.Url).HasColumnName("Url").HasColumnType("nvarchar(1000)");
    //        entity.Property(e => e.StackTrace).HasColumnName("StackTrace").HasColumnType("nvarchar(max)").IsRequired(false);
    //        entity.Property(e => e.Device).HasColumnName("Device").HasColumnType("nvarchar(250)").IsRequired(false);
    //        entity.Property(e => e.Browser).HasColumnName("Browser").HasColumnType("nvarchar(250)").IsRequired(false);
    //        entity.Property(e => e.Resolution).HasColumnName("Resolution").HasColumnType("nvarchar(max)").IsRequired(false);
    //        entity.Property(e => e.PriorityId).HasColumnName("PriorityId").HasColumnType("int").IsRequired();
    //        entity.Property(e => e.StatusId).HasColumnName("StatusId").HasColumnType("int").IsRequired();
    //        entity.Property(e => e.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired(false);
    //        entity.Property(e => e.UserOID).HasColumnName("UserOID").HasColumnType("varchar(50)");
    //        entity.Property(e => e.InstalledEnvironmentId).HasColumnName("InstalledEnvironmentId").HasColumnType("int").IsRequired();
    //        entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeId").HasColumnType("int").IsRequired();
    //        entity.Property(e => e.Date).HasColumnName("Date").HasColumnType("datetime2");
    //        entity.Property(e => e.Deleted).HasColumnName("Deleted").HasColumnType("bit").IsRequired(false);
    //        entity.Property(e => e.LastModified).HasColumnName("LastModified").HasColumnType("datetime2").IsRequired(false);
    //        entity.Property(e => e.CreatedByOID).HasColumnName("CreatedByOID").HasColumnType("nvarchar(max)").IsRequired(false);
    //    }
    //}
}