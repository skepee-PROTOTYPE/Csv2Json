using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string headline = "title,date,description,imagelink,list_tags";
            List<string> news = new List<string>
            {
                "title1,21/01/2019,description1,http://***1,tag1;tag2;tag3",
                "title2,20/01/2019,description2,http://***2,tag2;tag3;tag4",
                "title3,19/01/2019,description3,http://***3,tag4;tag5;tag6",
                "title4,18/01/2019,description4,http://***4,tag6;tag7;tag8",
                "title5,17/01/2019,description5,http://***5,tag7;tag8;tag9"
            };

            List<dynamic> l = new List<dynamic>();

            var head = headline.Split(',');

            foreach (var elem in news)
            {
                dynamic z = new System.Dynamic.ExpandoObject();
                var dictionary = (IDictionary<string, object>)z;

                var values = elem.Split(',');

                for (int i = 0; i < head.Length; i++)
                {
                    var k = head[i].Trim();
                    var v = values[i].Trim();

                    if (k.StartsWith("list_"))
                    {
                        k = k.Replace("list_", "");
                        var lv = v.Split(";");
                        dictionary.Add(k, lv);
                    }
                    else
                    {
                        dictionary.Add(k, v);
                    }
                }
                l.Add(dictionary);
            }
            return Ok(l);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
