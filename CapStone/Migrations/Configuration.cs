namespace CapStone.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CapStone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CapStone.Models.ApplicationDbContext";
        }

        protected override void Seed(CapStone.Models.ApplicationDbContext context)
        {
            context.ETAs.AddOrUpdate(x => x.TIME,
                new ETA() { ETA_ID = 1, TIME = "1 Hour" },
                new ETA() { ETA_ID = 2, TIME = "3 Hours" },
                new ETA() { ETA_ID = 3, TIME = "1 Day" },
                new ETA() { ETA_ID = 4, TIME = "3 Days" },
                new ETA() { ETA_ID = 5, TIME = "1 Week" },
                new ETA() { ETA_ID = 6, TIME = "2 Weeks" },
                new ETA() { ETA_ID = 7, TIME = "1 Month" },
                new ETA() { ETA_ID = 8, TIME = "3 Months" },
                new ETA() { ETA_ID = 9, TIME = "6 Months" },
                new ETA() { ETA_ID = 10, TIME = "1 Year" },
                new ETA() { ETA_ID = 11, TIME = "As long as it takes" }
                            );

            context.Topics.AddOrUpdate(y => y.theme,
                new Topic() { TopicId = 1, theme = "Sport" },
                new Topic() { TopicId = 2, theme = "Art" },
                new Topic() { TopicId = 3, theme = "Community" },
                new Topic() { TopicId = 4, theme = "Career" },
                new Topic() { TopicId = 5, theme = "Nature" },
                new Topic() { TopicId = 6, theme = "Group" },
                new Topic() { TopicId = 7, theme = "Sponsored" },
                new Topic() { TopicId = 8, theme = "Miscellaneous" });
           
        }
    }
}
