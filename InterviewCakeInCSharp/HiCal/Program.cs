using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace HiCal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var meeting1 = new Meeting(2, 3);
            var meeting2 = new Meeting(3, 4);
            var meeting3 = new Meeting(6, 9);
            var meeting4 = new Meeting(1, 4);

            var initialMeetings = new List<Meeting> {meeting1, meeting2, meeting3, meeting4};

            var mergedMeetings = MergeRange(initialMeetings);
            foreach (var meeting in mergedMeetings)
            {
                Console.WriteLine(Convert.ToString(meeting.StartTime) + " - " + Convert.ToString(meeting.EndTime));
            }
        }

        public static List<Meeting> MergeRange(List<Meeting> meetings)
        {
            var mergedTimes = new List<int>();
            var mergedMeetings = new List<Meeting>();
            var meetingSet = new HashSet<int>();

            foreach (var meeting in meetings)
            {
                for (var i = meeting.StartTime; i <= meeting.EndTime; i++)
                {
                    meetingSet.Add(i);
                }
            }

           

            foreach (var time in meetingSet)
            {
                Console.WriteLine(Convert.ToString(time));
                if (mergedTimes.Count > 0)
                {
                    if (mergedTimes.Last() + 1 == time)
                    {
                        mergedTimes.Add(time);
                    }
                    else
                    {
                        if (mergedTimes.Count > 0)
                        {
                            mergedMeetings.Add(new Meeting(mergedTimes.First(), mergedTimes.Last()));
                        }
                    }
                }
                else
                {
                    mergedTimes.Add(time);
                }
            }

            return mergedMeetings;
        }
    }

    public class Meeting
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }
    }
}