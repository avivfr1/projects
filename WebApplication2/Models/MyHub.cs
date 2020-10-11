using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebApplication2.Models;

namespace WebApplication2
{
    [HubName("Scheduler")]
    public class MyHub : Hub
    {
        public MyHub()
        {
            notice();
        }
        
        public void notice()
        {
            while (true)
            {
                IEnumerable<ScheduleItemObject> events = Logic.scheduleItemObjects.OrderBy(sio => sio.startTime);
                ScheduleItemObject first = events.First();

                if (first.startTime >= DateTime.Now)
                {
                    Clients.All.SendAsync(first.name + " has been started");
                }
            }
        }
    }
}