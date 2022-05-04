#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainTickets.Models;

namespace TrainTickets.Data
{
    public class TrainTicketsContext : DbContext
    {
        public TrainTicketsContext (DbContextOptions<TrainTicketsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.OriginTrainStation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.DestTrainStation)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<TrainTickets.Models.Train> Train { get; set; }

        public DbSet<TrainTickets.Models.Station> Station { get; set; }

        public DbSet<TrainTickets.Models.Coach> Coach { get; set; }

        public DbSet<TrainTickets.Models.Place> Place { get; set; }

        public DbSet<TrainTickets.Models.TrainStation> TrainStation { get; set; }

        public DbSet<TrainTickets.Models.Ticket> Ticket { get; set; }
    }
}
