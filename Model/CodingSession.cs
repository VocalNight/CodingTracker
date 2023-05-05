using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Model {
    public class CodingSession {

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
            return $"{span.TotalHours} : {span.TotalMinutes}";
        }

        private DateTime CalculateTime(string dateString) {
            return DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        } 

    }
}
