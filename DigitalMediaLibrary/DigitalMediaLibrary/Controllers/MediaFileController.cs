using DigitalMediaLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DigitalMediaLibrary.WEB_API
{
    public class MediaFileController:ApiController
    {
        public IEnumerable<MediaFile> Get()
        {
            return null;
        }

        public MediaFile Get(long ID)
        {
            return null;
        }

        public void Post([FromBody]MediaFile value)
        {

        }

        public void Put(long ID, [FromBody]MediaFile value)
        {

        }

        public void Delete(long ID)
        {

        }
    }
}
