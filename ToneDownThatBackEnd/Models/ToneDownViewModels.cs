using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToneDownThatBackEnd.Models
{
    public class ToneDownViewModels
    {
        public class AddEntryViewModel
        {
            public string EntryAuthor { get; set; }     /* Author of Entry */
            public string EntryName { get; set; }       /* Name of Entry */
            public string Format { get; set; }          /* Format: Email, Social Post, Direct Message, or Document */
            public string Context { get; set; }         /* Context: Professional or Social */
            public string Content { get; set; }         /* The Text that the user enters */

            /* Emotional Tones */
            public double Anger { get; set; }
            public double Disgust { get; set; }
            public double Fear { get; set; }
            public double Joy { get; set; }
            public double Sadness { get; set; }

            /* Social Tones */
            public double Openness { get; set; }
            public double Conscientiousness { get; set; }
            public double Extraversion { get; set; }
            public double Agreeableness { get; set; }
            public double EmotionalRange { get; set; }
        }
    }
}