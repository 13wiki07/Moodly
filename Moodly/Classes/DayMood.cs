using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodly.Classes
{
    public class DayMood
    {
        private DateOnly date;
        private int moodValue;
        private string notes;
        public DayMood(DateOnly date, int moodValue, string notes)
        {
            this.date = date;
            this.moodValue = moodValue;
            this.notes = notes;
        }
        public DateOnly Date { get { return date; } }
        public int MoodValue { get { return moodValue; } }
        public string Notes { get { return notes; } }

    }
}
