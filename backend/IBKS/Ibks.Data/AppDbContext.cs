using Ibks.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ibks.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketReplyEntity> TicketReplies { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<PriorityEntity> Priorities { get; set; }
        public DbSet<TicketTypeEntity> TicketTypes { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            OnModelTicketCreating(builder);
            OnModelTicketReplyCreating(builder);
            OnModelTypesCreating(builder);
            OnModelUserCreating(builder);
        }

        private void OnModelTicketCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketEntity>(entity =>
            {
                entity.ToTable("Ticket", "Support");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.HasOne(p => p.Priority)
                      .WithMany()
                      .HasForeignKey(p => p.PriorityId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Status)
                      .WithMany()
                      .HasForeignKey(p => p.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.TicketType)
                      .WithMany()
                      .HasForeignKey(p => p.TicketTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Replies)
                      .WithOne(cp => cp.Ticket)
                      .HasForeignKey(cp => cp.Tid)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<UserEntity>()
                      .WithMany()
                      .HasForeignKey(p => p.UserOID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void OnModelTicketReplyCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketReplyEntity>(entity =>
            {
                entity.ToTable("TicketReply", "Support");
                entity.HasKey(p => p.ReplyId); 
                entity.Property(p => p.ReplyId).ValueGeneratedOnAdd();
            });
        }

        private void OnModelTypesCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriorityEntity>().ToTable("Priority", "Support");
            modelBuilder.Entity<StatusEntity>().ToTable("Status", "Support");
            modelBuilder.Entity<LogTypeEntity>().ToTable("LogType", "Support");
            modelBuilder.Entity<TicketTypeEntity>().ToTable("TicketType", "Support");
        }

        private void OnModelUserCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("User", "Support");
                entity.HasKey(p => p.OID); 
            });
        }
    }
}