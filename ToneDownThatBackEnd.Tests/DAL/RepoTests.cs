using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToneDownThatBackEnd.Models;
using ToneDownThatBackEnd.DAL;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace ToneDownThatBackEnd.Tests.DAL
{
    [TestClass]
    public class RepoTests
    {
        private Mock<DbSet<User>> mock_users { get; set; }
        private Mock<DbSet<Entry>> mock_entries { get; set; }

        private List<User> Users { get; set; }
        private List<Entry> Entries { get; set; }

        private Mock<UserManager<User>> mock_user_manager_context { get; set; }
        private Mock<ToneDownContext> mock_context { get; set; }
        private ToneDownRepository repo { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_users = new Mock<DbSet<User>>();
            mock_entries= new Mock<DbSet<Entry>>();

            Users = new List<User>();
            Entries = new List<Entry>();

            mock_context = new Mock<ToneDownContext>() { CallBase = true };
            mock_user_manager_context = new Mock<UserManager<User>>();
            repo = new ToneDownRepository(mock_context.Object);

            ConnectToDatastore();
        }

        public void ConnectToDatastore()
        {
            var query_users = Users.AsQueryable();
            var query_entries = Entries.AsQueryable();

            mock_users.As<IQueryable<User>>().Setup(m => m.Provider).Returns(query_users.Provider);
            mock_users.As<IQueryable<User>>().Setup(m => m.Expression).Returns(query_users.Expression);
            mock_users.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(query_users.ElementType);
            mock_users.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => query_users.GetEnumerator());

            mock_context.Setup(c => c.Users).Returns(mock_users.Object);
            mock_users.Setup(u => u.Add(It.IsAny<User>())).Callback((User t) => Users.Add(t));

            mock_entries.As<IQueryable<Entry>>().Setup(m => m.Provider).Returns(query_entries.Provider);
            mock_entries.As<IQueryable<Entry>>().Setup(m => m.Expression).Returns(query_entries.Expression);
            mock_entries.As<IQueryable<Entry>>().Setup(m => m.ElementType).Returns(query_entries.ElementType);
            mock_entries.As<IQueryable<Entry>>().Setup(m => m.GetEnumerator()).Returns(() => query_entries.GetEnumerator());

            mock_context.Setup(c => c.Entries).Returns(mock_entries.Object);
            mock_entries.Setup(u => u.Add(It.IsAny<Entry>())).Callback((Entry t) => Entries.Add(t));
            mock_entries.Setup(u => u.Remove(It.IsAny<Entry>())).Callback((Entry t) => Entries.Remove(t));
        }

        public void ImportMockData()
        {
            // Assigns Entries to this User
            Entry mockEntry1 = new Entry
            {
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
            };

            Entry mockEntry2 = new Entry
            {
                EntryId = 1,
                EntryAuthor = "Janelle Zorvan",
                EntryName = "Janelle's LinkedIn Summary",
                EntryDate = DateTime.Now,
                Format = "Social Post",
                Context = "Professional",
                Content = "Laptops and Back Again: A Developer's Tale. I always knew I was destined to go places, which is theoretically great, but doesn't really help much until you develop a good sense of direction. I started out wanting to pursue a future in higher education; I wanted to fill in Dr on forms, read, write, teach, and get a whip and fedora.Thankfully, a couple scholarships gave me the opportunity to discover the difference between an 'interest' and 'passion' and 'hobby' and 'career'. During the time I was researching career paths, I had friends and connections in technology who got to know my skill set and mentality tell me on a regular basis that I should consider going into programming / development.After some consideration, I started playing with resources online to learn programming languages and discovered that it was so very interesting and FUN to me in a way nothing I had yet tried had been.It really kept me hungry and wanting to learn more, playing into my love of problem solving and creative solutions.I then spoke with recruiters and developers in my network to find out how to get started and found a bootcamp that I could attend while still working full time.I challenged myself and could not be happier with what I found:  that career I'm passionate about. Now, I'm wrapping that up and ready for my next step - my first position in software development and I've never been more excited.",

                Anger = 0.124774,
                Disgust = 0.002098,
                Fear = 0.058569,
                Joy = 0.747186,
                Sadness = 0.098886,

                Openness = 0.597728,
                Conscientiousness = 0.063195,
                Extraversion = 0.250625,
                Agreeableness = 0.504802,
                EmotionalRange = 0.10008
            };

            // Creates a User to test:
            User mockUser = new User { Id = "0", UserName = "ZeroCool", Entries = new List<Entry> { mockEntry1, mockEntry2 } };

            Users.Add(mockUser);
            Entries.Add(mockEntry1);
            Entries.Add(mockEntry2);
            

        }

        [TestMethod]
        public void CanInstantiateRepo()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void TestMockData()
        {
            ImportMockData();

            int expected_users = 1;
            int actual_users = Users.Count();
            int expected_entries = 2;
            int actual_entries = Entries.Count;

            Assert.AreEqual(expected_entries, actual_entries);
            Assert.AreEqual(expected_users, actual_users);
        }

        [TestMethod]
        public void CanGetEntriesForUser()
        {
            ImportMockData();

            List<Entry> actual_entries = repo.GetAllEntriesByUser("ZeroCool");

            Assert.IsTrue(actual_entries.Count == 2);
        }

        [TestMethod]
        public void CanGetEntryById()
        {
            ImportMockData();

            Entry entry = repo.GetEntryById(1);

            Assert.IsTrue(entry.EntryName == "Janelle's LinkedIn Summary");
        }

        [TestMethod]
        public void CanAddAnEntryToUser()
        {
            ImportMockData();

            Entry entry_to_add = new Entry
            {
                EntryId = 2,
                EntryAuthor = "Donald Trump",
                EntryName = "Trump's New Year's Tweet",
                EntryDate = DateTime.Now,
                Format = "Social Post",
                Context = "Social",
                Content = "Happy New Year to all, including to my many enemies and those who have fought me and lost so badly they just don't know what to do. Love!",

                Anger = 0.136919,
                Disgust = 0.020634,
                Fear = 0.057937,
                Joy = 0.601538,
                Sadness = 0.163572,

                Openness = 0.02594,
                Conscientiousness = 0.839064,
                Extraversion = 0.525272,
                Agreeableness = 0.937548,
                EmotionalRange = 0.328904
            };

            repo.AddEntryToUser("ZeroCool", entry_to_add);
            List<Entry> actual_entries = repo.GetAllEntriesByUser("ZeroCool");

            Assert.IsTrue(actual_entries.Count == 3);
        }

        [TestMethod]
        public void CanDeleteAnEntry()
        {
            ImportMockData();

            repo.RemoveEntryById("ZeroCool", 1);
            List<Entry> actual_entries = repo.GetAllEntriesByUser("ZeroCool");

            Assert.IsTrue(actual_entries.Count == 1);
        }
    }
}
