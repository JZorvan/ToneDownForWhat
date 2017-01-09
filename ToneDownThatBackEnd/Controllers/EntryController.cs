using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using ToneDownThatBackEnd.DAL;
using ToneDownThatBackEnd.Models;
using static ToneDownThatBackEnd.Models.ToneDownViewModels;

namespace ToneDownThatBackEnd.Controllers
{
    public class EntryController : ApiController
    {
        private ToneDownRepository _repo = null;

        public EntryController()
        {
            _repo = new ToneDownRepository(); 
        }

        private string FindActiveUserName()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;
            return userName;
        }

        // GET api/<controller>   Retrieves all of the user's entries
        public IEnumerable<Entry> Get()
        {
            return _repo.GetAllEntriesByUser(FindActiveUserName());
        }

        // GET api/<controller>/5   Retrieves a specific user entry
        public Entry Get(int id)
        {
            if (_repo.GetAllEntriesByUser(FindActiveUserName()).Any(e => e.EntryId == id))
            {
                return _repo.GetEntryById(id);
            }
            return null;
        }

        [Authorize]
        // POST api/<controller>
        public Dictionary<string, bool> Post([FromBody]AddEntryViewModel value)
        {
            Dictionary<string, bool> answer = new Dictionary<string, bool>();

            if (ModelState.IsValid)
            {
                Entry newEntry = new Entry
                {
                    EntryAuthor = value.EntryAuthor,
                    EntryName = value.EntryName,
                    EntryDate = DateTime.Now,
                    Format = value.Format,
                    Context = value.Context,
                    Content = value.Content,

                    Anger = value.Anger,
                    Disgust = value.Disgust,
                    Fear = value.Fear,
                    Joy = value.Joy,
                    Sadness = value.Sadness,

                    Openness = value.Openness,
                    Conscientiousness = value.Conscientiousness,
                    Extraversion = value.Extraversion,
                    Agreeableness = value.Agreeableness,
                    EmotionalRange = value.EmotionalRange
                };
                _repo.AddEntryToUser(FindActiveUserName(), newEntry);
                answer.Add("Entry added: ", true);
            }
            else
            {
                answer.Add("Entry added: ", false);
            }
            return answer;
        }
    

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            if (_repo.GetAllEntriesByUser(FindActiveUserName()).Any(e => e.EntryId == id))
            {
                _repo.RemoveEntryById(FindActiveUserName(), id);
            }
        }
    }
}