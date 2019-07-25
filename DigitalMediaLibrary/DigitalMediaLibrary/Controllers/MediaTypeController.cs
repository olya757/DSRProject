using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DigitalMediaLibrary.Model;

namespace DigitalMediaLibrary.WEB_API
{
    public class MediaTypeController: ApiController
    {
        public IEnumerable<MediaType> Get()
        {
            return null;
        }

        public IHttpActionResult Get(long ID)
        {
            return null;
        }

        public void Post([FromBody]MediaType value)
        {

        }

        public void Put(long ID,[FromBody]MediaType value)
        {

        }

        public void Delete(long ID)
        {

        }
    }
}
