using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Logic
    {
        public Logic()
        {
            MyHub myhub = new MyHub();
        }
        public static List<ScheduleItemObject> scheduleItemObjects = new List<ScheduleItemObject>
        {
            new ScheduleItemObject{id = 1, name = "Aviv1", startTime = DateTime.Now, endTime = DateTime.Now},
            new ScheduleItemObject{id = 2, name = "Aviv2", startTime = new DateTime(2020, 10, 11, 15, 0, 0), endTime = new DateTime(2020, 10, 11, 15, 30, 0)}
         };

        public static int createEvent(ScheduleItemObject sioIn)
        {
            ScheduleItemObject sio = new ScheduleItemObject
            {
                name = sioIn.name,
                startTime = sioIn.startTime,
                endTime = sioIn.endTime
            };

            sio.id = getNextID();
            scheduleItemObjects.Add(sio);

            return sio.id;
        }

        public static ScheduleItemObject getEventByID(int id)
        {
            return getEventDetails(id);
        }

        public static bool updateEventByID(int id, ScheduleItemObject sioIn)
        {
            ScheduleItemObject sio = getEventDetails(id);

            if (sio != null)
            {
                scheduleItemObjects.Remove(sio);
                scheduleItemObjects.Add(sioIn);
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool DeleteEventByID(int id)
        {
            ScheduleItemObject sio = getEventDetails(id);

            if (sio != null)
            {
                scheduleItemObjects.Remove(sio);
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generic Functions

        private static ScheduleItemObject getEventDetails(int id)
        {
            return scheduleItemObjects.Where(scheduleItemObject => scheduleItemObject.id == id).FirstOrDefault();
        }

        private static int getNextID()
        {
            int id = 1;
            IEnumerable<ScheduleItemObject> events = scheduleItemObjects.OrderBy(x => x.id);

            if (events.Count() > 0)
            {
                id = events.Last().id + 1;
            }

            return id;
        }
    }

    public class ScheduleItemObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}