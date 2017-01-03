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
            
        }

        [TestMethod]
        public void CanInstantiateRepo()
        {
            ToneDownRepository repo = new ToneDownRepository();
            Assert.IsNotNull(repo);
        }

    }
}
