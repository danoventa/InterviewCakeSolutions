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
            var meeting3 = new Meeting(8, 9);
            var meeting4 = new Meeting(9, 13);
            var meeting5 = new Meeting(13, 15);
            var meeting6 = new Meeting(1, 5);
            var meeting7 = new Meeting(17, 19);

            var initialMeetings = new List<Meeting> {meeting1, meeting2, meeting3, meeting4, meeting5, meeting6, meeting7};

            var mergedMeetings = MergeRange(initialMeetings);
            foreach (var meeting in mergedMeetings)
            {
                Console.WriteLine(Convert.ToString(meeting.StartTime) + " - " + Convert.ToString(meeting.EndTime));
            }

            var mergedMeetingsOverlap = MergeRangeOverlap(initialMeetings);
            foreach (var meeting in mergedMeetingsOverlap)
            {
                Console.WriteLine(Convert.ToString(meeting.StartTime) + " - " + Convert.ToString(meeting.EndTime));
            }
            var mergedMeetingsNew = MergeRangeNew(initialMeetings);
            foreach (var meeting in mergedMeetingsOverlap)
            {
                Console.WriteLine(Convert.ToString(meeting.StartTime) + " - " + Convert.ToString(meeting.EndTime));
            }
        }

        public static List<Meeting> MergeRangeLinq(List<Meeting> meetings)
        {
            
        }

        public static List<Meeting> MergeRangeNew(List<Meeting> meetings)
        {
            var retList = new List<Meeting>();
            var hashMap = MapMeetings(meetings);
            var keys = hashMap.Keys.ToArray();
            Array.Sort(keys);

            var currentMerger = hashMap[keys[0]][0];
            foreach (var key in keys)
            {
                var meetList = hashMap[key];

                foreach (var meeting in meetList)
                {
                    if (currentMerger.EndTime > meeting.StartTime)
                    {
                        currentMerger.EndTime = Math.Max(currentMerger.EndTime, meeting.EndTime);
                        continue;
                    }
                    retList.Add(currentMerger);
                    currentMerger = meeting;
                }
            }
            retList.Add(currentMerger);
            
            return retList;
        }

        public static Dictionary<int, List<Meeting>> MapMeetings(List<Meeting> meetings)
        {
            var hashMap = new Dictionary<int, List< Meeting>>();
            foreach (var meeting in meetings)
            {
                var key = meeting.StartTime;
                if (hashMap.ContainsKey(key))
                {
                    hashMap[key].Add(meeting);
                    continue;
                }
                hashMap.Add(key, new List<Meeting>{meeting});
                
            }
            return hashMap;
        }

        public static List<Meeting> MergeRangeOverlap(List<Meeting> meetings)
        {
            var sortedMeetings = meetings.OrderBy(m => m.StartTime).ToList();
            var newMeetings = new List<Meeting> {sortedMeetings[0]};
            foreach (var meeting in sortedMeetings)
            {
                if (meeting.StartTime <= newMeetings.Last().EndTime)
                {
                    if (meeting.EndTime > newMeetings.Last().EndTime)
                    {
                        newMeetings.Last().EndTime = meeting.EndTime;
                    }
                }
                else
                {
                    newMeetings.Add(meeting);
                }
            }
            return newMeetings;
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

            var meetingArr = meetingSet.ToArray();
            Array.Sort(meetingArr);

            foreach (var time in meetingArr)
            {
                if (mergedTimes.Count > 0)
                {
                    if (mergedTimes.Last() + 1 == time)
                    {
                        mergedTimes.Add(time);
                    }
                    else
                    {
                        if (mergedTimes.Count <= 0) continue;
                        mergedMeetings.Add(new Meeting(mergedTimes.First(), mergedTimes.Last()));
                        mergedTimes = new List<int> {time};
                    }
                }
                else
                {

                    mergedTimes.Add(time);
                }
            }
            if (mergedTimes.Count > 0)
            {
                mergedMeetings.Add(new Meeting(mergedTimes.First(), mergedTimes.Last()));
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