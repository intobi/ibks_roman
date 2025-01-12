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
        public DbSet<TicketReplyEntity> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            OnModelTicketCreating(builder);
            OnModelTicketReplyCreating(builder);
        }

        private void OnModelTicketCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketEntity>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TicketEntity>()
            .HasMany(p => p.Replies)
                  .WithOne(cp => cp.Ticket)
                  .HasForeignKey(cp => cp.Tid)
                  .OnDelete(DeleteBehavior.Cascade); ;
        }
        private void OnModelTicketReplyCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketReplyEntity>()
                .Property(p => p.ReplyId)
                .ValueGeneratedOnAdd();
        }
    }
}
