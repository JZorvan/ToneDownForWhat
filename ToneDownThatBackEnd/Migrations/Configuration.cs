namespace ToneDownThatBackEnd.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToneDownThatBackEnd.DAL.ToneDownContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToneDownThatBackEnd.DAL.ToneDownContext context)
        {

            context.Entries.AddOrUpdate(
                e => e.EntryName,
                new Entry {
                    EntryId = 0,
                    EntryAuthor = "Rick Astley",
                    EntryName = "Never Gonna Give You Up",
                    EntryDate = DateTime.Now,
                    Format = "Document",
                    Context = "Social",
                    Content = "We're no strangers to love. You know the rules and so do I. A full commitment's what I'm thinking of. You wouldn't get this from any other guy. I just want to tell you how I'm feeling. Gotta make you understand. Never gonna give you up, never gonna let you down. Never gonna run around and desert you. Never gonna make you cry, never gonna say goodbye. Never gonna tell a lie and hurt you. We've known each other for so long. Your heart's been aching but you're too shy to say it. Inside we both know what's been going on. We know the game and we're gonna play it. And if you ask me how I'm feeling. Don't tell me you're too blind to see. Never gonna give you up, never gonna let you down. Never gonna run around and desert you. Never gonna make you cry, never gonna say goodbye. Never gonna tell a lie and hurt you. Never gonna give you up, never gonna let you down. Never gonna run around and desert you. Never gonna make you cry, never gonna say goodbye. Never gonna tell a lie and hurt you. We've known each other for so long. Your heart's been aching but you're too shy to say it. Inside we both know what's been going on. We know the game and we're gonna play it. I just want to tell you how I'm feeling. Gotta make you understand. Never gonna give you up, never gonna let you down. Never gonna run around and desert you. Never gonna make you cry, never gonna say goodbye. Never gonna tell a lie and hurt you.",

                    Anger = 0.146219,
                    Disgust = 0.077742,
                    Fear = 0.18059,
                    Joy = 0.229088,
                    Sadness = 0.534531,

                    Openness = 0.013117,
                    Conscientiousness = 0.686302,
                    Extraversion = 0.130908,
                    Agreeableness = 0.839812,
                    EmotionalRange = 0.194754
                });
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
        }
    }
}
