using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [RoutePrefix("api/events")]
    public class ValuesController : ApiController
    {
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ScheduleItemObject sio)
        {
            int result = Logic.createEvent(sio);
            return Ok(result);
        }

        [Route("Read/{id:int}")]
        [HttpGet]
        public IHttpActionResult Read(int id)
        {
            ScheduleItemObject sio = Logic.getEventByID(id);
            
            if (sio != null)
            {
                return Ok(sio);
            }

            else
            {
                return NotFound();
            }
        }

        [Route("Update/{id:int}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] ScheduleItemObject sio)
        {
            bool result = Logic.updateEventByID(id, sio);

            if (result)
            {
                return Ok("Event ID " + id + " has been updated");
            }

            else
            {
                return NotFound();
            }
        }

        [Route("Delete/{id:int}")]
        [HttpGet]
        public IHttpActionResult Delete(int id)
        {
            bool result = Logic.DeleteEventByID(id);

            if (result)
            {
                return Ok("Event ID " + id + " has been removed");
            }

            else
            {
                return NotFound();
            }
        }
    }
}
