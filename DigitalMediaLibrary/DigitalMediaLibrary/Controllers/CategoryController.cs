using DigitalMediaLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DigitalMediaLibrary.WEB_API
{
    public class CategoryController:ApiController
    {
        public IEnumerable<Category> Get()
        {
            return null;
        }

        public Category Get(long ID)
        {
            return null;
        }

        public void Post([FromBody]Category value)
        {

        }

        public void Put(long ID, [FromBody]Category value)
        {

        }

        public void Delete(long ID)
        {

        }
    }
}
