using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using NPushover;
using NPushover.RequestObjects;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post(string userkey, string requestMessage)
        {
            var pushover = new Pushover("ar5f4qqw4y9ehc548y2eeh13foozg3");
            var message = new Message()
            {
                Title = "Test message",
                Body = requestMessage,
                SupplementaryUrl = new SupplementaryURL
                {
                    Uri = new Uri("https://api.pushover.net/1/messages.json"),
                    Title = "Title"
                }
            };
            var send = pushover.SendMessageAsync(message, userkey);

            return "message sent";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
