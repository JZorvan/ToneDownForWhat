using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ToneDownThatBackEnd.Models;

namespace ToneDownThatBackEnd.DAL
{
    public class ToneDownRepository : IDisposable
    {
        private ToneDownContext Context;

        private UserManager<User> _userManager;

        public ToneDownRepository(ToneDownContext _context)
        {
            Context = _context;
            _userManager = new UserManager<User>(new UserStore<User>(_context));
        }
        public ToneDownRepository()
        {
            Context = new ToneDownContext();
            _userManager = new UserManager<User>(new UserStore<User>(Context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            User user = new User
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            Context.Dispose();
            _userManager.Dispose();
        }

        // Start Repo Methods for Users and Entries

            // Get all the Entries for a User, these can be filtered later
        public List<Entry> GetAllEntriesByUser (string username)
        {
            User user = Context.Users.SingleOrDefault(u => u.UserName == username);
            return user.Entries;
        }

        // Retrieve a Selected Entry by the ID
        public Entry GetEntryById(int id)
        {
            return Context.Entries.SingleOrDefault(e => e.EntryId == id);
        }

        // Add an Entry to a User
        public void AddEntryToUser (string username, Entry new_entry)
        {
            Context.Users.SingleOrDefault(u => u.UserName == username).Entries.Add(new_entry);
            Context.SaveChanges();
        }

            // Delete a Single Selected Entry
        public void RemoveEntryById(string username, int id)
        {
            User user = Context.Users.FirstOrDefault(u => u.UserName == username);
            Entry targetedEntry = Context.Entries.FirstOrDefault(p => p.EntryId == id);

            if (targetedEntry != null)
            {
                user.Entries.Remove(targetedEntry);
                Context.Entries.Remove(targetedEntry);
                Context.SaveChanges();
            }
        }
    }
}