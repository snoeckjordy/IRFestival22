﻿using IRFestival.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace IRFestival.Api.Data
{
    public class FestivalDbContext : DbContext
    {
        public FestivalDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleItem> ScheduleItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festival>().HasData(new Festival
            {
                Id = 1
            });

            var description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.";

            var stages = new List<Stage>() {
                         new Stage { Id = 1, FestivalId = 1, Name = "Main Stage", Description = description },
                         new Stage { Id = 2, FestivalId = 1, Name = "Orange Room", Description = description },
                         new Stage { Id = 3, FestivalId = 1, Name = "StarDust", Description = description },
            };
            modelBuilder.Entity<Stage>().HasData(stages);

            var artists = new List<Artist>() {
                      new Artist { Id = 1, FestivalId = 1, Name = "Diana Ross", ImagePath = "dianaross.jpg", Website = new Uri("http://www.dianaross.co.uk/indexb.html") },
                      new Artist { Id = 2, FestivalId = 1, Name = "The Commodores", ImagePath = "thecommodores.jpg", Website = new Uri("http://en.wikipedia.org/wiki/Commodores") },
                      new Artist { Id = 3, FestivalId = 1, Name = "Stevie Wonder", ImagePath = "steviewonder.jpg", Website = new Uri("http://www.steviewonder.net/") },
                      new Artist { Id = 4, FestivalId = 1, Name = "Lionel Richie", ImagePath = "lionelrichie.jpg", Website = new Uri("http://lionelrichie.com/") },
                      new Artist { Id = 5, FestivalId = 1, Name = "Marvin Gaye", ImagePath = "marvingaye.jpg", Website = new Uri("http://www.marvingayepage.net/") }
            };
            modelBuilder.Entity<Artist>().HasData(artists);

            var schedule = new Schedule
            {
                Id = 1,
                FestivalId = 1
            };

            modelBuilder.Entity<Schedule>().HasData(schedule);

            modelBuilder.Entity<ScheduleItem>().HasData(new ScheduleItem { Id = 1, ScheduleId = schedule.Id, ArtistId = artists[0].Id, StageId = stages[0].Id });
            modelBuilder.Entity<ScheduleItem>().HasData(new ScheduleItem { Id = 2, ScheduleId = schedule.Id, ArtistId = artists[4].Id, StageId = stages[0].Id });
            modelBuilder.Entity<ScheduleItem>().HasData(new ScheduleItem { Id = 3, ScheduleId = schedule.Id, ArtistId = artists[2].Id, StageId = stages[0].Id });
            modelBuilder.Entity<ScheduleItem>().HasData(new ScheduleItem { Id = 4, ScheduleId = schedule.Id, ArtistId = artists[1].Id, StageId = stages[0].Id });
            modelBuilder.Entity<ScheduleItem>().HasData(new ScheduleItem { Id = 5, ScheduleId = schedule.Id, ArtistId = artists[0].Id, StageId = stages[0].Id });

        }
    }


}
