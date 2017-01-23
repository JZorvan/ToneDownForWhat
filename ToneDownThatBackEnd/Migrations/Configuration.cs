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

                    Anger = 15,
                    Disgust = 8,
                    Fear = 18,
                    Joy = 23,
                    Sadness = 53,

                    Openness = 1,
                    Conscientiousness = 69,
                    Extraversion = 13,
                    Agreeableness = 84,
                    EmotionalRange = 19
                },
                new Entry
                {
                    EntryId = 1,
                    EntryAuthor = "Donald Trump",
                    EntryName = "Trump's New Year's Tweet",
                    EntryDate = DateTime.Now,
                    Format = "Social Post",
                    Context = "Social",
                    Content = "Happy New Year to all, including to my many enemies and those who have fought me and lost so badly they just don't know what to do. Love!",

                    Anger = 14,
                    Disgust = 2,
                    Fear = 6,
                    Joy = 60,
                    Sadness = 16,

                    Openness = 3,
                    Conscientiousness = 83,
                    Extraversion = 53,
                    Agreeableness = 94,
                    EmotionalRange = 33
                },
                new Entry
                {
                    EntryId = 1,
                    EntryAuthor = "Janelle Zorvan",
                    EntryName = "Janelle's LinkedIn Summary",
                    EntryDate = DateTime.Now,
                    Format = "Social Post",
                    Context = "Professional",
                    Content = "Laptops and Back Again: A Developer's Tale. I always knew I was destined to go places, which is theoretically great, but doesn't really help much until you develop a good sense of direction. I started out wanting to pursue a future in higher education; I wanted to fill in Dr on forms, read, write, teach, and get a whip and fedora.Thankfully, a couple scholarships gave me the opportunity to discover the difference between an 'interest' and 'passion' and 'hobby' and 'career'. During the time I was researching career paths, I had friends and connections in technology who got to know my skill set and mentality tell me on a regular basis that I should consider going into programming / development.After some consideration, I started playing with resources online to learn programming languages and discovered that it was so very interesting and FUN to me in a way nothing I had yet tried had been.It really kept me hungry and wanting to learn more, playing into my love of problem solving and creative solutions.I then spoke with recruiters and developers in my network to find out how to get started and found a bootcamp that I could attend while still working full time.I challenged myself and could not be happier with what I found:  that career I'm passionate about. Now, I'm wrapping that up and ready for my next step - my first position in software development and I've never been more excited.",

                    Anger = 12,
                    Disgust = 0,
                    Fear = 6,
                    Joy = 75,
                    Sadness = 10,

                    Openness = 60,
                    Conscientiousness = 6,
                    Extraversion = 25,
                    Agreeableness = 50,
                    EmotionalRange = 10
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
