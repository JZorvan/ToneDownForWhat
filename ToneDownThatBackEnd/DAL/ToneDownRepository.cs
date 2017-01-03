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
    }
}