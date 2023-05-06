using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Model {
    public class CodingSession {

        public CodingSession(string start, string end) { 
            StartTime = start;
            EndTime = end;
        }

        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        private string _duration;
        public string Duration {
            get => CalculateDuration();
            private set => _duration = value;
        }


        private string CalculateDuration() {

            DateTime start = CalculateTime(StartTime);
            DateTime end = CalculateTime(EndTime);
            TimeSpan span = end - start;

            string hours = span.Hours.ToString();
            string minutes = span.Minutes.ToString();

            return $"{FormatTime(hours)}:{FormatTime(minutes)}";
        }

        private DateTime CalculateTime(string dateString) {
            return DateTime.ParseExact(dateString, "dd-MM-yyyy HH:mm", null);
        } 

        private string FormatTime(string time) {
            if (time.Length == 1) {
                return $"0{time}";
            }
            return time;
        }

    }
}
