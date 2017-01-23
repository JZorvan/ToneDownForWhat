﻿using System;
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
            public int Anger { get; set; }
            public int Disgust { get; set; }
            public int Fear { get; set; }
            public int Joy { get; set; }
            public int Sadness { get; set; }

            /* Social Tones */
            public int Openness { get; set; }
            public int Conscientiousness { get; set; }
            public int Extraversion { get; set; }
            public int Agreeableness { get; set; }
            public int EmotionalRange { get; set; }
        }
    }
}