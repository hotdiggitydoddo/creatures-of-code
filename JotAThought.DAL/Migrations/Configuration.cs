namespace JotAThought.DAL.Migrations
{
    using JotAThought.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JotAThought.DAL.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JotAThought.DAL.BlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Posts.AddOrUpdate(
            //    p => p.Title,
            //    new Post { Title = "First Post", Content = "Here's the content!", CreatedOn = DateTime.Today, Author = "Ryan", Tags = new List<Tag>() }
            //    );
        }
    }
}
