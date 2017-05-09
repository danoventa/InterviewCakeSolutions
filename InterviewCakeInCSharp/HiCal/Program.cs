using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace HiCal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var meeting1 = new Meeting(2, 3);
            var meeting2 = new Meeting(2, 3);
            var meeting3 = new Meeting(2, 3);
            var meeting4 = new Meeting(2, 3);
            
            var initialMeetings = new List<Meeting> {meeting1, meeting2, meeting3, meeting4};

            var mergedMeetings = MergeRange(initialMeetings);
            foreach (var meeting in mergedMeetings)
            {
                Console.Write(Convert.ToString(meeting.StartTime) + " - " + Convert.ToString(meeting.EndTime));
            }
        }

        public static List<Meeting> MergeRange(List<Meeting> meetings)
        {
            Console.Write("THIS IS A TEST");
            var meeting1 = new Meeting(1, 2);
            var retList = new List<Meeting> {meeting1};
            return retList;
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